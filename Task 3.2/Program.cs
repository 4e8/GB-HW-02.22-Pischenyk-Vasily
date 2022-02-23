/*3. *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать программу, демонстрирующую все разработанные элементы класса.
Добавить свойства типа int для доступа к числителю и знаменателю;
Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа; ** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0"); *** Добавить упрощение дробей.

Пищенюк Василий*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLSUI;
using CLSfraction;



namespace Lesson3
{
    internal class Program
    {

        static void Task03_1()
        {
            string userInput = "0";
            string [] array = new string [1];
            int sum = 0; 
            int j = 0;
            int i;
            Console.WriteLine("Введите поочередно числа:");
            //ну мне ООЧЕНЬ хотелось сделать именно так
            do
            {
                array[j] = userInput = Console.ReadLine();
                string [] array_temp = new string [array.Length + 1];
                for (i = 0; i < array.Length; i++) array_temp[i] = array[i];
                array = array_temp;
                j++;
            }
            while (userInput != "0");
            Console.Write("Введенные нечетные положительные числа: ");
            foreach (string element in array)
            {
                int num;
                //мне все равно кажется tryparse в этом задании притянутым за уши, но результатом доволен
                if (Int32.TryParse(element, out num) && num > 0 && (num % 2 != 0))
                {
                    Console.Write($"{num} ");
                    sum += num;
                }
            }
            Console.Write("Сумма нечетных положительных чисел:");
            Console.WriteLine(sum);
        }

        static void Main(string[] args)
        {
            UI.ConsoleLoad();
            Console.WriteLine("Введите номер задания от 3 до 4");

            string menu;

            do
            {
                menu = Console.ReadLine();
                switch (menu)
                {
                    case "3":
                        Task03_1();
                        break;
                    case "4":
                        Fraction a = new Fraction(2, 10);
                        Fraction b = new Fraction(6, 9);
                        Console.WriteLine($"({a.ToString()}) + ({b.ToString()}) = {a.Plus(b).Simplify().ToString()}");
                        Console.WriteLine($"({a.ToString()}) - ({b.ToString()}) = {a.Multi(b).Simplify().ToString()}");
                        Console.WriteLine($"({a.ToString()}) * ({b.ToString()}) = {a.Minus(b).Simplify().ToString()}");
                        Console.WriteLine($"({a.ToString()}) / ({b.ToString()}) = {a.Divide(b).Simplify().ToString()}");
                        Console.WriteLine($"{b.ToString()} = {b.ToDouble():F2}");
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
