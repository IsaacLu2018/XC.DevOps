using log4net;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace XC.DevOps.Extend
{
    public class CustomMessageHandler : DelegatingHandler
    {
        private static ILog _log;
        public static ILoggerRepository repository { get; set; }
        public CustomMessageHandler()
        {
            repository = LogManager.CreateRepository("DevOpsApiRepository");
            _log = LogManager.GetLogger(repository.Name, "ExceptionLog");
            
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // 记录请求内容
            if (request.Content != null)
            {
                _log.Info(string.Format("Request Url：{0} \nRequest{1}", request.RequestUri.AbsoluteUri, request.Content.ReadAsStringAsync().Result));
            }

            // 发送HTTP请求到内部处理程序，在异步处理完成后记录响应内容
            return base.SendAsync(request, cancellationToken).ContinueWith<HttpResponseMessage>((task) =>
            {
                // 记录响应内容
                string msg = string.Format("Response:{0}", task.Result.Content.ReadAsStringAsync().Result);
                _log.Info(msg);
                return task.Result;
            });
        }
    }
}
