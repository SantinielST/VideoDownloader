using VideoDownloader.Commands;

namespace VideoDownloader.Services;

internal class Program
{
    public static string Url { get; set; } // статическое свойство для ссылки на видео

    static void Main(string[] args)
    {
        // приветствие
        Console.WriteLine("Программа позволяет получить информацию о видео или скачать его." +
            "\nСкопируйте ссылку на видео:");
        Url = Console.ReadLine(); // считываем ссылку

        // создадим отправителя
        var sender = new Sender(2);

        // создадим получателя
        var informer = new Informer();
        var downloader = new Downloader();

        // создадим команды
        var getVideoInfo = new GetVideoInfoCommand(informer);
        var dowloadVideo = new DownloderCommand(downloader);

        // инициализация команд
        sender.SetCommand(0, getVideoInfo);
        sender.SetCommand(1, dowloadVideo);

        // выбираем команду
        Console.WriteLine("Выберите команду (1 - получить информацию, 2 - скачать):");
        var numberCommand = int.Parse(Console.ReadLine());

        //бесконечный цикл с условием закрытия программы
        while (numberCommand != 0)
        {
            //  выполнение
            sender.Run(numberCommand - 1);
            
            Console.WriteLine();

            // запрашиваем дальнейшие действия
            Console.WriteLine("Выберите команду (1 - получить информацию, 2 - скачать, 3 - выбрать другое видео, 0 - закрыть программу):");
            numberCommand = int.Parse(Console.ReadLine());

            if (numberCommand == 3) // меняем ссылку на видео
            {
                Console.WriteLine("Скопируйте ссылку на видео:");
                Url = Console.ReadLine();

                Console.WriteLine("Выберите команду (1 - получить информацию, 2 - скачать):");  // запрашиваем дальнейшие действия
                numberCommand = int.Parse(Console.ReadLine());
            }
        }
    }
}
