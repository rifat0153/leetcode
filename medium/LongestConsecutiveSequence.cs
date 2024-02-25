using System.Collections.Immutable;

namespace leetcode.medium
{
    public class LongestConsecutiveSequence
    {
        public int LongestConsecutive(int[] nums)
        {
            var set = nums.ToImmutableHashSet();

            var longetst = 1;

            foreach (var num in nums)
            {
                if (set.Contains(num - 1))
                {
                    continue;
                }

                int seqLength = 1;
                while (set.Contains(num + seqLength))
                {
                    seqLength += 1;
                }

                longetst = Math.Max(longetst, seqLength);
            }

            return longetst;
        }

        public static void Test()
        {
            // Create an instance of the solution class
            LongestConsecutiveSequence solution = new();

            // Define test cases
            int[][] testCases = new int[][]
            {
                new int[] { 100, 4, 200, 1, 3, 2 },
                new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }
            };

            // Expected results
            int[] expectedResults = new int[] { 4, 9 };

            // Run the test cases
            for (int i = 0; i < testCases.Length; i++)
            {
                int result = solution.LongestConsecutive(testCases[i]);
                Console.WriteLine(
                    $"Test case {i + 1}: Expected: {expectedResults[i]}, Got: {result}"
                );
            }
        }
    }
}
