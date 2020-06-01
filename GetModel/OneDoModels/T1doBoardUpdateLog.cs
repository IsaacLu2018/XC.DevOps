using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class T1doBoardUpdateLog
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int? Type { get; set; }
        public string OUser { get; set; }
    }
}
