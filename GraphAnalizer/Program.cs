using System.Collections;
using GraphAnalizer;

#region Declaration

Operations operations = new Operations();
GraphOperations graphOperations = new GraphOperations();
Hashtable gr = new Hashtable();

//Describing a graph by adding edges to the table below

gr.Add(1, new int[] {1, 2});
gr.Add(2, new int[] {1, 3});
gr.Add(3, new int[] {3, 4});
gr.Add(4, new int[] {2, 5});
gr.Add(5, new int[] {3, 6});
gr.Add(6, new int[] {4, 6});
gr.Add(7, new int[] {5, 6});
gr.Add(8, new int[] {5, 7});
gr.Add(9, new int[] {6, 7});
gr.Add(10, new int[] {7, 8});
gr.Add(11, new int[] {6, 8});

Graph graph1 = new Graph(gr, 8);

#endregion

#region Main
List<Matrix> deltas = new List<Matrix>();
Console.WriteLine("Adjacency matrix");
deltas.Add(graph1.GetAdjacencyMatrix());
deltas.Last().Print();
Console.WriteLine();

for (int j = 2; j <= 5; j++)
{
    Console.WriteLine(j+" power of adjacency matrix");
    deltas.Add(operations.PowerOfMatrix(graph1.GetAdjacencyMatrix(), j));
    deltas.Last().Print();
    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine();

int i = 1;
Stack<Matrix> distances = new Stack<Matrix>();
Console.WriteLine(i + ")D: ");
 
distances.Push(graphOperations.CreateFirstDistanceMatrix(deltas[i - 1]));
distances.First().Print();

i++;
Console.WriteLine();

// distances.Push(graphOperations.CreateDistanceMatrix(deltas[i - 1], distances.Last()));
// distances.First().Print();
// i++;
// Console.WriteLine();

while (i <= 3)
{
    distances.Push(graphOperations.CreateDistanceMatrix(deltas[i - 1], distances.First()));
    Console.WriteLine(i + ") D=");
    distances.First().Print();
    Console.WriteLine()
        ;
    i++;
}

Matrix m = new Matrix(graph1.NumVertices, graph1.NumVertices);
m = m.OneContainingMatrix(graph1.NumVertices);
deltas.Add(m);




//r
Matrix r = operations.SumOfListMatrix(deltas);
Console.WriteLine("SUM");
r.Print();
r.BooleanTransformation();
Console.WriteLine("R:");
r.Print();

Console.WriteLine();
Console.WriteLine();

Console.WriteLine("R transposed");
r.Transposing().Print();
Console.WriteLine();

Console.WriteLine("Is graph fully linked");
Console.WriteLine(graphOperations.CheckOnFullyConnectedGraph(r));
Console.WriteLine();

Console.WriteLine("Is partly fully linked:");
Console.WriteLine(graphOperations.CheckOnPartlyConnectedGraph(r, r.Transposing()));
Console.WriteLine();

Console.WriteLine("Check if graph is weakly connected");
Console.WriteLine(graphOperations.CheckOnWeakConnectedGraph(r, graph1.NumVertices - 1));


//Console.WriteLine("Check for weakly connected graph");
#endregion