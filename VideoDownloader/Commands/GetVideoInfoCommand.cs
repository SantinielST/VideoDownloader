namespace VideoDownloader.Commands;

internal class GetVideoInfoCommand : ICommand
{
    private Informer _informer;

    public GetVideoInfoCommand(Informer informer)
    {
        _informer = informer;
    }

    public void Execute()
    {
        _informer.GetVideoInfo();
    }

    public void Undo()
    {
        throw new NotImplementedException();
    }
}
