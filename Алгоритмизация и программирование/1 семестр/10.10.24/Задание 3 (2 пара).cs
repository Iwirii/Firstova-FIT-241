//Дан массив из n положительных целых элементов и для заданного массива сформировать выходной массив, в который необходимо сначала положить все четные элементы, а потом нечетные
using System;
class Test
{
    static void Main()
    {
        Console.WriteLine("Введите кол-во элементов в массиве:");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] enter = new int[n];
        int[] exit = new int[n];
        int index=0;
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Введите число:");
            enter[i] = Convert.ToInt32(Console.ReadLine());
        }
        for (int i = 0; i < n; i++)
        {
            if (enter[i] % 2 == 0)
            {
                exit[index] = enter[i];
                index++;
            }
        }
        for (int i = 0; i < n; i++)
        {
            if (enter[i] % 2 != 0)
            {
                exit[index] = enter[i];
                index++;
            }
        }
            Console.WriteLine("Массив:");
        for (int k = 0; k < n; k++)
        {
            Console.Write(exit[k] + " ");
        }
    }
}
