using System.Text;
using System.Text.RegularExpressions;

namespace strings;

class Program
{
    static void Main(string[] args)
    {
        var str = "Arquebus";
        Console.WriteLine(SumVowelsAndConsonants(str));

        var res = ReverseS(str);
        Console.WriteLine(res);

        var res2 = ReverseStrInPlace(str);
        Console.WriteLine(res2);

        Console.WriteLine(CapitalizeWordsWithArray("Hello world"));
        Console.WriteLine(Up("Hello world"));

        var pal = "racecar";
        var isPal = pal == new string(pal.Reverse().ToArray());
        Console.WriteLine(isPal);

        Console.WriteLine(IP("A man, a plan, ab21 canal: Panama"));
        Console.WriteLine(IsCleanPalindrome("A man, a plan, a canal: Panama"));

        Console.WriteLine(CountS2("Hello World Hello"));
        Console.WriteLine(RMDig2("h3ll0 w0rld 2024"));

        var resd = Cw("hello");
        foreach (var c in resd)
        {
            Console.WriteLine(c);
        }

        Console.WriteLine(FBW("A man, a plan, a canal: Panama"));
    }

    // ---------------------------------------------------------------------------------------------------------------
    static (int, int) SumVowelsAndConsonants(string str)
    {
        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

        var vowelsCount = 0;
        var consonantsCount = 0;


        foreach (var c in str.ToLower())
        {
            if (char.IsLetter(c))
            {
                if (vowels.Contains(c))
                {
                    vowelsCount++;
                }
                else
                {
                    consonantsCount++;
                }
            }
        }

        return (vowelsCount, consonantsCount);
    }

    static (int, int) SumVowelsAndConsonants2(string str)
    {
        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

        var lower = str.ToLower().Where(char.IsLetter);

        int vowelsCount = lower.Count(c => vowels.Contains(c));
        int consonantsCount = lower.Count() - vowelsCount;

        return (vowelsCount, consonantsCount);
    }

    static (int, int) SumVowelsAndConsonants3(string str)
    {
        var map = new Dictionary<char, bool>
        {
            ['a'] = true,
            ['e'] = true,
            ['i'] = true,
            ['o'] = true,
            ['u'] = true
        };

        int v = 0, c = 0;

        foreach (char ch in str.ToLower())
        {
            if (!char.IsLetter(ch)) continue;

            if (map.TryGetValue(ch, out bool isVowel) && isVowel)
                v++;
            else
                c++;
        }

        return (v, c);
    }
    // ---------------------------------------------------------------------------------------------------------------

    static string ReverseString(string str)
    {
        char[] chars = str.ToLower().ToCharArray();

        var map = new List<char>();

        for (int i = chars.Length - 1; i >= 0; i--)
        {
            map.Add(chars[i]);
        }

        return new string(map.ToArray());
        return new string(str.ToLower().Reverse().ToArray());
    }

    static string ReverseString2(string str)
    {
        char[] chars = str.ToLower().ToCharArray();

        int left = 0;
        int right = chars.Length - 1;

        while (left < right)
        {
            (chars[left], chars[right]) = (chars[right], chars[left]);
            left++;
            right--;
        }

        return new string(chars);
    }


    static string ReverseStr(string str)
    {
        char[] chars = str.ToLower().ToCharArray();

        var newStr = new List<char>();

        for (int i = chars.Length - 1; i >= 0; i--)
        {
            newStr.Add(chars[i]);
        }

        return new string(newStr.ToArray());
    }

    static string ReverseStrInPlace(string str)
    {
        var chars = str.ToLower().ToCharArray();

        int left = 0;
        int right = chars.Length - 1;

        while (left < right)
        {
            var temp1 = chars[left];
            var temp2 = chars[right];
            chars[left] = temp2;
            chars[right] = temp1;

            left++;
            right--;
        }

        return new string(chars.ToArray());
    }


    static string CapitalizeWordsVerbose(string input)
    {
        var result = "";
        var isNewWord = true;

        foreach (char c in input)
        {
            if (char.IsWhiteSpace(c))
            {
                result += c;
                isNewWord = true;
            }
            else
            {
                result += isNewWord ? char.ToUpper(c) : char.ToLower(c);
                isNewWord = false;
            }
        }

        return result;
    }

    static string CapitalizeWordsWithArray(string input)
    {
        string[] words = input.Split(' ');
        string result = "";

        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];
            if (word.Length > 0)
            {
                string capitalized = char.ToUpper(word[0]) +
                                     (word.Length > 1 ? word.Substring(1).ToLower() : "");
                result += capitalized;
            }

