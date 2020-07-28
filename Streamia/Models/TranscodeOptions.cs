using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public static class TranscodeOptions
    {
        //Uncompressed audio formats (WAV - AIFF - AU - raw - PCM ) 
        //Formats with lossless compression (FLAC - Monkey's Audio - TTA - WavPack - ATRAC - .ape )
        //advanced lossless(ALAC - .m4a - MPEG-4 ALS - MPEG-4 DST - Windows Media Audio - SHN )
        // formate with lossy compression ( OPUS  - MP3 - Vorbis - AAC - MusePack - Windows Media Audio Lossy )
        public static string[] AudioCodic = {
                         "MKV","MKA", "MP4", "MPA", "FLV"
                         ,"F4V","3GP","3G2","MPG","PS","TS Stream"
                         ,"ALAC",".m4a","MPEG-4 ALS","MPEG-4 DST"," Windows Media Audio","SHN"
                         ,"OPUS","MP3","Vorbis","AAC","MusePack","Windows Media Audio Lossy"
                        };
        public static string[] VideoCodec = { "libaom-av1", };

        public static string[] AsbectRatio = {
                        "1:1" , "4:3" ,"16:10" , "16:9" 
                        ,"1.85:1" , "2.35:1","21:9"
                        ,"2.39:1" , "2:1" 
                        , "3:2","5:4" ,"7:6","4:1"
                        };
    }
}
