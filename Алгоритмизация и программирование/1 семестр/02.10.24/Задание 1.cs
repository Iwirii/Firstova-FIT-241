//Определить максимальный размер подпоследовательности, состоящий из одинаковых элементов
using System;
public class Test
{
    public static void Main()
    {
        int a, b, cnt = 1, n, maxposled = 1;
        Console.WriteLine("Введите количество чисел в последовательности:");
        n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите 1 элемент последовательности:");
        a = Convert.ToInt32(Console.ReadLine());
        for (int kolvo = 1; kolvo < n; kolvo++)
        {
            Console.WriteLine("Введите следующий элемент последовательности:");
            b = Convert.ToInt32(Console.ReadLine());
            if (a == b)
            {
                cnt++;
                maxposled = Math.Max(cnt, maxposled);
            }
            else
            {
                cnt = 1;
            }
            a = b;
        }
        Console.WriteLine($"Максимальный размер подпоследовательности: {maxposled}");
    }
}
