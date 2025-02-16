namespace Leetcode.Medium;

internal class DailyTemps
{
    public static void Test()
    {
        DailyTemperatures([73, 74, 75, 71, 69, 72, 76, 73])
            .Select(x => $"{x},")
            .ToList()
            .ForEach(Console.Write);
    }

    public static int[] DailyTemperatures(int[] temperatures)
    {
        int[] result = Enumerable.Range(0, temperatures.Length).Select(_ => 0).ToArray();
        Stack<(int Temp, int Index)> stack = [];
        stack.Push((temperatures[0], 0));

        for (int i = 1; i < temperatures.Length; i++)
        {
            var temp = temperatures[i];

            while (stack.TryPeek(out var val) && val.Temp < temp)
            {
                var tuple = stack.Pop();
                result[tuple.Index] = i - tuple.Index;
            }

            stack.Push((temp, i));
        }

        return result;
    }
}
