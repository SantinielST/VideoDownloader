using VideoDownloader.Commands;

namespace VideoDownloader;

/// <summary>
/// класс содержит набор каманд и активирует их взависимости от выбора пользователя
/// </summary>
internal class Sender
{
    ICommand[] commands;

    public string Url { get; set; }

    public Sender(int number)
    {
        commands = new ICommand[number];

        for (int i = 0; i < commands.Length; i++)
        {
            commands[i] = new NoCommand();
        }
    }

    public void SetCommand(int number, ICommand command)
    {
        commands[number] = command;
    }

    public void Run(int number)
    {
        commands[number].Execute();
    }
}
