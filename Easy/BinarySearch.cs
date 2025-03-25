namespace Leetcode.Easy;

internal class BinarySearch
{
    public static void Test()
    {
        Console.WriteLine(Search([-1, 0, 3, 5, 9, 12], 9));
        Console.WriteLine(Search([5], 5));
        //Console.WriteLine(Search([-1, 0, 3, 5, 9, 12], 2));
    }

    public static int Search(int[] nums, int target)
    {
        int l = 0;
        int r = nums.Length - 1;

        while (l <= r)
        {
            int mid = (l + r) / 2;

            if (nums[mid] == target)
                return mid;

            if (nums[mid] < target)
            {
                l = mid + 1;
            }
            else
            {
                r = mid - 1;
            }
        }

        return -1;
    }
}
