namespace leetcode.medium;

public class TwoSum2
{
    public int[] TwoSum(int[] numbers, int target)
    {
        int left = 0;
        int right = numbers.Length - 1;

        while(left < right)
        {
            if(numbers[left] + numbers[right]  > target )
            {
                right--;
            }
            else if (numbers[left] + numbers[right]  < target )
            {
                left++;
            }
            else {
                return [left++, right++];
            }
        }

        return [];
    }

    public static void Test()
    {
        // Create an instance of the solution class
        TwoSum2 solution = new TwoSum2();

        // Define test cases
        var testCases = new Tuple<int[], int>[]
        {
            new Tuple<int[], int>(new int[] { 2, 7, 11, 15 }, 9),
            new Tuple<int[], int>(new int[] { 3, 2, 4 }, 6)
        };

        // Expected results
        var expectedResults = new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 } };

        // Run the test cases
        for (int i = 0; i < testCases.Length; i++)
        {
            int[] result = solution.TwoSum(testCases[i].Item1, testCases[i].Item2);
            Console.WriteLine(
                $"Test case {i + 1}: Expected: {string.Join(",", expectedResults[i])}, Got: {string.Join(",", result)}"
            );
        }
    }
}
