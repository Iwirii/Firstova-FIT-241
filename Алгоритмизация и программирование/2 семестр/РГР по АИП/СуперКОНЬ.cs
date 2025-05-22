using System;
using System.Collections.Generic;

class Program
{
    struct Position
    {
        public int X;
        public int Y;
        public int Moves;
    }

    static bool IsBlack(int x, int y)
    {
        return (x + y) % 2 == 0;
    }

    static void Main()
    {
        Console.WriteLine("Введите размер доски N:");
        int N = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите координаты начальной и конечной клетки (X1 Y1 X2 Y2):");
        string[] coordinates = Console.ReadLine().Split();
        int X1 = int.Parse(coordinates[0]);
        int Y1 = int.Parse(coordinates[1]);
        int X2 = int.Parse(coordinates[2]);
        int Y2 = int.Parse(coordinates[3]);

        if (X1 == X2 && Y1 == Y2)
        {
            Console.WriteLine("0");
            return;
        }

        Queue<Position> queue = new Queue<Position>();
        queue.Enqueue(new Position { X = X1, Y = Y1, Moves = 0 });

        bool[,] visited = new bool[N + 1, N + 1];
        visited[X1, Y1] = true;

        int[] knightDx = { 2, 2, 1, 1, -1, -1, -2, -2 };
        int[] knightDy = { 1, -1, 2, -2, 2, -2, 1, -1 };

        int[] whiteDx = { 1, -1, 0, 0 };
        int[] whiteDy = { 0, 0, 1, -1 };

        while (queue.Count > 0)
        {
            Position current = queue.Dequeue();

            if (IsBlack(current.X, current.Y))
            {
                for (int i = 0; i < 8; i++)
                {
                    int newX = current.X + knightDx[i];
                    int newY = current.Y + knightDy[i];

                    if (newX >= 1 && newX <= N && newY >= 1 && newY <= N && !visited[newX, newY])
                    {
                        if (newX == X2 && newY == Y2)
                        {
                            Console.WriteLine(current.Moves + 1);
                            return;
                        }
                        visited[newX, newY] = true;
                        queue.Enqueue(new Position { X = newX, Y = newY, Moves = current.Moves + 1 });
                    }
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    int newX = current.X + whiteDx[i];
                    int newY = current.Y + whiteDy[i];

                    if (newX >= 1 && newX <= N && newY >= 1 && newY <= N && !visited[newX, newY])
                    {
                        if (newX == X2 && newY == Y2)
                        {
                            Console.WriteLine(current.Moves + 1);
                            return;
                        }
                        visited[newX, newY] = true;
                        queue.Enqueue(new Position { X = newX, Y = newY, Moves = current.Moves + 1 });
                    }
                }
            }
        }
        Console.WriteLine("NO");
    }
}
