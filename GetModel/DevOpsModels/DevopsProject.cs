using System;
using System.Collections.Generic;

namespace GetModel.DataBaseModel
{
    public partial class DevopsProject
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string State { get; set; }
        public int Priority { get; set; }
        public decimal Order { get; set; }
        public string Client { get; set; }
        public string Manager { get; set; }
        public string Team { get; set; }
        public string Link { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public string LastEditUser { get; set; }
    }
}
