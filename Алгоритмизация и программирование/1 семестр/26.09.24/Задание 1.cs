//Дана последовательность из n элементов (длина не меньше 3-х). Определить кол-во локальных минимумов (элемент значение которого меньше, чем у соседей)

using System;
class Test
{
    static void Main()
    {
        int kolvo, a, cntlocalmin = 0, left, middle, right;
        Console.WriteLine("Введите количество чисел, из которых будет состоять последовательность:");
        kolvo = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите первое число:");
        left = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите второе число:");
        middle = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите третье число:");
        right = Convert.ToInt32(Console.ReadLine());
        while (kolvo > 3)
        {
            if (left > middle && middle < right)
            {
                cntlocalmin++;
            }
            kolvo--;
            left = middle;
            middle = right;
            Console.WriteLine("Введите следующее число:");
            right = Convert.ToInt32(Console.ReadLine());
            
        }
        if (left > middle && middle < right)
        {
            cntlocalmin++;
        }
        Console.WriteLine(cntlocalmin);
    }
}
