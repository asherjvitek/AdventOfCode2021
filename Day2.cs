public static class Day2
{
    public static int DoTheThing(string path)
    {
        var aim = 0;
        var horizontal = 0;
        var depth = 0;

        var lines = File.ReadAllLines(path);

        foreach (var line in lines)
        {
            var split = line.Split(' ');
            var instruction = split.First();
            var amount = Convert.ToInt32(split.Last());

            switch (instruction)
            {
                case "forward":
                    horizontal += amount;
                    depth += aim * amount;
                    break;
                case "down":
                    aim += amount;
                    break;
                case "up":
                    aim -= amount;
                    break;
                default:
                    break;
            }
        }


        return horizontal * depth;
    }

    public static int DoTheThing1(string path)
    {
        var h = 0;
        var d = 0;

        var lines = File.ReadAllLines(path);

        foreach (var line in lines)
        {
            var split = line.Split(' ');
            var instruction = split.First();
            var amount = Convert.ToInt32(split.Last());

            switch (instruction)
            {
                case "forward":
                    h += amount;
                    break;

                case "down":
                    d += amount;
                    break;
                case "up":
                    d -= amount;
                    break;
                default:
                    break;
            }
        }


        return h * d;
    }
}
