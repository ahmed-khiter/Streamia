﻿using Streamia.Models.Enums;
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

        public string Notes { get; set; }

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
        public int MinuteDelay { get; set; } = 0;

        public ICollection<StreamServer> StreamServers { get; set; }
        public ICollection<BouquetStream> BouquetStreams { get; set; }

        [NotMapped]
        [Required]
        [Display(Name = "Servers")]
        public List<int> ServerIds { get; set; }

        public Stream()
        {
            StreamServers = new List<StreamServer>();
            BouquetStreams = new List<BouquetStream>();
        }
    }
}
