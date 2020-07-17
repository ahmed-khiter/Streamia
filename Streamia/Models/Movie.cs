using Streamia.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class Movie : TMDBResult
    {
        [Required]
        public string Path { get; set; }

        public string Extension { get; set; }

        [Display(Name = "Subtitle Path")]
        public string SubtitleLocation { get; set; }

        [Display(Name = "Channel SID")]
        public string ChannelSid { get; set; }

        [Display(Name = "Native Frame")]
        public bool NativeFrame { get; set; }

        [Display(Name = "Direct Source")]
        public bool DirectSource { get; set; }

        [Display(Name = "Remove Existing Subtitle")]
        public bool RemoveExistingSubtitle { get; set; }

        [Display(Name = "Process Movie")]
        public bool ProcessMovie { get; set; }

        public ICollection<BouquetMovie> BouquetMovies { get; set; }

        public Movie()
        {
            BouquetMovies = new List<BouquetMovie>();
        }

    }
}
