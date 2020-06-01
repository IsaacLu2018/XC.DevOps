using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class T1doBoardTaskProgress
    {
        public DateTime Date { get; set; }
        public long ProjectId { get; set; }
        public int AllNumber { get; set; }
        public int AlreadyNumber { get; set; }
        public int Rate { get; set; }
    }
}
