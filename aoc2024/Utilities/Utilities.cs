namespace Aoc2024.Utilities;

public interface IFileUtilities
{
    string[] ReadFile(string filename);
    string[] ReadFileKeepBlankLines(string filename);
}

public class FileUtilities : IFileUtilities
{
    public string[] ReadFile(string filename)
    {
        var projectFolder = Directory.GetCurrentDirectory();
        return File.ReadAllText(Path.Combine(projectFolder, filename))
            .TrimEnd()
            .Split("\n")
            .Where(it => !string.IsNullOrWhiteSpace(it))
            .Select(it => it.Trim())
            .ToArray();
    }

    public string[] ReadFileKeepBlankLines(string filename)
    {
        var projectFolder = Directory.GetCurrentDirectory();
        return File.ReadAllText(Path.Combine(projectFolder, filename))
            .TrimEnd()
            .Split("\n")
            .Select(it => it.Trim())
            .ToArray();
    }
}