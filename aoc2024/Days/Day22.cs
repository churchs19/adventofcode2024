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

        var input = inputLines.Select(long.Parse).ToList();

        var secrets = input.Select(seed => Generate(seed, 2000)).ToArray();

        return MaximizePrice(secrets);
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

    private readonly record struct ChangeSeq(long A, long B, long C, long D);

    private static long MaximizePrice(long[][] secrets)
    {
        var prices = secrets.Select(sequence => sequence
                .Select(val => val % 10L)
                .ToArray())
            .ToArray();
        var changes = prices
            .Select(sequence => sequence
                .Skip(1)
                .Select((val, i) => val - sequence[i])
                .ToArray())
            .ToArray();

        var sequencesMap = new Dictionary<ChangeSeq, Dictionary<int, int>>(capacity: 50_000);
        for (var b = 0; b < changes.Length; b++)
            for (var i = 0; i < changes[b].Length - 4; i++)
            {
                var key = new ChangeSeq(
                    A: changes[b][i + 0],
                    B: changes[b][i + 1],
                    C: changes[b][i + 2],
                    D: changes[b][i + 3]);

                if (!sequencesMap.TryGetValue(key, out var occurenceMap))
                {
                    occurenceMap = new Dictionary<int, int>([new KeyValuePair<int, int>(b, i)]);
                    sequencesMap[key] = occurenceMap;
                }
                else
                {
                    occurenceMap.TryAdd(b, i);
                }
            }

        return sequencesMap
            .OrderByDescending(kvp => kvp.Value.Count)
            .Select(kvp =>
            {
                var sum = 0L;
                foreach (var (buyerIdx, startIdx) in kvp.Value)
                {
                    sum += prices[buyerIdx][startIdx + 4];
                }
                return sum;
            }).Max();
    }
}