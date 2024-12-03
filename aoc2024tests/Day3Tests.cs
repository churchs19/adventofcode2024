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
        mockUtilities.ReadFile(filename).Returns(["xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))"]);
        var day3 = new Day3(mockUtilities);

        // Act
        var result = day3.Part1(filename);

        // Assert
        Assert.That(result, Is.EqualTo(161));
    }

    [Test]
    public void Part2_ReturnsExpected()
    {
        // Arrange
        var mockUtilities = Substitute.For<IUtilities>();
        var day3 = new Day3(mockUtilities);
        string filename = "input.txt";
        mockUtilities.ReadFile(filename).Returns(["xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"]);

        // Act
        var result = day3.Part2(filename);

        // Assert
        Assert.That(result, Is.EqualTo(48));
    }
}