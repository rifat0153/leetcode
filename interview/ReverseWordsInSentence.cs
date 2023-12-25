using System.Text;

namespace leetcode.interview;

public class ReverseWordsInSentence
{
    public static void Test()
    {
        string input = "Hello World";
        string expected = "World Hello";
        string result = Invoke(input);
        Console.WriteLine($"Input: \"{input}\"");
        Console.WriteLine($"Expected: \"{expected}\"");
        Console.WriteLine($"Output: \"{result}\"");
        Console.WriteLine("------------------------");

        // Add more test cases as needed.
    }

    public static string Invoke(string sentence)
    {
        // var result = string.Join(' ', sentence.Split(' ').Reverse());
        // return result;
        // do it in a functional way
        return sentence
            .Split(' ')
            .Reverse()
            .Aggregate(
                new StringBuilder(),
                (sb, x) => sb.Append(x).Append(' '),
                sb => sb.ToString().Trim()
            );
    }
}
