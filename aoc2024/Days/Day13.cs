using System.Text.RegularExpressions;

using Aoc2024.Utilities;

namespace Aoc2024.Days;

public partial class Day13(IFileUtilities utilities) : Day(utilities)
{
    public override long Part1(string filename)
    {
        var inputLines = _utilities.ReadFileKeepBlankLines(filename);
        var chunks = ChunkUtility.GetInputChunks(inputLines);

        long tokens = 0;

        foreach (var chunk in chunks)
        {
            var a = Button.Parse(chunk[0], cost: 3);
            var b = Button.Parse(chunk[1], cost: 1);
            var p = ParseLongs(chunk[2]);

            var (success, minimumPresses) = TryComputeMinimumPresses(a, b, px: p[0], py: p[1]);
            if (success)
            {
                tokens += minimumPresses;
            }
        }

        return tokens;
    }

    public override long Part2(string filename)
    {
        var inputLines = _utilities.ReadFileKeepBlankLines(filename);
        var chunks = ChunkUtility.GetInputChunks(inputLines);

        long tokens = 0;

        foreach (var chunk in chunks)
        {
            var a = Button.Parse(chunk[0], cost: 3);
            var b = Button.Parse(chunk[1], cost: 1);
            var p = ParseLongs(chunk[2]);

            var (success, minimumPresses) = TryComputeMinimumPresses(a, b, px: p[0] + 10000000000000L, py: p[1] + 10000000000000L);
            if (success)
            {
                tokens += minimumPresses;
            }
        }

        return tokens;
    }

    private readonly record struct Button(long X, long Y, int Cost)
    {
        public static Button Parse(string s, int cost)
        {
            var numbers = ParseLongs(s);
            return new Button(X: numbers[0], Y: numbers[1], cost);
        }
    }

    private static (bool success, long minimumPresses) TryComputeMinimumPresses(Button a, Button b, long px, long py)
    {
        //  Let 'Na' and 'Nb' denote how many times each respective button is pressed. We simply need to find a
        //  solution to the following system:
        //    Na * a.x + Nb * b.x = px
        //    Na * a.Y + Nb * b.Y = py
        //
        //  This is a simple linear system of equations. We can solve it using Cramer's rule. If the determinant
        //  of the matrix is zero, then the system has no solution. Otherwise, it has a unique solution.
        //
        //  The determinant of the matrix is simply a.x * b.y - a.y * b.x. If this is zero, then the system has no
        //  solution. Otherwise, we can find the solution using the following formulas:
        //    Na = (px * b.y - py * b.x) / (a.x * b.y - a.y * b.x)
        //    Nb = (a.x * py - a.y * px) / (a.x * b.y - a.y * b.x)

        var det = a.X * b.Y - a.Y * b.X;
        if (det == 0)
        {
            return (false, 0L);
        }

        var na = (px * b.Y - py * b.X) / det;
        var nb = (a.X * py - a.Y * px) / det;

        if (na * a.X + nb * b.X == px &&
            na * a.Y + nb * b.Y == py)
        {
            return (true, a.Cost * na + b.Cost * nb);
        }

        return (false, 0L);
    }

    [GeneratedRegex(@"(-?\d+)")]
    private static partial Regex NumberRegex();

    private static List<long> ParseLongs(string input)
    {
        return NumberRegex().Matches(input).Select(it => long.Parse(it.Value.AsSpan())).ToList();
    }
}