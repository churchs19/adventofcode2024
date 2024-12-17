namespace Aoc2024;

public class Day16(IUtilities utilities) : Day(utilities)
{
    public override long Part1(string filename)
    {
        var inputLines = _utilities.ReadFile(filename);

        var maze = inputLines.Select(x => x.ToCharArray()).ToArray();

        var start = FindPosition(maze, 'S');
        var end = FindPosition(maze, 'E');

        return FindShortestPath(maze, start, end).First().cost;
    }

    public override long Part2(string filename)
    {
        var inputLines = _utilities.ReadFile(filename);

        var maze = inputLines.Select(x => x.ToCharArray()).ToArray();

        var start = FindPosition(maze, 'S');
        var end = FindPosition(maze, 'E');

        var solutions = FindShortestPath(maze, start, end);

        var cells = solutions.SelectMany(it => it.path);

        return cells.Distinct().Count();
    }

    private static (int, int) FindPosition(char[][] maze, char target)
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

    private static List<(long cost, List<(int, int)> path)> FindShortestPath(char[][] maze, (int, int) start, (int, int) end)
    {
        var directions = new (int, int, int)[] { (0, 1, 0), (1, 0, 1), (0, -1, 2), (-1, 0, 3) };
        var pq = new PriorityQueue<(int, int, int, long, List<(int, int)>), long>();
        var visited = new HashSet<(int, int, int)>();
        var solutions = new List<(long cost, List<(int, int)> path)>();

        pq.Enqueue((start.Item1, start.Item2, 0, 0, new List<(int, int)> { start }), 0);

        while (pq.Count > 0)
        {
            var (x, y, dir, cost, path) = pq.Dequeue();

            if ((x, y) == end)
            {
                if (solutions.Count == 0 || solutions.First().cost == cost)
                {
                    solutions.Add((cost, path));
                }
                else if (cost > solutions.First().cost)
                {
                    return solutions;
                }
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
                    var newPath = new List<(int, int)>(path) { (nx, ny) };
                    pq.Enqueue((nx, ny, newDir, newCost, newPath), newCost);
                }
            }
        }

        return solutions.Count == 0 ? ([(long.MaxValue, new List<(int, int)>())]) : solutions;
    }
}