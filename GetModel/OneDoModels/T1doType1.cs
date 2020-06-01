using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class T1doType1
    {
        public int Id { get; set; }
        public int? OParentId { get; set; }
        public int? OTypeId { get; set; }
        public string OTypeName { get; set; }
        public string OSoureName { get; set; }
        public string OtherName { get; set; }
    }
}
