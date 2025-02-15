namespace Leetcode.Medium;

internal class ReversePolishNotation
{
    public static void Test()
    {
        Console.WriteLine(EvalRPN(["2", "1", "+", "3", "*"]));
        Console.WriteLine(EvalRPN(["4", "13", "5", "/", "+"]));
    }

    public static int EvalRPN(string[] tokens)
    {
        const string Add = "+";
        const string Subtract = "-";
        const string Multipy = "*";
        const string Divide = "/";

        Stack<string> stack = [];

        foreach (var item in tokens)
        {
            if (item is not (Add or Subtract or Multipy or Divide))
            {
                stack.Push(item);
                continue;
            }

            string r = stack.Pop();
            string l = stack.Pop();

            stack.Push(Operate(l, r, item).ToString());
        }

        return int.Parse(stack.Pop());

        static int Operate(string left, string right, string operand)
        {
            int l = int.Parse(left);
            int r = int.Parse(right);
            return operand switch
            {
                Add => l + r,
                Subtract => l - r,
                Multipy => l * r,
                Divide => l / r,
                _ => throw new InvalidOperationException(),
            };
        }
    }
}
