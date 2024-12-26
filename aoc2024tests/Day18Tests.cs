using Aoc2024.Utilities;
using Aoc2024.Days;

using NSubstitute;

namespace Aoc2024Tests;

[TestFixture]
public class Day18Tests
{
    [Test]
    public void Part1_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IFileUtilities>();
        mockUtilities.ReadFile(filename).Returns(["5,4",
"4,2",
"4,5",
"3,0",
"2,1",
"6,3",
"2,4",
"1,5",
"0,6",
"3,3",
"2,6",
"5,1",
"1,2",
"5,5",
"2,5",
"6,5",
"1,4",
"0,4",
"6,4",
"1,1",
"6,1",
"1,0",
"0,5",
"1,6",
"2,0"]);
        var day = new Day18(mockUtilities);

        // Act
        var result = day.Part1(filename);

        // Assert
        Assert.That(result, Is.EqualTo(22));
    }

    [Test]
    public void Part2_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IFileUtilities>();
        mockUtilities.ReadFile(filename).Returns(["5,4",
"4,2",
"4,5",
"3,0",
"2,1",
"6,3",
"2,4",
"1,5",
"0,6",
"3,3",
"2,6",
"5,1",
"1,2",
"5,5",
"2,5",
"6,5",
"1,4",
"0,4",
"6,4",
"1,1",
"6,1",
"1,0",
"0,5",
"1,6",
"2,0"]);
        var day = new Day18(mockUtilities);

        // Act
        var result = day.Part2(filename);

        // Assert
        Assert.That(result, Is.EqualTo(-1));
    }
}