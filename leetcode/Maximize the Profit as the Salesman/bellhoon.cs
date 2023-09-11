using System;
using System.Collections.Generic;
using System.Linq;

// 평균금액으로 구하려고했는데, 평균금액으로 전체이익의 최대값이 보장이 안됨.
// 제안범위도 겹침.
// 아이디어가 안떠오름.
// 성현님 pr보고 알아버림.

//1. offers의 end 기준으로 정렬해야함
//2. 이전 제안들의 최대이익을 저장
//3. 현재 제안의 최대이익 계산.

public class Solution
{
    public int MaximizeTheProfit(int n, IList<IList<int>> offers)
    {
        List<Tuple<int, int>> profitList = new List<Tuple<int, int>>();
        profitList.Add(new Tuple<int, int>(-1, 0));

        var sortedOffers = offers.OrderBy(offer => offer[1]).ToList();

        foreach (var offer in sortedOffers)
        {
            int previousHouse = offer[0] - 1;
            int start = 0, end = profitList.Count - 1;
            int currentProfit = 0;

            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (profitList[mid].Item1 <= previousHouse)
                {
                    currentProfit = Math.Max(profitList[mid].Item2 + offer[2], currentProfit);
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            currentProfit = Math.Max(currentProfit, profitList.Last().Item2);
            profitList.Add(new Tuple<int, int>(offer[1], currentProfit));
        }

        return profitList.Last().Item2;
    }
}

#region 처음 아이디어 (오답)
public class Solution
{
    public int MaximizeTheProfit(int n, IList<IList<int>> offers)
    {
        bool[] sold = new bool[n];

        var sortedOffers = offers.OrderByDescending(offer => (double)offer[2] / (offer[1] - offer[0] + 1)).ToList();

        int totalProfit = 0;

        foreach (var offer in sortedOffers)
        {
            bool canSell = true;

            for (int i = offer[0]; i <= offer[1]; i++)
            {
                if (sold[i])
                {
                    canSell = false;
                    break;
                }
            }

            if (canSell)
            {
                for (int i = offer[0]; i <= offer[1]; i++)
                {
                    sold[i] = true;
                }
                totalProfit += offer[2];
            }
        }

        return totalProfit;
    }
}
#endregion