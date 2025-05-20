using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите широту и долготу первого города в градусах");
        string[] line1 = Console.ReadLine().Split();
        Console.WriteLine("Введите широту и долготу второго города в градусах");
        string[] line2 = Console.ReadLine().Split();
        Console.WriteLine("Введите радиус планеты");
        int R = int.Parse(Console.ReadLine());

        int S1 = int.Parse(line1[0]);
        int D1 = int.Parse(line1[1]);
        int S2 = int.Parse(line2[0]);
        int D2 = int.Parse(line2[1]);

        double lat1 = S1 * Math.PI / 180.0;
        double lon1 = D1 * Math.PI / 180.0;
        double lat2 = S2 * Math.PI / 180.0;
        double lon2 = D2 * Math.PI / 180.0;

        double cos_c = Math.Sin(lat1) * Math.Sin(lat2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(Math.Abs(lon1 - lon2));

        cos_c = Math.Max(-1.0, Math.Min(1.0, cos_c));
        double centralAngle = Math.Acos(cos_c);

        double distance = R * centralAngle;

        Console.WriteLine(distance.ToString("F3", CultureInfo.InvariantCulture));
    }
}
