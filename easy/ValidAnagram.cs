namespace Leetcode.Easy;

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

        var map = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (map.ContainsKey(s[i]))
                map[s[i]]++;
            else
                map.Add(s[i], 1);
        }

        for (int i = 0; i < t.Length; i++)
        {
            if (map.ContainsKey(t[i]))
            {
                map[t[i]]--;

                if (map[t[i]] < 0)
                    return false;
            }
            else
                return false;
        }

        return true;
    }
}
