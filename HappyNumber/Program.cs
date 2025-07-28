namespace HappyNumber;

class Program
{
    static void Main(string[] args)
    {
        var n = 19;
        Console.WriteLine(IsHappyHash(n));
    }

    // HashSet
    static bool IsHappyHash(int n)
    {
        var seen = new HashSet<int>();

        while (n != 1)
        {
            if (seen.Contains(n)) return false;
            seen.Add(n);
            n = GetNext(n);
        }

        return true;
    }

    //  Floyd’s Cycle Detection 
    static bool IsHappyFcd(int n)
    {
        int slow = n;
        int fast = GetNext(n);

        while (fast != 1 && slow != fast)
        {
            slow = GetNext(slow);
            fast = GetNext(GetNext(fast));
        }

        return fast == 1;
    }

    private static int GetNext(int n)
    {
        int total = 0;
        
        while (n > 0)
        {
            int digit = n % 10;
            total += digit * digit;
            n /= 10;
        }

        return total;
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