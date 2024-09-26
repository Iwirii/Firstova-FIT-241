//N штук грядок. У каждой есть ширина и высота. Имеется колодец и расстояние от него. Определить путь, который мы пройдем при поливе всех грядок (проходим по периметру грядки и возвращаемся в колодец). Без цикла for.
using System;
class Task1
{
	static void Main()
	{
		int n, l, m, p, otvet;
		Console.WriteLine("Введите кол-во грядок:");
		n = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Введите ширину грядки:");
		l = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Введите длину грядки:");
		m = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Введите расстояние от колодца до первой грядки:");
		p = Convert.ToInt32(Console.ReadLine());
		otvet = (2 * p * n) + (m + l + m) * n + l * n * n;
		Console.WriteLine(otvet);
	}
}
