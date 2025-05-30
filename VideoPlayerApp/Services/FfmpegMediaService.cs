using System;
using System.IO;
using System.Threading.Tasks;
using Xabe.FFmpeg;

namespace VideoPlayerApp.Services
{
    public class FfmpegMediaService : IMediaService
    {
        public async Task<IMediaInfo> GetMediaInfoAsync(string filePath)
        {
            return await FFmpeg.GetMediaInfo(filePath);
        }

        public async Task<string> ExportFrameAsync(string filePath, TimeSpan time)
        {
            var fileName = Path.GetFileNameWithoutExtension(filePath);
            var output   = Path.Combine(
                Path.GetDirectoryName(filePath)!,
                $"{fileName}_{(int)time.TotalSeconds}.png");

            await FFmpeg.Conversions.New()
                .AddParameter($"-ss {time.TotalSeconds}")
                .AddParameter($"-i \"{filePath}\" -frames:v 1 \"{output}\"")
                .Start();

            return output;
        }
    }
}