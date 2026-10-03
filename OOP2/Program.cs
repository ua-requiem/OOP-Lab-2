using System;
using System.Globalization;

Console.OutputEncoding = System.Text.Encoding.UTF8;

double x = ReadDouble("x");
double y = ReadDouble("y");
double z = ReadDouble("z");

// Перевірка області визначення (ОДЗ)
if (x <= 0 || x + z == 0 || (y + Math.Cbrt(x - 1)) < 0)
{
    Console.WriteLine("Помилка: некоректні значення для обчислення (порушення ОДЗ).");
    return;
}

double s = Math.Log10(x) * (Math.Pow(y + Math.Cbrt(x - 1), 0.25) / (2 * Math.Abs(x + z)));
Console.WriteLine($"Результат обчислення: s = {Math.Round(s, 3):F3}");

static double ReadDouble(string name)
{
    while (true)
    {
        Console.Write($"Введіть дробове значення {name} = ");
        string input = Console.ReadLine()?.Replace(',', '.') ?? "";
        if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double val))
            return val;

        Console.WriteLine($"Помилка введення значення {name}. Будь-ласка повторіть введення ще раз!");
    }
}