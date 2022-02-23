using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CLSUI;
using System.Text.RegularExpressions;
using System.Globalization;


namespace MyLib
{
    public class StaticClass
    {
        public static void Task01(int[] array)
        {
            int res = 0;
            for (int i = 0; i < array.Length - 1; i++) if (array[i] % 3 == 0 ^ array[i + 1] % 3 == 0) res++;
            for (int i = 0; i < array.Length; i++) Console.WriteLine($"{array[i]} => {Convert.ToDouble(array[i]) / 3:F2}"); // проверочная строка
            Console.WriteLine(res);
        }
        //и только после того как был дописан ридТХТ я обнаружил что код из методички не работает потому что в тех файлах первое число это размер массива...
        //цитируя Слепакова: "а че ** если нет? вот так вот раз, и нет?"
        public static int[] ReadIntTXT(string file)
        {
            StreamReader sr = null;
            try { sr = new StreamReader(file); }
            catch (Exception exc) { Console.WriteLine(exc.Message); }

            int[] res = new int[0];
            string line = "";
            while (line != null)
            {
                line = sr.ReadLine();
                if (line == null) break;
                res = Append(res, int.Parse(line));
            }
            sr.Close();
            return res;
        }
        public static string[] ReadTXT(string file)
        {
            StreamReader sr = null;
            try { sr = new StreamReader(file); }
            catch (Exception exc) { Console.WriteLine(exc.Message); }

            string[] res = new string[File.ReadLines(file).Count()];
            for (int i=0;i<res.Length;i++) res[i] = sr.ReadLine();

            sr.Close();
            return res;
        }
        public static int[] Append(int[] a, int x)
        {
            int[] at = new int[a.Length+1];
            for (int i = 0; i < a.Length; i++)
            {
                at[i] = a[i];
            }
            at[at.Length-1] = x;
            return at;
        }
        public static string ToString(int[] a)
        {
            string res = "";
            for (int i = 0; i < a.Length; i++) res = $"{res}{a[i]},";
            return $"[{res}\b]";
            
        }
        public static void PrintDictionary(Dictionary<int, int> d)
        {
            foreach (KeyValuePair<int, int> kvp in d)
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
        }
        public static void PrintDictionary(Dictionary<string, string> d)
        {
            foreach (KeyValuePair<string, string> kvp in d)
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
        }
        public static void PrintDictionary(Dictionary<string, int> d)
        {
            foreach (KeyValuePair<string, int> kvp in d)
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
        }



    }
    internal class MyArray
    {
        int[] a;
        //  Создание массива и заполнение его одним значением el  
        public MyArray(int n, int el)
        {
            a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = el;
        }
        public MyArray(int[] b)
        {
            this.a = b;
        }
        public MyArray(string type, int n, int x, int y)
        {
            if (type == "r")//x=min,y=max
            {
                a = new int[n];
                Random rnd = new Random();
                for (int i = 0; i < n; i++)
                    a[i] = rnd.Next(x, y+1);
            }
            if (type == "s")//x=start, y=step
            {
                a = new int[n];
                a[0] = x;
                for (int i = 1; i < n; i++)
                    a[i] = a[i - 1] + y;
            }
        }
                public void PrintDictionary(Dictionary<int, int> d)
        {
            foreach (KeyValuePair<int, int> kvp in d) 
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
        }


