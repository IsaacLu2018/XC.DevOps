using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class T1doBoard
    {
        public long Id { get; set; }
        public long ParentId { get; set; }
        public string ItemName { get; set; }
        public int? Type { get; set; }
        public string Completion { get; set; }
        public DateTime? FinishDate { get; set; }
    }
}
