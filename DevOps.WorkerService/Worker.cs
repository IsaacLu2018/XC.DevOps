using GetModel.OneDoModels;
using log4net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevOps.WorkerService
{
    public class Worker : BackgroundService
    {
        // private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private readonly ILog _log;
        private static string _baseUrl;
        // private readonly doContext _doContext;

        /// <summary>
        /// 已经发送过请求的列表
        /// </summary>
        private List<string> sendList = new List<string>();
        // 获取当前时间的0点
        private DateTime startTime = DateTime.Now.Date;

        public Worker(IConfiguration configuration, ILog log)
        {
            // _logger = logger;
            _configuration = configuration;
            _log = log;
            _baseUrl = $"{configuration.GetSection("Urls").GetSection("DevOps").Value}";
            // _doContext = doContext;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            // DO YOUR STUFF HERE
            await base.StartAsync(cancellationToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            // DO YOUR STUFF HERE
            await base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
               // _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                try
                {
                    if (sendList.Count >= 1000)
                    {
                        sendList.Skip(500).Take(sendList.Count - 500).ToList();
                    }
                    using (var _doContext = new doContext())
                    {

                        var datebase = _doContext.T1doBase;
                        // 1次先读出全部....
                        // 逐条发送更新请求
                        //  每一条请求后都停滞100ms
                        // 当请求发送完毕 设置startTime为当前时间
                        // 5s跑一次

                        // 初始化的时候就取出全部 1do的实际完成时间 服务器有延迟 所以这边增加2mins 范围
                        var taskList = datebase.Where(task => task.RealFinishTime > startTime && task.RealFinishTime < DateTime.Now.AddMinutes(2)).Where(task => !sendList.Contains(task.ShowId)).Take(5).ToList();
                        var users = taskList.Select(t => t.OCustomer).ToList();
                        var userList = _doContext.TRegUser.Where(u => users.Contains(u.ShowId)).ToList();

                        // 理论上来说 应该不会有
                        taskList.ForEach(
                            async task =>
                            {
                                // TODO： 这里创建client是不是有问题
                                using (var client = new HttpClient())
                                {
                                    string url = $"{_baseUrl}/api/WorkItem/Finished";
                                    // 这里由于
                                    _log.Info($"请求接口：{url}\n");
                                    var user = userList.Where(u => u.ShowId == task.OCustomer).FirstOrDefault();
                                    if (null != user)
                                    {
                                        var req = JsonConvert.SerializeObject(new { showId = task.ShowId, passName = user.ULoginName });
                                        HttpContent httpContent = new StringContent(req, Encoding.UTF8);
                                        _log.Info($"请求参数{req}\n");
                                        httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                                        HttpResponseMessage response = await client.PostAsync(url, httpContent);
                                        var wikiRes = await response.Content.ReadAsStringAsync();
                                        _log.Info($"请求结果：{wikiRes}\n");
                                        // 增加已经发送的列表
                                        sendList.Add(task.ShowId);
                                    }
                                    else 
                                    {
                                        _log.Info($"找不到对应用户： {task.OCustomer}\n");
                                    }
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
