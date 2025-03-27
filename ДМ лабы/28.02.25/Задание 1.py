//Алгоритм дейкстры, вывести в программе кратчайший путь от одной заданной точки до другой
graph = [
    [0, 7, 9, 0, 0, 14],
    [7, 0, 10, 15, 0, 0],
    [9, 10, 0, 11, 0, 2],
    [0, 15, 11, 0, 6, 0],
    [0, 0, 0, 6, 0, 9],
    [14, 0, 2, 0, 9, 0]
]
cnt_of_vertex = len(graph)
start = int(input(f"Введите начальную точку (1-{cnt_of_vertex}): ")) - 1
end = int(input(f"Введите конечную точку (1-{cnt_of_vertex}): ")) - 1
visited = [False] * cnt_of_vertex
dist = [float('inf')] * cnt_of_vertex
prev = [None] * cnt_of_vertex
dist[start] = 0
for _ in range(cnt_of_vertex):
    min_dist = float('inf')
    u = -1
    for i in range(cnt_of_vertex):
        if not visited[i] and dist[i] < min_dist:
            min_dist = dist[i]
            u = i
    visited[u] = True
    for v in range(cnt_of_vertex):
        if graph[u][v] > 0 and not visited[v]:
            alt = dist[u] + graph[u][v]
            if alt < dist[v]:
                dist[v] = alt
                prev[v] = u
short_path = []
current = end
while current is not None:
    short_path.append(current+1)
    current = prev[current]
short_path.reverse()
if dist[end] < float('inf'):
    print(f"Кратчайший путь от {start+1} до {end+1}: {' -> '.join(map(str, short_path))} с расстоянием {dist[end]}")
else:
    print(f"Нет пути от {start+1} до {end+1}")
