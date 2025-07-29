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

        var negatives2 = ReplaceNegativeOnZero([8, -3, 4, 7, 9, -12, 15, -21, 6, -11, 5]);
        PrintArray(negatives2);

        var reverse = ReverseArray([8, 3, 4, 7, 9, 12, 15, 21, 6, 11, 5]);
        PrintArray(reverse);

        var reversePlace = ReverseArrayInPlace([8, 3, 4, 7, 9, 12, 15, 21, 6, 11, 5]);
        PrintArray(reversePlace);

        // string input = Console.ReadLine();
        // int target = int.Parse(input);
        // int count = NumSum(target, array1);
        // Console.WriteLine(count);
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

    private static int[] ReplaceNegativeOnZero(int[] array)
    {
        if (array.Length <= 0) return [];

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                array[i] = 0;
            }
        }

        return array;
    }

    private static List<int> ReverseArray(int[] array)
    {
        if (array.Length <= 0) return new List<int>();

        List<int> reversed = new List<int>();

        for (int i = array.Length - 1; i >= 0; i--)
        {
            reversed.Add(array[i]);
        }

        return reversed;
    }

    private static int[] ReverseArrayInPlace(int[] array)
    {
        if (array.Length <= 0) return new int[] { };

        int left = 0;
        int right = array.Length - 1;

        while (left < right)
        {
            var tempR = array[right];
            var tempL = array[left];
            array[left] = tempR;
            array[right] = tempL;

            left++;
            right--;
        }

        return array;
    }

    private static int NumSum(int target, int[] array)
    {
        int sum = 0;

        foreach (var s in array)
        {
            if (target == s)
            {
                sum++;
            }
        }

        return sum;
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

    static void PrintArray(List<int> array)
    {
        Console.WriteLine($"[{string.Join(", ", array)}]");
    }
}