using System.Text;

namespace leetcode.interview;

// Q: Reverse a string.
public class ReverseString
{
    public static void Test()
    {
        string input1 = "hello";
        var result1 = Invoke(input1);
        Console.WriteLine($"Input: \"{input1}\"");
        Console.WriteLine($"Expected Output: \"olleh\"");
        Console.WriteLine($"Your Output: \"{result1}\"");
        Console.WriteLine("------------------------");

        string input2 = "world";
        var result2 = Invoke(input2);
        Console.WriteLine($"Input: \"{input2}\"");
        Console.WriteLine($"Expected Output: \"dlrow\"");
        Console.WriteLine($"Your Output: \"{result2}\"");
        Console.WriteLine("------------------------");

        // You can add more test cases if needed.
    }

    public static string Invoke(string input)
    {
        var chars = input.ToCharArray();
        var length = chars.Length;

        foreach (var idx in Enumerable.Range(0, chars.Length / 2))
        {
            // swap elements
            (chars[idx], chars[length - idx - 1]) = (chars[length - idx - 1], chars[idx]);
        }

        return new string(chars);
    }
}
