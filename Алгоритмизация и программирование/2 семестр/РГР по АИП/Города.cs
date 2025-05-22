using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите количество городов и дорог через пробел:");
        string[] first_line = Console.ReadLine().Split();
        int city_count = int.Parse(first_line[0]);
        int road_count = int.Parse(first_line[1]);

        int INF = 1000 * city_count + 1;
        int[,] shortest_distance = new int[city_count, city_count];

        for (int i = 0; i < city_count; i++)
            for (int j = 0; j < city_count; j++)
                shortest_distance[i, j] = (i == j) ? 0 : INF;

        Console.WriteLine($"Введите {road_count} дорог в формате: номер_города_1 номер_города_2 длина_дороги");
        for (int i = 0; i < road_count; i++)
        {
            string[] road_info = Console.ReadLine().Split();
            int city_a = int.Parse(road_info[0]) - 1;
            int city_b = int.Parse(road_info[1]) - 1;
            int road_length = int.Parse(road_info[2]);

            if (road_length < shortest_distance[city_a, city_b])
            {
                shortest_distance[city_a, city_b] = road_length;
                shortest_distance[city_b, city_a] = road_length;
            }
        }

        // Алгоритм Флойда-Уоршелла
        for (int k = 0; k < city_count; k++)
            for (int i = 0; i < city_count; i++)
                for (int j = 0; j < city_count; j++)
                    if (shortest_distance[i, k] + shortest_distance[k, j] < shortest_distance[i, j])
                        shortest_distance[i, j] = shortest_distance[i, k] + shortest_distance[k, j];

        int max_distance = 0;
        for (int i = 0; i < city_count; i++)
            for (int j = 0; j < city_count; j++)
                if (shortest_distance[i, j] > max_distance && shortest_distance[i, j] < INF)
                    max_distance = shortest_distance[i, j];

        Console.WriteLine("Наибольшее расстояние между городами в стране:");
        Console.WriteLine(max_distance);
    }
}
