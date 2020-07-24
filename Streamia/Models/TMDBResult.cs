﻿using System;
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

        [Display(Name = "Poster URL")]
        public string PosterUrl { get; set; }
        public string Overview { get; set; }
        public virtual string Cast { get; set; }
        public virtual string Director { get; set; }
        public virtual string Gener { get; set; }

        [Display(Name = "Release Date")]
        public string ReleaseDate { get; set; }
        public virtual int Runtime { get; set; }
        public float Rating { get; set; }
    }
}
