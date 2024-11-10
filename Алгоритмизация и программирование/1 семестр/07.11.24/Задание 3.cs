//Определить, является ли вся строка палиндромом 
using System;
class Test
{
    static void Main()
    {
        Console.WriteLine("Введите строку:");
        string stroka = Console.ReadLine();
        string stroka1 = string.Join("", stroka.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        string reversestroka1 = new string(stroka1.Reverse().ToArray());
        if (reversestroka1 == stroka1)
        {
            Console.WriteLine("Данная строка - палиндром");
        }
        if (reversestroka1 != stroka1)
        {
            Console.WriteLine("Данная строка - не палиндром");
        }
    }
}
