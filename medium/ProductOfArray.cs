namespace leetcode.medium;

public class ProductOfArray
{
    public int[] CalculateProductOfArray(int[] nums)
    {
        int[] result = new int[nums.Length];

        // calculate the prefixes
        int prefix = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            result[i] = prefix;
            prefix *= nums[i];
        }

        // calcualte the postfix
        int postfix = 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            result[i] = result[i] * postfix;
            postfix *= nums[i];
        }

        return result;
    }

    public static void Test()
    {
        var productOfArray = new ProductOfArray();
        var testArray = new int[] { 1, 2, 3, 4 };
        var products = productOfArray.CalculateProductOfArray(testArray);
        foreach (var item in products)
        {
            Console.Write($"{item},");
        }
    }
}
