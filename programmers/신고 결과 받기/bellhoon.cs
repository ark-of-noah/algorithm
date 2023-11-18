using System;
using System.Collections.Generic;

public class Solution
{
    public int[] solution(string[] id_list, string[] report, int k)
    {
        Dictionary<string, HashSet<string>> reportInfo = new Dictionary<string, HashSet<string>>();
        Dictionary<string, int> reportCount = new Dictionary<string, int>();

        foreach (string id in id_list)
        {
            reportInfo[id] = new HashSet<string>();
            reportCount[id] = 0;
        }

        foreach (string rep in report)
        {
            string[] split = rep.Split(' ');
            string reporter = split[0];
            string reportee = split[1];

            if (!reportInfo[reporter].Contains(reportee))
            {
                reportInfo[reporter].Add(reportee);
                reportCount[reportee]++;
            }
        }

        HashSet<string> bannedUsers = new HashSet<string>();
        foreach (var pair in reportCount)
        {
            if (pair.Value >= k)
            {
                bannedUsers.Add(pair.Key);
            }
        }

        int[] answer = new int[id_list.Length];
        for (int i = 0; i < id_list.Length; i++)
        {
            foreach (var reportee in reportInfo[id_list[i]])
            {
                if (bannedUsers.Contains(reportee))
                {
                    answer[i]++;
                }
            }
        }

        return answer;
    }
}