//Имеется база данных, состоящая из трех взаимодействующих таблиц. Каждая таблица - отдельный класс.
//1 таблица - "Поставщики". Поля: номер по порядку, наименование, контактный телефон.
//2 таблица - "Товары". Поля: номер товара, название.
//3 таблица - "Движение товаров". Поля: номенклатурный номер товара, номер поставщика, префикс - поступление или продажа, дата, количество штук, стоимость за единицу.
//Необходимо, используя язык запросов, выдать:
//1. Остатки товаров
//2. Товары сгруппированные по поставщикам(только поставки)
//3. Товары по продажам, сгруппированные по дате продажи.
using System;
using System.Collections.Generic;
using System.Linq;

namespace simple_database_example
{
    class supplier
    {
        public int id { get; set; }              
        public string name { get; set; }        
        public string contact_phone { get; set; } 
    }

    class product
    {
        public int product_id { get; set; }      
        public string product_name { get; set; }  
    }

    class product_movement
    {
        public int product_id { get; set; }    
        public int supplier_id { get; set; }     
        public string prefix { get; set; }       
        public DateTime date { get; set; }       
        public int quantity { get; set; }       
        public decimal price_per_unit { get; set; } 
    }

    class program
    {
        static void Main(string[] args)
        {
            List<supplier> suppliers = new List<supplier>
            {
                new supplier { id = 1, name = "ООО Ромашка", contact_phone = "235432452" },
                new supplier { id = 2, name = "ЗАО Лотос", contact_phone = "2354341" },
                new supplier { id = 3, name = "ИП Васильев", contact_phone = "65435432" },
            };

            List<product> products = new List<product>
            {
                new product { product_id = 201, product_name = "Монитор" },
                new product { product_id = 202, product_name = "Клавиатура" },
                new product { product_id = 203, product_name = "Мышь" },
                new product { product_id = 204, product_name = "Принтер" },
            };

            List<product_movement> movements = new List<product_movement>
            {
                new product_movement { product_id = 201, supplier_id = 1, prefix = "П", date = new DateTime(2025, 4, 10), quantity = 20, price_per_unit = 5000m },
                new product_movement { product_id = 202, supplier_id = 2, prefix = "П", date = new DateTime(2025, 4, 12), quantity = 50, price_per_unit = 1500m },
                new product_movement { product_id = 203, supplier_id = 3, prefix = "П", date = new DateTime(2025, 4, 13), quantity = 40, price_per_unit = 800m },
                new product_movement { product_id = 201, supplier_id = 1, prefix = "Р", date = new DateTime(2025, 4, 15), quantity = 5, price_per_unit = 5500m },
                new product_movement { product_id = 202, supplier_id = 2, prefix = "Р", date = new DateTime(2025, 4, 16), quantity = 10, price_per_unit = 1600m },
                new product_movement { product_id = 204, supplier_id = 3, prefix = "Р", date = new DateTime(2025, 4, 17), quantity = 2, price_per_unit = 7000m }, 
            };

            var stock = from p in products
                        join m in movements on p.product_id equals m.product_id into pm
                        select new
                        {
                            product_name = p.product_name,
                            quantity_in_stock = pm.Where(x => x.prefix == "П").Sum(x => x.quantity) - pm.Where(x => x.prefix == "Р").Sum(x => x.quantity)
                        };

            Console.WriteLine("Остатки товаров:");
            foreach (var item in stock)
            {
                Console.WriteLine($"{item.product_name}: {item.quantity_in_stock} шт.");
            }

            var products_by_supplier = from m in movements
                                       where m.prefix == "П"
                                       join s in suppliers on m.supplier_id equals s.id
                                       join p in products on m.product_id equals p.product_id
                                       group p by s.name into g
                                       select new
                                       {
                                           supplier_name = g.Key,
                                           products = g.Distinct()
                                       };

            Console.WriteLine("\nТовары по поставщикам (только поступления):");
            foreach (var group in products_by_supplier)
            {
                Console.WriteLine($"Поставщик: {group.supplier_name}");
                foreach (var product in group.products)
                {
                    Console.WriteLine($"  - {product.product_name}");
                }
            }

            var sales_by_date = from m in movements
                                where m.prefix == "Р"
                                join p in products on m.product_id equals p.product_id
                                group new { p.product_name, m.quantity } by m.date.Date into g
                                select new
                                {
                                    date = g.Key,
                                    sales = g.Select(x => new { x.product_name, x.quantity })
                                };

            Console.WriteLine("\nПродажи по датам:");
            foreach (var day in sales_by_date)
            {
                Console.WriteLine($"Дата: {day.date.ToShortDateString()}");
                foreach (var sale in day.sales)
                {
                    Console.WriteLine($"  Товар: {sale.product_name}, Количество: {sale.quantity}");
                }
            }
        }
    }
}
