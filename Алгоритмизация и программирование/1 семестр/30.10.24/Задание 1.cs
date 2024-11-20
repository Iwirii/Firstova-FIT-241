//Дан ступенчатый массив размерностью 4 (4 ссылки на массивы) задать размерность и элементы каждого массива для каждого массива определить количество четных и нечетных элементов
using System;
class Test
{
    static void Main()
    {
        int[][] matrix = new int[4][];
        for (int i = 0; i < matrix.Length; i++)
        {
            Console.WriteLine($"Введите число элементов для {i + 1}-го подмассива:");
            int n = Convert.ToInt32(Console.ReadLine());
            matrix[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                Console.WriteLine($"Введите элемент {j + 1} для массива {i + 1}:");
                matrix[i][j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        for (int i = 0; i < matrix.Length; i++)
        {
            int chet = 0;
            int nechet = 0;

            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] % 2 == 0)
                {
                    chet++;
                }
                else
                {
                    nechet++;
                }
            }
            Console.WriteLine($"В массиве {i + 1}: Четных элементов - {chet}, Нечетных элементов - {nechet}");
        }
    }
}
