using System;

namespace XC.DevOps.Models
{
    public class ProjectModel 
    {
        public string Id { get; set; }
        public string title { get; set; }
        public string state { get; set; }
        public string stateValue { get; set; }
        public string client { get; set; }
        public string description { get; set; }
        public string manager { get; set; }
        public int priority { get; set; }
        public decimal order { get; set; }
        public string team { get; set; }
        public string link { get; set; }
        public string progress { get; set; }
        
        public DateTime? startTime { get; set; }
        public DateTime? endTime { get; set; }

    }
    
}

