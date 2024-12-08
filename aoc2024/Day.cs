namespace Aoc2024;

public abstract class Day(IUtilities utilities) : IDay
{
    protected readonly IUtilities _utilities = utilities;

    public abstract long Part1(string filename);
    public abstract long Part2(string filename);
}