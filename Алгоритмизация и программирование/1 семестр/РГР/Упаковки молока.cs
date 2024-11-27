using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите количество фирм(n):");
        int n = Convert.ToInt32(Console.ReadLine());
        double minprice = int.MaxValue;
        int index = 0;
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите 6 целых чисел: x1, y1, z1, x2, y2, z3 - размеры двух упаковок {i+1}-ой фирмы в см, и c1, c2 - их стоимость");
            var znacheniya = Console.ReadLine().Replace('.', ',').Split();
            int x1 = Convert.ToInt32(znacheniya[0]);
            int y1 = Convert.ToInt32(znacheniya[1]);
            int z1 = Convert.ToInt32(znacheniya[2]);
            int x2 = Convert.ToInt32(znacheniya[3]);
            int y2 = Convert.ToInt32(znacheniya[4]);
            int z2 = Convert.ToInt32(znacheniya[5]);
            float c1 = float.Parse(znacheniya[6]);
            float c2 = float.Parse(znacheniya[7]);

            int s1 = 2 * (x1 * y1 + y1 * z1 + x1 * z1);
            int s2 = 2 * (x2 * y2 + y2 * z2 + x2 * z2);

            int v1 = x1 * y1 * z1;
            int v2 = x2 * y2 * z2;

            double milkprice = 1000 * (c2 - c1 * s2 / s1) / (v2 - v1 * s2 / s1);
            if (milkprice<minprice)
            {
                minprice = milkprice;
                index = i;
            }
            if (milkprice == minprice)
            {
                index = Math.Min(index,i);
            }
        }
        Console.WriteLine($"Номер фирмы и стоимость 1 литра:{index + 1} {minprice:0.00}");
    }
}
