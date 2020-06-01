using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class T1doLabelFeedback
    {
        public int Fbid { get; set; }
        public long Id { get; set; }
        public string Label { get; set; }
        public int? Type { get; set; }
        public int? Weight { get; set; }
    }
}
