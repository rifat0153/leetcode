namespace Leetcode.Easy;

public class TwoSum
{
    public static void Test()
    {
        int[] nums = { 2, 7, 11, 15 };
        int target = 9;
        // int[] nums = { 3, 2, 4 };
        // int target = 6;

        var result = Invoke(nums, target);

        foreach (var n in result)
        {
            Console.Write($"{n} ");
        }
    }

    public static int[] Invoke(int[] nums, int target)
    {
        Dictionary<int, int> dict = new();

        for (int i = 0; i < nums.Length; i++)
        {
            var complement = target - nums[i];
            if (dict.ContainsKey(complement))
            {
                return new int[] { dict[complement], i };
            }
            dict[nums[i]] = i;
        }

        return Array.Empty<int>();
    }
}
