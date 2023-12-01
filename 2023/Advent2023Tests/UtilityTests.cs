using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advent2023Utility;

namespace Advent2023Tests;

[TestClass]
public class UtilityTests
{
    [TestMethod]
    public void FileRetrieval()
    {
        Assert.AreEqual("hcpjss\r\n4three\r\n1lxk2h", Utility.RetrieveData("Test.txt"));
    }

    [TestMethod]
    public void StringArrayRetrieval()
    {
        List<string> strings = new List<string>();
        strings.Add("hcpjss");
        strings.Add("4three");
        strings.Add("1lxk2h");

        List<string> stringActual = Utility.CreateStringList("Test.txt");

        Assert.AreEqual(strings.First(), stringActual.First());
        Assert.AreEqual(strings.ToArray()[1], stringActual.ToArray()[1]);
        Assert.AreEqual(strings.ToArray()[2], stringActual.ToArray()[2]);
    }
}
