/*
4. Написать программу обмена значениями двух переменных типа int без использования вспомогательных методов.
а) с использованием третьей переменной;
б) *без использования третьей переменной.
Пищенюк Василий*/

int x = 3;
int y = 4;
int z;

Console.WriteLine($"{x},{y}\n");
z = x;
x = y;
y = z;
Console.WriteLine($"{x},{y}\n");

// x, y = y, x; //а, ну да, ну да...
x = x + y;
y = x - y;
x = x - y;
Console.WriteLine($"{x},{y}");
