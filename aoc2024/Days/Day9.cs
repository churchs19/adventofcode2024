namespace Aoc2024;

public class Day9(IUtilities utilities) : Day(utilities)
{
    public override long Part1(string filename)
    {
        var inputLine = _utilities.ReadFile(filename)[0]
            .ToCharArray()
            .Select(it => long.Parse(it.ToString()))
            .ToArray();

        var disk = InitializeDisk(inputLine);
        CompactDisk(disk);

        var checksum = CalculateChecksum(disk);

        return checksum;
    }

    public override long Part2(string filename)
    {
        var inputLine = _utilities.ReadFile(filename)[0]
            .ToCharArray()
            .Select(it => long.Parse(it.ToString()))
            .ToArray();

        var disk = InitializeDisk(inputLine);
        CompactFiles(disk);

        return int.MinValue;
    }

    private static List<long?> InitializeDisk(long[] inputLine)
    {
        var disk = new List<long?>();
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

    private static void CompactDisk(List<long?> disk)
    {
        var firstNullIndex = disk.IndexOf(null);
        var fileBlockCount = disk.Count(it => it.HasValue);
        if (firstNullIndex == -1)
        {
            return;
        }

        while (firstNullIndex != fileBlockCount)
        {
            var lastBlockIndex = disk.FindLastIndex(it => it.HasValue);
            disk[firstNullIndex] = disk[lastBlockIndex];
            disk[lastBlockIndex] = null;
            firstNullIndex = disk.IndexOf(null);
        }

        return;
    }

    private static void CompactFiles(List<long?> disk)
    {
        var firstNullIndex = disk.IndexOf(null);
    }

    private static long CalculateChecksum(List<long?> disk)
    {
        long checksum = 0;
        for (var index = 0; index < disk.Count; index++)
        {
            if (disk[index] != null)
            {
                checksum += index * (disk[index] ?? 0);
            }
        }

        return checksum;
    }
}