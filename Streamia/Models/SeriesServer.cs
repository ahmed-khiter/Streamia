using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class SeriesServer : BaseEntity
    {
        public uint SeriesId { get; set; }
        public uint ServerId { get; set; }
        public uint Pid { get; set; } = 0;
        public Series Series { get; set; }
        public Server Server { get; set; }
    }
}
