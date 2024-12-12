namespace Aoc2024;

public class Day12(IUtilities utilities) : Day(utilities)
{
    public override long Part1(string filename)
    {
        var inputLines = _utilities.ReadFile(filename);

        var map = inputLines.Select(it => it.ToCharArray()).ToArray();

        var uniqueChars = map.SelectMany(it => it).Distinct().ToArray();

        var totalPrice = uniqueChars.Sum(it =>
        {
            var areas = FindAreas(map, it);
            var perimeters = FindPerimeters(map, it);

            return areas.Zip(perimeters, (area, perimeter) => area * perimeter).Sum();
        });

        return totalPrice;
    }

    public override long Part2(string filename)
    {
        var inputLines = _utilities.ReadFile(filename);

        var map = inputLines.Select(it => it.ToCharArray()).ToArray();

        var uniqueChars = map.SelectMany(it => it).Distinct().ToArray();



        return long.MinValue;
    }

    //find the area of all of the cells represented by the same character in the map
    private static List<long> FindAreas(char[][] map, char c)
    {
        int rows = map.Length;
        int cols = map[0].Length;
        bool[,] visited = new bool[rows, cols];
        List<long> areas = [];
        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                if (map[row][col] == c && !visited[row, col])
                {
                    areas.Add(GetAreaDepthFirst(map, row, col, c, visited));
                }
            }
        }
        return areas;
    }

    private static long GetAreaDepthFirst(char[][] map, int x, int y, char c, bool[,] visited)
    {
        int rows = map.Length;
        int cols = map[0].Length;

        // Check for out of bounds or if the cell is already visited or not the target character
        if (x < 0 || x >= rows || y < 0 || y >= cols || visited[x, y] || map[x][y] != c)
        {
            return 0;
        }

        // Mark the cell as visited
        visited[x, y] = true;

        // Initialize area count
        long area = 1;

        // Explore all 4 possible directions (up, down, left, right)
        area += GetAreaDepthFirst(map, x + 1, y, c, visited);
        area += GetAreaDepthFirst(map, x - 1, y, c, visited);
        area += GetAreaDepthFirst(map, x, y + 1, c, visited);
        area += GetAreaDepthFirst(map, x, y - 1, c, visited);

        return area;
    }

    //find the perimeter of all of the cells represented by the same character in the map
    private static List<long> FindPerimeters(char[][] map, char c)
    {
        int rows = map.Length;
        int cols = map[0].Length;
        bool[,] visited = new bool[rows, cols];
        List<long> perimeters = [];
        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                if (map[row][col] == c && !visited[row, col])
                {
                    perimeters.Add(GetPerimeterDepthFirst(map, row, col, c, visited));
                }
            }
        }
        return perimeters;
    }

    private static long GetPerimeterDepthFirst(char[][] map, int x, int y, char c, bool[,] visited)
    {
        int rows = map.Length;
        int cols = map[0].Length;

        // Check for out of bounds or if the cell is already visited or not the target character
        if (x < 0 || x >= rows || y < 0 || y >= cols || visited[x, y] || map[x][y] != c)
        {
            return 0;
        }

        // Mark the cell as visited
        visited[x, y] = true;

        // Initialize perimeter count
        long perimeter = 0;

        // Check all 4 possible directions (up, down, left, right)
        if (x + 1 >= rows || map[x + 1][y] != c) perimeter++;
        else perimeter += GetPerimeterDepthFirst(map, x + 1, y, c, visited);

        if (x - 1 < 0 || map[x - 1][y] != c) perimeter++;
        else perimeter += GetPerimeterDepthFirst(map, x - 1, y, c, visited);

        if (y + 1 >= cols || map[x][y + 1] != c) perimeter++;
        else perimeter += GetPerimeterDepthFirst(map, x, y + 1, c, visited);

        if (y - 1 < 0 || map[x][y - 1] != c) perimeter++;
        else perimeter += GetPerimeterDepthFirst(map, x, y - 1, c, visited);

        return perimeter;
    }
}