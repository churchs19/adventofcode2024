namespace Aoc2024;

public class Day6(IUtilities utilities) : Day(utilities)
{
    public override long Part1(string filename)
    {
        var lines = _utilities.ReadFile(filename);
        var map = lines.Select(x => x.ToCharArray()).ToArray();

        var startRow = Array.FindIndex(map, 0, map.Length, x => x.Contains('^') || x.Contains('v') || x.Contains('<') || x.Contains('>'));
        var startCol = Array.FindIndex(map[startRow], x => x == '^' || x == 'v' || x == '<' || x == '>');
        var direction = map[startRow][startCol];
        map[startRow][startCol] = '.';

        var visited = TraverseMap(map, startRow, startCol, direction);

        var visitedCount = visited.Count;
        return visitedCount;
    }

    public override long Part2(string filename)
    {
        var lines = _utilities.ReadFile(filename);
        var map = lines.Select(x => x.ToCharArray()).ToArray();

        var startRow = Array.FindIndex(map, 0, map.Length, x => x.Contains('^') || x.Contains('v') || x.Contains('<') || x.Contains('>'));
        var startCol = Array.FindIndex(map[startRow], x => x == '^' || x == 'v' || x == '<' || x == '>');
        var direction = map[startRow][startCol];
        map[startRow][startCol] = '.';

        var visited = TraverseMap(map, startRow, startCol, direction);

        return CountLoops(map, startRow, startCol, direction, visited);
    }

    private static HashSet<(int, int)> TraverseMap(char[][] map, int startRow, int startCol, char startDirection)
    {
        var visited = new HashSet<(int, int)>();
        var currentRow = startRow;
        var currentCol = startCol;
        var direction = startDirection;
        visited.Add((currentRow, currentCol));
        while (MapContains(map, NextCell(currentRow, currentCol, direction)))
        {
            var (nextRow, nextCol) = NextCell(currentRow, currentCol, direction);
            if (map[nextRow][nextCol] == '#')
            {
                direction = Turn(direction);
            }
            else
            {
                // No obstacle, move forward
                currentRow = nextRow;
                currentCol = nextCol;
                visited.Add((nextRow, nextCol));
            }
        }

        return visited;
    }

    private static int CountLoops(char[][] map, int startRow, int startCol, char direction, HashSet<(int, int)> path)
    {
        var loopCount = path.Except([(startRow, startCol)])
            .Count(x => CheckLoop(map, startRow, startCol, direction, x.Item1, x.Item2));
        return loopCount;
    }

    private static bool CheckLoop(char[][] map,
        int startRow,
        int startCol,
        char startDirection,
        int candidateRow,
        int candidateCol)
    {
        var currentRow = startRow;
        var currentCol = startCol;
        var direction = startDirection;
        var visited = new HashSet<(int, int, char)>();

        while (visited.Add((currentRow, currentCol, direction)) &&
            MapContains(map, NextCell(currentRow, currentCol, direction))
            )
        {
            var (nextRow, nextCol) = NextCell(currentRow, currentCol, direction);
            if ((nextRow == candidateRow && nextCol == candidateCol) ||
                map[nextRow][nextCol] == '#')
            {
                direction = Turn(direction);
            }
            else
            {
                currentRow = nextRow;
                currentCol = nextCol;
            }
        }

        return MapContains(map, NextCell(currentRow, currentCol, direction));
    }

    private static bool MapContains(char[][] map, (int, int) cell)
    {
        return cell.Item1 >= 0 && cell.Item1 < map.Length && cell.Item2 >= 0 && cell.Item2 < map[cell.Item1].Length;
    }

    private static char Turn(char direction)
    {
        //Obstacle, turn 90 degrees to the right
        if (direction == '^')
        { return '>'; }
        else if (direction == 'v')
        { return '<'; }
        else if (direction == '<')
        { return '^'; }
        else if (direction == '>')
        { return 'v'; }
        throw new ArgumentException("Direction must be one of '^', 'v', '<', '>'.", nameof(direction));
    }

    private static (int, int) NextCell(int row, int col, char direction)
    {
        var nextRow = row;
        var nextCol = col;

        switch (direction)
        {
            case '^':
                nextRow--;
                break;
            case 'v':
                nextRow++;
                break;
            case '<':
                nextCol--;
                break;
            case '>':
                nextCol++;
                break;
        }

        return (nextRow, nextCol);
    }
}