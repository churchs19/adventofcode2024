using Aoc2024.Utilities;
using Aoc2024.Days;

using NSubstitute;

namespace Aoc2024Tests;

[TestFixture]
public class Day20Tests
{
    [Test]
    public void Part1_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IFileUtilities>();
        mockUtilities.ReadFile(filename).Returns(["###############",
"#...#...#.....#",
"#.#.#.#.#.###.#",
"#S#...#.#.#...#",
"#######.#.#.###",
"#######.#.#...#",
"#######.#.###.#",
"###..E#...#...#",
"###.#######.###",
"#...###...#...#",
"#.#####.#.###.#",
"#.#...#.#.#...#",
"#.#.#.#.#.#.###",
"#...#...#...###",
"###############"]);
        var day = new Day20(mockUtilities);

        // Act
        var result = day.Part1(filename);

        // Assert
        Assert.That(result, Is.EqualTo(-1));
    }

    [Test]
    public void Part2_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IFileUtilities>();
        mockUtilities.ReadFile(filename).Returns(["###############",
"#...#...#.....#",
"#.#.#.#.#.###.#",
"#S#...#.#.#...#",
"#######.#.#.###",
"#######.#.#...#",
"#######.#.###.#",
"###..E#...#...#",
"###.#######.###",
"#...###...#...#",
"#.#####.#.###.#",
"#.#...#.#.#...#",
"#.#.#.#.#.#.###",
"#...#...#...###",
"###############"]);
        var day = new Day20(mockUtilities);

        // Act
        var result = day.Part2(filename);

        // Assert
        Assert.That(result, Is.EqualTo(-1));
    }
}