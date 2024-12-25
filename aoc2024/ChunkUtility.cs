namespace Aoc2024;

public static class ChunkUtility
{
    public static List<List<string>> GetInputChunks(IEnumerable<string> inputLines)
    {
        var chunks = new List<List<string>>();
        var currentChunk = new List<string>();

        foreach (var line in inputLines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                chunks.Add(currentChunk);
                currentChunk = [];
            }
            else
            {
                currentChunk.Add(line);
            }
        }

        if (currentChunk.Count > 0)
        {
            chunks.Add(currentChunk);
        }

        return chunks;
    }
}