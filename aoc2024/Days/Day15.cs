namespace Aoc2024;

public class Day15(IUtilities utilities) : Day(utilities)
{
    public override long Part1(string filename)
    {
        var inputLines = _utilities.ReadFileKeepBlankLines(filename);

        var splitIndex = Array.IndexOf(inputLines, "");
        var map = inputLines.Take(splitIndex).Select(it => it.ToCharArray()).ToArray();
        var directions = inputLines.Skip(splitIndex + 1).SelectMany(it => it.ToCharArray()).ToArray();

        var currentRow = map.Select((row, index) => (row, index)).First(it => it.row.Contains('@')).index;
        var currentCol = map[currentRow].ToList().IndexOf('@');

        foreach (var direction in directions)
        {
            (currentRow, currentCol) = ProcessMove(map, currentRow, currentCol, direction);
        }

        return CalculateSumGPSCoordinates(map);
    }

    public override long Part2(string filename)
    {
        var inputLines = _utilities.ReadFileKeepBlankLines(filename);

        var splitIndex = Array.IndexOf(inputLines, "");
        var map = inputLines.Take(splitIndex).Select(it => it.ToCharArray()).ToArray();
        var directions = inputLines.Skip(splitIndex + 1).SelectMany(it => it.ToCharArray()).ToArray();

        return long.MinValue;
    }

    private static (int, int) ProcessMove(char[][] map, int currentRow, int currentCol, char direction)
    {
        return direction switch
        {
            '^' => MoveUp(map, currentRow, currentCol),
            'v' => MoveDown(map, currentRow, currentCol),
            '<' => MoveLeft(map, currentRow, currentCol),
            '>' => MoveRight(map, currentRow, currentCol),
            _ => throw new Exception("Invalid direction"),
        };
    }

    private static (int, int) MoveUp(char[][] map, int currentRow, int currentCol)
    {
        if (map[currentRow - 1][currentCol] == '#')
        {
            return (currentRow, currentCol);
        }
        else if (map[currentRow - 1][currentCol] == 'O')
        {
            var nextIndex = currentRow - 2;
            while (nextIndex >= 0 && map[nextIndex][currentCol] == 'O')
            {
                nextIndex--;
            }
            if (map[nextIndex][currentCol] == '#')
            {
                return (currentRow, currentCol);
            }
            else
            {
                map[currentRow][currentCol] = '.';
                map[currentRow - 1][currentCol] = '@';
                map[nextIndex][currentCol] = 'O';
                return (currentRow - 1, currentCol);
            }
        }
        else
        {
            map[currentRow][currentCol] = '.';
            map[currentRow - 1][currentCol] = '@';
            return (currentRow - 1, currentCol);
        }
    }

    private static (int, int) MoveDown(char[][] map, int currentRow, int currentCol)
    {
        if (map[currentRow + 1][currentCol] == '#')
        {
            return (currentRow, currentCol);
        }
        else if (map[currentRow + 1][currentCol] == 'O')
        {
            var nextIndex = currentRow + 2;
            while (nextIndex < map.Length && map[nextIndex][currentCol] == 'O')
            {
                nextIndex++;
            }
            if (map[nextIndex][currentCol] == '#')
            {
                return (currentRow, currentCol);
            }
            else
            {
                map[currentRow][currentCol] = '.';
                map[currentRow + 1][currentCol] = '@';
                map[nextIndex][currentCol] = 'O';
                return (currentRow + 1, currentCol);
            }
        }
        else
        {
            map[currentRow][currentCol] = '.';
            map[currentRow + 1][currentCol] = '@';
            return (currentRow + 1, currentCol);
        }
    }

    private static (int, int) MoveLeft(char[][] map, int currentRow, int currentCol)
    {
        if (map[currentRow][currentCol - 1] == '#')
        {
            return (currentRow, currentCol);
        }
        else if (map[currentRow][currentCol - 1] == 'O')
        {
            var nextIndex = currentCol - 2;
            while (nextIndex >= 0 && map[currentRow][nextIndex] == 'O')
            {
                nextIndex--;
            }
            if (map[currentRow][nextIndex] == '#')
            {
                return (currentRow, currentCol);
            }
            else
            {
                map[currentRow][currentCol] = '.';
                map[currentRow][currentCol - 1] = '@';
                map[currentRow][nextIndex] = 'O';
                return (currentRow, currentCol - 1);
            }
        }
        else
        {
            map[currentRow][currentCol] = '.';
            map[currentRow][currentCol - 1] = '@';
            return (currentRow, currentCol - 1);
        }
    }

    private static (int, int) MoveRight(char[][] map, int currentRow, int currentCol)
    {
        if (map[currentRow][currentCol + 1] == '#')
        {
            return (currentRow, currentCol);
        }
        else if (map[currentRow][currentCol + 1] == 'O')
        {
            var nextIndex = currentCol + 2;
            while (nextIndex < map[currentRow].Length && map[currentRow][nextIndex] == 'O')
            {
                nextIndex++;
            }
            if (map[currentRow][nextIndex] == '#')
            {
                return (currentRow, currentCol);
            }
            else
            {
                map[currentRow][currentCol] = '.';
                map[currentRow][currentCol + 1] = '@';
                map[currentRow][nextIndex] = 'O';
                return (currentRow, currentCol + 1);
            }
        }
        else
        {
            map[currentRow][currentCol] = '.';
            map[currentRow][currentCol + 1] = '@';
            return (currentRow, currentCol + 1);
        }
    }

    private static long CalculateSumGPSCoordinates(char[][] map)
    {
        var sum = 0;
        for (var row = 0; row < map.Length; row++)
        {
            for (var col = 0; col < map[row].Length; col++)
            {
                if (map[row][col] == 'O')
                {
                    sum += (100 * row) + col;
                }
            }
        }
        return sum;
    }
}