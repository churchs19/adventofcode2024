namespace Aoc2024;

public class Day22(IUtilities utilities) : Day(utilities)
{
    public override long Part1(string filename)
    {
        var inputLines = _utilities.ReadFile(filename);
        var input = inputLines.Select(long.Parse).ToList();

        var secrets = input.Select(seed => Generate(seed, 2000)).ToArray();

        return secrets.Sum(sequence => sequence[^1]);
    }

    public override long Part2(string filename)
    {
        var inputLines = _utilities.ReadFile(filename);

        return long.MinValue;
    }

    private static long[] Generate(long seed, int n)
    {
        var seq = new long[n + 1];
        seq[0] = seed;

        for (var i = 1; i <= n; i++)
        {
            seq[i] = seq[i - 1];
            seq[i] = MixPrune(seq[i] << 6, seq[i]);
            seq[i] = MixPrune(seq[i] >> 5, seq[i]);
            seq[i] = MixPrune(seq[i] << 11, seq[i]);
        }

        return seq;
    }

    private static long MixPrune(long a, long b)
    {
        return (a ^ b) & 0xFFFFFFL;
    }
}