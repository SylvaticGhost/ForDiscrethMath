namespace GraphAnalizer;

public class GraphOperations
{
    private readonly Operations _operations;
    private readonly Functions _functions;

    public GraphOperations()
    {
        _operations = new Operations();
        _functions = new Functions();
    }

    public Matrix CreateFirstDistanceMatrix(Matrix adjacencyMatrix)
    {
        Matrix d = new Matrix(adjacencyMatrix.NumRows, adjacencyMatrix.NumCols);
        List<List<int>> cont = new List<List<int>>();
        cont = adjacencyMatrix.Containing;

        for (int i = 0; i < adjacencyMatrix.NumRows; i++)
        {
            for (int j = 0; j < adjacencyMatrix.NumCols; j++)
            {
                if (i != j && cont[i][j] == 0)
                    cont[i][j] = -1;
            }
        }

        d.Containing = cont;
        return d;
    }

    public Matrix CreateDistanceMatrix(Matrix adjecencyMatrix, Matrix previousD)
    {
        Matrix res = new Matrix(adjecencyMatrix.NumRows, adjecencyMatrix.NumCols);
        List<List<int>> cont = new List<List<int>>();

        for (int i = 0; i < adjecencyMatrix.NumRows; i++)
        {
            List<int> row = new List<int>();
            
            for (int j = 0; j < adjecencyMatrix.NumCols; j++)
            {
                if (previousD.Containing[i][j] < 0)
                {
                    if (adjecencyMatrix.Containing[i][j] > 0)
                        row.Add(adjecencyMatrix.Containing[i][j]);
                        //row.Add(-1);
                    else
                        row.Add(-1);
                }
                else
                    row.Add(adjecencyMatrix.Containing[i][j] + previousD.Containing[i][j]);
            }
            
            cont.Add(row);
        }

        res.Containing = cont;
        return res;
    }

    public Matrix ReachMatrix(List<Matrix> deltas)
    {
        Matrix oneCont = new Matrix(deltas[0].NumRows, deltas[0].NumCols);
        oneCont = oneCont.OneContainingMatrix(deltas[0].NumCols);
        
        deltas.Add(oneCont);

        Matrix result = _operations.SumOfListMatrix(deltas);
        
        result.BooleanTransformation();

        return result;
    }

    public bool CheckOnFullyConnectedGraph(Matrix r)
    {
        Matrix j = new Matrix(r.NumRows, r.NumCols);
        j.FillBySameElement(1);
        r.BooleanTransformation();
        if (r.IsEqualTo(j))
            return true;
        else
            return false;
    }
    
    
    public bool CheckOnPartlyConnectedGraph(Matrix r, Matrix rt)
    {
        Matrix R = _operations.Plus(r, rt);
        R.BooleanTransformation();
        
        Matrix J = new Matrix(r.NumRows, r.NumCols);
        J.FillBySameElement(1);

        if (R.IsEqualTo(J))
            return true;
        else
            return false;
    }


    public bool CheckOnWeakConnectedGraph(Matrix r, int n)
    {
        Matrix rt = r.Transposing();
        
        Matrix j = new Matrix(r.NumRows, r.NumCols);
        j.FillBySameElement(1);
        
        Matrix m = _operations.PowerOfMatrix(_operations.SumOfMatrix(r, rt, j), n - 1);
        m.BooleanTransformation();
         
        if (m.IsEqualTo(j))
            return true;
        else
            return false;

    }
    
}