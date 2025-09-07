public static class Day4
{
    private class BoardItem(int item)
    {
        public int Item { get; set; } = item;
        public bool Marked { get; set; }
    }

    public static int DoTheThing(string path)
    {
        var lines = File.ReadAllLines(path);

        var numbers = new List<int>();
        var boards = new List<BoardItem[][]>();
        var hasWon = new List<int>();

        Load(lines, numbers, boards);
        PrintState(numbers, boards);

        foreach (var call in numbers)
        {
            for (int i = 0; i < boards.Count; i++)
            {
                if (hasWon.Contains(i)) continue;

                MarkBoard(boards[i], call);

                if (CheckForWin(boards[i]))
                {
                    hasWon.Add(i);

                    Console.WriteLine(i + 1);

                    if (hasWon.Count == boards.Count)
                    {
                        Console.WriteLine($"Winning Board: {i + 1}; Call: {call}");
                        PrintBoard(boards[i]);
                        return boards[i].SelectMany(x => x.Select(x => x)).Where(x => !x.Marked).Sum(x => x.Item) * call;
                    }
                }
            }

            // PrintBoard(boards[1]);

        }

        PrintState(numbers, boards);

        return 0;

    }

    private static bool CheckForWin(BoardItem[][] board)
    {
        for (int j = 0; j < board.Length; j++)
        {
            var line = board[j];

            if (line.All(x => x.Marked))
            {
                return true;
            }

        }

        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                if (!board[x][y].Marked)
                    break;

                if (x == 4)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static void MarkBoard(BoardItem[][] board, int call)
    {
        for (int j = 0; j < board.Length; j++)
        {
            var line = board[j];

            for (int k = 0; k < line.Length; k++)
            {
                if (call == line[k].Item)
                {
                    line[k].Marked = true;
                    return;
                }
            }

        }
    }

    private static void Load(string[] lines, List<int> numbers, List<BoardItem[][]> boards)
    {
        var board = new BoardItem[5][];
        var bi = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];

            if (i == 0)
            {
                var nums = line.Split(',').Select(x => Convert.ToInt32(x.ToString()));
                numbers.AddRange(nums);
                continue;
            }

            if (string.IsNullOrEmpty(line))
            {
                bi = 0;
                board = new BoardItem[5][];
                boards.Add(board);
                continue;
            }

            if (bi > 4) throw new Exception("bi is > 4 and that means that something is wrong");

            var boardNums = line.Split(' ');
            var row = new BoardItem[5];
            var ri = 0;

            foreach (var num in boardNums)
            {
                if (string.IsNullOrWhiteSpace(num)) continue;

                if (ri > 4) throw new Exception("ri is > 4 and that means that something is wrong");

                row[ri] = new BoardItem(Convert.ToInt32(num));
                ri++;
            }

            board[bi] = row;
            bi++;
        }
    }

    private static void PrintState(List<int> numbers, List<BoardItem[][]> boards)
    {
        Console.WriteLine(string.Join(',', numbers));
        Console.WriteLine();

        foreach (var b in boards)
        {

            PrintBoard(b);
            Console.WriteLine();
        }
    }

    private static void PrintBoard(BoardItem[][] board)
    {
        foreach (var line in board)
        {
            foreach (var num in line)
            {
                var format = num.Marked ? TermColor.RED : TermColor.NORMAL;
                Console.Write($"{format}{num.Item,2} ");
            }

            Console.WriteLine();
        }
    }
}
