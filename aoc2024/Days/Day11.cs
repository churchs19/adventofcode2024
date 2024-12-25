namespace Aoc2024;

public class Day11(IFileUtilities utilities) : Day(utilities)
{
    public override long Part1(string filename)
    {
        var inputLines = _utilities.ReadFile(filename);

        var stones = inputLines[0].Split(" ").ToList();

        var cache = new Dictionary<(string, int), long>();

        return stones.Sum(it => CountStones(it, 25, cache));

    }

    public override long Part2(string filename)
    {
        var inputLines = _utilities.ReadFile(filename);

        var stones = inputLines[0].Split(" ").ToList();

        var cache = new Dictionary<(string, int), long>();

        return stones.Sum(it => CountStones(it, 75, cache));
    }

    private static long CountStones(string stone, int blinks, Dictionary<(string, int), long> cache)
    {
        if (blinks == 0)
        {
            return 1;
        }

        var key = (stone, blinks--);
        if (cache.TryGetValue(key, out var cached))
        {
            return cached;
        }

        if (stone == "0")
        {
            cache[key] = CountStones(stone: "1", blinks, cache);
        }
        else if (stone.Length % 2 == 0)
        {
            var first = long.Parse(stone[..(stone.Length / 2)]).ToString();
            var second = long.Parse(stone[(stone.Length / 2)..]).ToString();
            cache[key] = CountStones(first, blinks, cache) + CountStones(second, blinks, cache);
        }
        else
        {
            cache[key] = CountStones((long.Parse(stone) * 2024).ToString(), blinks, cache);
        }

        return cache[key];
    }
}