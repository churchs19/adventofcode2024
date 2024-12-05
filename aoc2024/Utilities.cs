namespace Aoc2024;

public interface IUtilities
{
    string[] ReadFile(string filename);
    string[] ReadFileKeepBlankLines(string filename);
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
}