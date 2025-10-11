namespace ContainsDuplicate;

class Program
{
    static void Main(string[] args)
    {
        var nums = new[] { 3, 2, 1, 3 };
        var result = HasDuplicate2(nums);
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
        Array.Sort(nums);
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