using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class Stream : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Source { get; set; }

        public string Note { get; set; }

        [Display(Name = "Generate PTS")]
        public bool GeneratePts { get; set; } = true;

        [Display(Name = "Stream All")]
        public bool StreamAll { get; set; }

        [Display(Name = "Allow RTMP")]
        public bool AllowRtmp { get; set; }

        [Display(Name = "Recording")]
        public bool AllowRecording { get; set; }

        [Display(Name = "Direct Source")]
        public bool DirectSource { get; set; }

        [Display(Name = "Enigma SID")]
        public string EnigmaSID { get; set; }

        [Display(Name = "Minutes to Delay")]
        public int MinuteDelay { get; set; }

        [Required]
        public List<Server> Servers { get; set; }

        public Category Category { get; set; }

        [Display(Name = "Add to Bouquet")]
        public List<BouquetSource> BouquetSources { get; set; }
    }
}
