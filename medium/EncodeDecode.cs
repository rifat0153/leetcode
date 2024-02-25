using System.Text;

namespace leetcode.medium;

public class EncodeDecode
{
    private static readonly char Delimeter = '#';

    // Encodes a list of strings to a single string.
    public string Encode(List<string> strs)
    {
        var result = strs.Aggregate(
            new StringBuilder(),
            (acc, curr) =>
            {
                return acc.Append($"{curr.Length}{Delimeter}{curr}");
            },
            (sb) => sb.ToString()
        );

        return result;
    }

    // Decodes a single string to a list of strings.
    public List<string> Decode(string s)
    {
        var result = new List<string>();
        int i = 0;

        while (i < s.Length)
        {
            int j = i + s.IndexOf(Delimeter);
            var lengthStr = s[i..j];
            var itemLength = Convert.ToInt32(lengthStr);
            var currStr = s.Substring(j + 1, itemLength);
            result.Add(currStr);
            i = j + 1 + itemLength;
        }

        return result;
    }

    public static void Test()
    {
        EncodeDecode codec = new();
        List<string> input = new List<string> { "Hello", "World", "GitHub", "Copilot" };
        Console.WriteLine("Input: " + string.Join(", ", input));

        string encoded = codec.Encode(input);
        Console.WriteLine("Encoded: " + encoded);

        List<string> decoded = codec.Decode(encoded);
        Console.WriteLine("Decoded: " + string.Join(", ", decoded));
    }
}
