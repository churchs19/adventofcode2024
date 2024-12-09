namespace Aoc2024;

public class Day9(IUtilities utilities) : Day(utilities)
{
    public override long Part1(string filename)
    {
        var inputLine = _utilities.ReadFile(filename)[0]
            .ToCharArray()
            .Select(it => int.Parse(it.ToString()))
            .ToArray();

        var disk = InitializeDisk(inputLine);

        return int.MinValue;
    }

    public override long Part2(string filename)
    {
        var inputLine = _utilities.ReadFile(filename)[0]
            .ToCharArray()
            .Select(it => int.Parse(it.ToString()))
            .ToArray();

        var disk = InitializeDisk(inputLine);

        return int.MinValue;
    }

    private static List<int?> InitializeDisk(int[] inputLine)
    {
        var disk = new List<int?>();
        int currentIndex = 0;
        for (var i = 0; i < inputLine.Length; i += 2)
        {
            for (var j = 0; j < inputLine[i]; j++)
            {
                disk.Add(currentIndex);
            }
            if (i + 1 < inputLine.Length)
            {
                for (var j = 0; j < inputLine[i + 1]; j++)
                {
                    disk.Add(null);
                }
            }
            currentIndex++;
        }

        return disk;
    }


}