using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using GetModel.OneDoModels;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Text;
using log4net;

namespace DevOps.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private readonly ILog _log;
        private static string _baseUrl;

        /// <summary>
        /// 已经发送过请求的列表
        /// </summary>
        private List<string> sendList = new List<string>();
        // 获取当前时间的0点
        private DateTime startTime = DateTime.Now.Date;

        public Worker(ILogger<Worker> logger, IConfiguration configuration,ILog log)
        {
            _logger = logger;
            _configuration = configuration;
            _log = log;
            _baseUrl = $"{configuration.GetSection("Urls").GetSection("DevOps").Value}";
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                try
                {
                    if (sendList.Count >= 1000)
                    {
                        sendList.Skip(500).Take(sendList.Count - 500).ToList();
                    }

                    using (var context = new doContext())
                    {
                        var datebase = context.T1doBase;
                        // 1次先读出全部....
                        // 逐条发送更新请求
                        //  每一条请求后都停滞100ms
                        // 当请求发送完毕 设置startTime为当前时间
                        // 5s跑一次

                        // 初始化的时候就取出全部
                        var taskList = datebase.Where(task => task.RealFinishTime > startTime && task.RealFinishTime < DateTime.Now).Where(task => !sendList.Contains(task.ShowId)).Take(5).ToList();
                        var users = taskList.Select(t => t.OCustomer).ToList();
                        var userList = context.T1doUser.Where(u => users.Contains(u.ShowId)).ToList() ;

                        // 理论上来说 应该不会有
                        taskList.ForEach(
                            async task =>
                            {
                            // TODO： 这里创建client是不是有问题
                            using (var client = new HttpClient())
                                {
                                    string url = $"{_baseUrl}/api/WorkItem/Finished?showId={task.ShowId}&passName={userList.Where(u=>u.ShowId== task.OCustomer).First()}";
                                    // 这里由于
                                    _log.Info($"请求接口：{url}");
                                    HttpContent httpContent = new StringContent("", Encoding.UTF8);
                                    httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                                    HttpResponseMessage response = await client.PostAsync(url, httpContent);
                                    var wikiRes = await response.Content.ReadAsStringAsync();
                                    _log.Info($"请求结果：{wikiRes}");
                                // 增加已经发送的列表
                                sendList.Add(task.ShowId);
                                }
                            });

                        await Task.Delay(5000, stoppingToken);
                    }
                }
                catch (Exception ex)
                {
                    _log.Error($"意外错误{ex.Message}");
                }
                // 筛选数组 若一天内没有关闭500 条数据的话....

            }
        }
    }
}
