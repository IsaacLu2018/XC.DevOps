using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class T1doLog
    {
        public string ShowId { get; set; }
        public int Id { get; set; }
        public string OUser { get; set; }
        public string OUserName { get; set; }
        public DateTime? OpTime { get; set; }
        public string Log { get; set; }
        public int? LogType { get; set; }
        public string Oprator { get; set; }
        public int? Isoverdue { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string Content { get; set; }
        public bool? Calculation { get; set; }
        public DateTime? CrateTime { get; set; }
    }
}
