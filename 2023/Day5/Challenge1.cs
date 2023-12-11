using Advent2023Utility;
using System.Text.RegularExpressions;

namespace Advent2023Day5;

public class Challenge1
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

        List<long> answers = new List<long>();

        answers = NextIteration(seeds, seedToSoil);
        answers = NextIteration(answers, soilToFertilizer);
        answers = NextIteration(answers, fertilizerToWater);
        answers = NextIteration(answers, waterToLight);
        answers = NextIteration(answers, lightToTemperature);
        answers = NextIteration(answers, temperatureToHumidity);
        answers = NextIteration(answers, humidityToLocation);

        long answer = answers.Min();

        return answer;
    }

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

    public List<long> ExpandSeedsList(List<long> seeds)
    {
        var answer = new List<long>();

        for (int i = 0; i < (seeds.Count / 2); i = i + 2)
        {
            List<long> temp = LongRange(seeds[i], seeds[i + 1]).ToList();
            answer = answer.Concat(temp).Distinct().ToList();
        }

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
