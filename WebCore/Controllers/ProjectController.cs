using GetModel.DevOpsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XC.DevOps.Common;
using XC.DevOps.Extend;
using XC.DevOps.Models;

namespace XC.DevOps.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private static readonly int _baseNumber = 65536;
        private readonly hz_xc_devopsContext _context;
        public ProjectController(ILogger<ProjectController> logger, IConfiguration configuration, IHttpClientFactory httpClientFactory, hz_xc_devopsContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _context = context;
        }


        [HttpGet("GetWorkItems")]
        /// <summary>
        /// 由于那边没有允许跨域，这边调用的时候做一层处理
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public async Task<object> GetWorkItems(string day)
        {
            string url = $"{_configuration.GetSection("Urls").GetSection("DevOps").Value}/api/Project/workItems?day={day}";
            using (var client = _httpClientFactory.CreateClient())
            {
                HttpContent httpContent = new StringContent("", Encoding.UTF8);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync(url, httpContent);
                return await response.Content.ReadAsStringAsync();
            }
        }

        /// <summary>
        ///  获取全部列
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<IEnumerable<ProjectModel>> GetAll()
        {
            /*
             * 1. 先调用 /api/Project/Report 拿到项目ID ，名称，项目地址，项目进度
             * 2. 按照ID取出数据库中对用的项目
             * 3. 找不到的项目就其他字段返回空
             * 4. 找不到的项目需要显示在最前面
             */
            // 调用接口 
            var projects = new List<DevOpsProjectModel>();
            string url = $"{_configuration.GetSection("Urls").GetSection("DevOps").Value}/api/Project/Report";

            using (var client = _httpClientFactory.CreateClient())
            {
                var result = await client.GetAsync(url);
                string res = result.Content.ReadAsStringAsync().Result;
                try
                {
                    projects = JsonConvert.DeserializeObject<List<DevOpsProjectModel>>(res);
                }
                catch (Exception ex)
                {
                    // TODO: 错误处理
                    return new List<ProjectModel>() { };
                }
            }
            if (projects.Count > 0)
            {

                var datebase = _context.DevopsProject;
                var IdList = projects.Select(s => s.projectNodeGUID).ToList();
                // 找出数据库中所有已经有的数据
                var existList = datebase.Where(m => IdList.Contains(m.Id)).ToList();

                var resList = projects.Select(m =>
                {
                    var project = existList.Where(p => p.Id == m.projectNodeGUID).FirstOrDefault();
                    string progress = $"{m.reqFinished}/{m.reqCount}";
                    var model = new ProjectModel()
                    {
                        Id = m.projectNodeGUID,
                        title = m.projectNodeName,
                        link = m.url,
                        progress = progress == "0/0" ? "无法追踪" : progress
                    };
                    if (null != project)
                    {
                        model.manager = project.Manager;
                        model.priority = project.Priority;
                        model.startTime = project.StartTime;
                        model.state = project.State;
                        model.team = project.Team;
                        model.order = project.Order;
                        model.client = project.Client;
                        model.stateValue = CommonEnumable.stateDic[project.State];
                    }
                    else
                    {
                        model.order = _baseNumber * -10000;
                    }

                    return model;
                }).ToList();

                // 排序处理 根据order 和优先级进行排序
                return resList.OrderBy(r => r.order).ThenBy(r => r.priority);
            }
            else
            {
                return new List<ProjectModel>() { };
            }
        }

        /// <summary>
        /// 获取单个项目
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetItem")]
        public ProjectModel Get(string Id)
        {

            var datebase = _context.DevopsProject;
            var model = datebase.Where(d => d.Id == Id).FirstOrDefault();
            var res = new ProjectModel() { };
            if (null != model)
            {
                ModelBindGenericClass<DevopsProject, ProjectModel>.ModelBind(model, res);
            }

            return res;
        }

        /// <summary>
        ///  没有就插入 有则更新完成项目更新
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        public async Task<ResponseBaseModel> Update([FromBody] ProjectModel req)
        {
            var res = new ResponseBaseModel()
            {
                isSuccess = false
            };
            bool updateWIki = false;
            if (null != req)
            {
                var datebase = _context.DevopsProject;
                var project = datebase.Where(m => m.Id == req.Id).FirstOrDefault();
                try
                {
                    if (null != project)
                    {
                        // 内容更新
                        project.Manager = req.manager;
                        project.Priority = req.priority;
                        project.StartTime = req.startTime;
                        project.EndTime = req.endTime;
                        project.Team = req.team;
                        project.Client = req.client;
                        project.State = req.state;
                        if (project.Description != req.description)
                        {
                            project.Description = req.description;
                            updateWIki = true;
                        }
                        datebase.Update(project);
                    }
                    else
                    {
                        updateWIki = true;
                        var newProject = new DevopsProject() { };
                        // 插入新的
                        ModelBindGenericClass<ProjectModel, DevopsProject>.ModelBind(req, newProject);
                        // 设置order
                        var min = datebase.Min(d => d.Order);
                        newProject.Order = min - _baseNumber;
                        datebase.Add(newProject);
                    }

                    // 提交
                    _context.SaveChanges();
                    res.isSuccess = true;

                    // 不显示调用wiki结果
                    if (updateWIki)
                    {
                        // 同步wiki
                        string url = $"{_configuration.GetSection("Urls").GetSection("DevOps").Value}/api/Project/SendWiki";
                        //  projectGuid={req.Id}&content={req.description}
                        string wikiReq = JsonConvert.SerializeObject(new
                        {
                            projectGuid = req.Id,
                            content = req.description
                        });
                        using (var client = _httpClientFactory.CreateClient())
                        {
                            HttpContent httpContent = new StringContent(wikiReq, Encoding.UTF8);
                            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                            HttpResponseMessage response = await client.PostAsync(url, httpContent);
                            var wikiRes = await response.Content.ReadAsStringAsync();
                            // wiki 同步结果不显示
                        }
                    }
                }
                catch (Exception ex)
                {
                    res.message = $"更新发生意外错误，{ex.Message}";
                }
            }
            else
            {
                res.message = "请求参数不为空";
            }
            return res;
        }

        /// <summary>
        /// 更新顺序
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost("SetOrder")]
        public ResponseBaseModel SetOrder(string Id, int priority, decimal order)
        {
            var res = new ResponseBaseModel()
            {
                isSuccess = false
            };
            var datebase = _context.DevopsProject;
            var model = datebase.Where(d => d.Id == Id).FirstOrDefault();
            if (null != model)
            {
                model.Priority = priority;
                model.Order = order;
                datebase.Update(model);
                // TODO：ef事务....
                // 同时更新最近时间
                var lastInfo = _context.DevopsLastUpdate.First();
                lastInfo.LastUpdateDate = DateTime.Now;

                _context.SaveChanges();
                res.isSuccess = true;
            }
            return res;
        }

        /// <summary>
        /// TODO: 重新更新项目排序 考虑项目一直被拖动的后果....
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetNumber")]
        public List<int> GetNumber()
        {
            var list = new List<int>();
            for (int i = 0; i < 116; i++)
            {
                list.Add(-i * _baseNumber);
            }
            return list;
        }

        [HttpGet("GetLastUpdateInfo")]
        public DevopsLastUpdate GetLastUpdateInfo()
        {
            return _context.DevopsLastUpdate.FirstOrDefault();
        }

        [HttpGet("GetProjects")]
        public List<string> GetProjects()
        {
            return _context.DevopsProject.Select(p=>p.Title).ToList();
        }
    }
}