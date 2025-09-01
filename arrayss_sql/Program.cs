namespace arrayss_sql;

class Program
{
    static void Main(string[] args)
    {
        //  1-------------------------------------------------------
        var clientsA = new int[] { 1, 2, 3, 4, 5 };
        var clientsB = new int[] { 6, 7, 8, 9, 10 };

        var clientsAstring = new string[] { "a", "b", "c", "d" };
        var clientsBstring = new string[] { "z", "x", "v", "g" };


        PrintArray(IMerge(clientsA, clientsB));
        PrintArray(DMerge(clientsA, clientsB));

        PrintArray(IMerge(clientsAstring, clientsBstring));
        PrintArray(DMerge(clientsAstring, clientsBstring));
        //-------------------------------------------------------
    }

    // int ---------------------------------
    static List<T> IMerge<T>(T[] a, T[] b)
    {
        var result = new List<T>();

        foreach (var c in a)
        {
            result.Add(c);
        }

        foreach (var c in b)
        {
            result.Add(c);
        }

        return result;
    }

    static List<T> DMerge<T>(T[] a, T[] b)
    {
        var res = a.Concat(b).ToList();

        return res;
    }

    // ----------------------------------------------------------


    static void PrintArray(List<int> array)
    {
        if (array.Count == 0)
        {
            Console.WriteLine("[]");
            return;
        }

        Console.WriteLine($"[{string.Join(", ", array)}]");
    }

    static void PrintArray(List<string> array)
    {
        if (array.Count == 0)
        {
            Console.WriteLine("[]");
            return;
        }

        Console.WriteLine($"[{string.Join(", ", array)}]");
    }
}