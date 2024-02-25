using System;
using System.Collections.Generic;

namespace leetcode.medium;

public class GroupAnagrams
{
    public static List<List<string>> GroupAnagramMethod(string[] strs)
    {
        var anagrams = new Dictionary<string, List<string>>();

        foreach (var s in strs)
        {
            var count = new char[26]; // count each char occurence in s
            foreach (var c in s)
            {
                count[c - 'a']++;
            }

            var hash = new string(count);

            if (!anagrams.ContainsKey(hash))
            {
                anagrams[hash] = new List<string>();
            }

            anagrams[hash].Add(s);
        }

        return anagrams.Values.ToList();
    }

    public static void Test()
    {
        string[] exampleData = { "eat", "tea", "tan", "ate", "nat", "bat" };

        List<List<string>> result = GroupAnagramMethod(exampleData);

        Console.WriteLine("Grouped Anagrams:");
        foreach (List<string> group in result)
        {
            Console.WriteLine(string.Join(", ", group));
        }
    }
}
