//База данных по компьютерам.
//1 таблица: "Порядковый номер". Наименования: "Марки", "Модель"
//2 таблица: "Порядковый номер". Наименования: "Наименование операционной системы"
//3 таблица: "Пользователи". Наименования: "Порядковый номер пользователя", "ФИО", "Есть ноутбук? (Да/Нет)", "Марка ноутбука", "Операционная система"(идентифицировать null или нулем, если нет ноутбука).
//Что выдать?
//1. Выдать всех пользователей, сгруппированных по наличию компьютера
//2. Выдать пользователей, сгруппированных по марке ноутбука
//3. Выдать пользователей, сгруппированных по операционной системе
//4. Выдать все данные, где будет пользователь, наличие компьютера, марка, модель, операционная система
using System;
using System.Collections.Generic;
using System.Linq;

namespace computer_database_example
{
    class computer_brand_model
    {
        public int id { get; set; }        
        public string brand { get; set; }    
        public string model { get; set; }     
    }

    class operating_system
    {
        public int id { get; set; }           
        public string os_name { get; set; }   
    }

    class user
    {
        public int user_id { get; set; }            
        public string full_name { get; set; }      
        public bool has_laptop { get; set; }      
        public int? laptop_brand_model_id { get; set; } 
        public int? os_id { get; set; }                
    }

    class program
    {
        static void Main(string[] args)
        {
            var computer_brand_models = new List<computer_brand_model>
            {
                new computer_brand_model { id = 1, brand = "Acer", model = "Aspire 5" },
                new computer_brand_model { id = 2, brand = "Dell", model = "XPS 13" },
                new computer_brand_model { id = 3, brand = "Asus", model = "ZenBook 14" }
            };

            var operating_systems = new List<operating_system>
            {
                new operating_system { id = 1, os_name = "Windows 7" },
                new operating_system { id = 2, os_name = "Windows 10" },
                new operating_system { id = 3, os_name = "Linux" }
            };

            var users = new List<user>
            {
                new user { user_id = 1, full_name = "Алексей Морозов", has_laptop = true, laptop_brand_model_id = 1, os_id = 2 },
                new user { user_id = 2, full_name = "Елена Крылова", has_laptop = false, laptop_brand_model_id = null, os_id = null },
                new user { user_id = 3, full_name = "Игорь Смирнов", has_laptop = true, laptop_brand_model_id = 3, os_id = 3 },
                new user { user_id = 4, full_name = "Ольга Васильева", has_laptop = true, laptop_brand_model_id = 2, os_id = 1 },
                new user { user_id = 5, full_name = "Марина Белова", has_laptop = false, laptop_brand_model_id = null, os_id = null }
            };

            var group_by_has_laptop = users.GroupBy(u => u.has_laptop);

            Console.WriteLine("Пользователи, сгруппированные по наличию ноутбука:");
            foreach (var group in group_by_has_laptop)
            {
                Console.WriteLine(group.Key ? "Есть ноутбук:" : "Нет ноутбука:");
                foreach (var user in group)
                {
                    Console.WriteLine($"  {user.full_name}");
                }
            }

            var group_by_brand = users.GroupBy(u =>
            {
                if (u.laptop_brand_model_id.HasValue)
                {
                    var brand = computer_brand_models.FirstOrDefault(b => b.id == u.laptop_brand_model_id.Value)?.brand;
                    return brand ?? "Неизвестная марка";
                }
                else
                {
                    return "Нет ноутбука";
                }
            });

            Console.WriteLine("\nПользователи, сгруппированные по марке ноутбука:");
            foreach (var group in group_by_brand)
            {
                Console.WriteLine(group.Key + ":");
                foreach (var user in group)
                {
                    Console.WriteLine($"  {user.full_name}");
                }
            }

            var group_by_os = users.GroupBy(u =>
            {
                if (u.os_id.HasValue)
                {
                    var os_name = operating_systems.FirstOrDefault(os => os.id == u.os_id.Value)?.os_name;
                    return os_name ?? "Неизвестная ОС";
                }
                else
                {
                    return "Нет ОС";
                }
            });

            Console.WriteLine("\nПользователи, сгруппированные по операционной системе:");
            foreach (var group in group_by_os)
            {
                Console.WriteLine(group.Key + ":");
                foreach (var user in group)
                {
                    Console.WriteLine($"  {user.full_name}");
                }
            }

            var full_data = from u in users
                            join c in computer_brand_models on u.laptop_brand_model_id equals c.id into brand_group
                            from brand in brand_group.DefaultIfEmpty()
                            join os in operating_systems on u.os_id equals os.id into os_group
                            from operating_system in os_group.DefaultIfEmpty()
                            select new
                            {
                                user_name = u.full_name,
                                has_laptop = u.has_laptop ? "Да" : "Нет",
                                brand = brand?.brand ?? "-",
                                model = brand?.model ?? "-",
                                os_name = operating_system?.os_name ?? "-"
                            };

            Console.WriteLine("\nВсе данные по пользователям:");
            foreach (var item in full_data)
            {
                Console.WriteLine($"Пользователь: {item.user_name}, Есть ноутбук: {item.has_laptop}, Марка: {item.brand}, Модель: {item.model}, ОС: {item.os_name}");
            }
        }
    }
}
