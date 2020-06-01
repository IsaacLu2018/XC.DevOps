using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class TRegCompanyDept
    {
        public int Id { get; set; }
        public string ShowId { get; set; }
        public string DName { get; set; }
        public string DParentidShowId { get; set; }
        public int DLevel { get; set; }
        public string DPath { get; set; }
        public string DPathName { get; set; }
        public int DSort { get; set; }
        public string CShowId { get; set; }
        public int DAvailableCount { get; set; }
        public int DUnavailableCount { get; set; }
        public int DChilddeptCount { get; set; }
        public string CreateUser { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string DIcon { get; set; }
        public string Background { get; set; }
        public string AppId { get; set; }
        public string AppName { get; set; }
        public int? USign { get; set; }
    }
}
