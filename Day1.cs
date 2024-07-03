public static class Day1
{
    public static int DoTheThing(string path)
    {
        var lines = File.ReadAllLines(path);
        var count = 0;
        var last = int.MaxValue;
        var sums = new List<int>();

        for (int i = 2; i < lines.Length; i++)
        {
            var line1 = Convert.ToInt32(lines[i - 2]);
            var line2 = Convert.ToInt32(lines[i - 1]);
            var line3 = Convert.ToInt32(lines[i - 0]);

            sums.Add(line1 + line2 + line3);
        }

        foreach (var line in sums)
        {
            var d = Convert.ToInt32(line);

            if (d > last)
                count++;

            last = d;

        }

        return count;
    }

    public static int DoTheThing1(string path)
    {
        var lines = File.ReadAllLines(path);
        var count = 0;
        var last = int.MaxValue;

        foreach (var line in lines)
        {
            var d = Convert.ToInt32(line);

            if (d > last)
                count++;

            last = d;

        }

        return count;
    }
}
