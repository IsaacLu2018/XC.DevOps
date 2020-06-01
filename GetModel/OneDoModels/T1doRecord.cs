using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class T1doRecord
    {
        public long? Recordid { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public DateTime? Createtime { get; set; }
        public string Record { get; set; }
        public int? Type { get; set; }
    }
}
