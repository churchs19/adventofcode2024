using Aoc2024.Utilities;

namespace Aoc2024.Days;

public class Day4(IFileUtilities utilities) : Day(utilities)
{
    public override long Part1(string filename)
    {
        var lines = _utilities.ReadFile(filename);

        var matrix = lines.Select(x => x.ToCharArray()).ToArray();

        var foundCount = 0;
        //Word search matrix for "XMAS"
        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                if (matrix[row][col] == 'X')
                {
                    // Search Up
                    if ((row - 3) >= 0)
                    {
                        if (matrix[row - 1][col] == 'M' && matrix[row - 2][col] == 'A' && matrix[row - 3][col] == 'S')
                        {
                            foundCount++;
                        }

                        if ((col - 3) >= 0) // Search left
                        {
                            if (matrix[row - 1][col - 1] == 'M' && matrix[row - 2][col - 2] == 'A' && matrix[row - 3][col - 3] == 'S')
                            {
                                foundCount++;
                            }
                        }

                        if ((col + 3) < matrix[row].Length) // Search right
                        {
                            if (matrix[row - 1][col + 1] == 'M' && matrix[row - 2][col + 2] == 'A' && matrix[row - 3][col + 3] == 'S')
                            {
                                foundCount++;
                            }
                        }
                    }

                    //Search Same Row
                    if ((col - 3) >= 0) // Search left
                    {
                        if (matrix[row][col - 1] == 'M' && matrix[row][col - 2] == 'A' && matrix[row][col - 3] == 'S')
                        {
                            foundCount++;
                        }
                    }
                    if ((col + 3) < matrix[row].Length) // Search right
                    {
                        if (matrix[row][col + 1] == 'M' && matrix[row][col + 2] == 'A' && matrix[row][col + 3] == 'S')
                        {
                            foundCount++;
                        }
                    }

                    // Search Down
                    if ((row + 3) < matrix.Length)
                    {
                        if (matrix[row + 1][col] == 'M' && matrix[row + 2][col] == 'A' && matrix[row + 3][col] == 'S')
                        {
                            foundCount++;
                        }

                        if ((col - 3) >= 0) // Search left
                        {
                            if (matrix[row + 1][col - 1] == 'M' && matrix[row + 2][col - 2] == 'A' && matrix[row + 3][col - 3] == 'S')
                            {
                                foundCount++;
                            }
                        }

                        if ((col + 3) < matrix[row].Length) // Search right
                        {
                            if (matrix[row + 1][col + 1] == 'M' && matrix[row + 2][col + 2] == 'A' && matrix[row + 3][col + 3] == 'S')
                            {
                                foundCount++;
                            }
                        }
                    }
                }
            }
        }

        return foundCount;
    }

    public override long Part2(string filename)
    {
        var lines = _utilities.ReadFile(filename);


        var matrix = lines.Select(x => x.ToCharArray()).ToArray();

        var foundCount = 0;
        //Word search matrix for "X-MAS" ("MAS" in the shape of an X)
        for (int row = 1; row < matrix.Length - 1; row++)
        {
            for (int col = 1; col < matrix[row].Length - 1; col++)
            {
                if (matrix[row][col] == 'A')
                {
                    // Search all 4 orientations
                    if (matrix[row - 1][col - 1] == 'M' && matrix[row - 1][col + 1] == 'M' && matrix[row + 1][col - 1] == 'S' && matrix[row + 1][col + 1] == 'S')
                    {
                        foundCount++;
                    }
                    if (matrix[row - 1][col - 1] == 'S' && matrix[row - 1][col + 1] == 'S' && matrix[row + 1][col - 1] == 'M' && matrix[row + 1][col + 1] == 'M')
                    {
                        foundCount++;
                    }
                    if (matrix[row - 1][col - 1] == 'M' && matrix[row - 1][col + 1] == 'S' && matrix[row + 1][col - 1] == 'M' && matrix[row + 1][col + 1] == 'S')
                    {
                        foundCount++;
                    }
                    if (matrix[row - 1][col - 1] == 'S' && matrix[row - 1][col + 1] == 'M' && matrix[row + 1][col - 1] == 'S' && matrix[row + 1][col + 1] == 'M')
                    {
                        foundCount++;
                    }
                }
            }
        }

        return foundCount;
    }
}