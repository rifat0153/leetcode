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

        int minLen = int.MaxValue;
        int start = 0; // Store the start index of the min window

        Dictionary<char, int> freq = [];
        foreach (char c in t)
            freq[c] = freq.GetValueOrDefault(c, 0) + 1;

        Dictionary<char, int> window = [];
        int need = t.Length;
        int have = 0;
        int l = 0;

        for (int r = 0; r < s.Length; r++)
        {
            char c = s[r];
            window[c] = window.GetValueOrDefault(c, 0) + 1;

            if (freq.ContainsKey(c) && window[c] == freq[c])
                have++;

            while (have == need)
            {
                if (r - l + 1 < minLen)
                {
                    minLen = r - l + 1;
                    start = l; // Update the starting index
                }

                char leftChar = s[l];
                window[leftChar]--;

                if (freq.TryGetValue(leftChar, out int value) && window[leftChar] < value)
                    have--;

                l++;
            }
        }

        return minLen == int.MaxValue ? "" : s.Substring(start, minLen);
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
