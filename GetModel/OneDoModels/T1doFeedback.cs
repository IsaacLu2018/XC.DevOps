using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class T1doFeedback
    {
        public string ShowId { get; set; }
        public int Id { get; set; }
        public string OUser { get; set; }
        public string OUserName { get; set; }
        public DateTime? FbTime { get; set; }
        public long? TimeStamp { get; set; }
        public string Fbcontent { get; set; }
        public int? FbType { get; set; }
        public string Attrid { get; set; }
        public string FbUser { get; set; }
        public string FbUserName { get; set; }
        public string Userid { get; set; }
        public string AttrName { get; set; }
        public string AttrPath { get; set; }
        public int? Star { get; set; }
        public int? Isoverdue { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string At { get; set; }
        public string ShortMessage { get; set; }
        public int? Temp { get; set; }
        public string Result { get; set; }
        public bool? IsCreateReport { get; set; }
        public string CallMessage { get; set; }
        public int? Source { get; set; }
    }
}
