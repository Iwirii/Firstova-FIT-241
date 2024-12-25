//Дан класс "поезд", содержащий следующие поля: номер поезда, название пункта отправления, название пункта назначения, время отправления(время отправления с заданной станции).
//Класс "станция", который содержит следующие поля: название станции, массив объектов типа "поезд"(массив с заданным количеством объектов)
//Необходимо реализовать меню, в котором будут следующие пункты:
//1.Ввод данных
//2. Вывод информации о поездах, которые имеют заданное значение пункта назначения
//3. Вывод данных о поездах, которые отправляются после заданного времени отправления
//4. Выход

using System;

public class Train
{
    public string TrainNumber { get; set; }
    public string DepartureStation { get; set; }
    public string DestinationStation { get; set; }
    public DateTime DepartureTime { get; set; }

    public Train(string trainNumber, string departureStation, string destinationStation, DateTime departureTime)
    {
        TrainNumber = trainNumber;
        DepartureStation = departureStation;
        DestinationStation = destinationStation;
        DepartureTime = departureTime;
    }

    public override string ToString()
    {
        return $"Поезд: {TrainNumber}, Отправление: {DepartureStation}, Назначение: {DestinationStation}, Время отправления: {DepartureTime}";
    }
}

public class Station
{
    public string StationName { get; set; }
    public Train[] Trains { get; set; }

    public Station(string stationName, int trainCapacity)
    {
        StationName = stationName;
        Trains = new Train[trainCapacity];
    }

    public void InputTrains()
    {
        for (int i = 0; i < Trains.Length; i++)
        {
            Console.WriteLine($"Введите данные для поезда {i + 1}:");
            Console.Write("Номер поезда: ");
            string trainNumber = Console.ReadLine();
            Console.Write("Название пункта отправления: ");
            string departureStation = Console.ReadLine();
            Console.Write("Название пункта назначения: ");
            string destinationStation = Console.ReadLine();
            Console.Write("Время отправления (в формате: ГГГГ-ММ-ДД ЧЧ:ММ): ");
            DateTime departureTime = DateTime.Parse(Console.ReadLine());

            Trains[i] = new Train(trainNumber, departureStation, destinationStation, departureTime);
        }
    }

    public void PrintTrainsByDestination(string destination)
    {
        Console.WriteLine($"Поезда с пунктом назначения '{destination}':");
        foreach (var train in Trains)
        {
            if (train != null && train.DestinationStation.Equals(destination, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(train);
            }
        }
    }

    public void PrintTrainsAfterTime(DateTime time)
    {
        Console.WriteLine($"Поезда, отправляющиеся после {time}:");
        foreach (var train in Trains)
        {
            if (train != null && train.DepartureTime > time)
            {
                Console.WriteLine(train);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите название станции: ");
        string stationName = Console.ReadLine();

        Console.Write("Введите количество поездов: ");
        int trainCapacity = int.Parse(Console.ReadLine());

        Station station = new Station(stationName, trainCapacity);

        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Ввод данных");
            Console.WriteLine("2. Вывод информации о поездах с заданным пунктом назначения");
            Console.WriteLine("3. Вывод данных о поездах, отправляющихся после заданного времени");
            Console.WriteLine("4. Выход");
            Console.Write("Выберите пункт меню: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    station.InputTrains();
                    break;
                case 2:
                    Console.Write("Введите пункт назначения: ");
                    string destination = Console.ReadLine();
                    station.PrintTrainsByDestination(destination);
                    break;
                case 3:
                    Console.Write("Введите время отправления (в формате: ГГГГ-ММ-ДД ЧЧ:ММ): ");
                    DateTime time = DateTime.Parse(Console.ReadLine());
                    station.PrintTrainsAfterTime(time);
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}
