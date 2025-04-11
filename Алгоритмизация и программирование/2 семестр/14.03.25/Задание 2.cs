//Будет класс машина, описание машины: год выпуска, модель, цвет, булевская переменная машина чистая или грязная. 
//Класс гараж, который содержит все машины(список из объектов машин), класс мойка, в котором будет реализован только 1 метод, моющий машину, если она грязная(выдавать сообщение машина такая-то помыта или нет). 
//Будет делегат, который будет отправлять машины в мойку.
using System;
using System.Collections.Generic;

public class Car
{
    public int Year { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public bool IsDirty { get; set; }

    public Car(int year, string model, string color, bool isDirty)
    {
        Year = year;
        Model = model;
        Color = color;
        IsDirty = isDirty;
    }
}

public class Garage
{
    public List<Car> Cars { get; set; } = new List<Car>();
}

public class CarWash
{
    public void WashCar(Car car)
    {
        if (car.IsDirty)
        {
            car.IsDirty = false;
            Console.WriteLine($"Машина {car.Model} ({car.Year}, {car.Color}) помыта!");
        }
        else
        {
            Console.WriteLine($"Машина {car.Model} ({car.Year}, {car.Color}) уже чистая.");
        }
    }
}

class Program
{
    delegate void WashDelegate(Car car);

    static void Main()
    {
        Garage garage = new Garage();

        Console.WriteLine("Введите количество машин в гараже:");
        int carCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < carCount; i++)
        {
            Console.WriteLine($"\nМашина #{i + 1}:");

            Console.Write("Год выпуска: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Модель: ");
            string model = Console.ReadLine();

            Console.Write("Цвет: ");
            string color = Console.ReadLine();

            Console.Write("Грязная? (да/нет): ");
            bool isDirty = Console.ReadLine().ToLower() == "да";

            garage.Cars.Add(new Car(year, model, color, isDirty));
        }

        CarWash carWash = new CarWash();

        WashDelegate washDelegate = carWash.WashCar;

        Console.WriteLine("\n Отправляем машины в мойку...");
        Console.WriteLine("----------------------------------");

        foreach (Car car in garage.Cars)
        {
            washDelegate(car);
        }

        Console.WriteLine("\n Состояние машин после мойки:");
        Console.WriteLine("----------------------------------");
        foreach (Car car in garage.Cars)
        {
            string status = car.IsDirty ? "Грязная" : "Чистая";
            Console.WriteLine($"{car.Model} ({car.Year}, {car.Color}): {status}");
        }
    }
}
