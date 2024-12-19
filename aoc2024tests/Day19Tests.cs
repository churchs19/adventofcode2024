using Aoc2024;

using NSubstitute;

namespace Aoc2024Tests;

[TestFixture]
public class Day19Tests
{
    [Test]
    public void Part1_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IUtilities>();
        mockUtilities.ReadFileKeepBlankLines(filename).Returns(["r, wr, b, g, bwu, rb, gb, br",
"",
"brwrr",
"bggr",
"gbbr",
"rrbgbr",
"ubwu",
"bwurrg",
"brgr",
"bbrgwb"]);
        var day = new Day19(mockUtilities);

        // Act
        var result = day.Part1(filename);

        // Assert
        Assert.That(result, Is.EqualTo(6));
    }

    [Test]
    public void Part2_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IUtilities>();
        mockUtilities.ReadFileKeepBlankLines(filename).Returns(["r, wr, b, g, bwu, rb, gb, br",
"",
"brwrr",
"bggr",
"gbbr",
"rrbgbr",
"ubwu",
"bwurrg",
"brgr",
"bbrgwb"]);
        var day = new Day19(mockUtilities);

        // Act
        var result = day.Part2(filename);

        // Assert
        Assert.That(result, Is.EqualTo(-1));
    }
}