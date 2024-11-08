using System;
class Test
{
    static void Main()
    {
        Console.WriteLine("Введите количество действий (n):");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите описание действия (действие и число через пробел) в формате SV, где S - тип действия(\"*\" - умножить; \"-\" - отнять; \"+\" - прибавить), а V - аргумент действия(|V| число <= 100 либо символ \"x\".)");
        string s = "";
        for (int i = 0; i < n; i++)
        {
            string a = Console.ReadLine();
            s += " " + a;
        }
        string[] otdelno = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine("Введите результат (r):");
        int r = Convert.ToInt32(Console.ReadLine());
        for (int x = -100; x <= 100; x++)
        {
            int res = x;
            for (int i = 0; i <= n + n - 1; i++)
            {
                if (otdelno[i] == "x")
                {
                    if (otdelno[i - 1] == "+")
                    {
                        res += x;
                    }
                    if (otdelno[i - 1] == "-")
                    {
                        res -= x;
                    }
                }
                if (otdelno[i] == "+" && otdelno[i+1] != "x")
                {
                    res += Convert.ToInt32(otdelno[i + 1]);
                }
                if (otdelno[i] == "-" && otdelno[i + 1] != "x")
                {
                    res -= Convert.ToInt32(otdelno[i + 1]);
                }
                if (otdelno[i] == "*" && otdelno[i + 1] != "x")
                {
                    res *= Convert.ToInt32(otdelno[i + 1]);
                }
            }
            if (res == r)
            {
                Console.WriteLine("Загаданное число:");
                Console.WriteLine(x);
            }
        }
    }
}
