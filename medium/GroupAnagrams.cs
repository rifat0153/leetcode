namespace ConsoleApp1.Medium;

internal class GroupAnagrams
{
    public static void Test()
    {
        GroupAnagramsTest(["eat", "tea", "tan", "ate", "nat", "bat"])
            .ToList()
            .ForEach(x => Console.WriteLine(string.Join("\t", x)));
    }

    public static IList<IList<string>> GroupAnagramsTest(string[] strs)
    {
        Dictionary<string, IList<string>> anagrams = [];

        foreach (var str in strs)
        {
            char[] charArr = new char[26];

            foreach (var c in str)
            {
                charArr[c - 'a']++;
            }

            var key = new string(charArr);
            if (anagrams.TryGetValue(key, out var value))
                value?.Add(str);
            else
                anagrams[key] = [str];
        }

        return anagrams.Values.ToList();
    }
}
