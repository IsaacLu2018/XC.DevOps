using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class T1doLabelRecord
    {
        public long Recordid { get; set; }
        public long Id { get; set; }
        public string Label { get; set; }
        public int? Type { get; set; }
        public int? Weight { get; set; }
    }
}
