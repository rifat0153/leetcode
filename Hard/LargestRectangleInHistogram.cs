namespace Leetcode.Hard;

internal class LargestRectangleInHistogram
{
    public static void Test()
    {
        Console.WriteLine(LargestRectangleArea([2, 1, 5, 6, 2, 3]));
        Console.WriteLine(LargestRectangleArea([2, 4]));
        Console.WriteLine(LargestRectangleArea([1, 1]));
        Console.WriteLine(LargestRectangleArea([2, 4]));
        Console.WriteLine(LargestRectangleArea([4, 2]));
        Console.WriteLine(LargestRectangleArea([2, 1, 2]));
    }

    public static int LargestRectangleArea(int[] heights)
    {
        Stack<(int index, int height)> stack = [];
        int max = 0;

        for (int i = 0; i < heights.Length; i++)
        {
            int h = heights[i];
            int start = i;
            while (stack.TryPeek(out var last) && last.height > h)
            {
                var (index, height) = stack.Pop();
                max = Math.Max(max, height * (i - index));
                start = index;
            }

            stack.Push((start, h));
        }

        foreach (var (index, height) in stack)
        {
            var area = height * (heights.Length - index);
            max = Math.Max(max, area);
        }

        return max;
    }
}
