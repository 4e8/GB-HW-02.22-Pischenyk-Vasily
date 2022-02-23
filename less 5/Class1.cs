//6. * Создать класс с методами, которые могут пригодиться в вашей учебе (Print, Pause).

namespace less_5
{
    public class Class1
    {
        internal static void PrintCenter(string mess)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - mess.Length) / 2, Console.WindowHeight / 2);
            Console.WriteLine(mess);
        }
        internal static void Pause(int time = 2)
        {
            Thread.Sleep(time*1000);
        }
    }
}
