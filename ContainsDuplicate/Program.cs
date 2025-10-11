namespace ContainsDuplicate;

class Program
{
    static void Main(string[] args)
    {
        var nums = new[] { 1, 2, 3, 3 };
        var result = HasDuplicate(nums);
        Console.WriteLine(result);
    }

    static bool HasDuplicate(int[] nums)
    {
        var hash = new HashSet<int>();

        foreach (var i in nums)
        {
            if (hash.Contains(i))
            {
                return true;
            }

            hash.Add(i);
        }

        return false;
    }

    static bool HasDuplicate2(int[] nums)
    {
        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] == nums[i + 1])
            {
                return true;
            }
        }

        return false;
    }
}