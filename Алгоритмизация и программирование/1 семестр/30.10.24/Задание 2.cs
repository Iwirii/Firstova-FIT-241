//Дан ступенчатый массив размерностью 4 (4 ссылки на массивы) для каждой строки определить положение элемента значение которого больше чем сумма остальных элементов строки, если такого нет выдать сообщение указав номер строки массива
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
            bool flag = false;
            int summa = 0;
            for (int j = 0; j < matrix[i].Length; j++)
            {
                summa += matrix[i][j];
            }
            for (int k = 0;  k < matrix[i].Length; k++)
            {
                if (matrix[i][k] > summa - matrix[i][k])
                {
                    Console.WriteLine($"Элемент в {i + 1}-ой строке, значение которого больше чем сумма остальных элементов строки, стоит {k + 1}-ым по порядку");
                    flag = true;
                }
            }
            if (flag == false)
            {
                Console.WriteLine($"В {i + 1}-ой строке такого элемента нет");
            }
        }
    }
}
