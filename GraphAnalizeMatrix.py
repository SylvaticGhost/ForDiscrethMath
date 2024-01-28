from typing import List


def print_matrix(matrix: List[List[int]]):
    for row in matrix:
        print(row)


def sum(list: List[int]) -> int:
    sum = 0
    for a in list:
        sum += a
    return sum


graph = {1: [1, 2],
         2: [1, 3],
         3: [2, 3],
         4: [2, 4],
         5: [4, 3],
         6: [3, 6],
         7: [4, 7],
         8: [5, 7],
         9: [5, 6],
         10: [5, 8],
         11: [7, 8],
         12: [6, 8]}


v: int = 8


def count_d_plus(matrixS: List[List[int]]) -> List[int]:
    result: List[int] = []

    for j in range(len(matrixS[0])):
        s: int = 0
        for i in range(len(matrixS)):
            s += matrixS[i][j]
        result.append(s)

    return result


#Incident matrix
matrixI = []
for i in range(0, v):
    row = []
    for j in range(0, len(graph)):
        row.append(0)
    matrixI.append(row)


for i in range(1, len(graph) + 1):
    cords: List[int] = graph[i]
    matrixI[cords[0] - 1][i - 1] = -1
    matrixI[cords[1] - 1][i - 1] = 1
print("матриця інцидентності")
print_matrix(matrixI)


#Matrix s
print("Матриця суміжності")
matrixS: List[List[int]] = []
for i in range(0, v):
    row = []
    for j in range(0, v):
        row.append(0)
    matrixS.append(row)

for i in range(1, len(graph) + 1):
    cords: List[int] = graph[i]
    matrixS[cords[0] - 1][cords[1] - 1] = 1

print_matrix(matrixS)

#півстепені
print("Визначення півстепенів")
d_plus = []
d_minus = []
for row in matrixS:
    d_minus.append(sum(row))
print("d-:")
print(d_minus)

print("d+")
print(count_d_plus(matrixS))