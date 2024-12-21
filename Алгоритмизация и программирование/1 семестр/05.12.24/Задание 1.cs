using System;
namespace StudentManagement
{
    class Student
    {
        public string FullName { get; set; }
        public int BirthYear { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public string Address { get; set; }

        public Student(string fullName, int birthYear, string motherName, string fatherName, string address)
        {
            FullName = fullName;
            BirthYear = birthYear;
            MotherName = motherName;
            FatherName = fatherName;
            Address = address;
        }

        public override string ToString()
        {
            return $"{FullName}, Год рождения: {BirthYear}, Мама: {MotherName}, Папа: {FatherName}, Адрес: {Address}";
        }
    }

    class Program
    {
        static Student[] students = new Student[100];
        static int count = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Заполнение данных о учениках");
                Console.WriteLine("2. Изменение данных о ученике");
                Console.WriteLine("3. Выборка по первому символу ФИО");
                Console.WriteLine("4. Поиск по адресу");
                Console.WriteLine("5. Поиск по году рождения");
                Console.WriteLine("6. Выход");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        FillStudentData();
                        break;

                    case "2":
                        ModifyStudentData();
                        break;

                    case "3":
                        SearchByInitial();
                        break;

                    case "4":
                        SearchByAddress();
                        break;

                    case "5":
                        SearchByBirthYear();
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Некорректный ввод. Пожалуйста, попробуйте снова.");
                        break;
                }
            }
        }

        static void FillStudentData()
        {
            if (count >= students.Length)
            {
                Console.WriteLine("Массив полон. Невозможно добавить больше учеников.");
                return;
            }

            Console.Write("Введите ФИО ученика: ");
            string fullName = Console.ReadLine();
            Console.Write("Введите год рождения: ");
            if (!int.TryParse(Console.ReadLine(), out int birthYear))
            {
                Console.WriteLine("Некорректный ввод года рождения.");
                return;
            }
            Console.Write("Введите ФИО мамы (необязательно): ");
            string motherName = Console.ReadLine();
            Console.Write("Введите ФИО папы (необязательно): ");
            string fatherName = Console.ReadLine();
            Console.Write("Введите адрес (улица, дом, квартира): ");
            string address = Console.ReadLine();

            students[count] = new Student(fullName, birthYear, motherName, fatherName, address);
            count++;
            Console.WriteLine("Данные ученика добавлены.");
        }

        static void ModifyStudentData()
        {
            if (count == 0)
            {
                Console.WriteLine("Нет данных о учениках для изменения.");
                return;
            }

            Console.Write("Введите ФИО ученика для изменения: ");
            string fullName = Console.ReadLine();
            Student student = Array.Find(students, s => s != null && s.FullName.Equals(fullName, StringComparison.OrdinalIgnoreCase));

            if (student != null)
            {
                Console.Write("Введите новый год рождения: ");
                if (!int.TryParse(Console.ReadLine(), out int newBirthYear))
                {
                    Console.WriteLine("Некорректный ввод года рождения.");
                    return;
                }

                student.BirthYear = newBirthYear;

                Console.Write("Введите новое ФИО мамы (необязательно): ");
                student.MotherName = Console.ReadLine();

                Console.Write("Введите новое ФИО папы (необязательно): ");
                student.FatherName = Console.ReadLine();

                Console.Write("Введите новый адрес: ");
                student.Address = Console.ReadLine();

                Console.WriteLine("Данные ученика изменены.");
            }
            else
            {
                Console.WriteLine("Ученик не найден.");
            }
        }

        static void SearchByInitial()
        {
            Console.Write("Введите начальную букву ФИО: ");

            if (!char.TryParse(Console.ReadLine(), out char initial))
            {
                Console.WriteLine("Некорректный ввод начальной буквы.");
                return;
            }

            bool found = false;

            foreach (var student in students)
            {
                if (student != null && student.FullName.StartsWith(initial.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(student);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Ученики с такой начальной буквой не найдены.");
            }
        }

        static void SearchByAddress()
        {
            Console.Write("Введите улицу для поиска: ");
            string street = Console.ReadLine();

            bool found = false;

            foreach (var student in students)
            {
                if (student != null && student.Address.IndexOf(street, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Console.WriteLine(student);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Ученики, проживающие на заданной улице, не найдены.");
            }
        }

        static void SearchByBirthYear()
        {
            Console.Write("Введите год рождения: ");

            if (!int.TryParse(Console.ReadLine(), out int birthYear))
            {
                Console.WriteLine("Некорректный ввод года рождения.");
                return;
            }

            bool found = false;

            foreach (var student in students)
            {
                if (student != null && student.BirthYear == birthYear)
                {
                    Console.WriteLine(student);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Ученики с указанным годом рождения не найдены.");
            }
        }
    }
}
