#Алгоритм Флойда
graph = [
    [0, 3, 0, 5],
    [3, 0, 1, 0],
    [0, 1, 0, 2],
    [5, 0, 2, 0]
]
n = len(graph)
for k in range(n):
    for i in range(n):
        for j in range(n):
            if graph[i][k] != 0 and graph[k][j] != 0:
                if graph[i][j] == 0 or graph[i][j] > graph[i][k] + graph[k][j]:
                    graph[i][j] = graph[i][k] + graph[k][j]

print("  ", end="")
for v in range(1, n + 1):
    print(v, end=" ")
print()
for i in range(n):
    print(i + 1, end=" ")
    for j in range(n):
        if graph[i][j] == 0:
            print("-", end=" ")
        else:
            print(graph[i][j], end=" ")
    print()
