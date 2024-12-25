using Aoc2024;

using NSubstitute;

namespace Aoc2024Tests;

[TestFixture]
public class Day6Tests
{
    [Test]
    public void Part1_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IFileUtilities>();
        mockUtilities.ReadFile(filename).Returns(["....#.....",
".........#",
"..........",
"..#.......",
".......#..",
"..........",
".#..^.....",
"........#.",
"#.........",
"......#..."]);
        var day = new Day6(mockUtilities);

        // Act
        var result = day.Part1(filename);

        // Assert
        Assert.That(result, Is.EqualTo(41));
    }

    [Test]
    public void Part2_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IFileUtilities>();
        mockUtilities.ReadFile(filename).Returns(["....#.....",
".........#",
"..........",
"..#.......",
".......#..",
"..........",
".#..^.....",
"........#.",
"#.........",
"......#..."]);
        var day = new Day6(mockUtilities);

        // Act
        var result = day.Part2(filename);

        // Assert
        Assert.That(result, Is.EqualTo(6));
    }
}