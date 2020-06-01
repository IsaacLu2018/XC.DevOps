using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class T1doFwpstatus
    {
        public int Id { get; set; }
        public string ShowId { get; set; }
        public string OUser { get; set; }
        public int? IsRead { get; set; }
        public int? Online { get; set; }
        public DateTime? ModifyTime { get; set; }
        public DateTime? GmtModified { get; set; }
    }
}
