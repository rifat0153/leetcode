namespace Leetcode.Medium;

internal class TopKFreqItems
{
    public static void Test()
    {
        TopKFrequent([1, 1, 1, 2, 2, 3], 2).ToList().ForEach(Console.WriteLine);
        //TopKFrequent([1], 1).ToList().ForEach(Console.WriteLine);
    }

    public static int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> freq = [];

        foreach (var n in nums)
        {
            if (freq.TryGetValue(n, out var count))
                freq[n] = ++count;
            else
                freq[n] = 1;
        }

        freq.ToList().ForEach(kv => Console.WriteLine($"{kv.Key} - {kv.Value}"));

        var buckets = Enumerable.Range(0, nums.Length).Select(i => new List<int>()).ToArray();

        foreach (var (key, value) in freq)
        {
            buckets[value - 1].Add(key);
        }

        List<int> result = [];

        for (int i = buckets.Length - 1; i >= 0 && result.Count < k; i--)
        {
            for (int j = buckets[i].Count - 1; j >= 0 && result.Count < k; j--)
                result.Add(buckets[i][j]);
        }

        return result.ToArray();
    }
}
