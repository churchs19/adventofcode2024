namespace Aoc2024;
public class Day2(IUtilities utilities) : Day(utilities)
{
    public override int Part1(string filename)
    {
        var lines = _utilities.ReadFile(filename);

        var numbers = lines.Select(it => it.Split(' ').Select(int.Parse).ToList()).ToList();

        var safeRows = numbers.Select(Part1Safe).ToList();

        return safeRows.Count(it => it == true);
    }

    public override int Part2(string filename)
    {
        var lines = _utilities.ReadFile(filename);

        var numbers = lines.Select(it => it.Split(' ').Select(int.Parse).ToList()).ToList();

        var safeRows = numbers.Select(Part2Safe).ToList();

        return safeRows.Count(it => it == true);
    }

    private bool Part1Safe(List<int> numberRow)
    {
        if (numberRow.Count < 2) return true;

        var direction = numberRow[0] < numberRow[1] ? 1 : -1;
        for (var i = 1; i < numberRow.Count; i++)
        {
            if (!IsSafeLevel(direction, numberRow[i - 1], numberRow[i])) return false;
        }

        return true;
    }

    private bool Part2Safe(List<int> numberRow)
    {
        if (numberRow.Count < 2) return true;

        if (Part1Safe(numberRow)) return true;

        for (var i = 0; i < numberRow.Count; i++)
        {
            var newNumberRow = new List<int>(numberRow);
            newNumberRow.RemoveAt(i);
            if (Part1Safe(newNumberRow)) return true;
        }

        return false;
    }

    private static bool IsSafeLevel(int direction, int value1, int value2)
    {
        var newDirection = value1 < value2 ? 1 : -1;
        return newDirection == direction && Math.Abs(value2 - value1) <= 3 && Math.Abs(value2 - value1) >= 1;
    }
}