using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XC.DevOps.Models
{
    public class ResponseBaseModel
    {
        /// <summary>
        ///  返回信息
        /// </summary>
        public string message { get; set; }
        
        /// <summary>
        /// 代码字段
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool isSuccess { get; set; }
    }

    public class ResponseBaseModel<T> where T : class
    {
        /// <summary>
        /// 数据
        /// </summary>
        public T data { get; set; }

        /// <summary>
        ///  返回信息
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 代码字段
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool isSuccess { get; set; }
    }
}
