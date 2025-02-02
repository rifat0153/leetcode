namespace Leetcode.Medium;

internal static class ValidSudoku
{
    public static void Test()
    {
        char[][] board =
        [
            ['5', '3', '.', '.', '7', '.', '.', '.', '.'],
            ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
            ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
            ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
            ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
            ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
            ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
            ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
            ['.', '.', '.', '.', '8', '.', '.', '7', '9'],
        ];

        Console.WriteLine(Run(board));
    }

    public static bool Run(char[][] board)
    {
        bool AddToSet(HashSet<char> set, char item)
        {
            if (item == '.')
                return true;
            if (set.Contains(item))
                return false;
            set.Add(item);
            return true;
        }

        HashSet<char> oneToNineSet = ['1', '2', '3', '4', '5', '6', '7', '8', '9'];

        // check the rows
        foreach (var row in board)
        {
            HashSet<char> seen = [];
            foreach (char c in row)
            {
                if (!AddToSet(seen, c))
                    return false;
            }
        }

        // check the cols
        foreach (var col in Enumerable.Range(0, 9))
        {
            HashSet<char> seen = [];
            foreach (var row in Enumerable.Range(0, 9))
            {
                if (!AddToSet(seen, board[row][col]))
                    return false;
            }
        }

        // check each 3x3 grid
        foreach (var i in Enumerable.Range(0, 3))
        {
            foreach (var j in Enumerable.Range(0, 3))
            {
                HashSet<char> seen = [];
                for (int row = i * 3; row < (i * 3) + 3; row++)
                {
                    for (int col = j * 3; col < (j * 3) + 3; col++)
                    {
                        if (!AddToSet(seen, board[row][col]))
                            return false;
                    }
                }
            }
        }

        return true;
    }
}
