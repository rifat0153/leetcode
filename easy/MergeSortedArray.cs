namespace Leetcode.Easy;

public class MergeSortedArray
{
    public static void Test()
    {
        int[] nums1 = { 1, 2, 3, 0, 0, 0 };
        int[] nums2 = { 2, 5, 6 };

        Invoke(nums1, 3, nums2, 3);

        foreach (var i in nums1)
        {
            Console.WriteLine(i);
        }
    }

    public static void Invoke(int[] nums1, int m, int[] nums2, int n)
    {
        for (int i = n; i < 1; i++) { }
    }
}
