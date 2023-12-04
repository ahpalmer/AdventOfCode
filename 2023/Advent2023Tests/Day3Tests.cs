using Advent2023Day3;
using System.Text.RegularExpressions;

namespace Advent2023Tests;

//I think this doesn't work because the objects that I'm comparing aren't literally the same objects.  Rusty fixed this in the coda code by adding an equality override method within each object's class definition.  There's no way I'm doing that for this.
[TestClass]
public class Day3Tests
{
    //Challenge1 challenge1 { get; set; }
    //public string input1 { get; set; }
    //public string input2 { get; set; }
    //public int Y1 { get; set; }
    //public int Y2 { get; set; }
    //Regex regexDigits = new Regex(@"\d+", RegexOptions.ECMAScript);


    //[TestInitialize]
    //public void Day3TestSetup()
    //{
    //    challenge1 = new Challenge1();
    //    input1 = "..975..95..................717..........................................747................................................622..............";
    //    input2 = "................/47...........@....701...610.........252.660*.............*..236.....323..........108........653............................";
    //    Y1 = 0;
    //    Y2 = 1;
    //}

    //[TestMethod]
    //public void FindAllSymbolsTest()
    //{
    //    Challenge1 challenge1 = new Challenge1();
    //    string input1 = "..975..95..................717..........................................747................................................622..............";
    //    string input2 = "................/47...........@....701...610.........252.660*.............*..236.....323..........108........653............................";
    //    int Y1 = 0;
    //    int Y2 = 1;
    //    List<Point> expectedAnswer1 = new List<Point>();
    //    List<Point> expectedAnswer2 = new List<Point>();
    //    Point ans21 = new Point(16, 1, true);
    //    Point ans22 = new Point(31, 1, true);
    //    Point ans23 = new Point(60, 1, true);
    //    Point ans24 = new Point(74, 1, true);
    //    expectedAnswer2.Add(ans21);
    //    expectedAnswer2.Add(ans22);
    //    expectedAnswer2.Add(ans23);
    //    expectedAnswer2.Add(ans24);

    //    Assert.AreEqual(expectedAnswer1, challenge1.FindAllSymbols(input1, Y1));
    //    Assert.AreEqual(expectedAnswer2, challenge1.FindAllSymbols(input2, Y2));
    //}

    //[TestMethod]
    //public void FindAllNumbersTest()
    //{
    //    Point point1 = new Point(2, 0, false);
    //    Point point2 = new Point(3, 0, false);
    //    Point point3 = new Point(4, 0, false);
    //    List<Point> pointList = new List<Point> { point1, point2, point3 };
    //    NumberPoint expectedNumberPoint = new NumberPoint(975, pointList, false);

    //    Assert.AreEqual(expectedNumberPoint, challenge1.FindAllNumbers(input1, Y1).First());
    //}
}
