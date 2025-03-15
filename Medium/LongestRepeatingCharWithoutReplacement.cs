namespace Leetcode.Medium;

internal class LongestRepeatingCharWithoutReplacement
{
    public static void Test()
    {
        Console.WriteLine(CharacterReplacement("ABAB", 2));
        Console.WriteLine(CharacterReplacement("AABABBA", 1));
    }

    public static int CharacterReplacement(string s, int k)
    {
        Dictionary<char, int> freq = [];
        int max = 0;
        int l = 0;

        for (int r = 0; r < s.Length; r++)
        {
            char c = s[r];
            freq[c] = freq.GetValueOrDefault(c, 0) + 1;

            while ((r - l + 1) - freq.Values.Max() > k)
            {
                freq[s[l]]--;
                l++;
            }

            max = Math.Max(max, r - l + 1);
        }

        return max;
    }
}
