//Дан размер массива m*n, определить номера пар строк, состоящих из одинаковых элементов.(112 211 одинаковые, 112 221 разные, сортировать элементы в строках нельзя). 
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
        int[] summa = new int[n];
        int[] proiz = new int[n];
        int[] nuli = new int[n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.WriteLine($"Введите значение для элемента [{i},{j}]:");
                enter[i, j] = int.Parse(Console.ReadLine());
            }
        }
        for (int i = 0; i < n; i++)
        {
            proiz[i] = 1;
        }
        for (int row = 0; row < n; row++)
        {
            for (int column = 0; column < m; column++)
            {
                summa[row] += enter[row, column];
                proiz[row] *= enter[row, column];
                if (enter[row,column] == 0)
                {
                    nuli[row] += 1;
                }
            }
        }
        for (int i=0; i<n; i++)
        {
            for (int j = i+1; j < n; j++)
            {
                if (summa[i] == summa[j] && proiz[i] == proiz[j] && nuli[i] == nuli[j])
                {
                    Console.WriteLine($"Строки {i + 1} и {j + 1} одинаковые");
                }
            }
        }
    }
}
