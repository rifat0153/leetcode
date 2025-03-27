using LanguageExt.TypeClasses;

namespace Leetcode.Medium;

internal class Search2DMatrix
{
    public static void Test()
    {
        Console.WriteLine(
            SearchMatrix(
                [
                    [1, 3, 5, 7],
                    [10, 11, 16, 20],
                    [23, 30, 34, 60],
                ],
                34
            )
        );

        Console.WriteLine(
            SearchMatrix(
                [
                    [1, 3, 5, 7],
                    [10, 11, 16, 20],
                    [23, 30, 34, 60],
                ],
                16
            )
        );
    }

    public static bool SearchMatrix(int[][] matrix, int target)
    {
        var foundRow = FindTargetRow(matrix);
        if (foundRow == -1)
            return false;

        var nums = matrix[foundRow];
        int l = 0;
        int r = nums.Length - 1;

        while (l <= r)
        {
            int mid = (l + r) / 2;

            if (nums[mid] == target)
                return true;

            if (nums[mid] < target)
                l = mid + 1;
            else
                r = mid - 1;
        }

        return false;

        int FindTargetRow(int[][] matrix)
        {
            int colLength = matrix[0].Length;
            int l = 0;
            int r = matrix.Length - 1;

            while (l <= r)
            {
                int mid = (l + r) / 2;
                int firstColVal = matrix[mid][0];
                int lastColVal = matrix[mid][colLength - 1];

                if (target >= firstColVal && target <= lastColVal)
                    return mid;
                else if (firstColVal > target)
                    r = mid - 1;
                else
                    l = mid + 1;
            }

            return -1;
        }
    }
}
