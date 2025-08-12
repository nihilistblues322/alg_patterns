namespace packs1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Sum(5));
        MultiplicationTable(7);

        Console.WriteLine(FactorialIterative(5));
        Console.WriteLine(EvenOrOdd(5));

        Console.WriteLine(FindMinMax([5, 6, 8, 11, 23, 45, 9, 2]));
        Console.WriteLine(SumArray([5, 6, 8, 11, 23, 45, 9, 2]));

        var arr = new[] { 1, 2, 3, 4, 5 };
        ReverseArray(arr);
        foreach (var i in arr)
        {
            Console.Write($"{i}, ");
        }
    }

    static int Sum(int input)
    {
        int sum = 0;
        for (int i = 1; i <= input; i++)
        {
            sum += i;
        }

        return sum;
    }

    static void MultiplicationTable(int n)
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{n} × {i} = {n * i}");
        }
    }

    static bool IsPositive(int input)
    {
        return input > 0;
    }

    static long FactorialIterative(int n)
    {
        long result = 1;
        for (int i = 2; i <= n; i++)
            result *= i;
        return result;
    }

    static string EvenOrOdd(int input)
    {
        if (input % 2 == 0)
            return "Even";

        return "Odd";
    }

    //==

    static (int min, int max) FindMinMax(int[] input)
    {
        var min = int.MaxValue;
        var max = int.MinValue;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] < min) min = input[i];
            if (input[i] > max) max = input[i];
        }

        return (min, max);
    }

    static int SumArray(int[] input)
    {
        int sum = 0;

        for (int i = 0; i < input.Length; i++)
        {
            sum += input[i];
        }

        return sum;
    }

    static void ReverseArray(int[] array)
    {
        var right = array.Length - 1;
        var left = 0;

        while (left < right)
        {
            var temp1 = array[left];
            var temp2 = array[right];
            array[left] = temp2;
            array[right] = temp1;

            left++;
            right--;
        }
    }
}