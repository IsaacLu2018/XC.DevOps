using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class T1doOrder
    {
        public string ShowId { get; set; }
        public long Id { get; set; }
        public string Useraccount { get; set; }
        public int? Type { get; set; }
        public DateTime? ModifyTime { get; set; }
    }
}