        public int Sum
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < a.Length; i++) sum = sum + a[i];
                return sum;
            }
        }
        public int MaxCount
        {
            get
            {
                int max = a.Max();
                int res = 0;
                for (int i = 1; i < a.Length; i++)
                    if (a[i] == max) res++;
                return res;

            }
        }
        public int[] ToArray
        {
            get { return a; }
            set { a = value; }
        }

        public int Max
        {
            get
            {
                int max = a[0];
                for (int i = 1; i < a.Length; i++)
                    if (a[i] > max) max = a[i];
                return max;
            }
        }
        public int Min
        {
            get
            {
                int min = a[0];
                for (int i = 1; i < a.Length; i++)
                    if (a[i] < min) min = a[i];
                return min;
            }
        }
        public int CountPositiv
        {
            get
            {
                int count = 0;
                for (int i = 0; i < a.Length; i++)
                    if (a[i] > 0) count++;
                return count;
            }
        }
        public override string ToString()
        {
            string s = "";
            foreach (int v in a)
                s = s + v + " ";
            return $"[{s}]";
        }
        public MyArray Inverse()
        {
            int[] inv = new int[a.Length];
            for (int i = 0; i < a.Length; i++) inv[i] = a[i] * (-1);
            return new MyArray(inv);
        }
        public MyArray Multi(int x)
        {
            for (int i = 0; i < a.Length; i++) a[i] = a[i] * (x);
            return this;
        }

        public Dictionary<int,int> Task03()
        {
            Dictionary<int, int> d = new();

            foreach (int elem in a)
            {
                int eCount = 0;
                foreach (int _elem in a)
                    if (_elem == elem) eCount++;
                try
                {
                    d.Add(elem, eCount);
                }
                catch (Exception ex) { }
                
                
            }
            //for (int i = 0; i < a.Length; i++)
            //{

            //    int eCount = 0;
            //    for (int j = 0; j < a.Length; j++)
            //        if (a[j] == a[i]) eCount++;

            //    if (d[a[i]] == null) d.Add(a[i], eCount);
                
            //}
            return d;
        }
        
    }
    internal class Array2d
    {
        int[,] a;
        int iMax, jMax;
        public int[,] array
        {
            get { return a; }
        }
        public Array2d(int a, int b)
        {
            this.a = new int[a,b];
        }
        public void FillRandom(int min,int max)
        {
            Random rnd = new Random();
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++) a[i, j] = rnd.Next(min,max+1);
            }
        }
        public int Sum()
        {
            int sum = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++) sum += a[i, j];
            }
            return sum;
        }
        //почему то при написании первой функции foreach не работал на такой массив, когда оказалось что можно решил оставить 
        public int SumAbove(int min)
        {
            int sum = 0;
            foreach (int elem in a)
                if (elem < min) sum += elem;
            return sum;
        }
        public int Min
        {
            get
            {
                int min = 0;
                foreach (int elem in a)
                    if (elem < min) min = elem;
                return min;
            }
        }
        public int Max
        {
            get
            {
                int max = a[0,0];
                foreach (int elem in a)
                    if (elem > max) max = elem;
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        if (a[i, j] > max)
                        {
                            iMax = i;
                            jMax = j;
                        }
                    }
                }
                return max;
            }
        }
        public string GetNumberOfMax(ref int iMax, ref int jMax)
        {
            int max = a[0, 0];
            iMax = 0;
            jMax = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] > max)
                    {
                        iMax = i;
                        jMax = j;
                    }
                }
            }
            return $"index of max: {iMax},{jMax}";
        }
        public Array2d(string file)
        {
            StreamReader sr = null;
            try { sr = new StreamReader(file); }
            catch (Exception exc) { Console.WriteLine(exc.Message); }
            string[] row = sr.ReadLine().Split(" ");
            int[,] res = new int[File.ReadLines(file).Count(), row.Length];
            int i = 0;
            while (i < File.ReadLines(file).Count())
            {
                for (int j = 0;j < row.Length; j++)
                {
                    try { res[i, j] = int.Parse(row[j]); }
                    catch { }
                }
                ++i;
                if (i < File.ReadLines(file).Count()) row = sr.ReadLine().Split(" ");
            }
            sr.Close();
            this.a = res;
        }
        public void WriteToFile(string file)
        {
            StreamWriter sw = new StreamWriter(file);
            for(int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    sw.Write($"{a[i, j]}");
                    if (j < a.GetLength(1) - 1) sw.Write(' ');
                }
                sw.Write("\n");
            }
            sw.Close();
        }
    }
    public struct Account
    {
        string Login;
        string Password;
        Regex regex = new Regex(@"[A-Za-z]{1}[0-9A-Za-z]{1,9}");

        char[] pattern = { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };


        public Account()
        {
            Console.WriteLine("Логин:");
            Login = UI.Input();
            if (!regex.IsMatch(Login))
            {
                Console.WriteLine("Логин не соответствует требованиям!");
                this = new Account();
            }
            else
            {
                Console.WriteLine("Пароль:");
                Password = UI.Input();
            }

            // Альтернатива без регех ↓

            //Console.WriteLine("Логин:");
            //Login = UI.Input();
            //bool validate = true;
            //for (int i = 0; i < Login.Length; i++)
            //    foreach (char c in pattern)
            //        if (Login[i].ToLower() != c || !char.IsLetter(Login[1]))
            //        {
            //            Console.WriteLine("Логин не соответствует требованиям!");
            //            validate = false;
            //            break;
            //        }
            //if (!validate) this = new Account();
            //else
            //{
            //    Console.WriteLine("Пароль:");
            //    Password = UI.Input();
            //}
        }
        public bool LogIn()
        {
            string[] arr = StaticClass.ReadTXT("..\\..\\..\\..\\Accounts.txt");
            string log, pass;
            foreach (string elem in arr)
                if (Login == elem.Remove(elem.IndexOf(" ")) && Password == elem.Substring(elem.IndexOf(" ") + 1))
                    return true;
            return false;
        }
        public bool LogInAlternate()//мне кажется так должно быть быстрее, тк мы не читаем весь файл
        {
            string log, pass;
            string file = "..\\..\\..\\..\\Accounts.txt";
            StreamReader sr = null;
            try { sr = new StreamReader(file); }
            catch (Exception exc) { Console.WriteLine(exc.Message); }
            string[] res = new string[2];

            for (int i = 0; i < File.ReadLines(file).Count(); i++)
            {
                string line = sr.ReadLine();
                res[0] = line.Remove(line.IndexOf(" "));
                res[1] = line.Substring(line.IndexOf(" ") + 1);
                if (res[0] == Login && res[1] == Password)
                {
                    sr.Close();
                    return true;
                }
            }
            sr.Close();
            return false;
        }
    }
}
