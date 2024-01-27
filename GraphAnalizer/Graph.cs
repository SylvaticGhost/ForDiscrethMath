using System.Collections;

namespace GraphAnalizer;

public class Graph
{
    public Hashtable ListOfEdges;
    private int _numEdges;
    private Matrix _adjacencyMatrix;
    public int NumVertices;
    private Matrix _incidentMatrix;
    private readonly Functions _functions;
    
    public Graph(Hashtable l, int vrt)
    {
        ListOfEdges = l;
        _numEdges = l.Count;
        NumVertices = vrt;
        _functions = new Functions();
        _adjacencyMatrix = _CreateAdjacencyMatrix();
        _incidentMatrix = _CreateIncidentMatrix();
    }

    /// <summary>
    /// Initialize a graph by setting a list of edges
    /// </summary>
    public void Initialize()
    {
        string row = " ";
        Console.WriteLine(@"Write an edge by writing a number of the vertix, Example: 1 21
        After ending send a empty string to stop writing edges");
        while (true)
        {
            row = Console.ReadLine();
            
            if(row.Length > 1)
                AddEdge(row);
            else
                break;
        }
        
    }


    public void RecountNumEdges()
    {
        _numEdges = ListOfEdges.Count;
    }

    private void AddEdge(string t)
    {
        string[] vertices = t.Split(" ");

        int v1 = int.Parse(vertices[0]);
        int v2 = int.Parse(vertices[1]);
        
        
        if (vertices.Length > 1)
        {
            int[] vert = new [] { v1, v2 };
            ListOfEdges.Add(_numEdges + 1, vert);
            _numEdges++;
        }
        else
        {
            Console.WriteLine("Failed to add edge");
            return;
        }
        
        Console.WriteLine("Added the edge: v"+v1+"v"+v2);
        
    }

    public void WriteListOfEdges()
    {
        Console.WriteLine("List of edges:");
        RecountNumEdges();
        for (int i = 1; i <= _numEdges; i++)
        {
            int[]? vertices = (int[])ListOfEdges[i];
            
            if(vertices.Length == 2)
                Console.WriteLine("v"+vertices[0]+"v"+vertices[1]);
            else
                Console.WriteLine("Empty");
        }
        Console.WriteLine();
    }


    private Matrix _CreateAdjacencyMatrix()
    {
        Matrix result = new Matrix(NumVertices, NumVertices);
        List<List<int>> cont = new List<List<int>>();
        
        for (int i = 0; i < NumVertices; i++)
        {
            List<int> row = new List<int>();
            
            for(int j = 0; j < NumVertices; j++)
                row.Add(0);
            
            cont.Add(row);
        }

        for (int i = 1; i <= _numEdges; i++)
        {
            int[]? cords = (int[])ListOfEdges[i];

            cont[cords[0] - 1][cords[1] - 1] = 1;
        }

        result.Containing = cont;
        
        return result;
    }


    public void PrintAdjacencyMatrix()
    {
        Console.WriteLine("AdjacencyMatrix:");
        _adjacencyMatrix.Print();
        Console.WriteLine();
    }


    private Matrix _CreateIncidentMatrix()
    {
        Matrix result = new Matrix(NumVertices, _numEdges);
        List<List<int>> cont = new List<List<int>>();

        for (int i = 0; i < NumVertices; i++)
        {
            List<int> row = new List<int>();
            
            for (int j = 0; j < _numEdges; j++)
            {
                row.Add(0);
            }
            cont.Add(row);
        }

        for (int i = 1; i <= _numEdges; i++)
        {
            int[]? cords = (int[])ListOfEdges[i];

            cont[cords[0] - 1][cords[1] - 1] = -1;
            cont[cords[1] - 1][cords[0] - 1] = 1;
        }

        result.Containing = cont;
        return result;
    }

    
    public void PrintIncidentMatrix()
    {
        Console.WriteLine("Incident matrix:");
        _incidentMatrix.Print();
        Console.WriteLine();
    }
    
    
    public void CountDPlus()
    {
        List<int> result = new List<int>();

        for (int j = 0; j < _adjacencyMatrix.Containing[0].Count; j++)
        {
            int s = 0;

            for (int i = 0; i < _adjacencyMatrix.Containing.Count; i++)
                s += _adjacencyMatrix.Containing[i][j];
            
            result.Add(s);
        }
        
        Console.WriteLine("Dplus: " + _functions.ListToString<int>(result));
    }


    public void CountDMinus()
    {
        List<int> result = new List<int>();

        foreach (List<int> row in _adjacencyMatrix.Containing)
            result.Add(_functions.SumOfList(row));
        
        Console.WriteLine("DMinus: " + _functions.ListToString<int>(result));
    }


    public Matrix GetAdjacencyMatrix()
    {
        return _adjacencyMatrix;
    }
    
    
}