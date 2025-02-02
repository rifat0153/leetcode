namespace Leetcode.Easy;

public class StockPrice
{
    public static void Test()
    {
        int[] prices = { 7, 6, 4, 3, 1 };

        Console.WriteLine(MaxProfit(prices));
    }

    public static int MaxProfit(int[] prices)
    {
        if (prices.Length == 0 || prices.Length == 1)
            return 0;

        int profit = 0;
        int stockPrice = prices[0];

        for (int i = 0; i < prices.Length; i++)
        {
            int currPrice = prices[i];

            //  sell the stock if currPrice is greater than stock price
            if (currPrice > stockPrice)
            {
                profit += currPrice - stockPrice;
                stockPrice = currPrice;
            }

            // we just update sotck price mimicing we sold on the same day
            if (currPrice <= stockPrice)
            {
                stockPrice = currPrice;
            }
        }

        return profit;
    }
}
