using Streamia.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class Transcode : BaseEntity
    {
        public string Name { get; set; }

        [Display(Name ="Video Codec")]
        public string VideoCodec { get; set; }

        [Display(Name = "Audio Codec")]
        public string AudioCodec { get; set; }

        [Display(Name = "Avg Audio bitrate")]
        public string AvgAudioBitrate { get; set; }

        [Display(Name = "Min Bitrate")]
        public string MinBitrate { get; set; }

        [Display(Name = "Mac Bitrate")]
        public string MaxBitrate { get; set; }

        [Display(Name = "Average bitrate")]
        public string AvgBitrate { get; set; }

        [Display(Name = "Buffer size")]
        public string BufferSize { get; set; }

        [Display(Name="Constant rate factor")]
        public int CRF { get; set; }

        public string Preset { get; set; }

        public string Scaling { get; set; }

        [Display( Name="Aspect Ratio")]
        public string AspectRatio { get; set; }

        [Display(Name= "Audio sample rate")]
        public string AudioSampleRate { get; set; }

        public Hardware Hardware { get; set; }
    }
}
