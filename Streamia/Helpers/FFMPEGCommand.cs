using Streamia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamia.Helpers
{
    public static class FFMPEGCommand
    {
        public static string GenerateTranscodeParams(Transcode transcodeProfile)
        {
            StringBuilder command = new StringBuilder(" -y -nostdin -hide_banner ");
            if (!string.IsNullOrEmpty(transcodeProfile.VideoCodec))
            {
                command.Append($" -c:v {transcodeProfile.VideoCodec}");
            }
            if (!string.IsNullOrEmpty(transcodeProfile.VideoProfile))
            {
                command.Append($" -profile:v {transcodeProfile.VideoProfile}");
            }
            if (!string.IsNullOrEmpty(transcodeProfile.AudioCodec))
            {
                command.Append($" -c:a {transcodeProfile.AudioCodec}");
            }
            if (!string.IsNullOrEmpty(transcodeProfile.Preset))
            {
                command.Append($" -preset {transcodeProfile.Preset}");
            }

            return command.ToString();
        }
    }
}
