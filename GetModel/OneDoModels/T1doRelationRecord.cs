using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class T1doRelationRecord
    {
        public string ShowId { get; set; }
        public long Id { get; set; }
        public long? Recordid { get; set; }
        public int? Sort { get; set; }
        public int? Similarity { get; set; }
        public int? Type { get; set; }
        public DateTime? Modifytime { get; set; }
    }
}
