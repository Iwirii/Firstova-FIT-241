//базовый класс, который включает наименование(string)
//три наследника:
//1 - класс, отображающий окружность: радиус
//2 - квадрат: длина стороны
//3 - равносторонний треугольник: длина стороны
//интерфейс с двумя методами: поиск периметра и площади
//каждый из трех классов является наследником базового класса и интерфейса
//создать три объекта разных классов и выдать их площадь и периметр
//при наследовании сначала имя класса, потом интерфейс
using System;
namespace Shapes
{
    public abstract class Shape
    {
        public string Name { get; set; }
        public Shape(string name)
        {
            Name = name;
        }
    }

    public interface IShape
    {
        double Perimeter();
        double Area();
    }

    public class Circle : Shape, IShape
    {
        public double Radius { get; set; }
        public Circle(string name, double radius) : base(name)
        {
            Radius = radius;
        }
        public double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }
        public double Area()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Square : Shape, IShape
    {
        public double SideLength { get; set; }
        public Square(string name, double sideLength) : base(name)
        {
            SideLength = sideLength;
        }
        public double Perimeter()
        {
            return 4 * SideLength;
        }
        public double Area()
        {
            return SideLength * SideLength;
        }
    }

    public class Triangle : Shape, IShape
    {
        public double SideLength { get; set; }
        public Triangle(string name, double sideLength) : base(name)
        {
            SideLength = sideLength;
        }
        public double Perimeter()
        {
            return 3 * SideLength;
        }
        public double Area()
        {
            return (Math.Sqrt(3) / 4) * SideLength * SideLength;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle("Окружность", 5);
            Square square = new Square("Квадрат", 4);
            Triangle triangle = new Triangle("Треугольник", 3);

            Console.WriteLine($"{circle.Name}: Площадь = {circle.Area()}, Периметр = {circle.Perimeter()}");
            Console.WriteLine($"{square.Name}: Площадь = {square.Area()}, Периметр = {square.Perimeter()}");
            Console.WriteLine($"{triangle.Name}: Площадь = {triangle.Area()}, Периметр = {triangle.Perimeter()}");
        }
    }
}
