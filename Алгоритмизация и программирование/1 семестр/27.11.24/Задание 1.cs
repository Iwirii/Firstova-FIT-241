//Создаем класс, где будет 2 переменных целого типа (2 поля в самом классе инт). 
//Конструкторы будут следующие: конструктор по умолчанию (без аргумента), конструктор который принимает 1 объект для инициализации, 
//конструктор которые принимает 2 объекта.
//Если конструктор идет по умолчанию, необходимо проинициализировать нулями. Когда 1 значение, второе значение проинициализировать нулем. 
//Записать 4 метода. 
//1)	Суммирование двух переменных класса
//2)	Произведение 2 переменных класса
//3)	Разность
//4)	Деление первого аргумента на второй, проверить деление на 0(вывести невозможно)
using System;
namespace Test
{
    class Numbers
    {
        public int arg1;
        public int arg2;
        public Numbers(int Arg1, int Arg2)
        {
            arg1 = Arg1;
            arg2 = Arg2;
        }
        public Numbers(int Arg1)
        {
            arg1 = Arg1;
            arg2 = 0;
        }
        public Numbers()
        {
            arg1 = 0;
            arg2 = 0;
        }
        public void Summa()
        {
            Console.WriteLine($"Сумма:{arg1 + arg2}");
        }
        public void Proizvedenie()
        {
            Console.WriteLine($"Произведение:{arg1 * arg2}");
        }
        public void Raznost()
        {
            Console.WriteLine($"Разность:{arg1 - arg2}");
        }
        public void Delenie()
        {
            if (arg2 == 0)
            {
                Console.WriteLine("Делить на 0 нельзя");
            }
            else
            {
                Console.WriteLine($"Частное:{arg1 / arg2}");
            }
        }
        static void Main()
        {
            int a = 124;
            int b = 2;

            Numbers test1 = new Numbers(a,b);
            test1.Summa();
            test1.Proizvedenie();
            test1.Raznost();
            test1.Delenie();
            Console.WriteLine();

            Numbers test2 = new Numbers(a);
            test2.Summa();
            test2.Proizvedenie();
            test2.Raznost();
            test2.Delenie();
            Console.WriteLine();

            Numbers test3 = new Numbers();
            test3.Summa();
            test3.Proizvedenie();
            test3.Raznost();
            test3.Delenie();
            Console.WriteLine();
        }
    }
}
