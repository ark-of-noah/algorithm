using System;
using System.Linq;
public class Solution
{
    public int[] solution(int[] lottos, int[] win_nums)
    {
        int zeroCount = lottos.Count(num => num == 0);
        int matchCount = lottos.Count(lotto => win_nums.Contains(lotto) && lotto != 0);

        int maxRank = CalculateRank(matchCount + zeroCount);
        int minRank = CalculateRank(matchCount);

        return new int[] { maxRank, minRank };
    }

    private int CalculateRank(int matchCount)
    {
        switch (matchCount)
        {
            case 6: return 1;
            case 5: return 2;
            case 4: return 3;
            case 3: return 4;
            case 2: return 5;
            default: return 6;
        }
    }
}