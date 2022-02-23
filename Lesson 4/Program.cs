/*1. Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно. Заполнить случайными числами. Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3. В данной задаче под парой подразумевается два подряд идущих элемента массива.
Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.

2. Реализуйте задачу 1 в виде статического класса StaticClass;
а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
б) Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;
в)*Добавьте обработку ситуации отсутствия файла на диске.

3.
а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом. Создать свойство Sum, которое возвращает сумму элементов массива, метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива (старый массив, остается без изменений), метод Multi, умножающий каждый элемент массива на определённое число, свойство MaxCount, возвращающее количество максимальных элементов.
б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки
в) *** Подсчитать частоту вхождения каждого элемента в массив (коллекция Dictionary<int,int>)

4. Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив. Создайте структуру Account, содержащую Login и Password.
5.
а) Реализовать библиотеку с классом для работы с двумерным массивом. Реализовать конструктор, заполняющий массив случайными числами. Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство, возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out).
*б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
**в) Обработать возможные исключительные ситуации при работе с файлами.


Пищенюк Василий*/

using CLSUI;
using MyLib;


namespace Lesson_4
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            UI.ConsoleLoad();
            

            string menu;

            do
            {
                Console.WriteLine("Введите номер задания от 1 до 5");
                menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        MyArray array20 = new MyArray("r", 20, -10000, 10000);

                        StaticClass.Task01(array20.ToArray);
                        break;
                    case "2":
                        Console.WriteLine(StaticClass.ToString(StaticClass.ReadIntTXT("..\\..\\..\\..\\TextFile1.txt")));
                        //Console.WriteLine(StaticClass.ToString(StaticClass.ReadTXT("..\\..\\..\\TextFile1.txt"))); // демонстрация ексепта
                        
                        break;
                    case "3":
                        
                        MyArray arrStep = new MyArray("s", 10, 1, 3);
                        Console.WriteLine(arrStep.ToString());
                        Console.WriteLine(arrStep.Sum.ToString());
                        Console.WriteLine(arrStep.Inverse().ToString());
                        Console.WriteLine(arrStep.ToString());
                        Console.WriteLine(arrStep.Multi(2).ToString());
                        
                        Console.WriteLine(arrStep.MaxCount.ToString());
                        MyArray array10 = new MyArray("r", 20, 1, 5);
                        StaticClass.PrintDictionary(array10.Task03()); //upd: ПОНЯЛ как выводить словари, горжусь собой :D
                        break;
                    case "4":
                        Account admin = new Account();
                        if (admin.LogIn()) Console.WriteLine("Welcome!");
                        else Console.WriteLine("Access denied");
                        if (admin.LogInAlternate()) Console.WriteLine("Welcome!");
                        else Console.WriteLine("Access denied");
                        break;
                    case "5":
                        Array2d a2 = new Array2d(5, 3);
                        a2.FillRandom(1, 10);
                        Console.WriteLine(a2.Sum());
                        Console.WriteLine(a2.SumAbove(5));
                        Console.WriteLine(a2.Min);
                        Console.WriteLine(a2.Max);
                        //Array2d txt = new Array2d("..\\..\\..\\..\\2d.txt");
                        
                        break;
                    case "51":
                        Array2d a3 = new Array2d(50, 3);
                        a3.FillRandom(1, 5);
                        a3.WriteToFile("..\\..\\..\\..\\2d.txt");
                        Array2d txt = new Array2d("..\\..\\..\\..\\2d.txt");
                        break;
                    case "6":
                        //создание файла для задания с ЕГЭ
                        string file1 = "..\\..\\..\\..\\Names.txt";
                        string file2 = "..\\..\\..\\..\\2d.txt";
                        string _f1 = File.ReadAllText(file1);
                        string[] f1 = _f1.Split(new char[] {'\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        string _f2 = File.ReadAllText(file2);
                        string[] f2 = _f2.Split("\n");
                        StreamWriter sw = new StreamWriter("..\\..\\..\\..\\EGEdata.txt");
                        for (int i = 0; i < f1.Length; i++)
                            sw.WriteLine($"{f1[i]} {f2[i]}");
                        sw.Close();
                        break;
                    case "0":
                        Console.WriteLine("дапабачення"); ;
                        break;
                    default:
                        Console.WriteLine("InputError");
                        break;


                }
            }
            while(menu != "0");

            
            
        }
    }
    
}
