//Делаем на лямбда, для двух переменных с использованием лямбда-выражения, реализовать сложение, вычитание, умножение, деление на 0, отслеживать ошибку при делении на 0
using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите первое число:");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите второе число:");
        int b = Convert.ToInt32(Console.ReadLine());

        Func<int, int, int> add = (x, y) => x + y;
        Func<int, int, int> subtract = (x, y) => x - y;
        Func<int, int, int> multiply = (x, y) => x * y;
        Func<int, int, double> divide = (x, y) =>
        {
            if (y == 0)
            {
                throw new DivideByZeroException("Ошибка: деление на ноль!");
            }
            return (double)x / y; 
        };

        Console.WriteLine($"Сложение: {add(a, b)}");
        Console.WriteLine($"Вычитание: {subtract(a, b)}");
        Console.WriteLine($"Умножение: {multiply(a, b)}");

        try
        {
            Console.WriteLine($"Деление: {divide(a, b)}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
