namespace Leetcode.easy;

public static class ValidAnagram
{
    public static void Test()
    {
        string s = "anagram";
        string t = "nagaram";

        Console.WriteLine(IsAnagram(s, t));
    }

    public static bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        var charMap = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (charMap.ContainsKey(s[i]))
                charMap[s[i]]++;
            else
                charMap.Add(s[i], 1);
        }

        for (int i = 0; i < t.Length; i++)
        {
            if (charMap.ContainsKey(t[i]))
            {
                charMap[t[i]]--;

                if (charMap[t[i]] < 0)
                    return false;
            }
            else
                return false;
        }

        return true;
    }
}
