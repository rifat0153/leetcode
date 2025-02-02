namespace Leetcode.interview;

public class LongestSubstringWithoutRepeatingCharacters
{
    public static void Test()
    {
        string input1 = "abcabcbb";
        int expected1 = 3;
        int result1 = Invoke(input1);
        Console.WriteLine($"Input: \"{input1}\"");
        Console.WriteLine($"Expected: {expected1}");
        Console.WriteLine($"Output: {result1}");
        Console.WriteLine("------------------------");

        string input2 = "bbbbb";
        int expected2 = 1;
        int result2 = Invoke(input2);
        Console.WriteLine($"Input: \"{input2}\"");
        Console.WriteLine($"Expected: {expected2}");
        Console.WriteLine($"Output: {result2}");
        Console.WriteLine("------------------------");

        string input3 = "pwwkew";
        int expected3 = 3;
        int result3 = Invoke(input3);
        Console.WriteLine($"Input: \"{input3}\"");
        Console.WriteLine($"Expected: {expected3}");
        Console.WriteLine($"Output: {result3}");
        Console.WriteLine("------------------------");

        // Add more test cases as needed.
    }

    public static int Invoke(string s)
    {
        var left = 0;
        var max = 0;

        var set = new HashSet<int>();

        for (int right = 0; right < s.Length; right++)
        {
            while (set.Contains(s[right]) && left <= right)
            {
                set.Remove(s[left]);
                left++;
            }

            set.Add(s[right]);
            max = Math.Max(max, set.Count);
        }

        return set.Count;
    }
}
