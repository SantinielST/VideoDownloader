using VideoDownloader.Services;

namespace VideoDownloader.Commands;

/// <summary>
/// команда для поиска информации о видео
/// </summary>
internal class GetVideoInfoCommand : ICommand
{
    private Informer _informer;

    public GetVideoInfoCommand(Informer informer)
    {
        _informer = informer; // подключаем к командам
    }

    public void Execute()
    {
        _informer.GetVideoInfo();
    }

    public void Undo()
    {
       
    }
}
