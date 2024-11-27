//На вход подается набор строк, признак окончания ввода строк пустая строка(строки состоят из английских букв, регистр неважен).
//Определить максимальную длину подстроки в каждой строке, состоящей из сочетания abc, при этом необязательно присутствуют все три символа (abcabcabc = 9 символов, abca = 4 символа). Важен порядок, но не важно количество (между подстроками любые символы)
using System;
class Program
{
    static void Main()
    {
        string stroka;
        while (true)
        {
            Console.WriteLine("Введите строку:");
            stroka = Console.ReadLine();
            if (stroka == "")
            {
                break; 
            }
            int maxLength = 0; 
            int currentLength = 0; 
            char[] alph = { 'a', 'b', 'c' }; 
            int alphIndex = 0; 
            for (int i = 0; i < stroka.Length; i++)
            {
                char ch = char.ToLower(stroka[i]); 

                if (ch == alph[alphIndex])
                {
                    currentLength++;
                    alphIndex++; 
                    if (alphIndex == alph.Length)
                    {
                        alphIndex = 0; 
                    }
                }
                else
                {
                    maxLength = Math.Max(maxLength, currentLength); 
                    currentLength = 0;
                    alphIndex = 0; 
                }
            }
            maxLength = Math.Max(maxLength, currentLength);
            Console.WriteLine(maxLength);
        }
    }
}
