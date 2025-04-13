using YoutubeExplode;
using YoutubeExplode.Videos;

namespace VideoDownloader;

internal class VideoFinder
{
    private YoutubeClient youtubeClient = new();

    public async Task<Video> GetVideo()
    {
        var video = await youtubeClient.Videos.GetAsync(Program.Url);
        
        return video;
    }
}
