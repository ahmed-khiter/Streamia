using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class StreamServer : BaseEntity
    {
        public uint StreamId { get; set; }
        public uint ServerId { get; set; }
        public uint Pid { get; set; } = 0;
        public Stream Stream { get; set; }
        public Server Server { get; set; }
    }
}
