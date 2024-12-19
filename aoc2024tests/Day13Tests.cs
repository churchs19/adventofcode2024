using Aoc2024;

using NSubstitute;

namespace Aoc2024Tests;

[TestFixture]
public class Day13Tests
{
    [Test]
    public void Part1_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IUtilities>();
        mockUtilities.ReadFileKeepBlankLines(filename).Returns(["Button A: X+94, Y+34",
"Button B: X+22, Y+67",
"Prize: X=8400, Y=5400",
"",
"Button A: X+26, Y+66",
"Button B: X+67, Y+21",
"Prize: X=12748, Y=12176",
"",
"Button A: X+17, Y+86",
"Button B: X+84, Y+37",
"Prize: X=7870, Y=6450",
"",
"Button A: X+69, Y+23",
"Button B: X+27, Y+71",
"Prize: X=18641, Y=10279"]);
        var day = new Day13(mockUtilities);

        // Act
        var result = day.Part1(filename);

        // Assert
        Assert.That(result, Is.EqualTo(480));
    }
}