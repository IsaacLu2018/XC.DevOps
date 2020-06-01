using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class TRegCompany
    {
        public int Id { get; set; }
        public string ShowId { get; set; }
        public string CCode { get; set; }
        public string CName { get; set; }
        public DateTime EndTime { get; set; }
        public string CreateUser { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreateTime { get; set; }
        public int? CActivationStatus { get; set; }
        public DateTime? CActivationTime { get; set; }
    }
}
