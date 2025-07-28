namespace SlidingWindow;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = [1, 3, 2, 6, -1, 4, 1, 8, 2];
        int k = 5;

        // var result1 = FindAverages1(k, arr);
        var result2 = FindAverages2(k, arr);

        // PrintArray(result1);
        PrintArray(result2);


        int[] arr2 = [2, 1, 5, 1, 3, 2];
        int k2 = 3;
        var result3 = FindMaxSumOfSubarray(arr2, k2);
        Console.WriteLine(result3);


        Console.WriteLine("Maximum sum of a subarray of size K: " +
                          FindMaxSumSubArray(3, [2, 1, 5, 1, 3, 2]));


        Console.WriteLine("Smallest of a subarray of size s: " +
                          FindMinSubArray(7, [2, 1, 5, 2, 3, 2]));
    }

    public static double[] FindAverages1(int k, int[] arr)
    {
        double[] result = new double[arr.Length - k + 1];

        for (int i = 0; i <= arr.Length - k; i++)
        {
            double sum = 0;
            for (int j = i; j < i + k; j++)
            {
                sum += arr[j];
            }

            result[i] = sum / k;
        }

        return result;
    }

    public static double[] FindAverages2(int k, int[] numbers)
    {
        // Мы хотим найти среднее для каждого окна длиной k в массиве numbers.
        // Например: если numbers = [1,3,2,6,-1,4] и k=3
        //   то средние будут: [2.0, 3.67, 2.33, 3.0]

        // 1. Создаем массив, в котором будем хранить ответы (средние значения)
        double[] averages = new double[numbers.Length - k + 1];

        // 2. Это наша "копилка" — будем складывать в нее числа текущего окна
        double sum = 0;

        // 3. Этот индекс показывает, откуда начинается текущее окно
        int startIndex = 0;

        // 4. Цикл: идем по массиву слева направо
        for (int endIndex = 0; endIndex < numbers.Length; endIndex++)
        {
            // ► Добавляем текущее число в "копилку"
            sum += numbers[endIndex];

            // ► Если в копилке уже k чисел — значит, окно полное
            if (endIndex >= k - 1)
            {
                // Считаем среднее для окна: делим сумму на количество чисел
                averages[startIndex] = sum / k;

                // Убираем из суммы число, которое "выпадает" из окна
                sum -= numbers[startIndex];

                // Сдвигаем старт окна на одну позицию вправо
                startIndex++;
            }
        }

        // 5. Возвращаем массив средних значений
        return averages;
    }


    private static int FindMaxSumOfSubarray(int[] numbers, int windowSize)
    {
        int maxSum = 0; // здесь будет храниться самая большая сумма
        int currentSum = 0; // текущая сумма в окне
        int windowStart = 0; // начало окна (элемент, который будем удалять, когда окно сдвигается)

        // идем по массиву, расширяя окно справа
        for (int windowEnd = 0; windowEnd < numbers.Length; windowEnd++)
        {
            // добавляем новый элемент в окно
            currentSum += numbers[windowEnd];

            // когда набрали достаточно элементов (окно размера windowSize)
            if (windowEnd >= windowSize - 1)
            {
                // проверяем, не побили ли мы рекорд по сумме
                maxSum = Math.Max(maxSum, currentSum);

                // убираем элемент, который выходит из окна
                currentSum -= numbers[windowStart];

                // сдвигаем окно на 1 вправо
                windowStart++;
            }
        }

        return maxSum;
    }


    public static int FindMaxSumSubArray(int inputNumber, int[] inputArray)
    {
        int maxSum = 0; // тут будем хранить максимальную сумму

        // внешний цикл — выбирает старт окна
        for (int firstIndex = 0; firstIndex <= inputArray.Length - inputNumber; firstIndex++)
        {
            var windowSum = 0; // сумма текущего окна

            // внутренний цикл — складывает числа в окне длиной k
            for (int secondIndex = firstIndex; secondIndex < firstIndex + inputNumber; secondIndex++)
            {
                windowSum += inputArray[secondIndex];
            }

            // сравниваем, что больше — старая максимальная сумма или новая
            maxSum = Math.Max(maxSum, windowSum);
        }

        return maxSum;
    }

    public static int FindMinSubArray(int targetSum, int[] numbers)
    {
        int windowStart = 0;
        int windowSum = 0;
        int minLength = int.MaxValue; // пока ставим "бесконечность"

        for (int windowEnd = 0; windowEnd < numbers.Length; windowEnd++)
        {
            // Добавляем новый элемент в окно
            windowSum += numbers[windowEnd];

            // Сжимаем окно, пока сумма >= targetSum
            while (windowSum >= targetSum)
            {
                // Проверяем, является ли текущее окно самым коротким
                int currentLength = windowEnd - windowStart + 1;
                minLength = Math.Min(minLength, currentLength);

                // Убираем элемент, который слева (он выйдет из окна)
                windowSum -= numbers[windowStart];
                windowStart++;
            }
        }

        // Если minLength не поменялось — значит, подходящего окна не было
        return (minLength == int.MaxValue) ? 0 : minLength;
    }


    static void PrintArray(double[] array)
    {
        if (array.Length == 0)
        {
            Console.WriteLine("[]");
            return;
        }

        Console.WriteLine($"[{string.Join(", ", array)}]");
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