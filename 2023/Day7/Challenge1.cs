using Advent2023Utility;
using System.Globalization;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Advent2023Day7;

class Challenge1
{
    Regex regex = new Regex(@"^(.{5})\s(\d{1,3})");

    public int Solve()
    {
        List<string> dataList = Utility.CreateStringList();
        List<(string, int)> cardsAndBets = CreateCardsAndBetsList(dataList);
        List<(string, int, int)> cardsAndBetsAnswer = CreateRankingList(cardsAndBets);
        var sorted = cardsAndBetsAnswer.OrderBy(x => x.Item3).ToList();
        var doubleSorted = SortHandsByFirstCard(sorted);

        var answer = sorted.Select((value, index) => new { value.Item2, index });

        return 0;
    }

    public List<(string, int, int)> SortHandsByFirstCard(List<(string, int, int)> sorted)
    {
        var sixList = sorted.Where(x => x.Item3 == 6).ToList();
        var fiveList = sorted.Where(x => x.Item3 == 5).ToList();
        var fourList = sorted.Where(x => x.Item3 == 4).ToList();
        var threeList = sorted.Where(x => x.Item3 == 3).ToList();
        var twoList = sorted.Where(x => x.Item3 == 2).ToList();
        var oneList = sorted.Where(x => x.Item3 == 1).ToList();
        var zeroList = sorted.Where(x => x.Item3 == 0).ToList();

        foreach (var item in sixList)
        {

        }
    }

    public List<(string, int, int)> BubbleSort(List<(string, int, int)> listToSort)
    {
        (string, int, int) temp;
        for (int i = 0; i < listToSort.Count - 2; i ++)
        {
            for (int j = 0; i < listToSort.Count - 2; j ++)
            {
                if (listToSort[i] > listToSort[i + 1])  
                temp = listToSort[j];

            }
        }
    }

    public bool CompareCards(string firstValue, string secondValue)
    {
        if (firstValue[0] == "J")
        {
            firstInt = 
        }
    }

    public List<(string, int, int)> CreateRankingList(List<(string, int)> cardsAndBets)
    {
        List<(string, int, int)> cardsAndBetsAnswer = new List<(string, int, int)>();
        foreach ((string, int) card in cardsAndBets)
        {
            bool dupes = AreThereDuplicates(card.Item1);
            if (!dupes)
            {
                cardsAndBetsAnswer.Add((card.Item1, card.Item2, 0));
                continue;
            }
            List<int> numberOfDupes = FindNumberOfDuplicates(card.Item1);
            numberOfDupes.Sort();
            numberOfDupes.Reverse();
            if (numberOfDupes.First() == 5)
            {
                cardsAndBetsAnswer.Add((card.Item1, card.Item2, 6));
            }
            else if (numberOfDupes.First() == 4)
            {
                cardsAndBetsAnswer.Add((card.Item1, card.Item2, 5));
            }
            else if (numberOfDupes.Count() == 2 && numberOfDupes[0] == 3)
            {
                cardsAndBetsAnswer.Add((card.Item1, card.Item2, 4));
            }
            else if (numberOfDupes.Count() == 1 && numberOfDupes.First() == 3)
            {
                cardsAndBetsAnswer.Add((card.Item1, card.Item2, 3));
            }
            else if (numberOfDupes.Count() == 2 && numberOfDupes.First() == 2)
            {
                cardsAndBetsAnswer.Add((card.Item1, card.Item2, 2));
            }
            else if (numberOfDupes.Count() == 1 && numberOfDupes.First() == 2)
            {
                cardsAndBetsAnswer.Add((card.Item1, card.Item2, 1));
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        return cardsAndBetsAnswer;
    }

    public List<int> FindNumberOfDuplicates(string input)
    {
        var answer = input.GroupBy(c => c)
            .Where(c => c.Count() > 1)
            .Select(g => g.Count())
            .ToList();

        return answer;
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

    //Method that parses the individual char into an int and if it fails, use a switch case to test letters

    //Need a method to test duplicates

    //Are there dupes
    public bool AreThereDuplicates(string input)
    {
        return input.GroupBy(c => c).Any(g => g.Count() > 1);
    }
    //Look at a method 
    public void FindDuplicates(string input)
    {
        var test = input.GroupBy(c => c)
            .Where(g => g.Count() > 1);

        foreach (var testThing in test)
        {
            var thing = testThing.Key;
            var countThing = testThing.Count();
        }

    }
}