using System.Text;
using VideoDownloader.Exceptions;
using YoutubeExplode.Videos;

namespace VideoDownloader.Services
{
    /// <summary>
    /// сервис для вывода информации о видео
    /// </summary>
    internal class Informer
    {
        private VideoFinder videoFinder = new VideoFinder();
        private Video video;

        public void GetVideoInfo()
        {
            video = videoFinder.GetVideo();

            var videoInfoTextBuilder = new StringBuilder();

            videoInfoTextBuilder.Append($"Название: {video.Title}");
            videoInfoTextBuilder.Append($"\nПродолжительность: {video.Duration}");
            videoInfoTextBuilder.Append($"\nАвтор: {video.Author}");
            videoInfoTextBuilder.Append($"\nОписание: {video.Description}");

            Console.WriteLine(videoInfoTextBuilder);
        }
    }
}
