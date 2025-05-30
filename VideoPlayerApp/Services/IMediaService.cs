using System;
using System.Threading.Tasks;
using Xabe.FFmpeg;

namespace VideoPlayerApp.Services
{
    public interface IMediaService
    {
        Task<IMediaInfo> GetMediaInfoAsync(string filePath);

        Task<string> ExportFrameAsync(string filePath, TimeSpan time);
    }
}