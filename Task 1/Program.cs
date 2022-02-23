/*1. Написать метод, возвращающий минимальное из трёх чисел.
2. Написать метод подсчета количества цифр числа.
3. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
4. Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. С помощью цикла do while ограничить ввод пароля тремя попытками.
5.
а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.

6. *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. «Хорошим» называется число, которое делится на сумму своих цифр. Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
7.
a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.

Пищенюк Василий*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    internal class Program
    {

        static int Task01(int x, int y, int z)
        {
            if (x < y && x<z){
                return x;
            }
            if (y < z)
            {
                return y;
            }
            else
            {
                return z;
            }
        }
        static int Task02(int x)
        {
            return x.ToString().Length; 
        }
        static void Task03()
        {
            string userInput = "0";
            int sum = 0;
            Console.WriteLine("Введите поочередно числа:");
            do
            {

                int num = Convert.ToInt32(userInput = Console.ReadLine());
                if(num>0 & (num%2 != 0))
                {
                    sum += num;
                }
               
            }
            while (userInput != "0");
            Console.WriteLine("Сумма нечетных положительных чисел:");
            Console.WriteLine(sum);
        }
        static bool Task04()
        {
            int tries = 3;
            string login, password;

            do
            {
                Console.WriteLine("Логин:");
                login = Console.ReadLine();
                Console.WriteLine("Пароль:");
                password = Console.ReadLine();
                --tries;
                if(login == "root" & password == "GeekBrains")
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Неверно, осталось попыток: " + tries);
                }
            }
            while (tries > 0);
            return false;
        }
        static void Task05()
        {
            Console.WriteLine("Введите ваш рост(см):");
            double height = Convert.ToDouble(Console.ReadLine())/100;
            Console.WriteLine("Введите ваш вес(кг):");
            double mass = Convert.ToDouble(Console.ReadLine());
            
            double BMI = mass / (height * height);
            if (BMI < 18.5)
            {
                Console.WriteLine("Надо бы поднабрать вес!");
                double w = (height * height * 18.5) - mass;
                Console.WriteLine($"Нужно набрать еще минимум {w:N1} кг");
            }
            else if (BMI >= 25)
            {
                Console.WriteLine("Пора худеть!");
                double w = mass-(height * height * 25);
                Console.WriteLine($"Нужно скинуть еще минимум { w: N1} кг");
            }
            else
            {
                Console.WriteLine("Вы в отличной форме!");
            }

        }
        static void Task06()
        {
            DateTime start = DateTime.Now;
            int res = 0;
            for (int i = 0; i < 1000000000; ++i)
            {
                if (i % (i.ToString().Length) == 0)
                {
                    ++res;
                }

            }
            DateTime end = DateTime.Now;
            TimeSpan timeSpan = end - start;
            Console.WriteLine($"В лярде { res} «хороших» чисел, на подсчет потрачено милисекунд: {timeSpan.Milliseconds }");

        }
        static void Task07(int a, int b )
        {
            Console.WriteLine(a);
            if (a != b)
            {
                Task07(++a, b);
            }
        }
        static int Task071(int a, int b)
        {
            if (a != b)
            {
                return b-a+Task071(++a, b);
            }
           return 0;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер задания от 1 до 7 (+ 71)");

            string menu ;

            do
            {
                menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        Console.WriteLine(Task01(1, 6, 3));
                        Console.WriteLine(Task01(3, 1, 4));
                        Console.WriteLine(Task01(9, 6, 3));
                        break;
                    case "2":
                        Console.WriteLine( Task02(1234) ); 
                        Console.WriteLine( Task02(5000000) ); 
                        break;
                    case "3":
                        Task03();
                        break;
                    case "4":
                        if (Task04())
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Clear();
                            Console.WriteLine("     ___________.________                   ________.___________");
                            Console.WriteLine("     \\_________  \\______ Welcome, Commander! ______/  _________/");
                            Console.WriteLine("             *\\______   \\________/ \\________/   ______/*");
                            Console.WriteLine("                  *\\________/           \\________/*\n");
                        }
                        else
                        {
                            Console.WriteLine("Попытки кончились! БАН на, разбан - 200 рублей админу на карту: 7846 57...");
                            return;
                        }
                        break;
                    case "5":
                        Task05();
                        break;
                    case "6":
                        Task06();
                        break;
                    case "7":
                        Task07(1, 10);
                        break;
                    case "71":
                        Console.WriteLine(Task071(1, 10));
                        break;
                    case "0":
                        Console.WriteLine("дапабачення"); ;
                        break;
                    default:
                        Console.WriteLine("InputError");
                        break;
                }
            }
            while (menu != "0");
        }

    }
}
