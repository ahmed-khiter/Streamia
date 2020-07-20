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
        public string Source { get; set; }

        [Display(Name = "Subtitle Path")]
        public string SubtitleLocation { get; set; }

        [Display(Name = "Direct Source")]
        public bool DirectSource { get; set; }

        [Display(Name = "Remove Existing Subtitle")]
        public bool RemoveExistingSubtitle { get; set; }

        public ICollection<MovieServer> MovieServers { get; set; }

        public ICollection<BouquetMovie> BouquetMovies { get; set; }

        public Movie()
        {
            MovieServers = new List<MovieServer>();
            BouquetMovies = new List<BouquetMovie>();
        }

    }
}
