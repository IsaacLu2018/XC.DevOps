using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class T1doBoardTaskReport
    {
        public long Id { get; set; }
        public DateTime? Date { get; set; }
        public string Summary { get; set; }
        public int? Number { get; set; }
        public long? ProjectId { get; set; }
    }
}
