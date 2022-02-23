using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Console
    {
        public static void Write(int value)
        {
            System.Console.WriteLine($"---{value}---");
        }
        static void Main(string[] args)
        {
            //Console.Write(123);
            //System.Console.Write(123);
            
            System.Console.WriteLine(3.4+3);
        }

    }
}
