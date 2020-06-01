using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class TRegUserDept
    {
        public int Id { get; set; }
        public string UName { get; set; }
        public string UDeptId { get; set; }
        public string CShowId { get; set; }
        public int? IsMain { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public string CreateUserName { get; set; }
        public int? UDeptSort { get; set; }
    }
}
