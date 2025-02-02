namespace leetcode.Easy;

public class SingleNumber
{
    public static void Test()
    {
        int[] nums = { 4, 1, 2, 1, 2 };

        Console.WriteLine(SingleNumberTest(nums));
    }

    public static int SingleNumberTest(int[] nums)
    {
        Dictionary<int, int> numsFreq = new();

        if (nums.Length == 1)
        {
            return nums[0];
        }

        int singleNumber = nums[0];

        foreach (int n in nums)
        {
            if (numsFreq.ContainsKey(n))
            {
                numsFreq[n] = 2;
            }
            else
            {
                numsFreq.Add(n, 1);
            }
        }

        return numsFreq.Where(n => n.Value == 1).SingleOrDefault()!.Key;
    }
}
