using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class Approval
    {
        public long Id { get; set; }
        public int? Source { get; set; }
        public int? Type { get; set; }
        public string Name { get; set; }
        public long? GmtCreate { get; set; }
        public long? GmtModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}
