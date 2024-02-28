using System;

namespace leetcode.medium;

public class ContainerWithMostWater
{
    public int MaxArea(int[] height)
    {
        int left = 0;
        int right = height.Length - 1;

        int maxArea = 0;

        while (left < right)
        {
            int area = Math.Min(height[left], height[right]) * (right - left);
            maxArea = Math.Max(maxArea, area);

            if (height[left] < height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return maxArea;
    }

    public static void Test()
    {
        var solution = new ContainerWithMostWater();

        // Test case 1
        var input1 = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
        var expectedOutput1 = 49;
        var actualOutput1 = solution.MaxArea(input1);
        Console.WriteLine(
            actualOutput1 == expectedOutput1 ? "Test case 1 passed" : "Test case 1 failed"
        );

        // Test case 2
        var input2 = new int[] { 1, 1 };
        var expectedOutput2 = 1;
        var actualOutput2 = solution.MaxArea(input2);
        Console.WriteLine(
            actualOutput2 == expectedOutput2 ? "Test case 2 passed" : "Test case 2 failed"
        );

        // Test case 3
        var input3 = new int[] { 4, 3, 2, 1, 4 };
        var expectedOutput3 = 16;
        var actualOutput3 = solution.MaxArea(input3);
        Console.WriteLine(
            actualOutput3 == expectedOutput3 ? "Test case 3 passed" : "Test case 3 failed"
        );

        // Test case 4
        var input4 = new int[] { 1, 2, 1 };
        var expectedOutput4 = 2;
        var actualOutput4 = solution.MaxArea(input4);
        Console.WriteLine(
            actualOutput4 == expectedOutput4 ? "Test case 4 passed" : "Test case 4 failed"
        );
    }
}
