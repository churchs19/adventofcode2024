using Aoc2024;

using NSubstitute;

namespace Aoc2024Tests;

[TestFixture]
public class Day2Tests
{
    [Test]
    public void Part1_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IUtilities>();
        mockUtilities.ReadFile(filename).Returns([]);
        var day2 = new Day2(mockUtilities);

        // Act
        var result = day2.Part1(filename);

        // Assert
        Assert.That(result, Is.EqualTo(-1));
    }

    [Test]
    public void Part2_ReturnsExpected()
    {
        // Arrange
        var mockUtilities = Substitute.For<IUtilities>();
        var day2 = new Day2(mockUtilities);
        string filename = "input.txt";
        mockUtilities.ReadFile(filename).Returns([]);

        // Act
        var result = day2.Part2(filename);

        // Assert
        Assert.That(result, Is.EqualTo(-1));
    }
}