namespace Leetcode.Hard;

public class MinimumWindowSubstring
{
    public static void Test()
    {
        Console.WriteLine(MinWindow("ADOBECODEBANC", "ABC"));
        Console.WriteLine(MinWindow("a", "a"));
        Console.WriteLine(MinWindow("a", "aa"));
    }

    public static string MinWindow(string s, string t)
    {
        if (s is "" || t is "" || t.Length > s.Length)
            return "";

        Dictionary<char, int> need = [];
        foreach (var item in t)
            need[item] = need.GetValueOrDefault(item, 0) + 1;

        string? minWindow = null;
        int count = t.Length;
        int l = 0;
        Dictionary<char, int> have = [];

        for (int r = 0; r < s.Length; r++)
        {
            char c = s[r];
            have[c] = have.GetValueOrDefault(c, 0) + 1;

            if (need.TryGetValue(c, out int neededCount) && have[c] <= neededCount)
            {
                count--;
            }

            while (count == 0)
            {
                if (minWindow == null || r - l + 1 < minWindow.Length)
                {
                    minWindow = s[l..(r + 1)];
                }

                char leftChar = s[l];
                have[leftChar]--;

                if (need.ContainsKey(leftChar) && have[leftChar] < need[leftChar])
                {
                    count++;
                }
                l++;
            }
        }

        return minWindow ?? "";
    }

    public static string GetMinLen2(string s, string t)
    {
        if (t == "")
            return "";

        Dictionary<char, int> countT = [];
        Dictionary<char, int> window = [];

        foreach (char c in t)
        {
            if (countT.ContainsKey(c))
            {
                countT[c]++;
            }
            else
            {
                countT[c] = 1;
            }
        }

        int have = 0,
            need = countT.Count;
        int[] res = { -1, -1 };
        int resLen = int.MaxValue;
        int l = 0;

        for (int r = 0; r < s.Length; r++)
        {
            char c = s[r];
            if (window.ContainsKey(c))
            {
                window[c]++;
            }
            else
            {
                window[c] = 1;
            }

            if (countT.ContainsKey(c) && window[c] == countT[c])
            {
                have++;
            }

            while (have == need)
            {
                if ((r - l + 1) < resLen)
                {
                    resLen = r - l + 1;
                    res[0] = l;
                    res[1] = r;
                }

                char leftChar = s[l];
                window[leftChar]--;
                if (countT.ContainsKey(leftChar) && window[leftChar] < countT[leftChar])
                {
                    have--;
                }
                l++;
            }
        }

        return resLen == int.MaxValue ? "" : s.Substring(res[0], resLen);
    }
}
