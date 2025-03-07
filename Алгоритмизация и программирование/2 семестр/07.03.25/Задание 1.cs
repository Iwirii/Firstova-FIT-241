//Будет список из элементов класса телефон, необходимо с помощью словаря определить чаще всего используемый тариф. 
//В классе телефон будут описаны следующие поля: номер телефона, ФИО и тариф. 
//С помощью словаря надо будет вытянуть какой оператор чаще всего используется в телефонах. 
using System;
using System.Collections.Generic;
using System.Linq;
class Phone
{
    public string TelephoneNumber { get; set; }
    public string Tarif { get; set; }
    public string FullName { get; set; }

    public Phone(string telephoneNumber, string fullName, string tarif)
    {
        TelephoneNumber = telephoneNumber;
        FullName = fullName;
        Tarif = tarif;
    }
}
class Program
{
    static void Main(string[] args)
    {
        List<Phone> phones = new List<Phone>
        {
            new Phone("65435633343", "Иванов Иван", "Тариф A"),
            new Phone("26256645334", "Петров Петр", "Тариф B"),
            new Phone("26467653356", "Сидорова Света", "Тариф A"),
            new Phone("67542253453", "Кузнецова Кира", "Тариф C"),
            new Phone("76334532564", "Семенов Семен", "Тариф B"),
            new Phone("77543311143", "Тихонов Тихон", "Тариф A")
        };

        Dictionary<string, int> tarifCount = new Dictionary<string, int>();
        foreach (var phone in phones)
        {
            if (tarifCount.ContainsKey(phone.Tarif))
            {
                tarifCount[phone.Tarif]++;
            }
            else
            {
                tarifCount[phone.Tarif] = 1;
            }
        }
        var mostUsedTarif = tarifCount.OrderByDescending(tc => tc.Value).First();
        Console.WriteLine($"Чаще всего используемый тариф: {mostUsedTarif.Key} (использован {mostUsedTarif.Value} раз)");
    }
}
