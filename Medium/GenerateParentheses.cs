namespace Leetcode.Medium;

internal class GenerateParentheses
{
    public static void Test()
    {
        GenerateParenthesisImpl(3).ToList().ForEach(Console.WriteLine);
    }

    public static IList<string> GenerateParenthesisImpl(int n)
    {
        List<string> result = [];

        void Backtrack(List<string> list, int openCount, int closeCount)
        {
            if (openCount == closeCount && closeCount == n)
            {
                result.Add(string.Join("", list));
                return;
            }

            if (openCount < n)
            {
                list.Add("(");
                Backtrack(list, openCount + 1, closeCount);
                list.RemoveAt(list.Count - 1);
            }

            if (closeCount < openCount)
            {
                list.Add(")");
                Backtrack(list, openCount, closeCount + 1);
                list.RemoveAt(list.Count - 1);
            }
        }

        Backtrack([], 0, 0);

        return result;
    }
}
