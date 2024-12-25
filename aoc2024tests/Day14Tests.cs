using Aoc2024;

using NSubstitute;

namespace Aoc2024Tests;

[TestFixture]
public class Day14Tests
{
    [Test]
    public void Part1_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IFileUtilities>();
        mockUtilities.ReadFile(filename).Returns(["p=0,4 v=3,-3",
"p=0,0 v=1,3",
"p=3,0 v=-2,-2",
"p=7,6 v=-1,-3",
"p=3,0 v=-1,-2",
"p=9,3 v=2,3",
"p=7,3 v=-1,2",
"p=2,4 v=2,-3",
"p=9,5 v=-3,-3"]);
        var day = new Day14(mockUtilities);

        // Act
        var result = day.Part1(filename);

        // Assert
        Assert.That(result, Is.EqualTo(12));
    }

    [Test]
    public void Part2_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IFileUtilities>();
        mockUtilities.ReadFile(filename).Returns(["p=0,4 v=3,-3",
"p=0,0 v=1,3",
"p=3,0 v=-2,-2",
"p=7,6 v=-1,-3",
"p=3,0 v=-1,-2",
"p=9,3 v=2,3",
"p=7,3 v=-1,2",
"p=2,4 v=2,-3",
"p=9,5 v=-3,-3"]);
        var day = new Day14(mockUtilities);

        // Act
        var result = day.Part2(filename);

        // Assert
        Assert.That(result, Is.EqualTo(-1));
    }
}