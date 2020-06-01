using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class Holiday
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Week { get; set; }
        public int? Type { get; set; }
        public string Desc { get; set; }
        public string WeekOfYear { get; set; }
        public DateTime Modifytime { get; set; }
        public DateTime? DateTime { get; set; }
        public string Time { get; set; }
        public string Day { get; set; }
        public string Weeknum { get; set; }
        public string Data { get; set; }
        public long? ItemId { get; set; }
        public string Atemp { get; set; }
        public string Btemp { get; set; }
        public string Dtemp { get; set; }
    }
}
