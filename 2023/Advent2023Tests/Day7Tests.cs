using Advent2023Day7;

namespace Advent2023Tests;

[TestClass]
public class Day7Tests
{
    [TestMethod]
    public void CreateCardsAndBetsListTest()
    {
        // Arrange
        var challenge1 = new Challenge1();
        var stringInput = new List<string> { "abcde 123", "fghij 456", "klmno 789" };
        var expected = new List<(string, int)>
            {
                ("abcde", 123),
                ("fghij", 456),
                ("klmno", 789)
            };

        // Act
        var actual = challenge1.CreateCardsAndBetsList(stringInput);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}