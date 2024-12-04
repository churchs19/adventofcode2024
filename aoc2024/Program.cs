using Aoc2024;

var days = new List<IDay>
{
    new Day1(new Utilities()),
    new Day2(new Utilities()),
    new Day3(new Utilities())
};

for (var i = 0; i < days.Count; i++)
{
    Console.WriteLine($"Day {i + 1} - Part 1: {days[i].Part1($"inputs/{i + 1}.txt")}");
    Console.WriteLine($"Day {i + 1} - Part 2: {days[i].Part2($"inputs/{i + 1}.txt")}");
}
