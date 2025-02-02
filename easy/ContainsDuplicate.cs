namespace ConsoleApp1.Easy;

public class ContainsDuplicate
{
    public static void Test()
    {
        int[] s = { 1, 2, 3, 1 };

        Console.WriteLine(Invoke(s));
    }

    public static bool Invoke(int[] nums)
    {
        Dictionary<int, int> dict = new();

        foreach (var n in nums)
        {
            if (dict.ContainsKey(n))
            {
                return true;
            }
            else
            {
                dict.Add(n, n);
            }
        }

        return false;
    }
}
