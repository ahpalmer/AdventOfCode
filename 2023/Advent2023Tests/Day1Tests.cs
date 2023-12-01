using Advent2023Day1;
using System.Text.RegularExpressions;

namespace Advent2023Tests;

[TestClass]
public class Day1Tests
{
    [TestMethod]
    public void FindMatchesTestChallenge1()
    {
        Challenge1 challenge1 = new Challenge1();
        Regex regex = new Regex(@"\d", RegexOptions.ECMAScript);

        Assert.AreEqual(42, challenge1.FindMatches("hcpjssql4kjhbcqzkvr2fivebpllzqbkhg", regex));
        Assert.AreEqual(41, challenge1.FindMatches("4threethreegctxg3dmbm1", regex));
    }

    [TestMethod]
    public void SolveChallenge1Tests()
    {
        Challenge1 chal1 = new Challenge1();
        chal1.Solve();
    }

    [TestMethod]
    public void FindMatchesTestChallenge2()
    {
        Challenge2 challenge2 = new Challenge2();
        Regex regex = new Regex(@"\d|one|two|three|four|five|six|seven|eight|nine", RegexOptions.ECMAScript);
        Regex regexBackwards = new Regex(@"\d|eno|owt|eerht|ruof|evif|xis|neves|thgie|enin", RegexOptions.ECMAScript);


        Assert.AreEqual("4", challenge2.FindMatch("hcpjssql4kjhbcqzkvr2fivebpllzqbkhg", regex, 0));
        Assert.AreEqual("1", challenge2.FindMatch(challenge2.ReverseText("4threethreegctxg3dmbm1"), regexBackwards, 1));
        Assert.AreEqual("6", challenge2.FindMatch("sixbfjblhsjr3", regex, 0));
        Assert.AreEqual("3", challenge2.FindMatch(challenge2.ReverseText("eighthree"), regexBackwards, 1));
    }

    [TestMethod]
    public void ReverseText()
    {
        Challenge2 challenge2 = new Challenge2();
        Assert.AreEqual("olleh", challenge2.ReverseText("hello"));
    }
}