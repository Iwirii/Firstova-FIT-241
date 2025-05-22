using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите размер минного поля N*M");
        string[] sizes = Console.ReadLine().Split();
        int N = int.Parse(sizes[0]);
        int M = int.Parse(sizes[1]);

        int[,] field = new int[N, M];
        for (int i = 0; i < N; i++)
        {
            Console.Write($"Введите {M} мин для {i + 1} ряда: ");
            string[] row = Console.ReadLine().Split();
            for (int j = 0; j < M; j++)
                field[i, j] = int.Parse(row[j]);
        }

        int[,] minMines = new int[N, M];
        int[,] prev = new int[N, M];

        for (int j = 0; j < M; j++)
        {
            minMines[0, j] = field[0, j];
            prev[0, j] = -1; 
        }

        for (int i = 1; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                int minPrev = minMines[i - 1, j];
                int minIndex = j;

                if (j > 0 && minMines[i - 1, j - 1] < minPrev)
                {
                    minPrev = minMines[i - 1, j - 1];
                    minIndex = j - 1;
                }
                if (j < M - 1 && minMines[i - 1, j + 1] < minPrev)
                {
                    minPrev = minMines[i - 1, j + 1];
                    minIndex = j + 1;
                }

                minMines[i, j] = field[i, j] + minPrev;
                prev[i, j] = minIndex;
            }
        }

        int minTotal = minMines[N - 1, 0];
        int minCol = 0;
        for (int j = 1; j < M; j++)
        {
            if (minMines[N - 1, j] < minTotal)
            {
                minTotal = minMines[N - 1, j];
                minCol = j;
            }
        }

        int[] path = new int[N];
        int col = minCol;
        for (int i = N - 1; i >= 0; i--)
        {
            path[i] = col + 1; 
            col = prev[i, col];
        }

        for (int i = 0; i < N; i++)
            Console.WriteLine(path[i]);
    }
}
