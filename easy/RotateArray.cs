namespace leetcode.easy;

public class RotateArray
{
    public static void Test()
    {
        int[] nums = { 1, 2, 3, 4, 5, 6, 7 };

        Console.WriteLine(RotateArrayTest(nums, 3));
    }

    public static int[] RotateArrayTest(int[] nums, int k)
    {
        int l = 0,
            r = nums.Length - 1;

        k %= nums.Length;

        while (l < r)
        {
            (nums[l], nums[r]) = (nums[r], nums[l]);
            l++;
            r--;
        }

        l = 0;
        r = k - 1;
        while (l < r)
        {
            (nums[l], nums[r]) = (nums[r], nums[l]);
            l++;
            r--;
        }

        l = k;
        r = nums.Length - 1;
        while (l < r)
        {
            (nums[l], nums[r]) = (nums[r], nums[l]);
            l++;
            r--;
        }

        return nums;
    }
}
