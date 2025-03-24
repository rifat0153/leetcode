namespace Leetcode.Easy;

internal class MaximumAverageSubArray1
{
    public static void Test()
    {
        Console.WriteLine(FindMaxAverage([1, 12, -5, -6, 50, 3], 4));
        Console.WriteLine(FindMaxAverage([5], 1));
    }

    public static double FindMaxAverage(int[] nums, int k)
    {
        double maxAvg = double.MinValue;
        double currSum = 0;

        int l = 0;
        for (int r = 0; r < nums.Length; r++)
        {
            if (r < k)
            {
                currSum += nums[r];
                if (r == k - 1)
                    maxAvg = Math.Max(maxAvg, currSum / k);
                continue;
            }

            currSum -= nums[l];
            currSum += nums[r];
            maxAvg = Math.Max(maxAvg, currSum / k);
            l++;
        }

        return maxAvg;
    }

    public static double FindMaxAverageReadable(int[] nums, int k)
    {
        double currSum = 0;

        // Calculate the sum of the first 'k' elements
        for (int i = 0; i < k; i++)
        {
            currSum += nums[i];
        }

        double maxAvg = currSum / k;

        // Slide the window across the array
        for (int r = k; r < nums.Length; r++)
        {
            currSum += nums[r] - nums[r - k];
            maxAvg = Math.Max(maxAvg, currSum / k);
        }

        return maxAvg;
    }
}
