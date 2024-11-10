//Дана строка, необходимо отформатировать строку таким образом, чтобы между словами было ровно по одному пробелу.
using System;
class Test
{
    static void Main()
    {
        Console.WriteLine("Введите строку:");
        string stroka = Console.ReadLine();
        string ee = string.Join(" ",stroka.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        Console.WriteLine("Отформатированная строка:");
        Console.WriteLine(ee);
    }
}
