//будет класс телефон, где будет марка, год выпуска, страна использования, с использованием библиотеки линк необходимо сформировать запросы, 
//которые позволяют работать с базой данных телефонов, и первый запрос: сгруппировать все телефоны по стране; второй запрос: выдать телефоны с заданным годом выпуска; 
//третье: сгруппировать телефоны по марке. Будет меню, где заполняем базу данных и делаем выборку с библиотекой LINQ.
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneDatabaseApp
{
    class Phone
    {
        public string Brand { get; set; }  
        public int Year { get; set; }      
        public string Country { get; set; }       

        public Phone(string brand, int year, string country)
        {
            Brand = brand;
            Year = year;
            Country = country;
        }

        public override string ToString()
        {
            return $"Марка: {Brand}, Год: {Year}, Страна: {Country}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Phone> phones = new List<Phone>();

            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1 - Добавить телефон");
                Console.WriteLine("2 - Сгруппировать телефоны по стране");
                Console.WriteLine("3 - Показать телефоны по году выпуска");
                Console.WriteLine("4 - Сгруппировать телефоны по марке");
                Console.WriteLine("0 - Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                if (choice == "0")
                    break;

                switch (choice)
                {
                    case "1":
                        AddPhone(phones);
                        break;
                    case "2":
                        GroupByCountry(phones);
                        break;
                    case "3":
                        FilterByYear(phones);
                        break;
                    case "4":
                        GroupByBrand(phones);
                        break;
                    default:
                        Console.WriteLine("Неверный выбор, попробуйте ещё раз.");
                        break;
                }
            }
        }

        static void AddPhone(List<Phone> phones)
        {
            Console.Write("Введите марку телефона: ");
            string brand = Console.ReadLine();

            Console.Write("Введите год выпуска: ");
            bool yearParsed = int.TryParse(Console.ReadLine(), out int year);
            if (!yearParsed)
            {
                Console.WriteLine("Неверный формат года.");
                return;
            }

            Console.Write("Введите страну использования: ");
            string country = Console.ReadLine();

            phones.Add(new Phone(brand, year, country));
            Console.WriteLine("Телефон добавлен.");
        }

        static void GroupByCountry(List<Phone> phones)
        {
            var grouped = phones.GroupBy(p => p.Country);

            Console.WriteLine("\nТелефоны, сгруппированные по стране:");
            foreach (var group in grouped)
            {
                Console.WriteLine($"Страна: {group.Key}");
                foreach (var phone in group)
                {
                    Console.WriteLine($"  {phone}");
                }
            }
        }

        static void FilterByYear(List<Phone> phones)
        {
            Console.Write("Введите год для фильтрации: ");
            bool yearParsed = int.TryParse(Console.ReadLine(), out int year);
            if (!yearParsed)
            {
                Console.WriteLine("Неверный формат года.");
                return;
            }

            var filtered = phones.Where(p => p.Year == year);

            Console.WriteLine($"\nТелефоны, выпущенные в {year}:");
            foreach (var phone in filtered)
            {
                Console.WriteLine(phone);
            }
        }

        static void GroupByBrand(List<Phone> phones)
        {
            var grouped = phones.GroupBy(p => p.Brand);

            Console.WriteLine("\nТелефоны, сгруппированные по марке:");
            foreach (var group in grouped)
            {
                Console.WriteLine($"Марка: {group.Key}");
                foreach (var phone in group)
                {
                    Console.WriteLine($"  {phone}");
                }
            }
        }
    }
}
