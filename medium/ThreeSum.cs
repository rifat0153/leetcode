namespace Leetcode.Medium;

public class ThreeSum
{
    public IList<IList<int>> ThreeSumMethod(int[] nums)
    {
        Array.Sort(nums);

        var set = new HashSet<(int, int, int)>();

        for (int i = 0; i < nums.Length - 2; i++)
        {
            // if prev and curr is same, just continue, since duplicates are not allowed
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }

            int left = i + 1;
            int right = nums.Length - 1;

            while (left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];
                if (sum > 0)
                {
                    right--;
                }
                else if (sum < 0)
                {
                    left++;
                }
                else
                {
                    set.Add((nums[i], nums[left], nums[right]));
                    while (left < right && nums[left] == nums[left + 1])
                        left++;
                    while (left < right && nums[right] == nums[right - 1])
                        right--;
                    left++;
                    right--;
                }
            }
        }

        var list = set.Select(x => new List<int> { x.Item1, x.Item2, x.Item3 });

        return list.ToArray();
    }

    public static void Test()
    {
        // Create an instance of the solution class
        ThreeSum solution = new ThreeSum();

        // Define test cases
        int[][] testCases =
        [
            [0, 0, 0],
            [-1, 0, 1, 2, -1, -4],
            //  [-1, 0, 1, 2, -1, -4], []
        ];

        // Expected results
        IList<IList<int>>[] expectedResults =
        [
            [
                [0, 0, 0],
            ],
            [
                [-1, -1, 2],
                [-1, 0, 1],
            ],
            [
                [-1, -1, 2],
                [-1, 0, 1],
            ],
            [],
        ];

        // Run the test cases
        for (int i = 0; i < testCases.Length; i++)
        {
            IList<IList<int>> result = solution.ThreeSumMethod(testCases[i]);
            Console.WriteLine($"Test case {i + 1}:");
            Console.WriteLine("Expected:");
            foreach (var list in expectedResults[i])
            {
                Console.WriteLine(string.Join(",", list));
            }
            Console.WriteLine("Got:");
            foreach (var list in result)
            {
                Console.WriteLine(string.Join(",", list));
            }
        }
    }
}
