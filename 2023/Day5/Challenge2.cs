using Advent2023Utility;
using System.Text.RegularExpressions;

namespace Advent2023Day5;

//Brute-forced the problem.  Not elegant, took like 25 minutes, but it worked.
public class Challenge2
{
    Regex firstLineRegex = new Regex(@"(\d+)");
    public long Solve()
    {
        List<string> dataList = Utility.CreateStringList();
        List<long> seeds = FindNumbersCertainLines(dataList, 0, 0, firstLineRegex);
        List<(long, long, long)> seedToSoil = FindMaps(dataList, 4, 18, firstLineRegex);
        List<(long, long, long)> soilToFertilizer = FindMaps(dataList, 21, 33, firstLineRegex);
        List<(long, long, long)> fertilizerToWater = FindMaps(dataList, 36, 66, firstLineRegex);
        List<(long, long, long)> waterToLight = FindMaps(dataList, 69, 90, firstLineRegex);
        List<(long, long, long)> lightToTemperature = FindMaps(dataList, 93, 125, firstLineRegex);
        List<(long, long, long)> temperatureToHumidity = FindMaps(dataList, 128, 171, firstLineRegex);
        List<(long, long, long)> humidityToLocation = FindMaps(dataList, 174, 193, firstLineRegex);

        List<long> tempAnswers = new List<long>();
        List<long> answers = new List<long>();

        for (int i = 0; i < (seeds.Count / 2); i = i + 2)
        {
            List<long> tempExpandedSeeds = ExpandSeedsList(seeds[i], seeds[i + 1]);
            tempAnswers = NextIteration(tempExpandedSeeds, seedToSoil);
            var tempAnswers2 = NextIteration(tempAnswers, soilToFertilizer);
            var tempAnswers3 = NextIteration(tempAnswers2, fertilizerToWater);
            var tempAnswers4 = NextIteration(tempAnswers3, waterToLight);
            var tempAnswers5 = NextIteration(tempAnswers4, lightToTemperature);
            var tempAnswers6 = NextIteration(tempAnswers5, temperatureToHumidity);
            var tempAnswers7 = NextIteration(tempAnswers6, humidityToLocation);

            long answer = tempAnswers7.Min();
            answers.Add(answer);
        }

        return answers.Min();
    }

    //List is too big.  It's getting too large and h
    public List<long> NextIteration(List<long> latestAnswer, List<(long, long, long)> nextIterationList)
    {
        List<long> answer = new List<long>();
        foreach (var seed in latestAnswer)
        {
            bool check = false;
            foreach ((long, long, long) item in nextIterationList)
            {
                if (item.Item2 <= seed && seed <= (item.Item2 + item.Item3))
                {
                    answer.Add(seed + (item.Item1 - item.Item2));
                    check = true;
                    break;
                }
            }

            if (!check)
            {
                answer.Add(seed);
            }
        }

        return answer;
    }

    public List<long> ExpandSeedsList(long start, long count)
    {
        var answer = LongRange(start, count).ToList();

        return answer;
    }

    //This didn't work.  The size of the list exceeded the maximum list or data storage size of c# lists.
    public List<long> ExpandSeedsListFAIL(List<long> seeds)
    {
        var answer = new List<long>();

        for (int i = 0; i < (seeds.Count / 2); i = i + 2)
        {
            List<long> temp = LongRange(seeds[i], seeds[i + 1]).ToList();
            answer = answer.Concat(temp).Distinct().ToList();
        }

        return answer;
    }

    public static IEnumerable<long> LongRange(long start, long count)
    {
        for (long i = 0; i < count; i++)
        {
            yield return start + i;
        }
    }

    public List<(long, long, long)> FindMaps(List<string> dataList, int firstLine, int lastLine, Regex regex)
    {
        List<(long, long, long)> mapList = new List<(long, long, long)> ();

        for (int i = firstLine - 1; i < lastLine; i++)
        {
            MatchCollection matches = regex.Matches(dataList[i]);
            (long, long, long) dataForOneLine = (Int64.Parse(matches[0].Value.ToString()), Int64.Parse(matches[1].Value.ToString()), Int64.Parse(matches[2].Value.ToString()));

            mapList.Add(dataForOneLine);
        }

        return mapList;
    }

    public List<long> FindNumbersCertainLines(List<string> dataList, int firstLine, int lastLine, Regex regex)
    {
        List<long> answerList = new List<long>();

        for (int i = firstLine; i <= lastLine; i ++)
        {
            MatchCollection matches = regex.Matches(dataList[i]);
            foreach(Match match in matches)
            {
                if (Int64.TryParse(match.ValueSpan.ToString(), out var actualNumber))
                {
                    answerList.Add(actualNumber);
                }
            }
        }

        return answerList;
    }

}
