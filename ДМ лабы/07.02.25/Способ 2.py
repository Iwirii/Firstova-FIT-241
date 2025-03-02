matrix = [[0, 1, 0, 0, 0],
          [1, 0, 1, 0, 0],
          [0, 1, 0, 1, 0],
          [0, 0, 1, 0, 0],
          [0, 0, 0, 0, 0]]
def find_connected_components(matrix):
    num_vertices = len(matrix)
    vertexes = [None] * num_vertices
    vertexes[0] = 1
    component_count = 1

    for i in range(num_vertices):
        for j in range(i):
            if matrix[j][i] == 1:
                if vertexes[i] is not None:
                    vertexes[i] = min(vertexes[i], vertexes[j])
                    vertexes[j] = vertexes[i]
                else:
                    vertexes[i] = vertexes[j]
        if vertexes[i] is None:
            component_count += 1
            vertexes[i] = component_count

    return len(set(vertexes))

print(f'Количество компонент связности графа: {find_connected_components(matrix)}')
