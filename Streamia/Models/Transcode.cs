using Streamia.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class Transcode : BaseEntity
    {
        public string Name { get; set; }

        public string VideoCodec { get; set; }

        public string AudioCodec { get; set; }

        public string AvgAudioBitrate { get; set; }

        public string MinBitrate { get; set; }

        public string MaxBitrate { get; set; }

        public string AvgBitrate { get; set; }

        public string BufferSize { get; set; }

        public string CRF { get; set; }

        public string Preset { get; set; }

        public string Scaling { get; set; }

        public string AspectRatio { get; set; }

        public string AudioSampleRate { get; set; }

        public Hardware Hardware { get; set; }
    }
}
