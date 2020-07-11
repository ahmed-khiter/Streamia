using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class StreamServerPid : BaseEntity
    {
        public int StreamId { get; set; }
        public int ServerId { get; set; }
        public int Pid { get; set; }
        public Stream Stream { get; set; }
        public Server Server { get; set; }
    }
}
