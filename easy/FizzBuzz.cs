namespace Leetcode.Easy;

public class FizzBuzz
{
    public static void Test()
    {
        var list = Invoke(15);

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }

    public static string[] Invoke(int n)
    {
        string[] list = new string[n];

        foreach (var i in Enumerable.Range(1, n))
        {
            list[i - 1] = i switch
            {
                var x when x % 3 == 0 && x % 5 == 0 => "FizzBuzz",
                var x when x % 3 == 0 => "Fizz",
                var x when x % 5 == 0 => "Buzz",
                _ => i.ToString(),
            };
        }

        return list;
    }
}
