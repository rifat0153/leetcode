namespace leetcode.easy;

// Find the Index of the First Occurrence in a String
public class StringOccurence
{
    public static void Test()
    {
        string s = "Hello, World!";
        string needle = "World";

        Console.WriteLine(Invoke(s, needle));
    }

    public static int Invoke(string haystack, string needle)
    {
        for (int i = 0; i <= haystack.Length - needle.Length; i++)
        {
            if (haystack.Substring(i, needle.Length) == needle)
            {
                return i;
            }
        }

        return -1;
    }
}
