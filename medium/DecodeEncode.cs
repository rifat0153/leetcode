using System.Text;

namespace Leetcode.Medium;

internal class DecodeEncode
{
    public static void Test()
    {
        string[] list = ["neet", "123code", "love", "you"];

        var encoded = Encode(list);
        Console.WriteLine(encoded);
        var decoded = Decode(encoded);
        Console.WriteLine(string.Join(", ", decoded));
    }

    private static char Seperator = '#';

    public static string Encode(IList<string> strs)
    {
        StringBuilder sb = new();
        foreach (string str in strs)
        {
            sb.Append(Seperator);
            sb.Append(str.Length);
            sb.Append(Seperator);
            sb.Append(str);
        }
        return sb.ToString();
    }

    public static List<string> Decode(string s)
    {
        if (s is null or "")
            return [];

        List<string> list = [];

        int i = 0;
        while (i < s.Length)
        {
            int numStart = i + 1;
            int numEnd = numStart;
            while (numEnd < s.Length && char.IsDigit(s[numEnd]) && s[numEnd] != Seperator)
            {
                numEnd++;
            }
            var numStr = s[numStart..numEnd];
            Console.WriteLine($"Count : {numStr}");
            int strLength = Convert.ToInt32(numStr);
            int strStart = numEnd + 1;

            //var currStr = s.Substring(numEnd, strLength);
            var currStr = s[strStart..(strStart + strLength)];

            Console.WriteLine(currStr);
            list.Add(currStr);

            i = strStart + strLength;
        }

        return list;
    }
}
