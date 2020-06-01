using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class T1doWechat
    {
        public int Id { get; set; }
        public string DataId { get; set; }
        public int? Type { get; set; }
        public DateTime? CreateTime { get; set; }
        public string Result { get; set; }
        public string Parameter { get; set; }
    }
}
