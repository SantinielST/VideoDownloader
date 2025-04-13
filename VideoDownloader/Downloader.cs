using YoutubeExplode;

namespace VideoDownloader
{
    internal class Downloader
    {
        private VideoFinder videoFinder = new();

        public async void DownloadVideo()
        {
            var video = videoFinder.GetVideo().Result;

            var outputDirectory = @"D:\Repos";
            var youtubeClient = new YoutubeClient();

            var sanitizedTitle = string.Join("_", video.Title.Split(Path.GetInvalidFileNameChars()));

            var streamManifest = await youtubeClient.Videos.Streams.GetManifestAsync(video.Id);
            var muxedStreams = streamManifest.GetMuxedStreams().OrderByDescending(s => s.VideoQuality).ToList();

            if (muxedStreams.Any())
            {
                var streamInfo = muxedStreams.First();
                using var httpClient = new HttpClient();
                var stream = await httpClient.GetStreamAsync(streamInfo.Url);
                var datetime = DateTime.Now;

                string outputFilePath = Path.Combine(outputDirectory, $"{sanitizedTitle}.{streamInfo.Container}");
                using var outputStream = File.Create(outputFilePath);
                await stream.CopyToAsync(outputStream);

                Console.WriteLine("Загрузка закончена!");
                Console.WriteLine($"Видео сохранено: {outputFilePath}{datetime}");
            }
            else
            {
                Console.WriteLine($"Не найден подходящий видеопоток для {video.Title}.");
            }
        }
    }
}
