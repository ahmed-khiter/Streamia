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
            command.Append($" -c:v {transcodeProfile.VideoCodec ?? "copy"}");
            command.Append($" -profile:v {transcodeProfile.VideoProfile ?? "main"}");
            command.Append($" -c:a {transcodeProfile.AudioCodec ?? "copy"}");
            if (!transcodeProfile.Preset.Equals("default"))
            {
                command.Append($" -preset {transcodeProfile.Preset}");
            }

            return command.ToString();
        }
    }
}
