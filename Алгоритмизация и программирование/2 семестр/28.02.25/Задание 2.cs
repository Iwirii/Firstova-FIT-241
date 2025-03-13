//На вход подается список числовых значений. 
//Необходимо с помощью множества определить элементы, из которых состоит список. 
//Необходимо выдать частоту появления каждого элемента(с использованием Dictionary)
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите числа через пробел: ");
        string input = Console.ReadLine();

        string[] string_numbers = input.Split(' ');
        List<int> numbers = new List<int>();

        for (int i = 0; i < string_numbers.Length; i++)
        {
            if (int.TryParse(string_numbers[i], out int number))
            {
                numbers.Add(number);
            }
        }

        HashSet<int> unique = new HashSet<int>(numbers);
        Dictionary<int, int> dict = new Dictionary<int, int>();
        foreach (int number in unique)
        {
            int count = 0;
            foreach (int n in numbers)
            {
                if (n == number)
                {
                    count++;
                }
            }
            dict[number] = count;
        }

        foreach (var pair in dict)
        {
            Console.WriteLine($"Элемент {pair.Key} появляется {pair.Value} раз(а).");
        }
    }
}
