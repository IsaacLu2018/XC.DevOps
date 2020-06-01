using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class T1doBoardLog
    {
        public long Id { get; set; }
        public long ItemId { get; set; }
        public string ItemName { get; set; }
        public long ParentId { get; set; }
        public DateTime UpdateTime { get; set; }
        public int Type { get; set; }
        public string OUser { get; set; }
    }
}
