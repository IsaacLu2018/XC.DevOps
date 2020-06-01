using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class TRegUser
    {
        public int Id { get; set; }
        public string ShowId { get; set; }
        public long? LaunchrId { get; set; }
        public string UName { get; set; }
        public string UPasswoed { get; set; }
        public string UTrueName { get; set; }
        public string UTrueNameC { get; set; }
        public string UHira { get; set; }
        public string UMail { get; set; }
        public string UJob { get; set; }
        public string UNumber { get; set; }
        public int? UStatus { get; set; }
        public string UTelephone { get; set; }
        public string UMobile { get; set; }
        public int? USort { get; set; }
        public string ULanguage { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public string LastLoginToken { get; set; }
        public int? IsAdmin { get; set; }
        public string CShowId { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public string CreateUserName { get; set; }
        public string ULoginName { get; set; }
        public string UTrueNameAc { get; set; }
        public int? UIsIn { get; set; }
        public string UAddress { get; set; }
        public int? UState { get; set; }
        public int? UIsShow { get; set; }
        public int? USign { get; set; }
        public int? Power { get; set; }
    }
}
