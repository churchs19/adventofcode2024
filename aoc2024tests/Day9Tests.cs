using Aoc2024;

using NSubstitute;

namespace Aoc2024Tests;

[TestFixture]
public class Day9Tests
{
    [Test]
    public void Part1_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IUtilities>();
        mockUtilities.ReadFile(filename).Returns(["2333133121414131402"]);
        var day = new Day9(mockUtilities);

        // Act
        var result = day.Part1(filename);

        // Assert
        Assert.That(result, Is.EqualTo(1928));
    }

    [Test]
    public void Part2_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IUtilities>();
        mockUtilities.ReadFile(filename).Returns(["2333133121414131402"]);
        var day = new Day9(mockUtilities);

        // Act
        var result = day.Part2(filename);

        // Assert
        Assert.That(result, Is.EqualTo(2858));
    }
}