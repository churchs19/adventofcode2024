namespace Aoc2024;

public abstract class Day(IFileUtilities utilities) : IDay
{
    protected readonly IFileUtilities _utilities = utilities;

    public abstract long Part1(string filename);
    public abstract long Part2(string filename);
}