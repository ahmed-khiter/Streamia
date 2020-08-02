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

        [Display(Name = "Avgerage Audio bitrate")]
        public string AvgAudioBitrate { get; set; }

        public int Probsize { get; set; }

        /*
         * -minrate + number
         */
        [Display(Name = "Min Bitrate")]
        public int MinBitrate { get; set; }

        /*
         * -maxrate + number
         */
        [Display(Name = "Max Bitrate")]
        public int MaxBitrate { get; set; }

        /*
         * -b:V + number to be able to control the bandwidth used 
         * -b:V or Max rate is used in conjunction with buffer size 
         */
        [Display(Name = "Average Bitrate")]
        public int AvgBitrate { get; set; }

        /*
         * -bufsize
         */
        [Display(Name = "Buffer Size")]
        public string BufferSize { get; set; }

        /*
         * default is 28 
         */
        [Display(Name="Constant Rate Factor")]
        public int CRF { get; set; }

        /*
         * The preset determines how fast the encoding process will be at the expense of detail.
         */
        public PresetOptions Preset { get; set; }

        /*
         * By default, this is disabled it helped preset 
         */
        public TuneOptions Tune { get; set; }

        public string Scaling { get; set; }

        [Display(Name = "Aspect Ratio")]
        public string AspectRatio { get; set; }

        [Display(Name = "Target Video Frame Rate")]
        public string TargetVideoFrameRate { get; set; }

        [Display(Name = "Audio Channel")]
        public int AudioChannel { get; set; }

        [Display(Name = "Remove Sensitive Parts")]
        public string RemoveSensitiveParts { get; set; }

        public int Threads { get; set; }

        [Display(Name= "Audio sample rate")]
        public string AudioSampleRate { get; set; }

        public TranscodeHardware Hardware { get; set; }

        //bitrate = file size / duration 
    }
}
