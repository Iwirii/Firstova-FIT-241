using System;
class Program
{
    static void Main()
    {
        Console.Write("Введите целое число (n) - максимальное количество, которое может быть изначально у крестьянина:");
        int n = Convert.ToInt32(Console.ReadLine());
        int res = n;
        for (int k = 3; k <= n; k = 2 * k + 1)
        {
            int z = n / k;
            res += z;
        }
        Console.WriteLine(res);
    }
}
