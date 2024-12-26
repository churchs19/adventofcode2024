using Aoc2024.Utilities;

namespace Aoc2024.Days;

public class Day10(IFileUtilities utilities) : Day(utilities)
{
    private readonly record struct State(int Row, int Col, string Path);

    public override long Part1(string filename)
    {
        var inputLines = _utilities.ReadFile(filename);

        var map = GetMap(inputLines);

        var count = 0;
        for (var row = 0; row < map.Length; row++)
        {
            for (var col = 0; col < map[row].Length; col++)
            {
                if (map[row][col] == 0)
                {
                    var paths = FindPaths(map, row, col);
                    count += paths.DistinctBy(it => (it.Row, it.Col)).Count();
                }
            }
        }

        return count;
    }

    public override long Part2(string filename)
    {
        var inputLines = _utilities.ReadFile(filename);

        var map = GetMap(inputLines);

        var count = 0;
        for (var row = 0; row < map.Length; row++)
        {
            for (var col = 0; col < map[row].Length; col++)
            {
                if (map[row][col] == 0)
                {
                    var paths = FindPaths(map, row, col);
                    count += paths.Count;
                }
            }
        }

        return count;
    }

    private static int[][] GetMap(string[] inputLines)
    {
        var map = inputLines.Select(it =>
            it.ToCharArray()
                .Where(x => !string.IsNullOrWhiteSpace(x.ToString()))
                .Select(x => int.Parse(x.ToString()))
                .ToArray())
            .ToArray();
        return map;
    }

    private static HashSet<State> FindPaths(int[][] map, int startingRow, int startingCol)
    {
        var paths = new HashSet<State>();

        var queue = new Queue<State>(collection: [new State(startingRow, startingCol, Path: $"({startingRow}, {startingCol})")]);

        var mapRows = map.Length;
        var mapCols = map.Max(it => it.Length);

        while (queue.Count != 0)
        {
            var state = queue.Dequeue();
            if (map[state.Row][state.Col] == 9)
            {
                paths.Add(state);
                continue;
            }

            // Up
            if (state.Row - 1 >= 0 && map[state.Row - 1][state.Col] == map[state.Row][state.Col] + 1)
            {
                queue.Enqueue(new State(state.Row - 1, state.Col, $"{state.Path} -> ({state.Row - 1}, {state.Col})"));
            }

            // Down
            if (state.Row + 1 < mapRows && map[state.Row + 1][state.Col] == map[state.Row][state.Col] + 1)
            {
                queue.Enqueue(new State(state.Row + 1, state.Col, $"{state.Path} -> ({state.Row + 1}, {state.Col})"));
            }

            // Left
            if (state.Col - 1 >= 0 && map[state.Row][state.Col - 1] == map[state.Row][state.Col] + 1)
            {
                queue.Enqueue(new State(state.Row, state.Col - 1, $"{state.Path} -> ({state.Row}, {state.Col - 1})"));
            }

            // Right
            if (state.Col + 1 < mapCols && map[state.Row][state.Col + 1] == map[state.Row][state.Col] + 1)
            {
                queue.Enqueue(new State(state.Row, state.Col + 1, $"{state.Path} -> ({state.Row}, {state.Col + 1})"));
            }
        }

        return paths;
    }
}