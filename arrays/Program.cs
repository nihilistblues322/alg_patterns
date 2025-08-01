namespace arrays;

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

        var shift = ShiftRight([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        PrintArray(shift);

        var shift2 = ShiftArrayInLeft([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        PrintArray(shift2);

        var pairs = GetAdjacentPairs(new[] { 1, 2, 3, 4 });
        foreach (var pair in pairs)
        {
            Console.Write($"({pair.Item1}, {pair.Item2}) ");
        }

        var nums = DoubleWindow([1, 2, 3, 4, 5, 6, 7, 8]);
        foreach (var num in nums)
        {
            Console.Write($"({num.Item1}, {num.Item2}) ");
        }

        var doubleWin = DoubleWin([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        foreach (var num in doubleWin)
        {
            Console.Write($"({num.Item1}, {num.Item2}) ");
        }

        var ds = DoubleSumWin([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        PrintArray(ds);
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

    private static int[] ShiftArrayInRight(int[] array)
    {
        int temp = array[array.Length - 1];

        for (int i = array.Length - 1; i > 0; i--)
        {
            array[i] = array[i - 1];
        }

        array[0] = temp;


        return array;
    }

    private static int[] ShiftArrayInLeft(int[] array)
    {
        int temp = array[0];

        for (int i = 0; i < array.Length - 1; i++)
        {
            array[i] = array[i + 1];
        }

        array[array.Length - 1] = temp;


        return array;
    }

    private static int[] ShiftRightCopy(int[] array)
    {
        if (array.Length == 0) return array;

        int[] result = new int[array.Length];

        for (int i = 1; i < array.Length; i++)
        {
            result[i] = array[i - 1];
        }

        result[0] = array[array.Length - 1];

        return result;
    }

    private static (int, int)[] DoubleWindow(int[] array)
    {
        if (array.Length < 2) return new (int, int)[] { };

        var result = new (int, int)[array.Length - 1];

        for (int i = 0; i <= array.Length - 2; i++)
        {
            result[i] = (array[i], array[i + 1]);
        }

        return result;
        return array.Zip(array.Skip(1), (a, b) => (a, b)).ToArray();
    }

    private static List<(int, int)> GetAdjacentPairs(int[] array)
    {
        var result = new List<(int, int)>();

        if (array.Length < 2)
            return result;

        for (int i = 0; i < array.Length - 1; i++)
        {
            result.Add((array[i], array[i + 1]));
        }

        return result;
    }

    private static (int, int)[] GetAdjacentPairs2(int[] array)
    {
        if (array.Length < 2)
            return Array.Empty<(int, int)>();

        var result = new (int, int)[array.Length - 1];

        for (int i = 0; i < array.Length - 1; i++)
        {
            result[i] = (array[i], array[i + 1]);
        }

        return result;
    }

    private static IEnumerable<(int, int)> GetAdjacentPairs3(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            yield return (array[i], array[i + 1]);
        }
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

    private static int[] Reverse1(int[] array)
    {
        int left = 0;
        int right = array.Length - 1;

        while (left < right)
        {
            var temp1 = array[right];
            var temp2 = array[left];
            array[left] = temp1;
            array[right] = temp2;

            left++;
            right--;
        }

        return array;
    }

    private static int[] ShiftRight(int[] array)
    {
        int temp = array[array.Length - 1];

        for (int i = array.Length - 1; i > 0; i--)
        {
            array[i] = array[i - 1];
        }

        array[0] = temp;

        return array;
    }

    private static int[] ShiftLeft(int[] array)
    {
        int temp = array[0];

        for (int i = 0; i < array.Length - 1; i++)
        {
            array[i] = array[i + 1];
        }

        array[array.Length - 1] = temp;

        return array;
    }

    private static (int, int)[] DoubleWin(int[] array)
    {
        if (array.Length < 2) return [];

        var windows = new (int, int)[array.Length - 1];

        for (int i = 0; i < array.Length - 1; i++)
        {
            windows[i] = (array[i], array[i + 1]);
        }

        return windows;
    }

    private static int[] DoubleSumWin(int[] array)
    {
        var sum = new int[array.Length - 2];

        for (int i = 0; i < array.Length - 2; i++)
        {
            sum[i] = (array[i] + array[i + 1] + array[i + 2]);
        }

        return sum;
    }
}