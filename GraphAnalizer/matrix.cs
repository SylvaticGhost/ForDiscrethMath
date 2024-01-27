namespace GraphAnalizer;

public class Matrix
{
    public List<List<int>> Containing { get; set; }
    /// <summary>
    /// Number of rows in the matrix
    /// </summary>
    public int NumRows { get; set; }
    
    /// <summary>
    /// Numbers of columns in the matrix
    /// </summary>
    public int NumCols { get; set; }
    
    
    private int CurrentRow { get; set; }
    private int CurrentColumn { get; set; }
    private readonly Functions _functions;
    
    public Matrix(int r, int c)
    {
        this.NumCols = c;
        this.NumRows = r;
        CurrentRow = 0;
        CurrentColumn = 0;
        _functions = new Functions();
    }

    
    public void Print()
    {
        foreach (var row in Containing)
        {
            foreach (var e in row)
            {
                Console.Write(e.ToString() + " ");
            }
            Console.Write("\n");
        }
    }

    
    public string GetSize()
    {
        return "Size: " + NumRows + "x" + NumCols;
    }

    
    public List<int> GetCurrentRow()
    {
        return Containing[CurrentRow];
    }

    
    public bool NextRow()
    {
        if (CurrentRow < NumRows - 1)
        {
            CurrentRow++;
            return true;
        }

        return false;
    }

    
    public List<int> GetCurrentColumn()
    {
        List<int> column = new List<int>();

        for (int i = 0; i < NumRows; i++)
        {
            column.Add(Containing[i][CurrentColumn]);
        }

        return column;
    }

    
    public bool NextColumn()
    {
        if (CurrentColumn < NumCols - 1)
        {
            CurrentColumn++;
            return true;
        }

        return false;
    }

    
    public void GoToFirstRow()
    {
        CurrentRow = 0;
    }


    public void GoToFirstColumn()
    {
        CurrentColumn = 0;
    }


    public void ResetPosition()
    {
        GoToFirstColumn();
        GoToFirstRow();
    }


    public bool DiagonalIsZeroContaining()
    {
        for(int i = 0; i < Containing.Count; i++)
            if (Containing[i][i] != 0)
                return false;

        return true;
    }


    public Matrix ZeroContainingMatrix(int r, int c)
    {
        Matrix result = new Matrix(r, c);
        List<List<int>> cont = new List<List<int>>();

        for (int i = 0; i < r; i++)
        {
            List<int> row = new List<int>();

            for (int j = 0; j < c; j++)
            {
                row.Add(0);
            }
            
            cont.Add(row);
        }

        result.Containing = cont;
        return result;
    }


    public Matrix OneContainingMatrix(int size)
    {
        Matrix result = ZeroContainingMatrix(size, size);
        List<List<int>> cont = result.Containing;

        for (int i = 0; i < size; i++)
            cont[i][i] = 1;

        result.Containing = cont;
        return result;
    }
    
    public void BooleanTransformation()
    {
        for (int i = 0; i < NumRows; i++)
        {
            for (int j = 0; j < NumCols; j++)
                Containing[i][j] = _functions.BooleanTransformation(Containing[i][j]);
        }
    }


    public Matrix Transposing()
    {
        ResetPosition();
        Matrix res = new Matrix(NumCols, NumRows);
        List<List<int>> cont = new List<List<int>>();

        do
        {
            cont.Add(GetCurrentColumn());
        } while (NextColumn());

        ResetPosition();
        res.Containing = cont;
        return res;
    }


    public bool IsEqualTo(Matrix b)
    {
        if (NumRows == b.NumRows && NumCols == b.NumCols)
        {
            for (int i = 0; i < NumRows; i++)
            {
                for (int j = 0; j < NumCols; j++)
                {
                    if (Containing[i][j] != b.Containing[i][j])
                        return false;
                    
                }
            }

            return true;
        }

        return false;
    }


    public void FillBySameElement(int e)
    {
        List<List<int>> cont = new List<List<int>>();

        for (int i = 0; i < NumRows; i++)
        {
            List<int> row = new List<int>();
            for(int j = 0; j < NumCols; j++)
                row.Add(e);
            
            cont.Add(row);
        }

        Containing = cont;
    }


    // public override string ToString()
    // {
    //     string res = "";
    //
    //     foreach (List<int> row in Containing)
    //     {
    //         foreach (int e in row)
    //         {
    //             res += e + " ";
    //         }
    //     }
    // }
}