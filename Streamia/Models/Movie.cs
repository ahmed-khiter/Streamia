using Streamia.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class Movie : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Path { get; set; }
        public string Note { get; set; }
        public string PosterUrl { get; set; }
        public string BackdropUrl { get; set; }
        public string Plot { get; set; }
        public string Cast { get; set; }
        public string Director { get; set; }
        public string Gener { get; set; }
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
        public bool ProcessMovie { get; set; }
        public TranscodeProfile TranscodingProfile { get; set; }
        public Category Category { get; set; }
    }
}
