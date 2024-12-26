using Aoc2024.Utilities;
using Aoc2024.Days;

using NSubstitute;

namespace Aoc2024Tests;

[TestFixture]
public class Day23Tests
{
    [Test]
    public void Part1_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IFileUtilities>();
        mockUtilities.ReadFile(filename).Returns(["kh-tc",
"qp-kh",
"de-cg",
"ka-co",
"yn-aq",
"qp-ub",
"cg-tb",
"vc-aq",
"tb-ka",
"wh-tc",
"yn-cg",
"kh-ub",
"ta-co",
"de-co",
"tc-td",
"tb-wq",
"wh-td",
"ta-ka",
"td-qp",
"aq-cg",
"wq-ub",
"ub-vc",
"de-ta",
"wq-aq",
"wq-vc",
"wh-yn",
"ka-de",
"kh-ta",
"co-tc",
"wh-qp",
"tb-vc",
"td-yn"]);
        var day = new Day23(mockUtilities);

        // Act
        var result = day.Part1(filename);

        // Assert
        Assert.That(result, Is.EqualTo(7));
    }

    [Test]
    public void Part2_ReturnsExpected()
    {
        // Arrange
        string filename = "input.txt";
        var mockUtilities = Substitute.For<IFileUtilities>();
        mockUtilities.ReadFile(filename).Returns(["kh-tc",
"qp-kh",
"de-cg",
"ka-co",
"yn-aq",
"qp-ub",
"cg-tb",
"vc-aq",
"tb-ka",
"wh-tc",
"yn-cg",
"kh-ub",
"ta-co",
"de-co",
"tc-td",
"tb-wq",
"wh-td",
"ta-ka",
"td-qp",
"aq-cg",
"wq-ub",
"ub-vc",
"de-ta",
"wq-aq",
"wq-vc",
"wh-yn",
"ka-de",
"kh-ta",
"co-tc",
"wh-qp",
"tb-vc",
"td-yn"]);
        var day = new Day23(mockUtilities);

        // Act
        var result = day.Part2(filename);

        // Assert
        Assert.That(result, Is.EqualTo(-1));
    }
}