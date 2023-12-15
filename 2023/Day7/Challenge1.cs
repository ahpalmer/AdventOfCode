using Advent2023Utility;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Advent2023Day7;

class Challenge1
{
    Regex regex = new Regex(@"^(.{5})\s(\d{1,3})");

    public int Solve()
    {
        List<string> dataList = Utility.CreateStringList();
        var cardsAndBets = CreateCardsAndBetsList(dataList);



        return 0;
    }

    public List<(string, int)> CreateCardsAndBetsList(List<string> stringInput)
    {
        List<(string, int)> cardsAndBet = new List<(string, int)>();

        foreach (string input in stringInput)
        {
            Match match = regex.Match(input);
            cardsAndBet.Add((match.Groups[1].Value.ToString(), Int32.Parse(match.Groups[2].Value)));
        }

        return cardsAndBet;
    }
}