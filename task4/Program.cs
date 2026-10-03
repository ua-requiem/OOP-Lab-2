using System;
using System.Globalization;

Console.OutputEncoding = System.Text.Encoding.UTF8;

double a = ReadDouble("a");
double b = ReadDouble("b");
double c = ReadDouble("c");

if (a == 0)
{
    Console.WriteLine("Коефіцієнт 'a' не може дорівнювати 0 (це не квадратне рівняння).");
    return;
}

double d = b * b - 4 * a * c;
Console.WriteLine($"Дискримінант D = {Math.Round(d, 3)}");

if (d > 0)
{
    double x1 = (-b + Math.Sqrt(d)) / (2 * a);
    double x2 = (-b - Math.Sqrt(d)) / (2 * a);
    Console.WriteLine($"Рівняння має два розв'язки:\nx1 = {Math.Round(x1, 3)}\nx2 = {Math.Round(x2, 3)}");
}
else if (d == 0)
{
    double x = -b / (2 * a);
    Console.WriteLine($"Рівняння має один розв'язок:\nx = {Math.Round(x, 3)}");
}
else
{
    Console.WriteLine("Рівняння не має дійсних розв'язків.");
}

static double ReadDouble(string name)
{
    while (true)
    {
        Console.Write($"Введіть коефіцієнт {name} = ");
        string input = Console.ReadLine()?.Replace(',', '.') ?? "";
        if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double val))
            return val;

        Console.WriteLine($"Помилка введення коефіцієнта {name}. Спробуйте ще раз!");
    }
}