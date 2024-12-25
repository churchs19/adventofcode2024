using Microsoft.VisualBasic;

namespace Aoc2024;

public class Day25(IFileUtilities utilities) : Day(utilities)
{
    public override long Part1(string filename)
    {
        var inputLines = _utilities.ReadFileKeepBlankLines(filename);

        var chunks = ChunkUtility.GetInputChunks(inputLines);

        var locks = chunks.Where(it => it.First() == "#####" && it.Last() == ".....")
            .Select(GetPinHeights)
            .ToList();
        var keys = chunks.Where(it => it.First() == "....." && it.Last() == "#####")
            .Select(GetPinHeights)
            .ToList();

        return locks.Select(it => CountKeysThatFit(it, keys)).Sum();
    }

    public override long Part2(string filename)
    {
        var inputLines = _utilities.ReadFileKeepBlankLines(filename);

        var chunks = ChunkUtility.GetInputChunks(inputLines);

        return long.MinValue;
    }

    private static List<int> GetPinHeights(List<string> chunk)
    {
        var pinHeights = new List<int>();
        var charArray = chunk.Select(it => it.ToCharArray()).ToArray();

        for (var column = 0; column < charArray[0].Length; column++)
        {
            var pinHeight = 0;
            for (var row = 1; row < charArray.Length - 1; row++)
            {
                if (charArray[row][column] == '#')
                {
                    pinHeight++;
                }
            }
            pinHeights.Add(pinHeight);
        }

        return pinHeights;
    }

    private static long CountKeysThatFit(List<int> testLock, List<List<int>> keys)
    {
        var combined = keys.Select(key => key.Zip(testLock, (keyHeight, lockHeight) => keyHeight + lockHeight).ToList());

        return combined.Count(it => it.All(height => height <= 5));
    }
}