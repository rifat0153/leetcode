namespace leetcode.easy;

public class MoveZeroes
{
    public static void Test()
    {
        int[] nums = { 0, 1, 0, 3, 12 };

        var s = "asdas asdasdasd asdasd hello";

        var lastWord = s.Split().Last().Length;

        Console.WriteLine(lastWord);

        var result = Invoke(nums);

        foreach (var n in result)
        {
            Console.Write($"{n} ");
        }
    }

    public static int[] Invoke(int[] nums)
    {
        var j = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                nums[j] = nums[i];
                j++;
            }
        }

        for (; j < nums.Length; j++)
        {
            nums[j] = 0;
        }

        return nums;
    }
}
