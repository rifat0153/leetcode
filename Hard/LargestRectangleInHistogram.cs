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
            var height = heights[i];

            int start = i; // Track where the rectangle starts
            while (stack.TryPeek(out var last) && last.height > height)
            {
                stack.Pop();
                area = Math.Max(last.height * (i - last.index), area);
                start = last.index; // Extend the start index
            }

            stack.Push((start, height));
        }

        while (stack.TryPeek(out var item))
        {
            stack.Pop();
            area = Math.Max(item.height * (heights.Length - item.index), area);
        }

        return area;
    }
}
