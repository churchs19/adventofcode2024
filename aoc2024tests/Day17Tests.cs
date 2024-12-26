using Aoc2024.Utilities;
using Aoc2024.Days;

using NSubstitute;

namespace Aoc2024Tests;

[TestFixture]
public class Day17Tests
{
    [Test]
    public void Part1_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IFileUtilities>();
        mockUtilities.ReadFileKeepBlankLines(filename).Returns(["Register A: 729",
"Register B: 0",
"Register C: 0",
"",
"Program: 0,1,5,4,3,0"]);
        var day = new Day17(mockUtilities);

        // Act
        var result = day.Part1(filename);

        // Assert
        Assert.That(result, Is.EqualTo(4635635210));
    }

    [Test]
    public void Part2_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IFileUtilities>();
        mockUtilities.ReadFileKeepBlankLines(filename).Returns(["Register A: 729",
"Register B: 0",
"Register C: 0",
"",
"Program: 0,1,5,4,3,0"]);
        var day = new Day17(mockUtilities);

        // Act
        var result = day.Part2(filename);

        // Assert
        Assert.That(result, Is.EqualTo(-1));
    }
}