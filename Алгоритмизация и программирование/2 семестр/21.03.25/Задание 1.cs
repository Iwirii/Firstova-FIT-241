//Имеется класс "точка", который описывается двумя координатами. 
//Есть поле, заданное 4 координатами. Точка перемещается по полю с рандомными значегиями по x и y. 
//Необходимо обработать события выхода точки за пределы поля.
using System;
public class Point
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public event EventHandler<string> OutOfBoundsEvent;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Move(int deltaX, int deltaY, Field field)
    {
        int newX = X + deltaX;
        int newY = Y + deltaY;

        if (!field.IsInside(newX, newY))
        {
            OutOfBoundsEvent?.Invoke(this, $"Точка вышла за границы! Текущая позиция: ({X}, {Y}), Попытка перемещения в: ({newX}, {newY})");
            Environment.Exit(0); 
        }

        X = newX;
        Y = newY;
        Console.WriteLine($"Точка переместилась в ({X}, {Y})");
    }
}

public class Field
{
    public int MinX { get; }
    public int MaxX { get; }
    public int MinY { get; }
    public int MaxY { get; }

    public Field(int minX, int maxX, int minY, int maxY)
    {
        MinX = minX;
        MaxX = maxX;
        MinY = minY;
        MaxY = maxY;
    }

    public bool IsInside(int x, int y)
    {
        return x >= MinX && x <= MaxX && y >= MinY && y <= MaxY;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Задайте границы поля:");
        Console.Write("Левый нижний угол X: ");
        int minX = int.Parse(Console.ReadLine());
        Console.Write("Левый нижний угол Y: ");
        int minY = int.Parse(Console.ReadLine());
        Console.Write("Правый верхний угол X: ");
        int maxX = int.Parse(Console.ReadLine());
        Console.Write("Правый верхний угол Y: ");
        int maxY = int.Parse(Console.ReadLine());

        Field field = new Field(minX, maxX, minY, maxY);

        Console.Write("\nВведите начальную координату X точки: ");
        int startX = int.Parse(Console.ReadLine());
        Console.Write("Введите начальную координату Y точки: ");
        int startY = int.Parse(Console.ReadLine());

        Point point = new Point(startX, startY);

        point.OutOfBoundsEvent += (sender, message) =>
        {
            Console.WriteLine(message);
        };

        Random random = new Random();
        int step = 1;

        while (true)
        {
            Console.WriteLine($"\nШаг {step}:");
            int deltaX = random.Next(-100, 101);
            int deltaY = random.Next(-100, 101);

            Console.WriteLine($"Попытка перемещения на ({deltaX}, {deltaY})");
            point.Move(deltaX, deltaY, field);
            step++;
        }
    }
}
