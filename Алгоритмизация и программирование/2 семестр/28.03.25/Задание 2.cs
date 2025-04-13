//Имеется список, переменные типа стринг, с помощью лямбда выражения выполнить отбор только тех элементов, которые начинаются на букву м
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> list = new List<string>();

        Console.Write("Введите количество элементов: ");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введите элемент {i + 1}: ");
            list.Add(Console.ReadLine());
        }

        var filtered = list.Where(e => e.StartsWith("М", StringComparison.OrdinalIgnoreCase));

        Console.WriteLine("Элементы, начинающиеся на букву 'М':");
        foreach (var elem in filtered)
        {
            Console.WriteLine(elem);
        }
    }
}
