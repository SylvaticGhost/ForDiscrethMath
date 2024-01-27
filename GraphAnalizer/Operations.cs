namespace GraphAnalizer;

/// <summary>
/// Contain the binary operation on matrixs
/// </summary>
public class Operations
{
    public Operations() { }

    public Matrix Multiply(Matrix a, Matrix b)
    {
        List<List<int>> cont = new List<List<int>>();
        Matrix res = new Matrix(b.NumCols, a.NumRows);

        do
        {
            List<int> r = a.GetCurrentRow();
            List<int> newRow = new List<int>();
            
            do
            {
                int s = 0;
                List<int> c = b.GetCurrentColumn();

                for (int i = 0; i < a.NumCols; i++)
                    s += r[i] * c[i];
                newRow.Add(s);
                
            } while (b.NextColumn());
            cont.Add(newRow);
            b.GoToFirstColumn();
            
        } while (a.NextRow());

        a.ResetPosition();
        b.ResetPosition();
        
        res.Containing = cont;
        return res;
    }


    public Matrix PowerOfMatrix(Matrix a, int power)
    {
        //Matrix res = new Matrix(a.NumRows, a.NumCols);
        Matrix res = Multiply(a, a);
        for (int i = 2; i < power; i++)
        {
            res = Multiply(res, a);
        }

        return res;
    }

    public Matrix Plus(Matrix a, Matrix b)
    {
        if (a.NumRows == b.NumRows && a.NumCols == b.NumCols)
        {
            Matrix result = new Matrix(a.NumRows, a.NumCols);
            List<List<int>> cont = new List<List<int>>();

            for (int i = 0; i < a.NumRows; i++)
            {
                List<int> row = new List<int>();

                for (int j = 0; j < a.NumCols; j++)
                    row.Add(a.Containing[i][j] + b.Containing[i][j]);
                    
                cont.Add(row);
            }

            result.Containing = cont;
            return result;
        }

        throw new Exception("Matrix must have the same size");
    }

    public Matrix SumOfListMatrix(List<Matrix> list)
    {
        Matrix a = list[0];
        for (int i = 1; i < list.Count; i++)
            a = Plus(a, list[i]);

        return a;
    }

    public Matrix SumOfMatrix(params Matrix[] arr)
    {
        Matrix a = arr[0];
        for (int i = 1; i < arr.Length; i++)
            a = Plus(a, arr[i]);

        return a;
    }
    
   
}