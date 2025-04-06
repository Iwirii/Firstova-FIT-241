#Алгоритм Форда-Беллмана
graph = [
    [0, 1, 0, 0, 3],
    [0, 0, 8, 7, 1],
    [0, 0, 0, 1, -5],
    [0, 0, 2, 0, 0],
    [0, 0, 0, 4, 0]
]

num_vertices = len(graph)
start_vertex = int(input("Введите номер начальной вершины (от 1 до " + str(num_vertices) + "): ")) - 1
distances = [float('inf')] * num_vertices
distances[start_vertex] = 0

for _ in range(num_vertices - 1):
    for u in range(num_vertices):
        for v in range(num_vertices):
            if graph[u][v] != 0:
                if distances[u] + graph[u][v] < distances[v]:
                    distances[v] = distances[u] + graph[u][v]
for u in range(num_vertices):
    for v in range(num_vertices):
        if graph[u][v] != 0:
            if distances[u] + graph[u][v] < distances[v]:
                print("Обнаружен отрицательный цикл")
                exit()

print("Кратчайшие расстояния от вершины", start_vertex + 1)
for i in range(num_vertices):
    if distances[i] == float('inf'):
        print("Вершина", i + 1, ": Недостижима")
    else:
        print("Вершина", i + 1, ":", distances[i])
