using Streamia.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class Stream : StreamBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Source { get; set; }

        [Display(Name = "Generate PTS")]
        public bool GeneratePts { get; set; } = true;

        [Display(Name = "Enable RTMP")]
        public bool EnableRtmp { get; set; }

        [Display(Name = "Enable Recording")]
        public bool EnableRecording { get; set; }

        [Display(Name = "Enigma SID")]
        public string EnigmaSID { get; set; }

        [Display(Name = "Delay in minutes")]
        public int Delay { get; set; } = 0;

        public ICollection<StreamServer> StreamServers { get; set; }
        public ICollection<BouquetStream> BouquetStreams { get; set; }

        [NotMapped]
        [Required]
        [Display(Name = "Servers")]
        public List<int> ServerIds { get; set; }

        public Stream()
        {
            State = StreamState.STOPPED;
            StreamServers = new List<StreamServer>();
            BouquetStreams = new List<BouquetStream>();
        }
    }
}
