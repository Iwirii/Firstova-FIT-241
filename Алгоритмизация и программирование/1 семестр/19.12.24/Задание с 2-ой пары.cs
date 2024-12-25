//Класс "животные", в котором одно поле "наименование"
//Класс "птицы", наследник "животные"
//Класс "млекопитающие", наследник "животные"
//В классе "птицы" характеристики: где обитают, куда летят зимовать
//В классе "млекопитающие" характеристики: обитание, вес животного
//Создание массива "птицы", создание массива "млекопитающие". Выборка по обитанию и там, и там. Для "птицы" выборка с местом зимовки. А для "млекопитающие" выборка по весу животного.
using System;
public class Animal
{
    public string Name { get; set; }

    public Animal(string name)
    {
        Name = name;
    }
}

public class Bird : Animal
{
    public string Habitat { get; set; }
    public string WinteringPlace { get; set; }

    public Bird(string name, string habitat, string winteringPlace) : base(name)
    {
        Habitat = habitat;
        WinteringPlace = winteringPlace;
    }

    public override string ToString()
    {
        return $"Птица: {Name}, Обитание: {Habitat}, Зимовка: {WinteringPlace}";
    }
}

public class Mammal : Animal
{
    public string Habitat { get; set; }
    public double Weight { get; set; }

    public Mammal(string name, string habitat, double weight) : base(name)
    {
        Habitat = habitat;
        Weight = weight;
    }

    public override string ToString()
    {
        return $"Млекопитающее: {Name}, Обитание: {Habitat}, Вес: {Weight} кг";
    }
}

class Program
{
    static void Main()
    {
        Bird[] birds = new Bird[3];
        Mammal[] mammals = new Mammal[3];
        int birdCount = 0;
        int mammalCount = 0;

        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Ввод данных о птицах");
            Console.WriteLine("2. Ввод данных о млекопитающих");
            Console.WriteLine("3. Поиск млекопитающих по месту обитания");
            Console.WriteLine("4. Поиск птиц по месту обитания");
            Console.WriteLine("5. Поиск млекопитающего с определенным весом");
            Console.WriteLine("6. Поиск птиц по месту зимования");
            Console.WriteLine("7. Выход");
            Console.Write("Выберите пункт меню: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    if (birdCount < birds.Length)
                    {
                        Console.Write("Введите название птицы: ");
                        string birdName = Console.ReadLine();
                        Console.Write("Введите место обитания: ");
                        string birdHabitat = Console.ReadLine();
                        Console.Write("Введите место зимовки: ");
                        string birdWinteringPlace = Console.ReadLine();

                        birds[birdCount++] = new Bird(birdName, birdHabitat, birdWinteringPlace);
                    }
                    else
                    {
                        Console.WriteLine("Массив птиц заполнен.");
                    }
                    break;

                case 2:
                    if (mammalCount < mammals.Length)
                    {
                        Console.Write("Введите название млекопитающего: ");
                        string mammalName = Console.ReadLine();
                        Console.Write("Введите место обитания: ");
                        string mammalHabitat = Console.ReadLine();
                        Console.Write("Введите вес животного (кг): ");
                        double mammalWeight;

                        while (!double.TryParse(Console.ReadLine(), out mammalWeight))
                        {
                            Console.Write("Некорректный ввод. Пожалуйста, введите вес в килограммах: ");
                        }

                        mammals[mammalCount++] = new Mammal(mammalName, mammalHabitat, mammalWeight);
                    }
                    else
                    {
                        Console.WriteLine("Массив млекопитающих заполнен.");
                    }
                    break;

                case 3:
                    Console.Write("Введите место обитания для поиска: ");
                    string habitatInput = Console.ReadLine();
                    SearchMammalsByHabitat(mammals, habitatInput);
                    break;

                case 4:
                    Console.Write("Введите место обитания для поиска птиц: ");
                    string birdHabitatInput = Console.ReadLine();
                    SearchBirdsByHabitat(birds, birdHabitatInput);
                    break;

                case 5:
                    Console.Write("Введите вес для поиска млекопитающих (кг): ");
                    double weightInput;

                    while (!double.TryParse(Console.ReadLine(), out weightInput))
                    {
                        Console.Write("Некорректный ввод. Пожалуйста, введите вес в килограммах: ");
                    }

                    SearchMammalsByWeight(mammals, weightInput);
                    break;

                case 6:
                    Console.Write("Введите место зимования для поиска птиц: ");
                    string winteringPlaceInput = Console.ReadLine();
                    SearchBirdsByWinteringPlace(birds, winteringPlaceInput);
                    break;

                case 7:
                    return;

                default:
                    Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    static void SearchMammalsByHabitat(Mammal[] mammals, string habitat)
    {
        bool found = false;

        foreach (var mammal in mammals)
        {
            if (mammal != null && mammal.Habitat.Equals(habitat, StringComparison.OrdinalIgnoreCase))
            {
                found = true;
                Console.WriteLine(mammal);
            }
        }

        if (!found)
        {
            Console.WriteLine("Млекопитающие с заданным местом обитания не найдены.");
        }
    }

    static void SearchBirdsByHabitat(Bird[] birds, string habitat)
    {
        bool found = false;

        foreach (var bird in birds)
        {
            if (bird != null && bird.Habitat.Equals(habitat, StringComparison.OrdinalIgnoreCase))
            {
                found = true;
                Console.WriteLine(bird);
            }
        }

        if (!found)
        {
            Console.WriteLine("Птицы с заданным местом обитания не найдены.");
        }
    }

    static void SearchMammalsByWeight(Mammal[] mammals, double weight)
    {
        bool found = false;

        foreach (var mammal in mammals)
        {
            if (mammal != null && mammal.Weight == weight) 
            {
                found = true;
                Console.WriteLine(mammal);
            }
        }

        if (!found)
        {
            Console.WriteLine($"Млекопитающие с весом {weight} кг не найдены.");
        }
    }

    static void SearchBirdsByWinteringPlace(Bird[] birds, string winteringPlace)
    {
        bool found = false;

        foreach (var bird in birds)
        {
            if (bird != null && bird.WinteringPlace.Equals(winteringPlace, StringComparison.OrdinalIgnoreCase))
            {
                found = true;
                Console.WriteLine(bird);
            }
        }

        if (!found)
        {
            Console.WriteLine("Птицы с заданным местом зимования не найдены.");
        }
    }
}
