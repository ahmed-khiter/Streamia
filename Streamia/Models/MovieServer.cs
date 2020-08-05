using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class MovieServer : BaseEntity
    {
        public uint MovieId { get; set; }
        public uint ServerId { get; set; }
        public uint Pid { get; set; } = 0;
        public Movie Movie { get; set; }
        public Server Server { get; set; }
    }
}
