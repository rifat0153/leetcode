namespace leetcode.easy;

public class GreatestCommonDivisor
{
    public static void Test()
    {
        string str1 = "ABABAB";
        string str2 = "ABAB";

        var result = GcdOfStrings(str1, str2);

        Console.WriteLine(result);
    }

    public static string GcdOfStrings(string str1, string str2)
    {
        var len1 = str1.Length;
        var len2 = str2.Length;

        var minLen = Math.Min(len1, len2);

        for (var l = minLen; l >= 1; l--)
        {
            if (IsDivisor(l, str1, str2))
            {
                return str1.Substring(0, l);
            }
        }

        return "-1";
    }

    private static bool IsDivisor(int length, string str1, string str2)
    {
        var len1 = str1.Length;
        var len2 = str2.Length;

        if (len1 % length != 0 || len2 % length != 0)
        {
            return false;
        }

        var prefix = str1.Substring(0, length);

        var factor1 = len1 / length;
        var factor2 = len2 / length;

        var str1MultiplitedFactor = "";
        foreach (var i in Enumerable.Range(1, factor1))
        {
            str1MultiplitedFactor += prefix;
        }
        var str2MultiplitedFactor = "";
        foreach (var i in Enumerable.Range(1, factor2))
        {
            str2MultiplitedFactor += prefix;
        }

        return str1MultiplitedFactor == str1 && str2MultiplitedFactor == str2;
    }
}
