using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class TMDBResult : StreamBase
    {
        [Required]
        public string Name { get; set; }
        public string Note { get; set; }

        [Display(Name = "Poster URL")]
        public string PosterUrl { get; set; }
        public string Overview { get; set; }
        public string Cast { get; set; }
        public string Director { get; set; }
        public string Gener { get; set; }

        [Display(Name = "Release Date")]
        public string ReleaseDate { get; set; }
        public int Runtime { get; set; }
        public float Rating { get; set; }
    }
}
