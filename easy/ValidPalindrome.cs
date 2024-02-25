namespace leetcode.easy;

public class ValidPalindrome
{
    public bool IsPalindrome(string s)
    {
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            if (!char.IsLetterOrDigit(s[left]))
            {
                left++;
            }
            else if (!char.IsLetterOrDigit(s[right]))
            {
                right--;
            }
            else
            {
                if (char.ToLower(s[left]) != char.ToLower(s[right]))
                {
                    return false;
                }
                left++;
                right--;
            }
        }

        return true;
    }

    public static void Test()
    {
        // Create an instance of the solution class
        ValidPalindrome solution = new ValidPalindrome();

        // Define test cases
        string[] testCases = new string[] { "A man, a plan, a canal: Panama", "race a car" };

        // Expected results
        bool[] expectedResults = new bool[] { true, false };

        // Run the test cases
        for (int i = 0; i < testCases.Length; i++)
        {
            bool result = solution.IsPalindrome(testCases[i]);
            Console.WriteLine($"Test case {i + 1}: Expected: {expectedResults[i]}, Got: {result}");
        }
    }
}
