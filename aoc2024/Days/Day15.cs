namespace Aoc2024;

public class Day15(IFileUtilities utilities) : Day(utilities)
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
            (currentRow, currentCol) = Part1ProcessMove(map, currentRow, currentCol, direction);
        }

        return CalculateSumGPSCoordinates(map);
    }

    public override long Part2(string filename)
    {
        var inputLines = _utilities.ReadFileKeepBlankLines(filename);

        var splitIndex = Array.IndexOf(inputLines, "");
        var map = inputLines.Take(splitIndex).Select(it => it.ToCharArray()).ToArray();
        var directions = inputLines.Skip(splitIndex + 1).SelectMany(it => it.ToCharArray()).ToArray();

        map = DoubleMap(map);

        var currentRow = map.Select((row, index) => (row, index)).First(it => it.row.Contains('@')).index;
        var currentCol = map[currentRow].ToList().IndexOf('@');

        foreach (var direction in directions)
        {
            (currentRow, currentCol) = Part2ProcessMove(map, currentRow, currentCol, direction);
        }

        return CalculateSumGPSCoordinates(map);
    }

    #region Part 1
    private static (int, int) Part1ProcessMove(char[][] map, int currentRow, int currentCol, char direction)
    {
        return direction switch
        {
            '^' => Part1MoveUp(map, currentRow, currentCol),
            'v' => Part1MoveDown(map, currentRow, currentCol),
            '<' => Part1MoveLeft(map, currentRow, currentCol),
            '>' => Part1MoveRight(map, currentRow, currentCol),
            _ => throw new Exception("Invalid direction"),
        };
    }

    private static (int, int) Part1MoveUp(char[][] map, int currentRow, int currentCol)
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

    private static (int, int) Part1MoveDown(char[][] map, int currentRow, int currentCol)
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

    private static (int, int) Part1MoveLeft(char[][] map, int currentRow, int currentCol)
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

    private static (int, int) Part1MoveRight(char[][] map, int currentRow, int currentCol)
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
    #endregion Part 1
    private static long CalculateSumGPSCoordinates(char[][] map)
    {
        var sum = 0;
        for (var row = 0; row < map.Length; row++)
        {
            for (var col = 0; col < map[row].Length; col++)
            {
                if (map[row][col] == 'O' || map[row][col] == '[')
                {
                    sum += (100 * row) + col;
                }
            }
        }
        return sum;
    }

    #region Part 2
    private static char[][] DoubleMap(char[][] map)
    {
        var newMap = new List<List<char>>();

        for (var row = 0; row < map.Length; row++)
        {
            newMap.Add([]);
            for (var col = 0; col < map[row].Length; col++)
            {
                switch (map[row][col])
                {
                    case '#':
                        newMap[row].Add('#');
                        newMap[row].Add('#');
                        break;
                    case '.':
                        newMap[row].Add('.');
                        newMap[row].Add('.');
                        break;
                    case '@':
                        newMap[row].Add('@');
                        newMap[row].Add('.');
                        break;
                    case 'O':
                        newMap[row].Add('[');
                        newMap[row].Add(']');
                        break;
                }
            }
        }
        return newMap.Select(it => it.ToArray()).ToArray();
    }

    private static (int, int) Part2ProcessMove(char[][] map, int currentRow, int currentCol, char direction)
    {
        return direction switch
        {
            '^' => Part2MoveUp(map, currentRow, currentCol),
            'v' => Part2MoveDown(map, currentRow, currentCol),
            '<' => Part2MoveLeft(map, currentRow, currentCol),
            '>' => Part2MoveRight(map, currentRow, currentCol),
            _ => throw new Exception("Invalid direction"),
        };
    }

    private static (int, int) Part2MoveUp(char[][] map, int currentRow, int currentCol)
    {
        if (map[currentRow - 1][currentCol] == '#')
        {
            return (currentRow, currentCol);
        }
        else if (map[currentRow - 1][currentCol] == '[' || map[currentRow - 1][currentCol] == ']')
        {
            return (currentRow, currentCol);
        }
        else
        {
            map[currentRow][currentCol] = '.';
            map[currentRow - 1][currentCol] = '@';
            return (currentRow - 1, currentCol);
        }
    }

    private static (int, int) Part2MoveDown(char[][] map, int currentRow, int currentCol)
    {
        if (map[currentRow + 1][currentCol] == '#')
        {
            return (currentRow, currentCol);
        }
        else if (map[currentRow + 1][currentCol] == '[' || map[currentRow + 1][currentCol] == ']')
        {
            return (currentRow, currentCol);
        }
        else
        {
            map[currentRow][currentCol] = '.';
            map[currentRow + 1][currentCol] = '@';
            return (currentRow + 1, currentCol);
        }
    }

    private static (int, int) Part2MoveLeft(char[][] map, int currentRow, int currentCol)
    {
        if (map[currentRow][currentCol - 1] == '#')
        {
            return (currentRow, currentCol);
        }
        else if (map[currentRow][currentCol - 1] == '[' || map[currentRow][currentCol - 1] == ']')
        {
            return (currentRow, currentCol);
        }
        else
        {
            map[currentRow][currentCol] = '.';
            map[currentRow][currentCol - 1] = '@';
            return (currentRow, currentCol - 1);
        }
    }

    private static (int, int) Part2MoveRight(char[][] map, int currentRow, int currentCol)
    {
        if (map[currentRow][currentCol + 1] == '#')
        {
            return (currentRow, currentCol);
        }
        else if (map[currentRow][currentCol + 1] == '[' || map[currentRow][currentCol + 1] == ']')
        {
            return (currentRow, currentCol);
        }
        else
        {
            map[currentRow][currentCol] = '.';
            map[currentRow][currentCol + 1] = '@';
            return (currentRow, currentCol + 1);
        }
    }
    #endregion Part 2
}