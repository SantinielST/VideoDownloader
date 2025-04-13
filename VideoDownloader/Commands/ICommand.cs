namespace VideoDownloader.Commands;

internal interface ICommand
{
    void Execute();
    void Undo();
}
