using System.Text;

namespace VideoDownloader
{
    internal class Informer
    {
        private VideoFinder videoFinder = new VideoFinder();

        public void GetVideoInfo()
        {
            var video = videoFinder.GetVideo().Result;

            var videoInfoTextBuilder = new StringBuilder();

            videoInfoTextBuilder.Append($"Название: {video.Title}");
            videoInfoTextBuilder.Append($"\nПродолжительность: {video.Duration}");
            videoInfoTextBuilder.Append($"\nАвтор: {video.Author}");
            videoInfoTextBuilder.Append($"\nОписание: {video.Description}");

            Console.WriteLine(videoInfoTextBuilder);
        }
    }
}
