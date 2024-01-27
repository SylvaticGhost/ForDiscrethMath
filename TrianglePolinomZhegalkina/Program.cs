//Write a values of boolean function to the list
List<int> funcValues = new List<int>{0, 0, 0, 1, 0, 1, 1, 1};

void OutputList(List<List<int>> list)
{
    foreach (List<int> e in list)
    {
        foreach (int i in e )
        {
            Console.Write(i);
        }
        Console.Write("\n");
    }
}

List<int> ReturnIndexWhFirstIs1(List<List<int>> triangle)
{
    List<int> result = new List<int>();
    for (int i = 0; i < triangle.Count; i++)
    {
        if(triangle[i][0] == 1) result.Add(i);
    }

    return result;
}
List<int[]> GenerateSets()
 {
     List<int[]> result = new List<int[]>();
      
     for (int x = 0; x <= 1; x++)
     {
         for (int y = 0; y <= 1; y++)
         {
             for (int z = 0; z <= 1; z++)
             {
                 int[] row = new int[3];
                 row[0] = x;
                 row[1] = y;
                 row[2] = z;
                 result.Add(row);
             }
         }
     }

     return result;
 }

string polinom = "";
//набори значень
 List<int[]> sets = GenerateSets();
 List<List<int>> triangle = new List<List<int>>();
 triangle.Add(funcValues);
int i = 0;
 

while (triangle.Last().Count() > 1)
{
    List<int> row = new List<int>();
    triangle.Add(row);
    for (int j = 0; j < triangle[i].Count - 1; j++)
    {
        triangle[i + 1].Add(triangle[i][j]^triangle[i][j + 1]);
    }
  
     
    i++;
}


OutputList(triangle);

List<int> index = ReturnIndexWhFirstIs1(triangle);
int len = 0;
foreach (int j in index)
{
    len = polinom.Length;
    if (sets[j][0] == 1) polinom += 'x';
    if (sets[j][1] == 1) polinom += 'y';
    if (sets[j][2] == 1) polinom += 'z';

    if (polinom.Length > len) polinom += " ^ ";
    
}

Console.WriteLine(polinom);
