//На вход подается набор строк, признак окончания ввода строк пустая строка(строки состоят из английских букв, регистр неважен).
//Определить кол-во строк, которых присутствует сочетание а*б, где *-любой 1 символ
using System;
class Test
{
    static void Main()
    {
        Console.WriteLine("Введите строки:");
        string s=Console.ReadLine();
        s = s.ToLower();
        int cnt = 0;
        char a = 'a';
        char b = 'b';
        while (s!="")
        {	
            for (int i=0; i < s.Length - 2; i++)
            {
                char symbol1 = s[i];
                char symbol2 = s[i + 2];
                if (symbol1 == a & symbol2 == b)
                {
                    cnt += 1;
                    break;
                }
            }
            s =Console.ReadLine();
            s = s.ToLower();
        }
        Console.WriteLine(cnt);
    }
}
