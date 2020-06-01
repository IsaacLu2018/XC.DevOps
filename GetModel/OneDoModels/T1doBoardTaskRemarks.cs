using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class T1doBoardTaskRemarks
    {
        public long Id { get; set; }
        public long TaskId { get; set; }
        public string CompanyId { get; set; }
        public string Content { get; set; }
    }
}
