using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class T1doProject
    {
        public long ItemId { get; set; }
        public DateTime OCreateTime { get; set; }
        public DateTime? OFinishTime { get; set; }
        public bool IsFinish { get; set; }
        public bool IsKey { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public string CrateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string GroupId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
