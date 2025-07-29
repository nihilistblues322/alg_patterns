namespace tasks;

class Program
{
    static void Main(string[] args)
    {
        int[] array1 = [8, 3, 4, 7, 9, 12, 15, 21, 6, 11, 5];
        int[] array2 = [8, -3, 4, 7, 9, -12, 15, -21, 6, -11, 5];
        Console.WriteLine(SumAll(array1));
        Console.WriteLine(FindAverage(array1));
        var res = FindMinMax(array1);
        PrintArray(res);

        Console.WriteLine(SumEven(array1));

        var negatives = ReplaceNegative(array2);
        PrintArray(negatives);
    }

    private static int SumAll(int[] array)
    {
        int sum = 0;

        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }

        return sum;
    }


    private static int FindAverage(int[] array)
    {
        int sum = 0;

        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }

        return sum / array.Length;
    }

    private static int[] FindMinMax(int[] array)
    {
        if (array.Length <= 0)
        {
            return [];
        }

        int min = array[0];
        int max = array[0];


        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
            }

            max = Math.Max(array[i], max);
        }

        return [min, max];
    }

    private static int SumEven(int[] array)
    {
        if (array.Length <= 0) return 0;

        int sum = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] % 2 == 0)
            {
                sum += array[i];
            }
        }

        return sum;
        return array.Where(n => n % 2 == 0).Sum();
    }

    private static int[] ReplaceNegative(int[] array)
    {
        if (array.Length <= 0) return [];
        
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                array[i] = -array[i];
            }
        }

        return array;
    }

    static void PrintArray(int[] array)
    {
        if (array.Length == 0)
        {
            Console.WriteLine("[]");
            return;
        }

        Console.WriteLine($"[{string.Join(", ", array)}]");
    }
}