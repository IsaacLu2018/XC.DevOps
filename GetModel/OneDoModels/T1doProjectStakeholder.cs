using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class T1doProjectStakeholder
    {
        public long Id { get; set; }
        public long ItemId { get; set; }
        public string OUser { get; set; }
        public string Company { get; set; }
        public long ProjectId { get; set; }
    }
}
