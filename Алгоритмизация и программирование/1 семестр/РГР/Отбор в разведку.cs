using System;
class Program
{
    static void Main()
    {
        Console.Write("Введите количество солдат (n): ");
        int n = int.Parse(Console.ReadLine());

        int cnt = Groups(n);
        Console.WriteLine($"Количество групп по 3 человека: {cnt}");
    }
    static int Groups(int n)
    {
        if (n < 3)
        {
            return 0;
        }
        if (n == 3)
        {
            return 1;
        }
        int chet = n / 2;
        int nechet = n - chet; 
        return Groups(chet) + Groups(nechet);
    }
}
