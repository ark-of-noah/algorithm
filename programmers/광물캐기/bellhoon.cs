// https://school.programmers.co.kr/learn/courses/30/lessons/172927
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int[] picks, string[] minerals) {
        var pickFatigue = new Dictionary<string, int[]>() 
        {
            { "diamond", new int[] { 1, 5, 25 } },
            { "iron", new int[] { 1, 1, 5 } },
            { "stone", new int[] { 1, 1, 1 } }
        };

        var fatigueList = new List<Tuple<int[], int>>();

        for (int i = 0; i < minerals.Length; i += 5) 
        {
            var fatigueValues = new int[3];

            for (int j = 0; j < 3; j++) 
            {
                for (int k = 0; k < 5 && i + k < minerals.Length; k++) 
                {
                    fatigueValues[j] += pickFatigue[minerals[i + k]][j];
                }
            }

            fatigueList.Add(new Tuple<int[], int>(fatigueValues, fatigueValues[2]));
        }
        
        int pickCount = picks.Sum();

        if (pickCount < fatigueList.Count) 
        {
            fatigueList = fatigueList.Take(pickCount).ToList();
        }
        
        fatigueList.Sort((a, b) => b.Item2.CompareTo(a.Item2));

        int totalFatigue = 0;
        foreach (var tuple in fatigueList) 
        {
            for (int j = 0; j < 3; j++) 
            {
                if (picks[j] > 0) 
                {
                    totalFatigue += tuple.Item1[j];
                    picks[j]--;
                    break;
                }
            }
        }

        return totalFatigue;
    }
}