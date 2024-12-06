namespace Aoc2024;

public class Day6(IUtilities utilities) : Day(utilities)
{
    public override int Part1(string filename)
    {
        var lines = _utilities.ReadFile(filename);
        var map = lines.Select(x => x.ToCharArray()).ToArray();

        var currentRow = Array.FindIndex(map, 0, map.Length, x => x.Contains('^') || x.Contains('v') || x.Contains('<') || x.Contains('>'));
        var currentCol = Array.FindIndex(map[currentRow], x => x == '^' || x == 'v' || x == '<' || x == '>');
        while (currentRow >= 0 && currentRow < map.Length && currentCol >= 0 && currentCol < map[currentRow].Length)
        {
            var nextRow = currentRow;
            var nextCol = currentCol;

            switch (map[currentRow][currentCol])
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
            var direction = map[currentRow][currentCol];
            if (nextRow < 0 || nextRow >= map.Length || nextCol < 0 || nextCol >= map[nextRow].Length)
            {
                map[currentRow][currentCol] = 'X';
                currentRow = nextRow;
                currentCol = nextCol;
            }
            else if (map[nextRow][nextCol] == '#')
            {
                //Obstacle, turn 90 degrees to the right
                if (direction == '^')
                { direction = '>'; }
                else if (direction == 'v')
                { direction = '<'; }
                else if (direction == '<')
                { direction = '^'; }
                else if (direction == '>')
                { direction = 'v'; }
                map[currentRow][currentCol] = direction;
            }
            else
            {
                // No obstacle, move forward
                map[nextRow][nextCol] = direction;
                map[currentRow][currentCol] = 'X';
                currentRow = nextRow;
                currentCol = nextCol;
            }
        }

        var visitedCount = map.SelectMany(x => x).Count(x => x == 'X');
        return visitedCount;
    }

    public override int Part2(string filename)
    {
        var lines = _utilities.ReadFile(filename);
        var map = lines.Select(x => x.ToCharArray()).ToArray();

        var currentRow = Array.FindIndex(map, 0, map.Length, x => x.Contains('^') || x.Contains('v') || x.Contains('<') || x.Contains('>'));
        var currentCol = Array.FindIndex(map[currentRow], x => x == '^' || x == 'v' || x == '<' || x == '>');
        var direction = map[currentRow][currentCol];
        var obstacles = new List<(int, int)>();
        while (currentRow >= 0 && currentRow < map.Length && currentCol >= 0 && currentCol < map[currentRow].Length)
        {
            var nextRow = currentRow;
            var nextCol = currentCol;
            var checkRow = currentRow;
            var checkCol = currentCol;

            switch (direction)
            {
                case '^':
                    nextRow--;
                    checkCol++;
                    break;
                case 'v':
                    nextRow++;
                    checkCol--;
                    break;
                case '<':
                    nextCol--;
                    checkRow--;
                    break;
                case '>':
                    nextCol++;
                    checkRow++;
                    break;
            }
            if (nextRow < 0 || nextRow >= map.Length || nextCol < 0 || nextCol >= map[nextRow].Length)
            {
                map[currentRow][currentCol] = direction == '>' || direction == '<' ? '-' : '|';
                currentRow = nextRow;
                currentCol = nextCol;
            }
            else if (map[nextRow][nextCol] == '#')
            {
                //Obstacle, turn 90 degrees to the right
                direction = GetNextDirection(direction);
                map[currentRow][currentCol] = '+';
            }
            else
            {
                map[currentRow][currentCol] = direction == '>' || direction == '<' ? '-' : '|';
                var checkChar = direction == '>' || direction == '<' ? '|' : '-';
                // No obstacle, move forward
                if (map[checkRow][checkCol] == checkChar && !obstacles.Contains((nextRow, nextCol)))
                {
                    obstacles.Add((nextRow, nextCol));
                }

                map[nextRow][nextCol] = direction;
                currentRow = nextRow;
                currentCol = nextCol;
            }
        }

        return obstacles.Count;
    }

    private char GetNextDirection(char direction)
    {
        if (direction == '^')
        { return '>'; }
        else if (direction == 'v')
        { return '<'; }
        else if (direction == '<')
        { return '^'; }
        else
        { return 'v'; }
    }

}