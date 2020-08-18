using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class Channel : StreamBase
    {
        [Required]
        public string Name { get; set; }

        public string Logo { get; set; }

        public string Source { get; set; }

        [Required]
        [Display(Name = "Transcode")]
        public override int? TranscodeId { get; set; }

        [NotMapped]
        public string[] SourcePath { get; set; }

        [NotMapped]
        public uint ServerId { get; set; }

        public ICollection<ChannelServer> ChannelServers { get; set; }

        public ICollection<BouquetChannel> BouquetChannels { get; set; }

        public Channel()
        {
            ChannelServers = new List<ChannelServer>();
            BouquetChannels = new List<BouquetChannel>();
        }
    }
}
