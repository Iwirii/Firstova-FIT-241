//Дано n строк, выдать только те строки, в которых количество гласных букв больше количества согласных букв (ъ и ь – согласные).
using System;
class Test
{
    static void Main()
    {
        Console.WriteLine("Укажите количество строк (n):");
        int n = Convert.ToInt32(Console.ReadLine());
        string glasnie = "ауоиэыяюеёАУОИЭЫЯЮЕЁ";
        string otvet = "";
        Console.WriteLine("Введите строки:");
        for (int i = 0; i < n; i++)
        {
            string stroka = Console.ReadLine();
            int gl = 0;
            int sgl = 0;
            for (int j = 0; j < stroka.Length; j++)
            {
                char symbol = stroka[j];
                if (glasnie.IndexOf(symbol) >= 0)
                {
                    gl += 1;
                }
                else if (char.IsLetter(symbol))
                {
                    sgl += 1;
                }
            }
            if (gl > sgl)
            {
                otvet += stroka + "\n";
            }
        }
        Console.WriteLine("Строки,в которых количество гласных букв больше количества согласных:");
        Console.WriteLine(otvet);
    }
}
