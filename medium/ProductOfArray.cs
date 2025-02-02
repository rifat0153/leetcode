namespace Leetcode.Medium;

internal class ProductOfArray
{
    public static void Test()
    {
        int[] nums = [1, 2, 4, 6];

        Console.WriteLine(string.Join(", ", ProductExceptSelf(nums)));
    }

    public static int[] ProductExceptSelf(int[] nums)
    {
        var total = nums.Aggregate(1, (acc, curr) => acc * curr, acc => acc);

        Console.WriteLine(total);

        return nums.Select(x => total / x).ToArray();
    }
}
