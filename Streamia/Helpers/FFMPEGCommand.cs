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
        public static string MakeCommand(Transcode transcodeProfile)
        {
            StringBuilder command = new StringBuilder("ffmpeg -y -nostdin -hide_banner -i INPUT_SRC");

            // 1920x1080
            command.Append(" -vf scale=w=1920:h=1080:force_original_aspect_ratio=decrease");
            command.Append($" -c:a {transcodeProfile.AudioCodec ?? "copy"}");
            command.Append(transcodeProfile.AudioSampleRate_1080 > 0 ? $" -ar {transcodeProfile.AudioSampleRate_720}" : string.Empty);
            command.Append($" -c:v {transcodeProfile.VideoCodec ?? "copy"}");
            command.Append(!transcodeProfile.Preset.Equals("default") ? $" -preset {transcodeProfile.Preset}" : string.Empty);
            command.Append(!transcodeProfile.VideoProfile.Equals("none") ? $" -profile:v  {transcodeProfile.VideoProfile}" : string.Empty);
            command.Append(transcodeProfile.CRF > 0 ? $" -crf {transcodeProfile.CRF}" : string.Empty);
            command.Append(" -hls_time LIST_TIME");
            command.Append(" -hls_playlist_type LIST_TYPE");
            command.Append(transcodeProfile.VideoBitrate_1080 > 0 ? $" -b:v {transcodeProfile.VideoBitrate_1080}k" : string.Empty);
            command.Append(transcodeProfile.MaxBitrate_1080 > 0 ? $" -maxrate {transcodeProfile.MaxBitrate_1080}k" : string.Empty);
            command.Append(transcodeProfile.BufferSize_1080 > 0 ? $" -bufsize {transcodeProfile.BufferSize_1080}k" : string.Empty);
            command.Append(transcodeProfile.AudioBitrate_1080 > 0 ? $" -b:a {transcodeProfile.AudioBitrate_1080}k" : string.Empty);
            command.Append(" -hls_segment_filename OUTPUT_SRC_1080");

            // 1280x720
            command.Append(" -vf scale=w=1280:h=720:force_original_aspect_ratio=decrease");
            command.Append($" -c:a {transcodeProfile.AudioCodec ?? "copy"}");
            command.Append(transcodeProfile.AudioSampleRate_720 > 0 ? $" -ar {transcodeProfile.AudioSampleRate_720}" : string.Empty);
            command.Append($" -c:v {transcodeProfile.VideoCodec ?? "copy"}");
            command.Append(!transcodeProfile.Preset.Equals("default") ? $" -preset {transcodeProfile.Preset}" : string.Empty);
            command.Append(!transcodeProfile.VideoProfile.Equals("none") ? $" -profile:v  {transcodeProfile.VideoProfile}" : string.Empty);
            command.Append(transcodeProfile.CRF > 0 ? $" -crf {transcodeProfile.CRF}" : string.Empty);
            command.Append(" -hls_time LIST_TIME");
            command.Append(" -hls_playlist_type LIST_TYPE");
            command.Append(transcodeProfile.VideoBitrate_720 > 0 ? $" -b:v {transcodeProfile.VideoBitrate_720}k" : string.Empty);
            command.Append(transcodeProfile.MaxBitrate_720 > 0 ? $" -maxrate {transcodeProfile.MaxBitrate_720}k" : string.Empty);
            command.Append(transcodeProfile.BufferSize_720 > 0 ? $" -bufsize {transcodeProfile.BufferSize_720}k" : string.Empty);
            command.Append(transcodeProfile.AudioBitrate_720 > 0 ? $" -b:a {transcodeProfile.AudioBitrate_720}k" : string.Empty);
            command.Append(" -hls_segment_filename OUTPUT_SRC_720");

            // 842x480
            command.Append(" -vf scale=w=842:h=480:force_original_aspect_ratio=decrease");
            command.Append($" -c:a {transcodeProfile.AudioCodec ?? "copy"}");
            command.Append(transcodeProfile.AudioSampleRate_480 > 0 ? $" -ar {transcodeProfile.AudioSampleRate_480}" : string.Empty);
            command.Append($" -c:v {transcodeProfile.VideoCodec ?? "copy"}");
            command.Append(!transcodeProfile.Preset.Equals("default") ? $" -preset {transcodeProfile.Preset}" : string.Empty);
            command.Append(!transcodeProfile.VideoProfile.Equals("none") ? $" -profile:v  {transcodeProfile.VideoProfile}" : string.Empty);
            command.Append(transcodeProfile.CRF > 0 ? $" -crf {transcodeProfile.CRF}" : string.Empty);
            command.Append(" -hls_time LIST_TIME");
            command.Append(" -hls_playlist_type LIST_TYPE");
            command.Append(transcodeProfile.VideoBitrate_480 > 0 ? $" -b:v {transcodeProfile.VideoBitrate_480}k" : string.Empty);
            command.Append(transcodeProfile.MaxBitrate_480 > 0 ? $" -maxrate {transcodeProfile.MaxBitrate_480}k" : string.Empty);
            command.Append(transcodeProfile.BufferSize_480 > 0 ? $" -bufsize {transcodeProfile.BufferSize_480}k" : string.Empty);
            command.Append(transcodeProfile.AudioBitrate_480 > 0 ? $" -b:a {transcodeProfile.AudioBitrate_480}k" : string.Empty);
            command.Append(" -hls_segment_filename OUTPUT_SRC_480");

            // 640x360
            command.Append(" -vf scale=w=640:h=360:force_original_aspect_ratio=decrease");
            command.Append($" -c:a {transcodeProfile.AudioCodec ?? "copy"}");
            command.Append(transcodeProfile.AudioSampleRate_360 > 0 ? $" -ar {transcodeProfile.AudioSampleRate_480}" : string.Empty);
            command.Append($" -c:v {transcodeProfile.VideoCodec ?? "copy"}");
            command.Append(!transcodeProfile.Preset.Equals("default") ? $" -preset {transcodeProfile.Preset}" : string.Empty);
            command.Append(!transcodeProfile.VideoProfile.Equals("none") ? $" -profile:v  {transcodeProfile.VideoProfile}" : string.Empty);
            command.Append(transcodeProfile.CRF > 0 ? $" -crf {transcodeProfile.CRF}" : string.Empty);
            command.Append(" -hls_time LIST_TIME");
            command.Append(" -hls_playlist_type LIST_TYPE");
            command.Append(transcodeProfile.VideoBitrate_360 > 0 ? $" -b:v {transcodeProfile.VideoBitrate_360}k" : string.Empty);
            command.Append(transcodeProfile.MaxBitrate_360 > 0 ? $" -maxrate {transcodeProfile.MaxBitrate_360}k" : string.Empty);
            command.Append(transcodeProfile.BufferSize_360 > 0 ? $" -bufsize {transcodeProfile.BufferSize_360}k" : string.Empty);
            command.Append(transcodeProfile.AudioBitrate_360 > 0 ? $" -b:a {transcodeProfile.AudioBitrate_360}k" : string.Empty);
            command.Append(" -hls_segment_filename OUTPUT_SRC_360");

            return command.ToString();
        }

        public static string CombineSources(string command, string input, string output, string listTime, string listType)
        {
            command = command.Replace("INPUT_SRC", input);
            command = command.Replace("LIST_TIME", listTime);
            command = command.Replace("LIST_TYPE", listType);
            command = command.Replace("OUTPUT_SRC_1080", $"{output}/1080p/1080p_%d.ts {output}/1080p/1080p.m3u8");
            command = command.Replace("OUTPUT_SRC_720", $"{output}/720p/720p_%d.ts {output}/720p/720p.m3u8");
            command = command.Replace("OUTPUT_SRC_480", $"{output}/480p/480p_%d.ts {output}/480p/480p.m3u8");
            command = command.Replace("OUTPUT_SRC_360", $"{output}/360p/360p_%d.ts {output}/360p/360p.m3u8");
            return command;
        }
    }
}
