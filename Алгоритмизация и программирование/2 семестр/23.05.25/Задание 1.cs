//На вход подается текст, состоящий из нескольких строк. 
//Количество строк (спрашиваете сколько строк у пользователя либо через while). 
//Создать массив размером 256. Массив будет хранить частоту появления каждого символа. 
//На основе массива выдать:
//1. Какой символ встречался реже всего(если несколько выдать все)
//2. Какой символ встречался чаще всего(если несколько выдать все)
//Выделять память стэк аллоком. Foreach использовать для движения по массиву нельзя

using System;
class Program
{
    unsafe static void Main()
    {
        Console.Write("Введите количество строк: ");
        bool parsed = int.TryParse(Console.ReadLine(), out int linesCount);
        if (!parsed || linesCount <= 0)
        {
            Console.WriteLine("Неверное количество строк.");
            return;
        }

        int* freq = stackalloc int[256];

        for (int i = 0; i < 256; i++)
        {
            freq[i] = 0;
        }

        Console.WriteLine("Введите строки:");

        for (int line = 0; line < linesCount; line++)
        {
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (c < 256) 
                {
                    freq[c]++;
                }
            }
        }

        int minFreq = int.MaxValue;
        int maxFreq = int.MinValue;

        for (int i = 0; i < 256; i++)
        {
            if (freq[i] > 0 && freq[i] < minFreq)
            {
                minFreq = freq[i];
            }
            if (freq[i] > maxFreq)
            {
                maxFreq = freq[i];
            }
        }

        Console.WriteLine("\nСимволы, встречающиеся реже всего:", minFreq);
        for (int i = 0; i < 256; i++)
        {
            if (freq[i] == minFreq)
            {
                Console.WriteLine((char)i);
            }
        }

        Console.WriteLine("\nСимволы, встречающиеся чаще всего:", maxFreq);
        for (int i = 0; i < 256; i++)
        {
            if (freq[i] == maxFreq)
            {
                Console.WriteLine((char)i);
            }
        }
    }
}
