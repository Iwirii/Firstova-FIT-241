//Дан массив из n положительных целых элементов и для заданного массива определить кол-во элементов все цифры которых чётные
using System;
class Test
{
    static void Main()
    {
        Console.WriteLine("Введите кол-во элементов в массиве:");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] enter = new int[n];
        int cnt = 0;
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Введите число:");
            enter[i] = Convert.ToInt32(Console.ReadLine());
        }
        for (int j = 0; j<n;j++)
        {
            int a = enter[j];
            bool flag = true;
            while (a > 0)
            {
                if (((a%10) % 2) != 0)
                {
                    flag = false;
                    break;
                }
                a /= 10;
            }
            if (flag == true)
            {
                cnt++;
            }
        }
        Console.WriteLine(cnt);
    }
}
