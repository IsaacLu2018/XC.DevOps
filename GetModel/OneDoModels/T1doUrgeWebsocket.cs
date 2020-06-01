using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class T1doUrgeWebsocket
    {
        public long Id { get; set; }
        public string Sessionid { get; set; }
        public string User { get; set; }
        public int? Type { get; set; }
        public bool? IsOnline { get; set; }
        public long? GmtCreate { get; set; }
        public long? GmtModified { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModeifyTime { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
