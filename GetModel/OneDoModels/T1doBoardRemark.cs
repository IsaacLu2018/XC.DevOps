using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class T1doBoardRemark
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public long ProjectId { get; set; }
        public int Type { get; set; }
    }
}
