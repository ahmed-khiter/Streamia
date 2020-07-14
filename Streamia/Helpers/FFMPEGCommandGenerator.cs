using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamia.Helpers
{
    public class FFMPEGCommandGenerator
    {
        private readonly StringBuilder commandBuilder;
        public string InputSource { get; set; }
        public string OutputSource { get; set; }
        public string StreamLoop { get; set; }
        public string Bitreate { get; set; }
        public string VideoCodec { get; set; }
        public string VideoProfile { get; set; }
        public string GroupOfPictures { get; set; }
        public string AudioCodec { get; set; }
        public string Format { get; set; }

        public FFMPEGCommandGenerator()
        {
            commandBuilder = new StringBuilder("nohup ffmpeg");
        }

        public string Generate()
        {
            commandBuilder.Append($" stream_loop {StreamLoop}");
            commandBuilder.Append($" -i {InputSource}");
            commandBuilder.Append($" -vcodec {VideoCodec}");
            commandBuilder.Append($" -vprofile {VideoProfile}");
            commandBuilder.Append($" -acodec {AudioCodec}");
            commandBuilder.Append($" -f {Format} ");
            commandBuilder.Append(OutputSource);
            commandBuilder.Append(" >/dev/null 2>&1 & echo $!");
            return commandBuilder.ToString();
        }
    }
}
