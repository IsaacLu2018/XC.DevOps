using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class T1doBoardDaliyReport
    {
        public long Id { get; set; }
        public long? ReportId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public DateTime? Time { get; set; }
        public string Company { get; set; }
        public int Number { get; set; }
        public long ProjectId { get; set; }
        public long? TaskId { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
