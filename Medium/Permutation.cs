namespace Leetcode.Medium;

internal class Permutation
{
    public static void Test()
    {
        Console.WriteLine(CheckInclusion("ab", "eidbaooo"));
        Console.WriteLine(CheckInclusion("ab", "eidboaoo"));
        Console.WriteLine(CheckInclusion("adc", "dcda"));
    }

    public static bool CheckInclusion(string s1, string s2)
    {
        Dictionary<char, int> freqS1 = [];
        foreach (var c in s1)
            freqS1[c] = freqS1.GetValueOrDefault(c, 0) + 1;

        Dictionary<char, int> windowFreq = [];
        var window = s1.Length;

        // populate the freq based on initial window
        for (int i = 0; i < window; i++)
            windowFreq[s2[i]] = windowFreq.GetValueOrDefault(s2[i], 0) + 1;

        for (int i = 0; i <= s2.Length - window; i++)
        {
            if (TwoDictEqual(freqS1, windowFreq))
                return true;

            if (i + window >= s2.Length)
                continue;

            windowFreq[s2[i]] = windowFreq[s2[i]] - 1; // decrease the char outside of window
            windowFreq[s2[i + window]] = windowFreq.GetValueOrDefault(s2[i + window], 0) + 1; // add the new char of window
        }

        return false;

        static bool TwoDictEqual(Dictionary<char, int> d1, Dictionary<char, int> d2)
        {
            foreach (var kv in d1)
            {
                if (kv.Value != d2.GetValueOrDefault(kv.Key, -1))
                    return false;
            }

            return true;
        }
    }
}
