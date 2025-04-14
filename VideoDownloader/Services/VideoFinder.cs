using VideoDownloader.Exceptions;
using YoutubeExplode;
using YoutubeExplode.Videos;

namespace VideoDownloader.Services;

/// <summary>
/// сервис для поиска видео
/// </summary>
internal class VideoFinder
{
    private YoutubeClient youtubeClient = new();
    private ErrorDataException error = new ErrorDataException("Ссылки не существует!");

    public Video GetVideo()
    {
        return CheckUrl().Result;
    }

    private async Task<Video> CheckUrl()
    {
        try
        {
            return await youtubeClient.Videos.GetAsync(Program.Url);
        }
        catch (Exception)
        {
            Console.WriteLine($"{error.Message}\nПопробуйте ещё:");
            Program.Url = Console.ReadLine();
            return GetVideo();
        }
    }
}
