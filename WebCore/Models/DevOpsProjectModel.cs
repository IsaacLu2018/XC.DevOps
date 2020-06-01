using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XC.DevOps.Models
{
    public class DevOpsProjectModel
    {
        public string projectNodeGUID { get; set; }
        public string projectNodeName { get; set; }
        public string url { get; set; }
        public string reqCount { get; set; }
        public string reqFinished { get; set; }
    }
}
