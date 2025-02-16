matrix = [[0, 1, 0, 0, 1],
          [1, 0, 1, 0, 0],
          [0, 1, 0, 1, 0],
          [0, 0, 1, 0, 1],
          [1, 0, 0, 1, 0]]
cnt_vershin = len(matrix)
visited = [False] * cnt_vershin
cnt=0
for i in range(cnt_vershin):
    if not visited[i]:
        komponenta = []
        queue = [i]
        visited[i] = True
        while len(queue)>0:
            current_vertex = queue.pop(0)
            komponenta.append(current_vertex + 1)
            for j in range(cnt_vershin):
                if matrix[current_vertex][j] == 1 and not visited[j]:
                    queue.append(j)
                    visited[j] = True
        cnt+=1
        print(f"Компонента связности: {komponenta}")
print(f"Количество компонент связности: {cnt}")
