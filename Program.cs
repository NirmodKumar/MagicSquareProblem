var lst = new List<int> { 4, 9, 2, 3, 5, 7, 8, 1, 5 };

var response = Wrapper(lst);

Console.WriteLine(response);

int Wrapper(List<int> lst)
{
    var res = int.MaxValue;

    var magicSquares = FindMagicSquare();

    foreach (var magicSquare in magicSquares)
    {
        res = Math.Min(res, Diff(lst, magicSquare));
    }

    return res;
}

int Diff(List<int> lst, List<int> magicSquare)
{
    return lst.Select((x, i) => Math.Abs(x - magicSquare[i]))
    .Sum();
}

List<List<int>> FindMagicSquare()
{
    var magicSquares = new List<List<int>>();

    var lst = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    var permu = Permutations(lst);

    foreach (var per in permu)
    {
        if (IsMagicSquare(per))
        {
            magicSquares.Add(per);
        }
    }

    return magicSquares;
}

bool IsMagicSquare(List<int> lst)
{
    int[][] a = { new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 } };

    // Convert list into 3 X 3 matrix
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            a[i][j] = lst[3 * i + j];
        }
    }

    int s = a[0].Sum();

    // Checking if each row sum is same
    for (int i = 1; i < 3; i++)
    {
        var temp = a[i].Sum();
        if (temp != s)
        {
            return false;
        }
    }


    // Checking if each column sum is same
    for (int j = 0; j < 3; j++)
    {
        var temp = a.Sum(row => row[j]);
        if (temp != s)
        {
            return false;
        }
    }

    // Checking if diagonal 1 sum is same
    var ds1 = a[0][0] + a[1][1] + a[2][2];
    if (ds1 != s)
    {
        return false;
    }

    // Checking if diagonal 2 sum is same
    var ds2 = a[0][2] + a[1][1] + a[2][0];
    if (ds2 != s)
    {
        return false;
    }


    return true;
}

static IEnumerable<List<int>> Permutations(List<int> lst)
{
    if (lst.Count <= 1)
    {
        yield return lst;
    }
    else
    {
        foreach (var perm in Permutations(lst.Skip(1).ToList()))
        {
            for (int i = 0; i < lst.Count; i++)
            {
                yield return perm.Take(i)
                .Concat(new List<int> { lst[0] })
                .Concat(perm.Skip(i))
                .ToList();
            }
        }
    }
}

static int formingMagicSquare(List<List<int>> s)
{
    int res = int.MaxValue;
    int[][] magicArrays = { new int[] { 8, 1, 6, 3, 5, 7, 4, 9, 2 }, new int[] { 4, 3, 8, 9, 5, 1, 2, 7, 6 }, new int[] { 2, 9, 4, 7, 5, 3, 6, 1, 8 }, new int[] { 6, 7, 2, 1, 5, 9, 8, 3, 4 }, new int[] { 6, 1, 8, 7, 5, 3, 2, 9, 4 }, new int[] { 8, 3, 4, 1, 5, 9, 6, 7, 2 }, new int[] { 4, 9, 2, 3, 5, 7, 8, 1, 6 }, new int[] { 2, 7, 6, 9, 5, 1, 4, 3, 8 } };
    var lst = s.SelectMany(x => x.Select(y => y)).ToList();
    foreach (var magicSquare in magicArrays)
    {
        var difference = lst.Select((x, i) => Math.Abs(x - magicSquare[i]))
    .Sum();
        res = Math.Min(res, difference);
    }

    return res;
}
