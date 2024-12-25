using Aoc2024;

using NSubstitute;

namespace Aoc2024Tests;

[TestFixture]
public class Day16Tests
{
    [Test]
    public void Part1_SmallExample_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IFileUtilities>();
        mockUtilities.ReadFile(filename).Returns(["###############",
"#.......#....E#",
"#.#.###.#.###.#",
"#.....#.#...#.#",
"#.###.#####.#.#",
"#.#.#.......#.#",
"#.#.#####.###.#",
"#...........#.#",
"###.#.#####.#.#",
"#...#.....#.#.#",
"#.#.#.###.#.#.#",
"#.....#...#.#.#",
"#.###.#.#.#.#.#",
"#S..#.....#...#",
"###############"]);
        var day = new Day16(mockUtilities);

        // Act
        var result = day.Part1(filename);

        // Assert
        Assert.That(result, Is.EqualTo(7036));
    }

    [Test]
    public void Part1_LargeExample_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IFileUtilities>();
        mockUtilities.ReadFile(filename).Returns(["#################",
"#...#...#...#..E#",
"#.#.#.#.#.#.#.#.#",
"#.#.#.#...#...#.#",
"#.#.#.#.###.#.#.#",
"#...#.#.#.....#.#",
"#.#.#.#.#.#####.#",
"#.#...#.#.#.....#",
"#.#.#####.#.###.#",
"#.#.#.......#...#",
"#.#.###.#####.###",
"#.#.#...#.....#.#",
"#.#.#.#####.###.#",
"#.#.#.........#.#",
"#.#.#.#########.#",
"#S#.............#",
"#################"]);
        var day = new Day16(mockUtilities);

        // Act
        var result = day.Part1(filename);

        // Assert
        Assert.That(result, Is.EqualTo(11048));
    }

    [Test]
    public void Part2_SmallExample_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IFileUtilities>();
        mockUtilities.ReadFile(filename).Returns(["###############",
"#.......#....E#",
"#.#.###.#.###.#",
"#.....#.#...#.#",
"#.###.#####.#.#",
"#.#.#.......#.#",
"#.#.#####.###.#",
"#...........#.#",
"###.#.#####.#.#",
"#...#.....#.#.#",
"#.#.#.###.#.#.#",
"#.....#...#.#.#",
"#.###.#.#.#.#.#",
"#S..#.....#...#",
"###############"]);
        var day = new Day16(mockUtilities);

        // Act
        var result = day.Part2(filename);

        // Assert
        Assert.That(result, Is.EqualTo(45));
    }

    [Test]
    public void Part2_LargeExample_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IFileUtilities>();
        mockUtilities.ReadFile(filename).Returns(["#################",
"#...#...#...#..E#",
"#.#.#.#.#.#.#.#.#",
"#.#.#.#...#...#.#",
"#.#.#.#.###.#.#.#",
"#...#.#.#.....#.#",
"#.#.#.#.#.#####.#",
"#.#...#.#.#.....#",
"#.#.#####.#.###.#",
"#.#.#.......#...#",
"#.#.###.#####.###",
"#.#.#...#.....#.#",
"#.#.#.#####.###.#",
"#.#.#.........#.#",
"#.#.#.#########.#",
"#S#.............#",
"#################"]);
        var day = new Day16(mockUtilities);

        // Act
        var result = day.Part2(filename);

        // Assert
        Assert.That(result, Is.EqualTo(64));
    }
}