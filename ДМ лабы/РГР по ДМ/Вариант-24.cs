def find_max_shortest_path(N, graph):
    dist = [[float('inf')] * N for _ in range(N)]

    for i in range(N):
        for j in range(N):
            if i == j:
                dist[i][j] = 0
            elif graph[i][j] != 0:
                dist[i][j] = graph[i][j]

    for k in range(N):
        for i in range(N):
            for j in range(N):
                if dist[i][j] > dist[i][k] + dist[k][j]:
                    dist[i][j] = dist[i][k] + dist[k][j]

    max_dist = 0
    for i in range(N):
        for j in range(N):
            if dist[i][j] != float('inf') and dist[i][j] > max_dist:
                max_dist = dist[i][j]

    return max_dist

N = int(input())
graph = []
for _ in range(N):
    row = list(map(int, input().split()))
    graph.append(row)

result = find_max_shortest_path(N, graph)
print(result)
