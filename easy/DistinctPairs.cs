namespace leetcode.easy;

public class DistinctPairs
{
    public static void Test()
    {
        int[] nums = { 1, 1, 2, 2, 3, 3 };
        int k = 1;

        var result = DistinctPairCount(nums, k);

        Console.Write(result);
    }

    public static int DistinctPairCount(int[] nums, int k)
    {
        HashSet<(int, int)> pairs = new();

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i; j < nums.Length; j++)
            {
                // To make we create distinct pairs we will sort the numbers in a deterministic way
                if (nums[j] < nums[i])
                {
                    pairs.Add((nums[j], nums[i]));
                }
                else
                {
                    pairs.Add((nums[i], nums[j]));
                }
            }
        }

        foreach (var pair in pairs)
        {
            Console.WriteLine($"{pair.Item1} {pair.Item2}");
        }

        var passingPairs = pairs.Where(p => p.Item2 - k == p.Item1 + p.Item2).Count();

        return passingPairs;
    }
}
