namespace leetcode.easy;

public class IntersectionTwoArrays
{
    public static void Test()
    {
        int[] nums1 = { 4, 9, 5 };
        int[] nums2 = { 9, 4, 9, 8, 4 };

        var result = Intersect(nums1, nums2);

        foreach (var n in result)
        {
            Console.Write($"{n} ");
        }
    }

    public static int[] Intersect(int[] nums1, int[] nums2)
    {
        ConvertArrayToDict(nums1, out Dictionary<int, int> dict1);
        ConvertArrayToDict(nums2, out Dictionary<int, int> dict2);

        // loop over each element in dict1 and see if it exists in dict2
        // if it does, add the min no of occurences to the result
        List<int> result = new();

        foreach (var kvp in dict1)
        {
            if (dict2.ContainsKey(kvp.Key))
            {
                int min = Math.Min(kvp.Value, dict2[kvp.Key]);

                for (int i = 0; i < min; i++)
                {
                    result.Add(kvp.Key);
                }
            }
        }

        return result.ToArray();
    }

    private static void ConvertArrayToDict(int[] nums, out Dictionary<int, int> dict)
    {
        dict = new Dictionary<int, int>();

        foreach (var n in nums)
        {
            if (dict.ContainsKey(n))
            {
                dict[n]++;
            }
            else
            {
                dict.Add(n, 1);
            }
        }
    }
}
