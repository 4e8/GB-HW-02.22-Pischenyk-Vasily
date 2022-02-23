/*1. Создать программу, которая будет проверять корректность ввода логина. Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
а) без использования регулярных выражений;
б) **с использованием регулярных выражений.

2. Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
а) Вывести только те слова сообщения, которые содержат не более n букв.
б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
в) Найти самое длинное слово сообщения.
г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
д) ***Создать метод, который производит частотный анализ текста. В качестве параметра в него передается массив слов и текст, в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст. Здесь требуется использовать класс Dictionary.

3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
Например: badc являются перестановкой abcd.

4. *Задача ЕГЭ.
На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы. В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, каждая из следующих N строк имеет следующий формат:

<Фамилия> <Имя> <оценки>,
где <Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом. Пример входной строки:

Иванов Петр 4 5 3
Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.


Пищенюк Василий*/




using CLSUI;
using Lesson_4;
using MyLib;
using System.Text;

namespace Lesson_5
{
    static class Message
    {
        static string text = File.ReadAllText("..\\..\\..\\..\\Essay.txt");
        static string[] ss = text.Split(new char[] { ' ', ',', '.', '!', '?', '-', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        public static string Text
        {
            get { return text; }
        }
        public static string[] Array
        {
            get { return ss; }
        }
        public static void Reload()
        {
            text = File.ReadAllText("..\\..\\..\\..\\Essay.txt");
            ss = text.Split(new char[] { ' ', ',', '.', '!', '?', '-', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        }
        public static void WriteWordsLongerThan(int n)
        {
            foreach (string s in ss)
                if (s.Length > n) Console.Write(s + ' ');
        }
        public static void DeleteWordsEndWith(char lett)
        {
            StringBuilder sb = new StringBuilder(ss.Length);
            foreach (string s in ss)
                if (s[s.Length - 1] != lett) sb.Append(s + ' ');
            text = sb.ToString();
            ss = text.Split(new char[] { ' ', ',', '.', '!', '?', '-', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("\n");
        }
        public static string FoundLongest()
        {
            int max = 0;
            string res = "";
            foreach (string s in ss)
                if (s.Length > max)
                {
                    res = s;
                    max = s.Length;
                }
            return res;
        }
        public static string LongestWords()
        {
            int longest = FoundLongest().Length;
            StringBuilder sbl = new StringBuilder(ss.Length);
            foreach (string s in ss)
                if (s.Length == longest) sbl.Append(s + ' ');
            return sbl.ToString();
        }
        public static Dictionary<string, int> FrequencyAnalysis(string[] words, string targetText)
        {
            Dictionary<string, int> d = new();
            foreach (string word in words)
            {
                int wCount = 0;
                foreach (string _word in words)
                    if (word == _word) wCount++;
                try
                {
                    d.Add(word, wCount);
                }
                catch (Exception ex) { }
            }
            return d;
        }
        public static bool IsRearrangement(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;

            int[] f = new int[100];
            char a = 'a';
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] >= 'a' && s1[i] <= 'z') f[s1[i] - a]++;
                if (s2[i] >= 'a' && s2[i] <= 'z') f[s2[i] - a]--;
            }
            for (int i = 0; i < f.Length; i++)
                if (f[i] != 0) return false;
            return true;
            //for (int i = 0;i < f.Length; i++)
            //    if (f[i] != 0)
            //        Console.WriteLine($"{(char)(i+'a')} - {f[i]}");
        }
    }
    internal class EGEGE
    {
        public EGEGE(string file)
        {
            StreamReader sr = null;
            try { sr = new StreamReader(file); }
            catch (Exception exc) { Console.WriteLine(exc.Message); }
            string[] row = new string[5];
            int pplCount = File.ReadLines(file).Count();
            string[] dataName = new string[pplCount];
            double[] dataMed = new double[pplCount];

            double z;
            for (int i = 0; i < pplCount; i++)
            {
                row = sr.ReadLine().Split(" ");
                dataName[i] = $"{row[0]} {row[1]}";
                dataMed[i] = (double.Parse(row[2]) + double.Parse(row[3]) + double.Parse(row[4])) / 3;    
            }
            Array.Sort(dataMed, dataName);
            for (int i = 0; i < 3; i++)
                Console.WriteLine($"{dataName[i]} - {dataMed[i]:F2}");
            for (int i = 3; i < pplCount - 3; i++)
                if (dataMed[i] <= dataMed[i - 1])
                    Console.WriteLine($"{dataName[i]} - {dataMed[i]:F2}");
                else break;
            //Dictionary<int,int> d = new Dictionary<int, int>();

            /////////////////////
            sr.Close();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            UI.ConsoleLoad();

            string menu;

            do
            {
                Console.WriteLine("Введите номер задания от 1 до 4");
                menu = UI.Input();
                switch (menu)
                {
                    case "1":
                        //дописана структура Account с прошлого урока
                        Account admin = new Account();
                        if (admin.LogIn()) Console.WriteLine("Welcome!");
                        else Console.WriteLine("Access denied");
                        if (admin.LogInAlternate()) Console.WriteLine("Welcome!");
                        else Console.WriteLine("Access denied");
                        break;
                    case "2":
                        Message.Reload();
                        Message.WriteWordsLongerThan(8);
                        Message.DeleteWordsEndWith('o');
                        Console.WriteLine(Message.Text);
                        Console.WriteLine(Message.FoundLongest());
                        Console.WriteLine(Message.LongestWords());
                        StaticClass.PrintDictionary(Message.FrequencyAnalysis(Message.Array, Message.Text));
                        break;
                    case "3":
                        Console.WriteLine(Message.IsRearrangement("qwerty", "qwertyy"));
                        Console.WriteLine(Message.IsRearrangement("qwerty", "ytrewq"));
                        Console.WriteLine(Message.IsRearrangement("qwerty", "asdfgh"));
                        break;
                    case "4":
                        EGEGE e = new EGEGE("..\\..\\..\\..\\EGEdata.txt");
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




