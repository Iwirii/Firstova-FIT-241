//Дан массив из n положительных целых элементов и для заданного массива заменить все чётные элементы на 0, нечетные на 1
using System;
class Test
{
    static void Main()
    {
        Console.WriteLine("Введите кол-во элементов в массиве:");
        int n = Convert.ToInt32(Console.ReadLine());
        int cnt = 0;
        int[] chet = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Введите число:");
            chet[i] = Convert.ToInt32(Console.ReadLine());
            if (chet[i] % 2 == 0)
            {
                chet[i] = 0;
            }
            else
            {
                chet[i] = 1;
            }
        }
        Console.WriteLine("Массив:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(chet[i] + "");
        }
    }
}
