using Aoc2024.Utilities;
using Aoc2024.Days;

using NSubstitute;

namespace Aoc2024Tests;

[TestFixture]
public class Day12Tests
{
    [Test]
    public void Part1_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IFileUtilities>();
        mockUtilities.ReadFile(filename).Returns(["RRRRIICCFF",
"RRRRIICCCF",
"VVRRRCCFFF",
"VVRCCCJFFF",
"VVVVCJJCFE",
"VVIVCCJJEE",
"VVIIICJJEE",
"MIIIIIJJEE",
"MIIISIJEEE",
"MMMISSJEEE"]);
        var day = new Day12(mockUtilities);

        // Act
        var result = day.Part1(filename);

        // Assert
        Assert.That(result, Is.EqualTo(1930));
    }

    [Test]
    public void Part1_XO_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IFileUtilities>();
        mockUtilities.ReadFile(filename).Returns(["OOOOO",
"OXOXO",
"OOOOO",
"OXOXO",
"OOOOO"]);
        var day = new Day12(mockUtilities);

        // Act
        var result = day.Part1(filename);

        // Assert
        Assert.That(result, Is.EqualTo(772));
    }

    [Test]
    public void Part2_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IFileUtilities>();
        mockUtilities.ReadFile(filename).Returns(["RRRRIICCFF",
"RRRRIICCCF",
"VVRRRCCFFF",
"VVRCCCJFFF",
"VVVVCJJCFE",
"VVIVCCJJEE",
"VVIIICJJEE",
"MIIIIIJJEE",
"MIIISIJEEE",
"MMMISSJEEE"]);
        var day = new Day12(mockUtilities);

        // Act
        var result = day.Part2(filename);

        // Assert
        Assert.That(result, Is.EqualTo(1206));
    }

    [Test]
    public void Part2_XO_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IFileUtilities>();
        mockUtilities.ReadFile(filename).Returns(["OOOOO",
"OXOXO",
"OOOOO",
"OXOXO",
"OOOOO"]);
        var day = new Day12(mockUtilities);

        // Act
        var result = day.Part2(filename);

        // Assert
        Assert.That(result, Is.EqualTo(436));
    }

    [Test]
    public void Part2_AB_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IFileUtilities>();
        mockUtilities.ReadFile(filename).Returns(["AAAAAA",
"AAABBA",
"AAABBA",
"ABBAAA",
"ABBAAA",
"AAAAAA"]);
        var day = new Day12(mockUtilities);

        // Act
        var result = day.Part2(filename);

        // Assert
        Assert.That(result, Is.EqualTo(368));
    }

    [Test]
    public void Part2_EX_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IFileUtilities>();
        mockUtilities.ReadFile(filename).Returns(["EEEEE",
"EXXXX",
"EEEEE",
"EXXXX",
"EEEEE"]);
        var day = new Day12(mockUtilities);

        // Act
        var result = day.Part2(filename);

        // Assert
        Assert.That(result, Is.EqualTo(236));
    }
}