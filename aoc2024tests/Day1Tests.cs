using Aoc2024;

using NSubstitute;

namespace Aoc2024Tests;

[TestFixture]
public class Day1Tests
{
    [Test]
    public void Part1_ReturnsExpected()
    {
        // Arrange
        string filename = "1/input.txt";
        var mockUtilities = Substitute.For<IFileUtilities>();
        mockUtilities.ReadFile(filename).Returns(["3   4",
            "4   3",
            "2   5",
            "1   3",
            "3   9",
            "3   3"]);
        var day1 = new Day1(mockUtilities);

        // Act
        var result = day1.Part1(filename);

        // Assert
        Assert.That(result, Is.EqualTo(11));
    }

    [Test]
    public void Part2_ReturnsExpected()
    {
        // Arrange
        var mockUtilities = Substitute.For<IFileUtilities>();
        var day1 = new Day1(mockUtilities);
        string filename = "input-test2.txt";
        mockUtilities.ReadFile(filename).Returns(["3   4",
            "4   3",
            "2   5",
            "1   3",
            "3   9",
            "3   3"]);

        // Act
        var result = day1.Part2(filename);

        // Assert
        Assert.That(result, Is.EqualTo(31));
    }
}