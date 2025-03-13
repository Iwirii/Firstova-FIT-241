#Алгоритм Прима
def prim(graph, start_vertex):
    num_vertices = len(graph)
    visited = [False] * num_vertices
    visited[start_vertex - 1] = True
    total_weight = 0
    while sum(visited) < num_vertices:
        min_weight = float('inf')
        min_edge = None
        for i in range(num_vertices):
            if visited[i]:
                for j in range(num_vertices):
                    if not visited[j] and graph[i][j] > 0 and graph[i][j] < min_weight:
                        min_weight = graph[i][j]
                        min_edge = (i, j)
        if min_edge is None:
            break
        total_weight += min_weight
        visited[min_edge[1]] = True
    return total_weight
graph = [
    [0, 2, 0, 6, 0, 0],
    [2, 0, 3, 8, 5, 0],
    [0, 3, 0, 0, 7, 0],
    [6, 8, 0, 0, 9, 4],
    [0, 5, 7, 9, 0, 1],
    [0, 0, 0, 4, 1, 0]
]
print("Введите номер отправной вершины от 1 до", len(graph), ":")
start_vertex = int(input())
total_weight = prim(graph, start_vertex)
print(f"Вес минимального остовного дерева: {total_weight}")
