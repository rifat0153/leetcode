namespace Leetcode.Easy;

public class PlusOne
{
    public static void Test()
    {
        int[] digits = { 4, 3, 2, 1 };

        var result = Invoke(digits);

        foreach (var n in result)
        {
            Console.Write($"{n} ");
        }
    }

    public static int[] Invoke(int[] digits)
    {
        var result = new List<int>();

        var carry = 0;

        for (var i = digits.Length - 1; i >= 0; i--)
        {
            var digit = digits[i];

            if (i == digits.Length - 1)
            {
                digit++;
            }

            digit += carry;

            if (digit > 9)
            {
                carry = 1;
                digit = 0;
            }
            else
            {
                carry = 0;
            }

            result.Add(digit);
        }

        if (carry == 1)
        {
            result.Add(1);
        }

        result.Reverse();

        return result.ToArray();
    }
}
