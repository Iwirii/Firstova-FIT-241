//Необходимо в строке, состоящей из слов, между которыми по одному пробелу, выдать все слова перевертыши (пример шабаш)
using System;
class Test
{
    static void Main()
    {
        Console.WriteLine("Введите строку:");
        string stroka = Console.ReadLine();
        string reversestroka = new string(stroka.Reverse().ToArray());
        string[] stroka1 = stroka.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string[] reversestroka1 = reversestroka.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < stroka1.Length; i++)
        {
            for (int j = reversestroka1.Length; j > 0; j--)
            {
                if (stroka1[i] == reversestroka1[j-1])
                {
                    Console.WriteLine(stroka1[i]);
                }
            }
        }
    }
}
