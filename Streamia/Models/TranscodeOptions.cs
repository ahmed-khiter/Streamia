using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public static class TranscodeOptions
    {
        /*
        - APNG(Animated protable network graphics)
        - Chinese AVS (Audio video standard ) (AVS1-P2 jizhum profile)(encoder libxaavs ) 
        - Cinepak 
        - ffmpeg video codec #1 
        - flash screen video  V1 
        - flash screen video  V2 
        - FLV / sorenson spark / sorenson H263(flash video )(decodes:Flv) (encoder flv )
        - GIF (graphic interchange formate ) 
        - H.261 
        - H.263
        - H.264 / AVC /Mpeg-4 AVC /Mpeg4 part 10 (encode libx264 libx264rgb)
        - H.265
        - MPEG-1 video 
        - MPEG-2 video
        - MPEG-4
        - microsoft video 1 

                  */
        public static string[] VideoCodec = {
                       "jpeg2000","libaom-av1","libravel", "libkvazaar", "libopenh264" ,"Hap"
                       , "libtheora" , "libvpx" , "libwebp" , "libx264","libx264rgb"
                       , "libx265","libxavs2","libxvid" , "MediaFoundation" , "mpeg2"
                       ,"png" , "ProRes","QSV encoders","snow" , "VAAPI encoders" , "vc2"};

        //Uncompressed audio formats (WAV - AIFF - AU - raw - PCM ) 
        //Formats with lossless compression (FLAC - Monkey's Audio - TTA - WavPack - ATRAC - .ape )
        //advanced lossless(ALAC - .m4a - MPEG-4 ALS - MPEG-4 DST - Windows Media Audio - SHN )
        // formate with lossy compression ( OPUS  - MP3 - Vorbis - AAC - MusePack - Windows Media Audio Lossy ) 
        /*
         * "MKV","MKA", "MP4", "MPA", "FLV"
        ,"F4V","3GP","3G2","MPG","PS","TS Stream","flac"
        ,"ALAC",".m4a","MPEG-4 ALS","MPEG-4 DST"," Windows Media Audio","SHN"
        ,"OPUS","MP3","Vorbis","AAC","MusePack","Windows Media Audio Lossy","ac3","libfdk_aac"
         */
        public static string[] AudioCodic = {
                        "aac" ,"ac3" , "ac3_fixed" , "flac" , "opus" , "libfdk_aac", "libmp3lame","libopencore-amrnb"
                        ,"libopus","libshine","libtwolame","libvo-amrwbenc","libvorbis","libwavpack","mjpeg","wavpack"
                        };

        public static string[] AsbectRatio = {
                        "1:1" , "4:3" ,"16:10" , "16:9" 
                        ,"1.85:1" , "2.35:1","21:9" , "32:9"
                        ,"2.39:1" , "2:1" ,"256:135"
                        , "3:2","5:4" ,"7:6","4:1"
                        };

        public static int[] audioBitrate = { 96, 112, 128, 160, 192, 256, 320 };
    }
}
