namespace Leetcode.Easy;

public class BuySellStock
{
    public int MaxProfit2(int[] prices)
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

    public int MaxProfit(int[] prices)
    {
        int l = 0;
        int r = 1;
        int maxProfit = 0;

        while (r < prices.Length)
        {
            int profit = prices[r] - prices[l];
            maxProfit = Math.Max(profit, maxProfit);

            if (profit >= 0)
                r++;
            else
                l++;
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
