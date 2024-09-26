//Определить все ли элементы последовательности чётные (на вывод да или нет)
using System;
class Task2
{
	static void Main()
	{
		int n, a, b = 0;
		n=Convert.ToInt32(Console.ReadLine());
		for (int i = 0; i < n; i++) 
		{
		    a=Convert.ToInt32(Console.ReadLine());
		if (a % 2 == 0)
		    {
		        b++;
		    }
		}
		if (b == n)
		{
		    Console.WriteLine("Да");
		}
		else
		{
		    Console.WriteLine("Нет");
		}
	}
}
