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
        int area = 0;
        Stack<(int index, int height)> stack = [];

        for (int i = 0; i < heights.Length; i++)
        {
            var h = heights[i];
            if (stack.Count == 0)
            {
                stack.Push((i, h));
                area = Math.Max(area, h);
                continue;
            }

            int start = i;
            while (stack.TryPeek(out var last) && last.height > h)
            {
                stack.Pop();
                area = Math.Max(area, (i - last.index) * last.height);
                start = last.index;
            }

            stack.Push((start, h));
        }

        foreach (var item in stack)
        {
            area = Math.Max(area, (heights.Length - item.index) * item.height);
        }

        return area;
    }
}
