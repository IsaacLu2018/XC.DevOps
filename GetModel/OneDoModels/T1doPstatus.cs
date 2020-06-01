using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class T1doPstatus
    {
        public string ShowId { get; set; }
        public int Id { get; set; }
        public string OUser { get; set; }
        public string OUserName { get; set; }
        public int? OStatus { get; set; }
        public string Status { get; set; }
        public int? UserType { get; set; }
        public int? IsDelete { get; set; }
        public int? IsRead { get; set; }
        public string Result { get; set; }
        public int? Otherid { get; set; }
        public int? Online { get; set; }
        public DateTime? GmtModified { get; set; }
        public bool? UrgeIsLook { get; set; }
        public int? Sort { get; set; }
        public int? Islook { get; set; }
        public int? Original { get; set; }
    }
}
