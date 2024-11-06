//Дан размер массива m*n. Отсортировать столбцы массива по возрастанию сумм столбцов.

using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите количество строк массива (m):");
        int m = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите количество столбцов массива (n):");
        int n = int.Parse(Console.ReadLine());
        int[,] array = new int[m, n];
        for (int row = 0; row < m; row++)
        {
            for (int column = 0; column < n; column++)
            {
                Console.WriteLine($"Введите значение для элемента [{row},{column}]:");
                array[row, column] = int.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine("Исходный массив:");
        for (int row = 0; row < m; row++)
        {
            for (int column = 0; column < n; column++)
            {
                Console.Write(array[row, column] + " ");
            }
            Console.WriteLine();
        }
        int[] columnSums = new int[n];
        for (int column = 0; column < n; column++)
        {
            for (int row = 0; row < m; row++)
            {
                columnSums[column] += array[row, column];
            }
        }
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (columnSums[j] > columnSums[j + 1])
                {
                    int tempSum = columnSums[j];
                    columnSums[j] = columnSums[j + 1];
                    columnSums[j + 1] = tempSum;
                    for (int k = 0; k < m; k++)
                    {
                        int temp = array[k, j];
                        array[k, j] = array[k, j + 1];
                        array[k, j + 1] = temp;
                    }
                }
            }
        }
        Console.WriteLine("Отсортированный массив по возрастанию сумм столбцов:");
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
