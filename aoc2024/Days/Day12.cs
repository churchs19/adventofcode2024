namespace Aoc2024;

public class Day12(IUtilities utilities) : Day(utilities)
{
    public override long Part1(string filename)
    {
        var inputLines = _utilities.ReadFile(filename);

        var map = inputLines.Select(it => it.ToCharArray()).ToArray();

        return long.MinValue;
    }

    public override long Part2(string filename)
    {
        var inputLines = _utilities.ReadFile(filename);

        return long.MinValue;
    }

    //find the area of all of the cells represented by the same character in the map
    private static long FindArea(char[][] map, int x, int y, char c)
    {
        return 0;
    }
}