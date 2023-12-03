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

    [TestMethod]
    public void TestMethodTestColorNumberChallenge2()
    {
        Challenge2 challenge2 = new Challenge2();
        Assert.AreEqual((5, 1, 1), challenge2.TestColorNumberChallenge2((1, 1, 1), "green", 5));
        Assert.AreEqual((1, 3, 1), challenge2.TestColorNumberChallenge2((1, 1, 1), "red", 3));
        Assert.AreEqual((1, 1, 4), challenge2.TestColorNumberChallenge2((1, 1, 1), "blue", 4));

    }

    [TestMethod]
    public void TestFindMatchesChallenge2()
    {
        Challenge2 challenge2 = new Challenge2();
        Regex regex = new Regex(@"\d+|green|blue|red", RegexOptions.ECMAScript);

        Assert.AreEqual((4, 14, 2), challenge2.FindMatchesChallenge2("Game 1: 1 green, 2 blue; 13 red, 2 blue, 3 green; 4 green, 14 red", regex));
        Assert.AreEqual((11, 12, 6), challenge2.FindMatchesChallenge2("Game 2: 2 blue, 11 green; 4 blue, 12 red, 4 green; 7 red, 1 blue, 9 green; 10 green, 12 red, 6 blue", regex));
    }

}
