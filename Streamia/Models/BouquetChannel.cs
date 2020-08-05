using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class BouquetChannel : BaseEntity
    {
        public uint BouquetId { get; set; }
        public uint ChannelId { get; set; }
        public Bouquet Bouquet { get; set; }
        public Channel Channel { get; set; }
    }
}
