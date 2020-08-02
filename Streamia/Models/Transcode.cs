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

        [Display(Name = "Video Preset")]
        public string VideoPreset { get; set; }

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
        public int AnalyzeDuration { get; set; }

        public int Probsize { get; set; }

        [Display(Name = "Min Bitrate")]
        public int MinBitrate { get; set; }

        [Display(Name = "Max Bitrate")]
        public int MaxBitrate { get; set; }

        [Display(Name = "Buffer Size")]
        public string BufferSize { get; set; }

        [Display(Name="Constant Rate Factor")]
        public int CRF { get; set; }

        [Display(Name = "Target Video Frame Rate")]
        public string TargetVideoFrameRate { get; set; }

        [Display(Name = "Audio Channels")]
        public int AudioChannels { get; set; }

        public int Threads { get; set; }
    }
}
