using LanguageExt.TypeClasses;

namespace Leetcode.Medium;

internal class CarFleet
{
    public static void Test()
    {
        //int target = 12;
        //int[] position = [10, 8, 0, 5, 3];
        //int[] speed = [2, 4, 1, 1, 3];
        //int target = 10;
        //int[] position = [3];
        //int[] speed = [3];
        int target = 10;
        int[] position = [6, 8];
        int[] speed = [3, 2];

        Console.WriteLine(CarFleetTest(target, position, speed));
    }

    public static int CarFleetTest(int target, int[] position, int[] speed)
    {
        if (position.Length == 0)
            return 0;

        Stack<double> stack = [];

        var pairs = position.Zip(speed, (p, s) => (pos: p, speed: s)).OrderByDescending(p => p.pos);

        foreach (var item in pairs)
        {
            double time = (double)(target - item.pos) / item.speed;
            if (stack.Count == 0)
            {
                stack.Push(time);
                continue;
            }

            stack.TryPeek(out var currSlowestTime);

            if (time >= currSlowestTime)
            {
                stack.Push(time);
            }
        }

        return stack.Count;
    }

    public static int CarFleetTestFunctional(int target, int[] position, int[] speed) =>
        position
            .Zip(speed, (p, s) => (pos: p, speed: s))
            .OrderByDescending(x => x.pos)
            .Aggregate(
                new Stack<double>(),
                (stack, pair) =>
                {
                    var timeToDest = (double)(target - pair.pos) / pair.speed;
                    if (stack.Count == 0 || timeToDest > stack.Peek())
                    {
                        stack.Push(timeToDest);
                    }
                    return stack;
                }
            )
            .Count;
}
