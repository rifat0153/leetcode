namespace leetcode.hard;

public class TrappingRainWater
{
    public int Trap(int[] height)
    {
        if (height.Length == 0)
            return 0;

        List<int> leftMaxes = new List<int>();
        int leftMax = height[0];
        for (int i = 0; i < height.Length; i++)
        {
            leftMax = Math.Max(height[i], leftMax);
            leftMaxes.Add(leftMax);
        }

        List<int> rightMaxes = new List<int>();
        int rightMax = height[^1];
        for (int i = height.Length - 1; i >= 0; i--)
        {
            rightMax = Math.Max(height[i], rightMax);
            rightMaxes.Add(rightMax);
        }
        rightMaxes.Reverse();

        List<int> minValues = new List<int>();
        for (int i = 0; i < height.Length; i++)
        {
            var diff = Math.Min(leftMaxes[i], rightMaxes[i]) - height[i];
            minValues.Add(diff > 0 ? diff : 0);
        }

        return minValues.Sum();
    }

    public int TrapNoExtraMemory(int[] height)
    {
        if (height.Length == 0)
        {
            return 0;
        }

        int result = 0;
        int left = 0;
        int right = height.Length - 1;
        int leftMax = height[0];
        int rightMax = height[^1];

        while (left < right)
        {
            if (leftMax < rightMax)
            {
                left++;
                leftMax = Math.Max(leftMax, height[left]);
                result += leftMax - height[left];
            }
            else
            {
                right--;
                rightMax = Math.Max(rightMax, height[right]);
                result += rightMax - height[right];
            }
        }

        return result;
    }

    public static void Test()
    {
        var solution = new TrappingRainWater();

        // Test case 1
        var input1 = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
        var actualOutput1 = solution.TrapNoExtraMemory(input1);
        Console.WriteLine($"Test case 1 result: {actualOutput1}");
    }
}
