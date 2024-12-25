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
        var mockUtilities = Substitute.For<IFileUtilities>();
        mockUtilities.ReadFile(filename).Returns(["7 6 4 2 1",
            "1 2 7 8 9",
            "9 7 6 2 1",
            "1 3 2 4 5",
            "8 6 4 4 1",
            "1 3 6 7 9"]);
        var day2 = new Day2(mockUtilities);

        // Act
        var result = day2.Part1(filename);

        // Assert
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void Part2_ReturnsExpected()
    {
        // Arrange
        var mockUtilities = Substitute.For<IFileUtilities>();
        var day2 = new Day2(mockUtilities);
        string filename = "input.txt";
        mockUtilities.ReadFile(filename).Returns(["7 6 4 2 1",
            "1 2 7 8 9",
            "9 7 6 2 1",
            "1 3 2 4 5",
            "8 6 4 4 1",
            "1 3 6 7 9"]);

        // Act
        var result = day2.Part2(filename);

        // Assert
        Assert.That(result, Is.EqualTo(4));
    }
}