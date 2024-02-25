namespace leetcode.medium;

public class ValidSudoku
{
    public static void Test()
    {
        char[][] board1 = [['5','3','.','.','7','.','.','.','.']
                            ,['6','.','.','1','9','5','.','.','.']
                            ,['.','9','8','.','.','.','.','6','.']
                            ,['8','.','.','.','6','.','.','.','3']
                            ,['4','.','.','8','.','3','.','.','1']
                            ,['7','.','.','.','2','.','.','.','6']
                            ,['.','6','.','.','.','.','2','8','.']
                            ,['.','.','.','4','1','9','.','.','5']
                            ,['.','.','.','.','8','.','.','7','9']];

        char[][] board2 = [['8','3','.','.','7','.','.','.','.']
                            ,['6','.','.','1','9','5','.','.','.']
                            ,['.','9','8','.','.','.','.','6','.']
                            ,['8','.','.','.','6','.','.','.','3']
                            ,['4','.','.','8','.','3','.','.','1']
                            ,['7','.','.','.','2','.','.','.','6']
                            ,['.','6','.','.','.','.','2','8','.']
                            ,['.','.','.','4','1','9','.','.','5']
                            ,['.','.','.','.','8','.','.','7','9']];

        Console.Write(IsValid(board1));
        Console.Write(IsValid(board2));
    }

    public static bool IsValid(char[][] board)
    {
        // validate all rows
        foreach(var i in Enumerable.Range(0,9))
        {
            var rowItems = board[i].Where(c => c != '.').ToArray();
            var set = new HashSet<char>();

            foreach(var item in rowItems)
            {
                if(set.Contains(item))
                {
                    return false;
                }
                set.Add(item);
            }
        }

        // validate all columns
        foreach(var col in Enumerable.Range(0,9))
        {
            var set = new HashSet<char>();
            foreach(var row in Enumerable.Range(0,9))
            {
                var item = board[row][col];
                if(item == '.') 
                {
                    continue;
                }

                if(set.Contains(item))
                {
                    return false;
                }
                set.Add(item);
            }
        }

        // Validate all 3*3 blocks
        // divide the block into 3 by 3 grids each containg a 3*3 block 
        Dictionary<(int row,int col), HashSet<char>> map = [];

        foreach(var i in Enumerable.Range(0,9))
        {
            foreach(var j in Enumerable.Range(0,9))
            {
                // find the larger block location
                var row = i / 3;
                var col = j / 3;

                var key = (row,col);
                var value = board[i][j];

                if(value == '.')
                {
                    continue;
                }

                if(map.ContainsKey(key))
                {
                    if(map[key].Contains(value))
                    {
                        return false;
                    }
                    map[key].Add(value);
                }
                else
                {
                    map.Add(key, [value]);
                }
            }
        }

        return true;
    }
}
