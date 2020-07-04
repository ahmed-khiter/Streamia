using Streamia.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class SourceServers
    {
        public int SourceId { get; set; }
        public int ServerId { get; set; }
        public SourceType SourceType { get; set; }
        public Server Server { get; set; }
    }
}
