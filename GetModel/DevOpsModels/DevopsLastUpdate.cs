using System;
using System.Collections.Generic;

namespace GetModel.DevOpsModels
{
    public partial class DevopsLastUpdate
    {
        public DateTime? LastUpdateDate { get; set; }
        public int Id { get; set; }
        public string LastUpdateUser { get; set; }
        public string LastUpdateUserId { get; set; }
        public string OpreationDetail { get; set; }
    }
}
