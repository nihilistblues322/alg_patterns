namespace TwoSum;

class Program
{
    static void Main(string[] args)
    {
        int[] nums = [2, 7, 11, 15];
        int target = 9;

        var result = TwoSum(nums, target);
        PrintArray(result);
    }

    static int[] TwoSum(int[] nums, int target)
    {
        var seenNumbers = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int currentNumber = nums[i];
            int needToFind = target - currentNumber;

            if (seenNumbers.TryGetValue(needToFind, out var number))
            {
                return [number, i];
            }

            seenNumbers[currentNumber] = i;
        }

        return [];
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