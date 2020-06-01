using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class Websocket
    {
        public long Id { get; set; }
        public string Sessionid { get; set; }
        public string Showid { get; set; }
        public int? Fbid { get; set; }
        public bool? IsOnline { get; set; }
        public long? GmtCreate { get; set; }
        public long? GmtModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}
