//В качестве указателя будет одномерный массив(переменная, которая указывает на адрес, по которому располагается массив)
//Ввод элементов пользователем. Определить количество элементов, выделить место под массив. В массиве посчитать количество элементов, кратные двум.
using System;
class Program
{
    unsafe static void Main()
    {
        Console.Write("Введите количество элементов массива: ");
        bool parsed = int.TryParse(Console.ReadLine(), out int n);
        if (!parsed || n <= 0)
        {
            Console.WriteLine("Неверное количество элементов");
            return;
        }

        int[] array = new int[n];

        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Элемент {i + 1}: ");
            bool elementParsed = int.TryParse(Console.ReadLine(), out int value);
            if (!elementParsed)
            {
                Console.WriteLine("Ошибка ввода");
                i--;
                continue;
            }
            array[i] = value;
        }

        int countEven = 0;
        fixed (int* ptr = array)
        {
            for (int i = 0; i < n; i++)
            {
                int current = *(ptr + i);
                if (current % 2 == 0)
                {
                    countEven++;
                }
            }
        }
        Console.WriteLine($"Количество элементов, кратных двум: {countEven}");
    }
}
