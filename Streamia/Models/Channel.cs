using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class Channel : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public ICollection<ChannelServer> ChannelServers { get; set; }

        public ICollection<BouquetChannel> BouquetChannels { get; set; }

        public Channel()
        {
            ChannelServers = new List<ChannelServer>();
            BouquetChannels = new List<BouquetChannel>();
        }
    }
}
