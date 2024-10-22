//Определить макс сумму подпоследовательности, состоящей из четных элементов
using System;
public class Test
{
    public static void Main()
    {
        int a,currsum=0, maxsum=0,cnt=1, ch=0;
        Console.WriteLine("Введите кол-во чисел:");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите первое число:");
        a = Convert.ToInt32(Console.ReadLine());
        bool flag = false;
        while (cnt < n)
        {
            if (Math.Abs(a) % 2 == 0)
            {
                ch = a;
                flag= true;
                break;
            }
            Console.WriteLine("Введите следующее число:");
            a = Convert.ToInt32(Console.ReadLine());
            cnt += 1;
        }
        if (flag == false)
        {
            Console.WriteLine("Чётных чисел нет");
        }
        else
        {
            while (cnt < n)
            {
                if (Math.Abs(ch) % 2 == 0)
                {
                    maxsum += ch;
                }
                else
                {
                    break;
                }
                cnt += 1;
                Console.WriteLine("Введите следующее число:");
                ch = Convert.ToInt32(Console.ReadLine());
                if (cnt == n)
                {
                    if (Math.Abs(ch) % 2 == 0)
                    {
                        maxsum += ch;
                    }
                }
            }
            currsum = maxsum;
            while (cnt < n)
            {
                if (Math.Abs(ch) % 2 == 0)
                {
                    currsum += ch;
                }
                else
                {
                    maxsum = Math.Max(currsum, maxsum);
                    currsum = 0;
                }
                Console.WriteLine("Введите следующее число:");
                ch = Convert.ToInt32(Console.ReadLine());
                cnt += 1;
                if (cnt == n)
                {
                    if (Math.Abs(ch) % 2 == 0)
                    {
                        currsum += ch;
                    }
                }
            }
            maxsum = Math.Max(currsum, maxsum);
            Console.WriteLine(maxsum);
        }
    }
}
