﻿using Streamia.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class Transcode : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Display(Name ="Video Codec")]
        public string VideoCodec { get; set; }

        [Display(Name = "Video Profile")]
        public string VideoProfile { get; set; }

        [Display(Name = "Avgerage Video Bitrate")]
        public string AvgVideoBitrate { get; set; }

        [Display(Name = "Audio Codec")]
        public string AudioCodec { get; set; }

        [Display(Name = "Audio Sample Rate")]
        public string AudioSampleRate { get; set; }

        [Display(Name = "Avgerage Audio Bitrate")]
        public string AvgAudioBitrate { get; set; }

        [Display(Name = "Analyze Duration")]
        public uint AnalyzeDuration { get; set; }
        public int Probsize { get; set; }
        public string Preset { get; set; }

        [Display(Name = "Min Bitrate")]
        public uint MinBitrate { get; set; }

        [Display(Name = "Max Bitrate")]
        public uint MaxBitrate { get; set; }

        [Display(Name = "Buffer Size")]
        public string BufferSize { get; set; }

        public uint CRF { get; set; }

        [Display(Name = "Target Video Frame Rate")]
        public string TargetVideoFrameRate { get; set; }

        [Display(Name = "Audio Channels")]
        public uint AudioChannels { get; set; }

        public uint Threads { get; set; }
    }
}
