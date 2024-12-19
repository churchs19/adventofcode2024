namespace Aoc2024;

public class Day19(IUtilities utilities) : Day(utilities)
{
    public override long Part1(string filename)
    {
        var inputLines = _utilities.ReadFileKeepBlankLines(filename);

        var separatorIndex = Array.IndexOf(inputLines, "");
        var options = inputLines.Take(separatorIndex).SelectMany(x => x.Split(", ")).ToList();
        var candidates = inputLines.Skip(separatorIndex + 1).ToList();

        int count = 0;
        var memo = new Dictionary<string, bool>();
        foreach (var candidate in candidates)
        {
            if (CanBeFormed(candidate, options, memo))
            {
                count++;
            }
        }

        return count;
    }

    private static bool CanBeFormed(string candidate, List<string> options, Dictionary<string, bool> memo)
    {
        if (string.IsNullOrEmpty(candidate)) return true;
        if (memo.TryGetValue(candidate, out var result)) return result;

        foreach (var option in options)
        {
            if (candidate.StartsWith(option))
            {
                var remaining = candidate[option.Length..];
                if (CanBeFormed(remaining, options, memo))
                {
                    memo[candidate] = true;
                    return true;
                }
            }
        }

        memo[candidate] = false;
        return false;
    }

    public override long Part2(string filename)
    {
        var inputLines = _utilities.ReadFileKeepBlankLines(filename);

        var separatorIndex = Array.IndexOf(inputLines, "");
        var options = inputLines.Take(separatorIndex).SelectMany(x => x.Split(", ")).ToList();
        var candidates = inputLines.Skip(separatorIndex + 1).ToList();

        long totalCombinations = 0;
        var memo = new Dictionary<string, long>();
        foreach (var candidate in candidates)
        {
            totalCombinations += CountCombinations(candidate, options, memo);
        }

        return totalCombinations;
    }

    private static long CountCombinations(string candidate, List<string> options, Dictionary<string, long> memo)
    {
        if (string.IsNullOrEmpty(candidate)) return 1L;
        if (memo.TryGetValue(candidate, out var result)) return result;

        long count = 0;
        foreach (var option in options)
        {
            if (candidate.StartsWith(option))
            {
                var remaining = candidate[option.Length..];
                count += CountCombinations(remaining, options, memo);
            }
        }

        memo[candidate] = count;
        return count;
    }
}