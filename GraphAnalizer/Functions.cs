namespace GraphAnalizer;

public class Functions
{
    public Functions() {}

    public string ListToString<T>(List<T?> list)
    {
        string result = string.Empty;

        foreach (var e in list)
        {
            result = result + e.ToString() + " ";
        }

        return result;
    }


    public int SumOfList(List<int> list)
    {
        int s = 0;
        
        foreach (int i in list)
        {
            s += i;
        }

        return s;
    }


    public int BooleanTransformation(double x)
    {
        if (x > 0)
            return 1;

        return 0;
    }
}