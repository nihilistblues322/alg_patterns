namespace arrayss_sql;

class Program
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString() => $"Id={Id}, Name={Name}";
    }

    class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student? x, Student? y)
        {
            if (x is null || y is null) return false;
            return x.Id == y.Id;
        }

        public int GetHashCode(Student obj) => obj.Id.GetHashCode();
    }

    static void Main(string[] args)
    {
        var clientsA = new int[] { 1, 2, 3, 4, 5, 5 };
        var clientsB = new int[] { 6, 7, 8, 9, 10, 10 };

        var clientsAstring = new string[] { "a", "b", "c", "d", "z" };
        var clientsBstring = new string[] { "z", "x", "v", "g", "z" };


        PrintArray(IMerge(clientsA, clientsB));
        PrintArray(DMerge(clientsA, clientsB));

        PrintArray(IMerge(clientsAstring, clientsBstring));
        PrintArray(DMerge(clientsAstring, clientsBstring));


        var studentsA = new List<Student>
        {
            new Student { Id = 1, Name = "Alice" },
            new Student { Id = 2, Name = "Bob" },
            new Student { Id = 3, Name = "Charlie" },
            new Student { Id = 3, Name = "Charlie" },
        };

        var studentsB = new List<Student>
        {
            new Student { Id = 2, Name = "Bobby" },
            new Student { Id = 4, Name = "Diana" },
            new Student { Id = 5, Name = "Eve" },
            new Student { Id = 6, Name = "Eve" },
            new Student { Id = 5, Name = "Eve" },
        };

        Console.WriteLine("=== Distinct + IEqualityComparer ===");
        var mergedComparer = studentsA.Concat(studentsB)
            .Distinct(new StudentComparer())
            .ToList();
        Print(mergedComparer);

        Console.WriteLine("\n=== GroupBy(Id) ===");
        var mergedGroupBy = studentsA.Concat(studentsB)
            .GroupBy(s => s.Id)
            .Select(g => g.First())
            .ToList();
        Print(mergedGroupBy);

        Console.WriteLine("\n=== Imperative (HashSet) ===");
        var mergedImperative = MergeImperative(studentsA, studentsB);
        Print(mergedImperative);


        var phonesA = new int[] { 111, 222, 333, 444 };
        var phonesB = new int[] { 333, 444, 555, 666 };

        PrintArray(DMerge(phonesA, phonesB));


        string[] array1 = { "123-456-7890", "111-222-3333", "(444) 555-6666" };
        string[] array2 = { "1112223333", "777 888 9999", "1234567890" }; // Дубликаты "111-222-3333" и "123-456-7890"
        string[] array3 = { "+1-987-654-3210", "4445556666" }; // Дубликат "(444) 555-6666"

        string[] uniqueNumbers = RemoveDuplicatePhoneNumbers(array1, array2, array3);

        Console.WriteLine("Уникальные телефонные номера:");
        foreach (var number in uniqueNumbers)
        {
            Console.WriteLine(number);
        }
    }


    static List<T> IMerge<T>(T[] a, T[] b)
    {
        var result = new List<T>();

        foreach (var c in a)
        {
            if (!result.Contains(c)) result.Add(c);
        }

        foreach (var c in b)
        {
            if (!result.Contains(c)) result.Add(c);
        }

        return result;
    }

    static List<T> DMerge<T>(T[] a, T[] b)
    {
        var res = a.Concat(b).Distinct().ToList();

        return res;
    }


    static void Print(IEnumerable<Student> students)
    {
        foreach (var s in students)
        {
            Console.WriteLine(s);
        }
    }

    static List<Student> MergeImperative(List<Student> a, List<Student> b)
    {
        var result = new List<Student>();
        var seenIds = new HashSet<int>();

        foreach (var s in a.Concat(b))
        {
            if (seenIds.Add(s.Id))
            {
                result.Add(s);
            }
        }

        return result;
    }


    static void PrintArray(List<int> array)
    {
        if (array.Count == 0)
        {
            Console.WriteLine("[]");
            return;
        }

        Console.WriteLine($"[{string.Join(", ", array)}]");
    }

    static void PrintArray(List<string> array)
    {
        if (array.Count == 0)
        {
            Console.WriteLine("[]");
            return;
        }

        Console.WriteLine($"[{string.Join(", ", array)}]");
    }

    public static string[] RemoveDuplicatePhoneNumbers(params string[][] phoneNumbersArrays)
    {
        // 1. Создаем HashSet для хранения уникальных номеров.
        // HashSet<string> очень эффективен для добавления и проверки на дубликаты.
        var uniquePhoneNumbers = new HashSet<string>();

        // 2. Итерируем по каждому входному массиву телефонных номеров.
        foreach (var phoneArray in phoneNumbersArrays)
        {
            // 3. Итерируем по каждому номеру в текущем массиве.
            foreach (var phoneNumber in phoneArray)
            {
                // Опционально: Очистка номера перед добавлением.
                // Например, удаление пробелов, скобок, тире, чтобы "123-456-7890" и "1234567890" считались одинаковыми.
                string cleanedPhoneNumber = CleanPhoneNumber(phoneNumber);

                // 4. Добавляем очищенный номер в HashSet.
                // Если номер уже существует, Add() просто вернет false и ничего не изменит.
                uniquePhoneNumbers.Add(cleanedPhoneNumber);
            }
        }

        // 5. Преобразуем HashSet обратно в массив строк.
        return uniquePhoneNumbers.ToArray();
    }


    private static string CleanPhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            return string.Empty;
        }

        var sb = new System.Text.StringBuilder();
        foreach (char c in phoneNumber)
        {
            if (char.IsDigit(c))
            {
                sb.Append(c);
            }
            else if (c == '+' && sb.Length == 0)
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }
}