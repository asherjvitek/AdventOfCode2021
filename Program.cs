var test = args.Length > 0 && args[0] == "-test";

var res = Day4.DoTheThing($"./inputs/day4{(test ? "_test" : "")}.txt");

Console.WriteLine(res);
