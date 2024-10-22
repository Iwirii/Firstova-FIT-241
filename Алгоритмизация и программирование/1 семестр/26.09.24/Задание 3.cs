//Необходимо определить 2 максимума в последовательности
using System;
class Test
{
    static void Main()
    {
        int n, a, b, c, maxi, max2;
        Console.WriteLine("Введите количество чисел в последовательности:");
        n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите число:");
        a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите число:");
        b = Convert.ToInt32(Console.ReadLine());
        if (a>b)
        {
            maxi=a;
            max2=b;
        }
        else
        {
            maxi = b;
            max2 = a;
        }
        for (int i = 2; i < n; i++)
        {
            Console.WriteLine("Введите число:");
            c = Convert.ToInt32(Console.ReadLine());
            if (c > maxi)
            {
                max2 = maxi;
                maxi = c;
            }
            else
            if (c < maxi && c > max2)
            {
                max2 = c;
            }
            else
            if (c == maxi)
            {
                max2 = maxi;
            }
        }
        if (maxi == max2)
        {
            Console.WriteLine(maxi);
        }
        else
        {
            Console.WriteLine(maxi);
            Console.WriteLine(max2);
        }
    }
}
