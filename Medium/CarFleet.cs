using LanguageExt.TypeClasses;

namespace Leetcode.Medium;

internal class CarFleet
{
    public static void Test()
    {
        int target = 12;
        int[] position = [10, 8, 0, 5, 3];
        int[] speed = [2, 4, 1, 1, 3];

        Console.WriteLine(CarFleetTest(target, position, speed));
    }

    public static int CarFleetTest(int target, int[] position, int[] speed)
    {
        if (position.Length == 0)
            return 0;

        Stack<(int pos, int speed)> stack = new();

        var pairs = position.Zip(speed, (p, s) => (p, s)).OrderByDescending(x => x.p);

        foreach (var pair in pairs)
        {
            if (!stack.TryPeek(out var prevPair))
            {
                stack.Push(pair);
                continue;
            }

            stack.Push(pair);

            var prevTime = (double)(target - prevPair.pos) / prevPair.speed;
            var currTime = (double)(target - pair.p) / pair.s;

            if (currTime <= prevTime)
            {
                stack.Pop();
            }
        }

        return stack.Count;
    }
}
