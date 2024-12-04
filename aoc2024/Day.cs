namespace Aoc2024;

public abstract class Day(IUtilities utilities) : IDay
{
    protected readonly IUtilities _utilities = utilities;

    public abstract int Part1(string filename);
    public abstract int Part2(string filename);
}