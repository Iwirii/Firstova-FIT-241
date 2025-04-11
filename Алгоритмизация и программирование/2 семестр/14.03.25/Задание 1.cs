//Класс с двумя переменными целого типа и будут реализованы следующие методы: 
//сложение, разность первого и второго элемента, умножение, целочисленное деление первого на второй элемент(проверка на 0 обязательна). 
//Описан делегат(тип и сигнатура на свое усмотрение). Необходимо создать 2 объекта заданного класса, будет  2 экземпляра делегата. 
//Первый работает с первым объектом и включает группу операторов
//(суммирование, результат суммирования, умноженный на второй элемент, деление результата, который был получен на предыдущем шаге на второй элемент). 
//Второй работает со вторым объектом, реализует операции
//(деление первого на второй, вычитание из результата деления второго элемента, умножение, полученного результата на второй элемент).
using System;
class MathOperations
{
    public int X;
    public int Y;

    public MathOperations(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int Add() => X + Y;
    public int Subtract() => X - Y;
    public int Multiply() => X * Y;
    public int Divide()
    {
        if (Y == 0)
        {
            throw new DivideByZeroException("Деление на ноль невозможно.");
        }
        return X / Y;
    }
}
delegate int MathDelegate();
class Program
{
    static void Main()
    {
        MathOperations obj1 = new MathOperations(15, 3);
        MathOperations obj2 = new MathOperations(20, 4);

        MathDelegate delegate1 = () =>
        {
            int sum = obj1.Add();
            int mult = sum * obj1.Y;
            return mult / obj1.Y;
        };

        MathDelegate delegate2 = () =>
        {
            int div = obj2.Divide();
            int sub = div - obj2.Y;
            return sub * obj2.Y;
        };

        try
        {
            Console.WriteLine($"Результат 1: {delegate1()}"); 
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        try
        {
            Console.WriteLine($"Результат 2: {delegate2()}");  
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
