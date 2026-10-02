using Aoc2024.Utilities;

namespace Aoc2024.Days;

public class Day12(IFileUtilities utilities) : Day(utilities)
{
    public override long Part1(string filename)
    {
        var inputLines = _utilities.ReadFile(filename);

        var map = inputLines.Select(it => it.ToCharArray()).ToArray();

        var uniqueChars = map.SelectMany(it => it).Distinct().ToArray();

        var totalPrice = uniqueChars.Sum(it =>
        {
            var areas = FindAreas(map, it).areas;
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

        var totalPrice = uniqueChars.Sum(it =>
        {
            var areas = FindAreas(map, it);

            return areas.areas.Zip(areas.areaCells, (area, areaCells) => area * CountSides(areaCells)).Sum();
        });

        return totalPrice;
    }

    //find the area of all of the cells represented by the same character in the map
    private static (List<long> areas, List<bool[,]> areaCells) FindAreas(char[][] map, char c)
    {
        int rows = map.Length;
        int cols = map[0].Length;
        bool[,] visited = new bool[rows, cols];
        List<long> areas = [];
        List<bool[,]> areaCells = [];
        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                if (map[row][col] == c && !visited[row, col])
                {
                    var areaVisited = new bool[rows, cols];
                    areas.Add(GetAreaDepthFirst(map, row, col, c, areaVisited));
                    visited = UnionBoolArrays(visited, areaVisited);
                    areaCells.Add(areaVisited);
                }
            }
        }
        return (areas, areaCells);
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

    public static long CountSides(bool[,] array)
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);
        List<(int, int)> corners = [];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (array[row, col])
                {
                    // Check if this cell is a corner
                    bool isCorner = false;

                    // Check top-left corner
                    if (row == 0 || col == 0 || !array[row - 1, col] || !array[row, col - 1])
                    {
                        isCorner = true;
                    }

                    // Check top-right corner
                    if (row == 0 || col == cols - 1 || !array[row - 1, col] || !array[row, col + 1])
                    {
                        isCorner = true;
                    }

                    // Check bottom-left corner
                    if (row == rows - 1 || col == 0 || !array[row + 1, col] || !array[row, col - 1])
                    {
                        isCorner = true;
                    }

                    // Check bottom-right corner
                    if (row == rows - 1 || col == cols - 1 || !array[row + 1, col] || !array[row, col + 1])
                    {
                        isCorner = true;
                    }

                    if (isCorner)
                    {
                        corners.Add((row, col));
                    }
                }
            }
        }

        return corners.Count;
    }

    public static bool[,] UnionBoolArrays(bool[,] array1, bool[,] array2)
    {
        int rows1 = array1.GetLength(0);
        int cols1 = array1.GetLength(1);
        int rows2 = array2.GetLength(0);
        int cols2 = array2.GetLength(1);

        if (rows1 != rows2 || cols1 != cols2)
        {
            throw new ArgumentException("Both arrays must have the same dimensions.");
        }

        bool[,] result = new bool[rows1, cols1];

        for (int row = 0; row < rows1; row++)
        {
            for (int col = 0; col < cols1; col++)
            {
                result[row, col] = array1[row, col] || array2[row, col];
            }
        }

        return result;
    }
}