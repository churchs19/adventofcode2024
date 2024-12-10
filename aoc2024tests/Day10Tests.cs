using Aoc2024;

using NSubstitute;

namespace Aoc2024Tests;

[TestFixture]
public class Day10Tests
{
    [Test]
    public void Part1_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IUtilities>();
        mockUtilities.ReadFile(filename).Returns(["89010123",
"78121874",
"87430965",
"96549874",
"45678903",
"32019012",
"01329801",
"10456732"]);
        var day = new Day10(mockUtilities);

        // Act
        var result = day.Part1(filename);

        // Assert
        Assert.That(result, Is.EqualTo(36));
    }

    [Test]
    public void Part2_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IUtilities>();
        mockUtilities.ReadFile(filename).Returns(["89010123",
"78121874",
"87430965",
"96549874",
"45678903",
"32019012",
"01329801",
"10456732"]);
        var day = new Day10(mockUtilities);

        // Act
        var result = day.Part2(filename);

        // Assert
        Assert.That(result, Is.EqualTo(-1));
    }
}