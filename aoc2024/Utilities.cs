namespace Aoc2024;

public interface IUtilities
{
    string[] ReadFile(string filename);
    string[] ReadFileKeepBlankLines(string filename);
    bool GridContains((int, int) node, int gridRows, int gridCols);
}

public class Utilities : IUtilities
{
    public string[] ReadFile(string filename)
    {
        var projectFolder = Directory.GetCurrentDirectory();
        return File.ReadAllText(Path.Combine(projectFolder, filename))
            .TrimEnd()
            .Split("\n")
            .Where(it => !string.IsNullOrWhiteSpace(it))
            .ToArray();
    }

    public string[] ReadFileKeepBlankLines(string filename)
    {
        var projectFolder = Directory.GetCurrentDirectory();
        return [.. File.ReadAllText(Path.Combine(projectFolder, filename))
            .TrimEnd()
            .Split("\n")];
    }

    public bool GridContains((int, int) node, int gridRows, int gridCols)
    {
        return node.Item1 >= 0 && node.Item1 < gridRows && node.Item2 >= 0 && node.Item2 < gridCols;
    }
}