            if (i < words.Length - 1)
                result += " ";
        }

        return result;
    }


    static string CapitalizeWordsWithBuilder(string input)
    {
        var sb = new StringBuilder();
        bool newWord = true;

        foreach (char c in input)
        {
            if (char.IsWhiteSpace(c))
            {
                sb.Append(c);
                newWord = true;
            }
            else
            {
                sb.Append(newWord ? char.ToUpper(c) : char.ToLower(c));
                newWord = false;
            }
        }

        return sb.ToString();
    }


    static string FirstUpp(string input)
    {
        bool isNew = true;
        var result = "";

        foreach (var c in input)
        {
            if (char.IsWhiteSpace(c))
            {
                result += c;
                isNew = true;
            }
            else
            {
                result += isNew ? char.ToUpper(c) : char.ToLower(c);
                isNew = false;
            }
        }

        return result;
    }

    static bool IsPalindrome(string input)
    {
        if (string.IsNullOrEmpty(input))
            return true;

        var cleaned = new string(
            input
                .Where(char.IsLetterOrDigit)
                .Select(char.ToLower)
                .ToArray()
        );

        int left = 0;
        int right = cleaned.Length - 1;

        while (left < right)
        {
            if (cleaned[left] != cleaned[right]) return false;

            left++;
            right--;
        }

        return true;
    }

    static bool IsCleanPalindrome(string str)
    {
        var cleaned = new string(str.ToLower().Where(char.IsLetterOrDigit).ToArray());

        return cleaned == new string(cleaned.Reverse().ToArray());
    }

    static string ReplaceWordManually(string input)
    {
        var words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < words.Length; i++)
        {
            string clean = words[i].TrimEnd('.', ',', ';', '!', '?');

            if (string.Equals(clean, "кот", StringComparison.OrdinalIgnoreCase))
            {
                char lastChar = words[i][words[i].Length - 1];
                bool hasPunct = !char.IsLetterOrDigit(lastChar);

                words[i] = "пёс" + (hasPunct ? lastChar.ToString() : "");
            }
        }

        return string.Join(" ", words);
    }

    static int CountWords(string input)
    {
        return input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Length;
    }

    static int CountWords2(string input)
    {
        var inWord = false;
        int count = 0;

        foreach (var c in input)
        {
            if (char.IsWhiteSpace(c))
            {
                inWord = false;
            }
            else if (!inWord)
            {
                inWord = true;
                count++;
            }
        }

        return count;
    }

    static string ReplaceDigits(string input)
    {
        var digits = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        var sb = new StringBuilder();

        foreach (var c in input)
        {
            if (!digits.Contains(c))
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }

    static string ReplaceDigits2(string input)
    {
        var sb = new StringBuilder();

        foreach (var c in input)
        {
            if (!char.IsDigit(c))
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }

    static string FindLongestWord(string input)
    {
        var words = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string longest = "";

        foreach (var word in words)
        {
            if (word.Length > longest.Length) longest = word;
        }

        return longest;
    }

    static string FindLongestWordLinq(string input)
    {
        return input
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .OrderByDescending(w => w.Length)
            .FirstOrDefault() ?? "";
    }

    static string FindLongestWordClean(string input)
    {
        var words = Regex.Split(input, @"\W+");
        string longest = "";

        foreach (var word in words)
        {
            if (word.Length > longest.Length)
                longest = word;
        }

        return longest;
    }


    static Dictionary<char, int> CountCharFrequency(string input)
    {
        var res = new Dictionary<char, int>();

        foreach (var c in input)
        {
            if (res.ContainsKey(c))
            {
                res[c]++;
            }
            else
            {
                res[c] = 1;
            }
        }

        return res;
    }

    static Dictionary<char, int> CountCharFrequencyLinq(string input)
    {
        return input
            .GroupBy(c => c)
            .ToDictionary(g => g.Key, g => g.Count());
    }


    //---
    static string ReverseS(string input)
    {
        var chars = input.ToLower().ToCharArray();
        var sb = new StringBuilder();

        for (int i = chars.Length - 1; i >= 0; i--)
        {
            sb.Append(chars[i]);
        }

        return new string(chars.ToArray());
    }

    static string Up(string input)
    {
        var isNew = true;
        var sb = new StringBuilder();

        foreach (var c in input)
        {
            if (char.IsWhiteSpace(c))
            {
                sb.Append(c);
                isNew = true;
            }
            else
            {
                sb.Append(isNew ? char.ToUpper(c) : char.ToLower(c));
                isNew = false;
            }
        }

        return sb.ToString();
    }

    static bool IP(string input)
    {
        var chars = new string(input.ToLower().Where(char.IsLetterOrDigit).ToArray());

        return chars == new string(chars.ToArray());
    }

    static int CountS(string input)
    {
        return input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Length;
    }

    static int CountS2(string input)
    {
        var inWord = false;
        var count = 0;

        foreach (var c in input)
        {
            if (char.IsWhiteSpace(c))
            {
                inWord = false;
            }
            else if (!inWord)
            {
                inWord = true;
                count++;
            }
        }

        return count;
    }

    static string RMDig(string input)
    {
        var chars = input.ToLower().ToCharArray();

        var word = new StringBuilder();

        foreach (var c in chars)
        {
            if (!char.IsDigit(c))
            {
                word.Append(c);
            }
        }

        return word.ToString();
    }

    static string RMDig2(string input)
    {
        return new string(input.Where(c => !char.IsDigit(c)).ToArray());
    }

    static Dictionary<char, int> Cw(string input)
    {
        var dict = new Dictionary<char, int>();

        foreach (var c in input)
        {
            if (dict.ContainsKey(c))
            {
                dict[c]++;
            }
            else
            {
                dict[c] = 1;
            }
        }

        return dict;
    }

    static Dictionary<char, int> Cw2(string input)
    {
        return input.GroupBy(c => c).ToDictionary(c => c.Key, g => g.Count());
    }

    static string FBW(string input)
    {
        var res = "";
        var chars = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        foreach (var c in chars)
        {
            if (chars.Length > c.Length)
            {
                res = c;
            } 
        }

        return res;
    }
}