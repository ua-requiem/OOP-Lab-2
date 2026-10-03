using System;
using System.Globalization;

Console.OutputEncoding = System.Text.Encoding.UTF8;

int k = ReadInt("k (>= 1)");
int n = ReadInt("n (>= 1)");

Console.WriteLine("\nОберіть варіант обчислення суми:");
Console.WriteLine("1: 1^n + 2^(n/2) + ... + k^(n/k)");
Console.WriteLine("2: 1^k + 2^k + ... + n^k");
Console.WriteLine("3: 1/n + 2/n^2 + ... + k/n^k");
Console.Write("Оберіть пункт (1-3): ");
string choice = Console.ReadLine() ?? "";

double sum = 0;

switch (choice)
{
    case "1":
        for (int i = 1; i <= k; i++)
        {
            sum += Math.Pow(i, (double)n / i);
        }
        Console.WriteLine($"Результат: {Math.Round(sum, 4)}");
        break;

    case "2":
        for (int i = 1; i <= n; i++)
        {
            sum += Math.Pow(i, k);
        }
        Console.WriteLine($"Результат: {Math.Round(sum, 4)}");
        break;

    case "3":
        for (int i = 1; i <= k; i++)
        {
            sum += i / Math.Pow(n, i);
        }
        Console.WriteLine($"Результат: {Math.Round(sum, 4)}");
        break;

    default:
        Console.WriteLine("Некоректний вибір пункту меню!");
        break;
}

static int ReadInt(string name)
{
    while (true)
    {
        Console.Write($"Введіть ціле число {name} = ");
        if (int.TryParse(Console.ReadLine(), out int val) && val >= 1)
            return val;

        Console.WriteLine("Помилка введення! Число має бути цілим і більшим або рівним 1.");
    }
}