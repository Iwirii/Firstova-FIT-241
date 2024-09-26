//Переменные целого типа. Из двух вводимых переменных выдать наибольшее и наименьшее значение. Нельзя использовать сравнения, встроенные функции, конструкция if.
using System;

class Task2
{
	static void Main()
	{
		int a, b, naib, naim;
		a = Convert.ToInt32(Console.ReadLine());
		b = Convert.ToInt32(Console.ReadLine());
		naib = (a + b + Math.Abs(a-b)) / 2;
		naim = (a + b - Math.Abs(a-b)) / 2;
		Console.WriteLine(naib);
		Console.WriteLine(naim);
	}
}
