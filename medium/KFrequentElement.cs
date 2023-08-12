namespace leetcode.medium;

public class KFrequentElement
{
    public static void Test()
    {
        int[] nums = { 1, 1, 1, 2, 2, 3 };

        Console.WriteLine(KFrequentElementTest(nums, 2));
    }

    public static int[] KFrequentElementTest(int[] nums, int k)
    {
        Dictionary<int, int> numsFreq = new();

        foreach (var n in nums)
        {
            if (numsFreq.TryGetValue(n, out int value))
            {
                numsFreq[n] = ++value;
            }
            else
            {
                numsFreq[n] = 1;
            }
        }

        List<int>[] buckets = Enumerable
            .Range(0, nums.Length + 1)
            .Select(_ => new List<int>())
            .ToArray();

        foreach (var entry in numsFreq)
        {
            int num = entry.Key;
            int freq = entry.Value;

            buckets[freq].Add(num);
        }

        List<int> result = new();
        for (int i = buckets.Length - 1; i >= 0 && result.Count < k; i--)
        {
            if (buckets[i].Count > 0)
            {
                result.AddRange(buckets[i]);
            }
        }

        return result.Take(k).ToArray();
    }
}
