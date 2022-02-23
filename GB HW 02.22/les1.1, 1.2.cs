/*
1.Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). В результате вся информация выводится в одну строчку:
а) используя склеивание;
б) используя форматированный вывод;
в) используя вывод со знаком $.

2. Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах.

 Пищенюк Василий*/ 

string name, surname, age, height, mass;

Console.WriteLine("Введите ваше имя:");
name = Console.ReadLine();
Console.WriteLine("..и фамилию:");
surname = Console.ReadLine();
Console.WriteLine("Сколько вам лет?:");
age = Console.ReadLine();
Console.WriteLine("Теперь ваш рост?:");
height = Console.ReadLine();
Console.WriteLine("..и вес:");
mass = Console.ReadLine();

Console.WriteLine(name + ", " + surname + ", " + age + ", " + height + ", " + mass);
Console.WriteLine("{0}, {1}, {2}, {3}, {4}", name, surname, age, height, mass);
Console.WriteLine($"{name}, {surname}, {age}, {height}, {mass}");

// Задание 2

double bmi = Convert.ToDouble(mass) / (Convert.ToDouble(height) * Convert.ToDouble(height) / 10000);
Console.WriteLine("Ваш ИМТ равен: {0:N1}",bmi);

