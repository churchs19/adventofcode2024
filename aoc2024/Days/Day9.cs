namespace Aoc2024;

public class Day9(IFileUtilities utilities) : Day(utilities)
{
    public override long Part1(string filename)
    {
        var inputLine = _utilities.ReadFile(filename)[0]
            .ToCharArray()
            .Select(it => int.Parse(it.ToString()))
            .ToArray();

        var disk = Disk.BuildDisk(inputLine);
        CompactDisk(disk);

        var checksum = disk.Checksum();

        return checksum;
    }

    public override long Part2(string filename)
    {
        var inputLine = _utilities.ReadFile(filename)[0]
            .ToCharArray()
            .Select(it => int.Parse(it.ToString()))
            .ToArray();

        var disk = Disk.BuildDisk(inputLine);
        CompactFiles(disk);

        var checksum = disk.Checksum();

        return checksum;
    }

    private static void CompactDisk(Disk disk)
    {
        var firstNullIndex = disk.Blocks.IndexOf(null);
        var fileBlockCount = disk.Blocks.Count(it => it.HasValue);
        if (firstNullIndex == -1)
        {
            return;
        }

        while (firstNullIndex != fileBlockCount)
        {
            var lastBlockIndex = disk.Blocks.FindLastIndex(it => it.HasValue);
            disk.Blocks[firstNullIndex] = disk.Blocks[lastBlockIndex];
            disk.Blocks[lastBlockIndex] = null;
            firstNullIndex = disk.Blocks.IndexOf(null);
        }

        return;
    }

    private static void CompactFiles(Disk disk)
    {
        for (var fileId = disk.Allocated.Count - 1; fileId >= 0; fileId--)
        {
            var file = disk.Allocated[fileId];
            for (var j = 0; j < disk.Free.Count; j++)
            {
                var free = disk.Free[j];
                if (free.Item1 >= file.Min) break;
                if ((free.Item2 - free.Item1 + 1) < file.Length) continue;

                for (var k = 0; k < file.Length; k++)
                {
                    disk.Blocks[free.Item1 + k] = fileId;
                    disk.Blocks[file.Min + k] = null;
                }

                disk.Free.RemoveAt(index: j);
                if ((free.Item2 - free.Item1 + 1) > file.Length)
                {
                    disk.Free.Insert(index: j, (free.Item1 + file.Length, free.Item2));
                }
                break;
            }
        }
    }
}

internal readonly record struct DiskFile(int Min, int Length);

internal class Disk(List<int?> blocks, List<DiskFile> allocated, List<(int, int)> free)
{
    internal List<int?> Blocks { get; } = blocks;
    internal List<DiskFile> Allocated { get; } = allocated;
    internal List<(int, int)> Free { get; } = free;

    internal long Checksum()
    {
        return Blocks.Select((it, index) => index * (it ?? 0L)).Sum();
    }

    internal static Disk BuildDisk(int[] inputLine)
    {
        var blocks = new List<int?>();
        var allocated = new List<DiskFile>();
        var free = new List<(int, int)>();

        int currentIndex = 0;
        for (var i = 0; i < inputLine.Length; i += 2)
        {
            allocated.Add(new DiskFile(Min: blocks.Count, Length: inputLine[i]));
            for (var j = 0; j < inputLine[i]; j++)
            {
                blocks.Add(currentIndex);
            }
            if (i + 1 < inputLine.Length)
            {
                var startFree = blocks.Count;
                for (var j = 0; j < inputLine[i + 1]; j++)
                {
                    blocks.Add(null);
                }
                free.Add((startFree, blocks.Count - 1));
            }
            currentIndex++;
        }

        return new Disk(blocks, allocated, free);
    }
}