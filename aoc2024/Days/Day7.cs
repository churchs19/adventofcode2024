namespace Aoc2024;

public class Day7(IFileUtilities utilities) : Day(utilities)
{
    public override long Part1(string filename)
    {
        var lines = _utilities.ReadFile(filename);

        var equations = lines.Select(x => x.Split(": "))
            .ToDictionary(x => long.Parse(x[0]), x => x[1].Split(" ").Select(long.Parse).ToList());

        long sum = 0;
        foreach (var equation in equations)
        {
            sum += TestEquation(equation.Key, equation.Value) ? equation.Key : 0;
        }

        return sum;
    }

    public override long Part2(string filename)
    {
        var lines = _utilities.ReadFile(filename);

        var equations = lines.Select(x => x.Split(": "))
            .ToDictionary(x => long.Parse(x[0]), x => x[1].Split(" ").Select(long.Parse).ToList());

        long sum = 0;
        foreach (var equation in equations)
        {
            sum += TestEquationPart2(equation.Key, equation.Value) ? equation.Key : 0;
        }

        return sum;
    }

    private static bool TestEquation(long testValue, List<long> operands)
    {
        operands.Reverse();
        var options = CalculateEquationOptions(operands);
        return options.Contains(testValue);
    }

    private static List<long> CalculateEquationOptions(List<long> operands)
    {
        if (operands.Count == 1)
        {
            return operands;
        }
        var results = new List<long>();
        foreach (var result in CalculateEquationOptions(operands.Skip(1).ToList()))
        {
            results.Add(operands[0] + result);
            results.Add(operands[0] * result);
        }
        return results;
    }

    private static bool TestEquationPart2(long testValue, List<long> operands)
    {
        operands.Reverse();
        var options = CalculateEquationOptionsPart2(operands);
        return options.Contains(testValue);
    }

    private static List<long> CalculateEquationOptionsPart2(List<long> operands)
    {
        if (operands.Count == 1)
        {
            return operands;
        }
        var results = new List<long>();
        foreach (var result in CalculateEquationOptionsPart2(operands.Skip(1).ToList()))
        {
            results.Add(operands[0] + result);
            results.Add(operands[0] * result);
            results.Add(long.Parse(result.ToString() + operands[0].ToString()));
        }
        return results;
    }
}