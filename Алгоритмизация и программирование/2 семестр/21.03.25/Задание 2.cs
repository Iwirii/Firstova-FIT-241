//Идут гонки лощадей. Каждый объект характеризуется начальным положением и именем лошади(начальное положение, если по оси x, то оно одинаковое, так как старт один). 
//В каждый момент времени за счет рандомного изменения скорости положение лошади меняется. Есть значение положения финиша. Обработать события победы одной из лошадей.
using System;
using System.Collections.Generic;
using System.Threading;

class Horse
{
    public string Name { get; }
    public int Position { get; private set; }

    public delegate void RaceFinishedHandler(string winnerName);
    public event RaceFinishedHandler OnFinish;

    private static Random random = new Random();

    public Horse(string name)
    {
        Name = name;
        Position = 0;
    }

    public int Move()
    {
        int step = random.Next(5, 21);
        Position += step;
        Console.WriteLine($"{Name} пробежал {step} метров. Всего: {Position}м");
        return Position;
    }
}

class Program
{
    static void Main()
    {
        var horses = new List<Horse>
        {
            new Horse("Ниф-ниф"),
            new Horse("Наф-наф"),
            new Horse("Нуф-нуф")
        };

        bool raceOver = false;
        List<string> winners = new List<string>();
        int finishLine = 100;

        while (!raceOver)
        {
            winners.Clear();

            foreach (var horse in horses)
            {
                horse.Move();
            }

            foreach (var horse in horses)
            {
                if (horse.Position >= finishLine)
                {
                    winners.Add(horse.Name);
                }
            }

            if (winners.Count > 0)
            {
                raceOver = true;
                Console.WriteLine();
                foreach (var winner in winners)
                {
                    Console.WriteLine($"Победила лошадь: {winner}!");
                }
            }

            Console.WriteLine(); 
            Thread.Sleep(500);
        }
    }
}
