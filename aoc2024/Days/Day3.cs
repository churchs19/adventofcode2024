using System.Text.RegularExpressions;

using Aoc2024.Utilities;

namespace Aoc2024.Days;

public partial class Day3(IFileUtilities utilities) : Day(utilities)
{
    [GeneratedRegex(@"mul\([\d]+,[\d]+\)")]
    private static partial Regex Part1Regex();
    [GeneratedRegex(@"(mul\([\d]+,[\d]+\))|(don't\(\))|(do\(\))")]
    private static partial Regex Part2Regex();

    [GeneratedRegex(@"[\d]+")]
    private static partial Regex NumberRegex();

    public override long Part1(string filename)
    {
        var lines = _utilities.ReadFile(filename);

        var sum = 0;
        foreach (var line in lines)
        {
            var matches = Part1Regex().Matches(line);

            foreach (Match match in matches)
            {
                var numbers = NumberRegex().Matches(match.Value);
                var num1 = int.Parse(numbers[0].Value);
                var num2 = int.Parse(numbers[1].Value);
                sum += num1 * num2;
            }
        }

        return sum;
    }

    public override long Part2(string filename)
    {
        var lines = _utilities.ReadFile(filename);

        var sum = 0;

        var enabled = true;
        foreach (var line in lines)
        {
            var matches = Part2Regex().Matches(line);

            foreach (Match match in matches)
            {
                if (match.Value == "don't()")
                {
                    enabled = false;
                    continue;
                }
                else if (match.Value == "do()")
                {
                    enabled = true;
                    continue;
                }
                else
                {
                    if (enabled)
                    {
                        var numbers = NumberRegex().Matches(match.Value);
                        var num1 = int.Parse(numbers[0].Value);
                        var num2 = int.Parse(numbers[1].Value);
                        sum += num1 * num2;
                    }
                }
            }
        }

        return sum;
    }
}