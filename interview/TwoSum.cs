namespace Leetcode.interview;

// Q: Two Sum: Given an array of integers, find two numbers such that they add up to a specific target number.
// return the indices
public class TwoSum
{
    public static void Test()
    {
        int[] nums1 = { 2, 7, 11, 15 };
        int target1 = 9;

        var result1 = Invoke(nums1, target1);
        Console.WriteLine($"Input: [{string.Join(", ", nums1)}], Target: {target1}");
        Console.WriteLine($"Expected Output: [0, 1]");
        Console.WriteLine($"Your Output: [{string.Join(", ", result1)}]");
        Console.WriteLine("------------------------");

        int[] nums2 = { 3, 2, 4 };
        int target2 = 6;

        var result2 = Invoke(nums2, target2);
        Console.WriteLine($"Input: [{string.Join(", ", nums2)}], Target: {target2}");
        Console.WriteLine($"Expected Output: [1, 2]");
        Console.WriteLine($"Your Output: [{string.Join(", ", result2)}]");
        Console.WriteLine("------------------------");

        int[] nums3 = { 3, 3 };
        int target3 = 6;

        var result3 = Invoke(nums3, target3);
        Console.WriteLine($"Input: [{string.Join(", ", nums3)}], Target: {target3}");
        Console.WriteLine($"Expected Output: [0, 1]");
        Console.WriteLine($"Your Output: [{string.Join(", ", result3)}]");
        Console.WriteLine("------------------------");
    }

    public static int[] Invoke(int[] nums, int target)
    {
        // Create a dictionary to hold numbers and their indices.
        var dict = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if (dict.ContainsKey(complement) && dict[complement] != i)
            {
                return new int[] { dict[complement], i };
            }

            // Add or update the number in the dictionary.
            dict[nums[i]] = i;
        }

        // Return an empty array if no solution is found.
        // (You might want to handle this case differently based on the problem constraints.)
        return new int[0];
    }
}
