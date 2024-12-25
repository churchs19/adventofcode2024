namespace Aoc2024;
public class Day1(IFileUtilities utilities) : Day(utilities)
{
    public override long Part1(string filename)
    {
        var lines = _utilities.ReadFile(filename);

        var numbers = lines.Select(it => it.Split("   "))
            .Select(it => it.Select(int.Parse).ToList())
            .ToList();

        var array1 = numbers.Select(it => it[0]).OrderBy(it => it).ToList();
        var array2 = numbers.Select(it => it[1]).OrderBy(it => it).ToList();

        var sum = 0;
        for (var i = 0; i < array1.Count; i++)
        {
            sum += Math.Abs(array1[i] - array2[i]);
        }

        return sum;
    }

    public override long Part2(string filename)
    {
        var lines = _utilities.ReadFile(filename);

        var numbers = lines.Select(it => it.Split("   "))
            .Select(it => it.Select(int.Parse).ToList())
            .ToList();

        var array1 = numbers.Select(it => it[0]).ToList();
        var array2 = numbers.Select(it => it[1]).ToList();


        var similarityScore = array1.Select(
            it => it * array2.Count(it2 => it2 == it))
            .Sum();

        return similarityScore;
    }
}