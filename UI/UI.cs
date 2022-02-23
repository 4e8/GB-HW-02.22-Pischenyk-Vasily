using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLSUI
{
    public class UI
    {
        static void Main(string[] args)
        {
            ConsoleLoad();
        }
        public static void ConsoleLoad()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.WriteLine("     ___________.________                   ________.___________");
            Console.WriteLine("     \\_________  \\______ Welcome, Commander! ______/  _________/");
            Console.WriteLine("             *\\______   \\________/ \\________/   ______/*");
            Console.WriteLine("                  *\\________/           \\________/*\n");

        }
        public static string Input()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            return input;
        }
    }
}
