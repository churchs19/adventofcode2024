using Aoc2024;

using NSubstitute;

namespace Aoc2024Tests;

[TestFixture]
public class Day3Tests
{
    [Test]
    public void Part1_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IUtilities>();
        mockUtilities.ReadFile(filename).Returns([""]);
        var day3 = new Day3(mockUtilities);

        // Act
        var result = day3.Part1(filename);

        // Assert
        Assert.That(result, Is.EqualTo(-1));
    }

    [Test]
    public void Part2_ReturnsExpected()
    {
        // Arrange
        var mockUtilities = Substitute.For<IUtilities>();
        var day3 = new Day3(mockUtilities);
        string filename = "input.txt";
        mockUtilities.ReadFile(filename).Returns([""]);

        // Act
        var result = day3.Part2(filename);

        // Assert
        Assert.That(result, Is.EqualTo(-1));
    }
}