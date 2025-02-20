//Создаем телефонный справочник, при этом у абонентов может быть несколько различных номеров телефона, подключенным к различным операторам связи в определенный год. 
//У нас будет ФИО, номер, к какому оператору подключен и год подключения, и к человеку город. 
//Необходимо написать программу, которая реализует меню по заполнению базы “телефонный справочник”, 
//по выборке данных конкретного оператора связи, по выборке по году подключения и выборка по номеру телефона (с целью узнать сведения об абоненте) и выход. 
class User
{
    public string FullName { get; set; }
    public Phone[] Phones { get; set; }
    public string City { get; set; }

    public User(string fullName, Phone[] phones, string city)
    {
        FullName = fullName;
        Phones = phones;
        City = city;
    }
}
class Phone
{
    public string TelephoneNumber { get; set; }
    public string Operatorr { get; set; }
    public int Year { get; set; }
    public Phone(string telephoneNumber, string operatorr, int year)
    {
        TelephoneNumber = telephoneNumber;
        Operatorr = operatorr;
        Year = year;
    }
}
class Program
{
    static User[] users = new User[100];
    static int count = 0;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Заполнение данных об абоненте");
            Console.WriteLine("2. Поиск по оператору связи");
            Console.WriteLine("3. Поиск по году подключения");
            Console.WriteLine("4. Поиск по номеру телефона");
            Console.WriteLine("5. Выход");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    FillUserData();
                    break;

                case "2":
                    SearchByOperator();
                    break;

                case "3":
                    SearchByYear();
                    break;

                case "4":
                    SearchByNumber();
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Некорректный ввод. Пожалуйста, попробуйте снова.");
                    break;
            }
        }
    }

    static void FillUserData()
    {
        if (count >= users.Length)
        {
            Console.WriteLine("Массив полон. Невозможно добавить больше абонентов.");
            return;
        }

        Console.Write("Введите ФИО абонента: ");
        string fullName = Console.ReadLine();
        Console.Write("Введите город проживания: ");
        string city = Console.ReadLine();
        Console.Write("Введите количество номеров абонента: ");
        int cntOfnumbers = Convert.ToInt32(Console.ReadLine());
        Phone[] allphones = new Phone[cntOfnumbers];
        for (int i = 0; i < cntOfnumbers; i++)
        {
            Console.Write("Введите номер телефона абонента: ");
            string telephoneNumber = Console.ReadLine();
            Console.Write("Введите оператора связи: ");
            string operatorr = Console.ReadLine();
            Console.Write("Введите год подключения: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Phone phone = new Phone(telephoneNumber, operatorr, year);
            allphones[i] = phone;
            Console.WriteLine("Номер успешно добавлен.");
        }

        users[count] = new User(fullName, allphones, city);
        count++;
        Console.WriteLine("Данные абонента добавлены.");
    }

    static void SearchByOperator()
    {
        Console.Write("Введите оператора связи: ");
        string operatorName = Console.ReadLine();

        bool found = false;

        foreach (var user in users)
        {
            if (user != null)
            {
                foreach (var phone in user.Phones)
                {
                    if (phone.Operatorr.Equals(operatorName, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"ФИО: {user.FullName}, Номер телефона: {phone.TelephoneNumber}, Год подключения: {phone.Year}, Город: {user.City}");
                        found = true;
                    }
                }
            }
        }
        if (!found)
        {
            Console.WriteLine("Абоненты с указанным оператором связи не найдены.");
        }
    }
    static void SearchByYear()
    {
        Console.Write("Введите год подключения: ");

        if (!int.TryParse(Console.ReadLine(), out int year))
        {
            Console.WriteLine("Некорректный ввод года подключения.");
            return;
        }

        bool found = false;

        foreach (var user in users)
        {
            if (user != null)
            {
                foreach (var phone in user.Phones)
                {
                    if (phone.Year == year)
                    {
                        Console.WriteLine($"ФИО: {user.FullName}, Номер телефона: {phone.TelephoneNumber}, Оператор: {phone.Operatorr}, Город: {user.City}");
                        found = true;
                    }
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("Абоненты с указанным годом подключения не найдены.");
        }
    }

    static void SearchByNumber()
    {
        Console.Write("Введите номер телефона: ");
        string telephoneNumberInput = Console.ReadLine();

        bool found = false;

        foreach (var user in users)
        {
            if (user != null)
            {
                foreach (var phone in user.Phones)
                {
                    if (phone.TelephoneNumber.Equals(telephoneNumberInput))
                    {
                        Console.WriteLine($"ФИО: {user.FullName}, Оператор: {phone.Operatorr}, Год подключения: {phone.Year}, Город: {user.City}");
                        found = true;
                    }
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("Абоненты с указанным номером телефона не найдены.");
        }
    }
}
