namespace Aoc2024.Utilities;

public static class GridUtility
{
    public static bool GridContains((int, int) node, int gridRows, int gridCols)
    {
        return node.Item1 >= 0 && node.Item1 < gridRows && node.Item2 >= 0 && node.Item2 < gridCols;
    }
}