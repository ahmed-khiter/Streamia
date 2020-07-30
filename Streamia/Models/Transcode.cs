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
        public int MinBitrate { get; set; } //-minrate + number

        [Display(Name = "Mac Bitrate")]
        public int MaxBitrate { get; set; } //-maxrate + number

        [Display(Name = "Average bitrate")]
        public int AvgBitrate { get; set; } //-b:V + number to be able to control the bandwidth used 
        //-b:V or Max rate is used in conjunction with buffer size 
        [Display(Name = "Buffer size")]
        public string BufferSize { get; set; }  // -bufsize

        [Display(Name="Constant rate factor")]
        public int CRF { get; set; } //default is 28 

        // The preset determines how fast the encoding process will be at the expense of detail.
        public PresetOptions Preset { get; set; }

        //By default, this is disabled it helped preset 
        public TuneOptions Tune { get; set; }

        public string Scaling { get; set; }

        [Display( Name="Aspect Ratio")]
        public string AspectRatio { get; set; }

        public string TargetVideoFrameRate { get; set; }

        public int AudioChannel { get; set; }

        public string RemoveSenstitveParts { get; set; }

        public int Threads { get; set; }

        [Display(Name= "Audio sample rate")]
        public string AudioSampleRate { get; set; }

        public TranscodeHardware Hardware { get; set; }

        //bitrate = file size / duration 
    }
}
