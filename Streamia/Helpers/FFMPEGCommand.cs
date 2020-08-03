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
                command.Append($" -vcodec {transcodeProfile.VideoCodec}");
            }
            return command.ToString();
        }
    }
}
