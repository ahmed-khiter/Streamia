using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class ChannelServer : BaseEntity
    {
        public uint ChannelId { get; set; }
        public uint ServerId { get; set; }
        public uint Pid { get; set; } = 0;
        public Channel Channel { get; set; }
        public Server Server { get; set; }
    }
}
