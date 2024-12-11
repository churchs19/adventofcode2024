namespace Aoc2024;

public class Day11(IUtilities utilities) : Day(utilities)
{
    public override long Part1(string filename)
    {
        var inputLines = _utilities.ReadFile(filename);

        var stones = inputLines[0].Split(" ").ToList();

        for (var i = 0; i < 25; i++)
        {
            stones = ProcessBlink(stones);
        }

        return stones.Count;
    }

    public override long Part2(string filename)
    {
        var inputLines = _utilities.ReadFile(filename);

        var stones = inputLines[0].Split(" ").ToList();

        for (var i = 0; i < 75; i++)
        {
            stones = ProcessBlink(stones);
        }

        return stones.Count;
    }

    private static List<string> ProcessBlink(List<string> stones)
    {
        var newStones = stones.SelectMany(it =>
        {
            string[] result = it == "0"
                ? (["1"])
                : it.Length % 2 == 0
                    ? ([long.Parse(it[..(it.Length / 2)]).ToString(), long.Parse(it[(it.Length / 2)..]).ToString()])
                    : ([(long.Parse(it) * 2024).ToString()]);
            return result;
        }).ToList();

        return newStones;
    }
}