namespace Aoc2024;

public class Day16(IUtilities utilities) : Day(utilities)
{
    public override long Part1(string filename)
    {
        var inputLines = _utilities.ReadFile(filename);

        var maze = inputLines.Select(x => x.ToCharArray()).ToArray();

        var start = FindPosition(maze, 'S');
        var end = FindPosition(maze, 'E');

        return FindShortestPath(maze, start, end);
    }

    public override long Part2(string filename)
    {
        var inputLines = _utilities.ReadFile(filename);

        var maze = inputLines.Select(x => x.ToCharArray()).ToArray();

        return long.MinValue;
    }

    private (int, int) FindPosition(char[][] maze, char target)
    {
        for (int i = 0; i < maze.Length; i++)
        {
            for (int j = 0; j < maze[i].Length; j++)
            {
                if (maze[i][j] == target)
                {
                    return (i, j);
                }
            }
        }
        throw new Exception($"{target} not found in the maze");
    }

    private long FindShortestPath(char[][] maze, (int, int) start, (int, int) end)
    {
        var directions = new (int, int, int)[] { (0, 1, 0), (1, 0, 1), (0, -1, 2), (-1, 0, 3) };
        var pq = new PriorityQueue<(int, int, int, long), long>();
        var visited = new HashSet<(int, int, int)>();

        pq.Enqueue((start.Item1, start.Item2, 0, 0), 0);

        while (pq.Count > 0)
        {
            var (x, y, dir, cost) = pq.Dequeue();

            if ((x, y) == end)
            {
                return cost;
            }

            if (!visited.Add((x, y, dir)))
            {
                continue;
            }

            foreach (var (dx, dy, newDir) in directions)
            {
                int nx = x + dx, ny = y + dy;
                if (nx >= 0 && ny >= 0 && nx < maze.Length && ny < maze[0].Length && maze[nx][ny] != '#')
                {
                    long newCost = cost + 1 + (dir != newDir ? 1000 : 0);
                    pq.Enqueue((nx, ny, newDir, newCost), newCost);
                }
            }
        }

        return long.MaxValue;
    }
}