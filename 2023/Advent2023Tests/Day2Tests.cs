using System.Text.RegularExpressions;
using Advent2023Day2;
using Moq;

namespace Advent2023Tests;

[TestClass]
public class Day2Tests
{
    [TestMethod]
    public void TestMethodTestColorNumber()
    {
        Challenge1 challenge1 = new Challenge1();
        Assert.AreEqual(true, challenge1.TestColorNumber(13, "green"));
        Assert.AreEqual(false, challenge1.TestColorNumber(15, "green"));
        Assert.AreEqual(true, challenge1.TestColorNumber(12, "red"));
        Assert.AreEqual(false, challenge1.TestColorNumber(15, "red"));
        Assert.AreEqual(true, challenge1.TestColorNumber(14, "blue"));
        Assert.AreEqual(false, challenge1.TestColorNumber(15, "blue"));
    }

    [TestMethod]
    public void TestFindMatches()
    {
        Regex regex = new Regex(@"\d+|green|blue|red", RegexOptions.ECMAScript);
        Challenge1 challenge1 = new Challenge1();

        Assert.AreEqual((1, false), challenge1.FindMatches("Game 1: 1 green, 2 blue; 13 red, 2 blue, 3 green; 4 green, 14 red", regex));
        Assert.AreEqual((2, true), challenge1.FindMatches("Game 2: 2 blue, 11 green; 4 blue, 12 red, 4 green; 7 red, 1 blue, 9 green; 10 green, 12 red, 6 blue", regex));
    }

}
