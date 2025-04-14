using VideoDownloader.Services;

namespace VideoDownloader.Commands;

internal class DownloderCommand : ICommand
{
    public Downloader _downloader;

    public DownloderCommand(Downloader downloader)
    {
        _downloader = downloader;
    }

    public void Execute()
    {
        _downloader.DownloadVideo();
    }

    public void Undo()
    {
       
    }
}
