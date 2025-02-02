namespace Leetcode.Easy;

public class ValidParenthesis
{
    public static void Test()
    {
        var s = "(]";

        Console.WriteLine(Invoke(s));
    }

    public static bool Invoke(string s)
    {
        Stack<char> charsStack = new();

        foreach (var c in s.ToCharArray())
        {
            // push to stack
            if (c == '(' || c == '[' || c == '{')
            {
                charsStack.Push(c);
                continue;
            }

            // pop the stack and see if the starting Parenthesis is found
            var val = charsStack.Pop();

            if (c == ')' && val != '(')
            {
                return false;
            }
            if (c == ']' && val != '[')
            {
                return false;
            }
            if (c == '}' && val != '{')
            {
                return false;
            }
        }

        return charsStack.Count == 0;
    }
}
