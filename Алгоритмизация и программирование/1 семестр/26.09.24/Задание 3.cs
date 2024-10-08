//Необходимо определить 2 максимума в последовательности
using System;
class Test
{
    static void Main()
    {
        int n, a, max, max2;
        Console.WriteLine("Введите количество чисел в последовательности:");
        n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите число:");
        a = Convert.ToInt32(Console.ReadLine());
        max = max2 = a;
        for (int i = 1; i < n; i++)
        {
            Console.WriteLine("Введите число:");
            a = Convert.ToInt32(Console.ReadLine());
            if (a > max)
            {
                max2 = max;
                max = a;
            }
            else
            if (a < max && a > max2)
            {
                max2 = a;
            }
            else
            if (a==max)
            {
                max2 = max;
            }
        }
        if (max == max2)
        {
            Console.WriteLine(max);
        }
        else
        {
            Console.WriteLine(max);
            Console.WriteLine(max2);
        }
    }
}
