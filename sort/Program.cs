namespace sort;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 5, 3, 2, 4, 8 };

        BubbleSort(numbers);

        Console.WriteLine(string.Join(", ", numbers));
    }

    static void BubbleSort(int[] array)
    {
        int n = array.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
    }

    static void BubbleSortOptimized(int[] array)
    {
        int n = array.Length;

        for (int i = 0; i < n - 1; i++)
        {
            bool swapped = false;

            for (int j = 0; j < n - 1 - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);

                    swapped = true;
                }
            }

            if (!swapped)
                break;
        }
    }

    //=====
}