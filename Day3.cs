public static class Day3
{
    public static int DoTheThing(string path)
    {
        var lines = File.ReadAllLines(path);

        var gamma = string.Empty;
        var epsilon = string.Empty;

        for (int i = 0; i < lines.First().Length; i++)
        {
            var counts = new Dictionary<char, int>
            {
                { '0', 0 },
                { '1', 0 },
            };

            foreach (var line in lines)
            {
                counts[line[i]]++;
            }

            gamma += counts.First(c => c.Value == counts.Max(x => x.Value)).Key;
            epsilon += counts.First(c => c.Value == counts.Min(x => x.Value)).Key;

        }

        Console.WriteLine($"{gamma} * {epsilon}");

        return Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);
    }
}
