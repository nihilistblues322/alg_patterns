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

        // var arr = new[] { 1, 2, 3, 4, 5 };
        // ReverseArray(arr);
        // foreach (var i in arr)
        // {
        //     Console.Write($"{i}, ");
        // }


        // var arr1 = new[] { 1, 2, 3, 4, 5 };
        // MoveLeft(arr1);
        // foreach (var i in arr1)
        // {
        //     Console.Write($"{i}, ");
        // }


        // var arr1 = new[] { 1, 0, 2, 3, 0, 4, 5, 0 };
        // var res = RemoveNulls(arr1);
        // foreach (var i in res)
        // {
        //     Console.Write($"{i}, ");
        // }

        Console.WriteLine(IsPal("level"));
        Console.WriteLine(Reverse2("bombordini"));
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

    static void MultiplicationTable(int input)
    {
        int sum = 0;

        for (int i = 0; i < input; i++)
        {
            Console.WriteLine($"{input} * {i} = {i * input}");
        }
    }

    static int FactorialIterative(int n)
    {
        int sum = 1;
        for (int i = 2; i <= n; i++)
        {
            sum *= i;
        }

        return sum;
    }

    static string EvenOrOdd(int n)
    {
        return n % 2 == 0 ? "Even" : "Odd";
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

    static void MoveLeft(int[] array)
    {
        int first = array[0];

        for (int i = 0; i < array.Length - 1; i++)
        {
            array[i] = array[i + 1];
        }

        array[array.Length - 1] = first;
    }

    static void MoveRight(int[] array)
    {
        int last = array[array.Length - 1];

        for (int i = array.Length - 1; i > 0; i--)
        {
            array[i] = array[i - 1];
        }

        array[0] = last;
    }


    static int[] RemoveNulls(int[] array)
    {
        int count = 0;
        foreach (var t in array)
            if (t != 0)
                count++;

        int[] result = new int[count];

        int idx = 0;
        foreach (var t in array)
        {
            if (t != 0)
            {
                result[idx] = t;
                idx++;
            }
        }

        return result;
        return array.Where(t => t != 0).ToArray();
    }


    static bool IsPal(string input)
    {
        var chars = input.ToLower().Where(char.IsLetterOrDigit).ToArray();

        int start = 0;
        int end = chars.Length - 1;

        while (start < end)
        {
            if (chars[start] != chars[end])
                return false;

            start++;
            end--;
        }

        return true;
    }

    static string Reverse(string input)
    {
        var chars = input.ToCharArray();

        int start = 0;
        int end = chars.Length - 1;

        while (start < end)
        {
            (chars[start], chars[end]) = (chars[end], chars[start]);

            start++;
            end--;
        }

        return new string(chars);
    }

    static string Reverse2(string input)
    {
        return new string(input.ToLower().Reverse().ToArray());
    }
}