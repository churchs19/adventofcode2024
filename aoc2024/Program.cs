using Aoc2024;

var utilities = new Utilities();
var days = new List<IDay>
{
    new Day1(utilities),
    new Day2(utilities),
    new Day3(utilities),
    new Day4(utilities),
    new Day5(utilities),
    new Day6(utilities),
    new Day7(utilities),
    new Day8(utilities),
    new Day9(utilities),
    new Day10(utilities),
    new Day11(utilities),
    new Day12(utilities),
    new Day13(utilities),
    new Day14(utilities),
    new Day15(utilities),
    new Day16(utilities),
    new Day17(utilities),
    new Day18(utilities),
    new Day19(utilities),
};

for (var i = 0; i < days.Count; i++)
{
    Console.WriteLine($"Day {i + 1} - Part 1: {days[i].Part1($"inputs/{i + 1}.txt")}");
    Console.WriteLine($"Day {i + 1} - Part 2: {days[i].Part2($"inputs/{i + 1}.txt")}");
}
