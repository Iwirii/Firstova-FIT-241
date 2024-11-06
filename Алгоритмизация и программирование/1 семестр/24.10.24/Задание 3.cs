//Дан массив m*n. Определить положение элементов минимакса (либо минимум по строке и максимум по столбцу, либо наоборот). 
using System;
class Test
{
    static void Main()
    {
        Console.WriteLine("Введите кол-во строк в массиве:");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите кол-во столбцов в массиве:");
        int m = Convert.ToInt32(Console.ReadLine());
        int[,] enter = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.WriteLine($"Введите значение для элемента [{i},{j}]:");
                enter[i, j] = int.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine("Исходный массив:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"{enter[i, j]} \t");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Положение элементов минимакса:");
        for (int i = 0; i < n; i++)
        {
            int minInRow = enter[i, 0];
            int minIndexCol = 0;
            for (int j = 1; j < m; j++)
            {
                if (enter[i, j] < minInRow)
                {
                    minInRow = enter[i, j];
                    minIndexCol = j;
                }
            }
            bool flag = true;
            for (int k = 0; k < n; k++)
            {
                if (enter[k, minIndexCol] > minInRow)
                {
                    flag = false;
                    break;
                }
            }
            if (flag == true)
            {
                Console.WriteLine($"Минимум в {i + 1} строке и максимум в {minIndexCol + 1} столбце: [{i}, {minIndexCol}]");
            }
        }
        for (int i = 0; i < n; i++)
        {
            int maxInRow = enter[i, 0];
            int maxIndexCol = 0;
            for (int j = 1; j < m; j++)
            {
                if (enter[i, j] > maxInRow)
                {
                    maxInRow = enter[i, j];
                    maxIndexCol = j;
                }
            }
            bool flag = true;
            for (int k = 0; k < n; k++)
            {
                if (enter[k, maxIndexCol] < maxInRow)
                {
                    flag = false;
                    break;
                }
            }

            if (flag == true)
            {
                Console.WriteLine($"Максимум в {i + 1} строке и минимум в {maxIndexCol + 1} столбце: [{i}, {maxIndexCol}]");
            }
        }
    }
}
