using System.Security;

namespace Aoc2024;

public class Day5(IUtilities utilities) : Day(utilities)
{
    public override long Part1(string filename)
    {
        var lines = _utilities.ReadFileKeepBlankLines(filename);

        var blankIndex = Array.IndexOf(lines, "");
        var rules = lines.Take(blankIndex).Select(it => it.Split('|').Select(int.Parse).ToArray()).ToArray();
        var printLines = lines.Skip(blankIndex + 1).Select(it => it.Split(',').Select(int.Parse).ToArray()).ToArray();

        var sum = 0;
        foreach (var printLine in printLines)
        {
            if (RulesPass(rules, printLine))
            {
                sum += printLine[printLine.Length / 2];
            }
        }

        return sum;
    }

    public override long Part2(string filename)
    {
        var lines = _utilities.ReadFileKeepBlankLines(filename);

        var blankIndex = Array.IndexOf(lines, "");
        var rules = lines.Take(blankIndex).Select(it => it.Split('|').Select(int.Parse).ToArray()).ToArray();
        var printLines = lines.Skip(blankIndex + 1).Select(it => it.Split(',').Select(int.Parse).ToArray()).ToArray();

        var sum = 0;
        foreach (var printLine in printLines)
        {
            if (!RulesPass(rules, printLine))
            {
                var sorted = new List<int>(printLine);
                sorted.Sort(new RulesComparer(rules));
                sum += sorted[sorted.Count / 2];
            }
        }

        return sum;
    }

    private static bool RulesPass(int[][] rules, int[] printLine)
    {
        if (printLine.Length == 1)
        {
            return true;
        }
        var currentValue = printLine[^1];
        var remainder = printLine[..^1];
        var applicableRules = rules.Where(it => it[0] == currentValue);
        foreach (var rule in applicableRules)
        {
            if (remainder.Contains(rule[1]))
            {
                return false;
            }
        }
        return RulesPass(rules, remainder);
    }

    private class RulesComparer(int[][] rules) : IComparer<int>
    {
        private readonly int[][] _rules = rules;
        public int Compare(int x, int y)
        {
            var applicableRules = _rules.Where(it => it[0] == x || it[1] == x || it[0] == y || it[1] == 1).ToList();
            var returnValue = applicableRules.Any(it => it[0] == x && it[1] == y) ? -1
                : applicableRules.Any(it => it[0] == y && it[1] == x) ? 1
                : 0;
            return returnValue;
        }
    }
}