namespace Leetcode.Easy;

public class BuySellStock
{
    public int MaxProfit(int[] prices)
    {
        if (prices.Length < 2)
        {
            return 0;
        }

        int left = 0;
        int right = 1;
        int maxProfit = 0;

        while (right < prices.Length)
        {
            if (prices[right] < prices[left])
            {
                left = right;
                right++;
            }
            else
            {
                maxProfit = Math.Max(maxProfit, prices[right] - prices[left]);
                right++;
            }
        }

        return maxProfit;
    }

    public static void Test()
    {
        var solution = new BuySellStock();

        // Test case 1
        var input1 = new int[] { 7, 1, 5, 3, 6, 4 };
        var actualOutput1 = solution.MaxProfit(input1);
        Console.WriteLine($"Test case 1 result: {actualOutput1}");

        // Test case 2 7,6,4,3,1
        var input2 = new int[] { 7, 6, 4, 3, 1 };
        var actualOutput2 = solution.MaxProfit(input2);
        Console.WriteLine($"Test case 1 result: {actualOutput2}");
    }
}
