using YoutubeExplode;

namespace VideoDownloader.Services
{
    /// <summary>
    /// сервис содержит метод для загрузки видео по ссылке
    /// </summary>
    internal class Downloader
    {
        private VideoFinder videoFinder = new();

        public async void DownloadVideo() // метод загрузки видео
        {
            var video = videoFinder.GetVideo(); // получаем видео

            var outputDirectory = @"D:\Repos\VideoDownloader\VideoDownloader\bin\Debug\net9.0"; // папка для сохранения

            var youtubeClient = new YoutubeClient(); // клиент для загрузки

            //await youtubeClient.Videos.DownloadAsync(Program.Url, "video.mp4"); // упрощённый вариант загрузки

            var sanitizedTitle = string.Join("_", video.Title.Split(Path.GetInvalidFileNameChars())); // будущее имя файла

            var streamManifest = await youtubeClient.Videos.Streams.GetManifestAsync(video.Id); // получаем манифест на потоки по видео
            var muxedStreams = streamManifest.GetMuxedStreams().OrderByDescending(s => s.VideoQuality).ToList(); // сортируем потоки по качеству видео со смешанными дорожками

            if (muxedStreams.Any()) // если список не пустой
            {
                var streamInfo = muxedStreams.First(); // берём лучшее качество
                using var httpClient = new HttpClient(); // запускаем клиент для соединения
                var stream = await httpClient.GetStreamAsync(streamInfo.Url); // создаём поток для скачивания
                var datetime = DateTime.Now; // текущая дата и время

                string outputFilePath = Path.Combine(outputDirectory, $"{sanitizedTitle}.{streamInfo.Container}"); // путь до скаченного файла
                using var outputStream = File.Create(outputFilePath); // поток для создания файла
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
