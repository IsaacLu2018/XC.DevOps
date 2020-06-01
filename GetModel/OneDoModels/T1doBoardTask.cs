using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class T1doBoardTask
    {
        public long Id { get; set; }
        public string Task { get; set; }
        public DateTime? Date { get; set; }
        public long? ProjectId { get; set; }
        public string Completion { get; set; }
        public string Principle { get; set; }
        public string PrincipleShowId { get; set; }
        public string PlannedDate { get; set; }
        public string Data { get; set; }
        public long? ItemId { get; set; }
        public string Atemp { get; set; }
        public string Btemp { get; set; }
        public string PlannedTime { get; set; }
        public string Dtemp { get; set; }
        public bool? IsRelation { get; set; }
    }
}
