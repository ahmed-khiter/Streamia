using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public enum Transcode
    {
        FullHD,
        HD,
        medium,
        low,
    }

    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Path { get; set; }
        public Category Category { get; set; } 
        public List<BouquetSource> BouquetSources { get; set; }
        public string Note { get; set; }
        public string PosterUrl { get; set; }
        public string BackdropUrl { get; set; }
        public string Plot { get; set; }
        public string Cast { get; set; }
        public string Director { get; set; }
        public string Genres { get; set; }
        public string ReleaseDate { get; set; }
        public int Runtime { get; set; }
        public float Rating { get; set; }
        public string Country { get; set; }
        public bool NativeFrame { get; set; }
        public bool DirectSource { get; set; }
        public bool CreateSymlink { get; set; }
        public string SidDevice { get; set; }
        public string TargetContainer { get; set; }
        public bool RemoveExistingSubtitle { get; set; }
        public string SubtitleLocation { get; set; }
        public Transcode TranscodingProfile { get; set; }
        [Required]
        public List<Server> Servers { get; set; }
        public bool ProcessMovie { get; set; }

       
    }
}
