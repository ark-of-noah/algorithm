//https://school.programmers.co.kr/learn/courses/30/lessons/150370
using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(string today, string[] terms, string[] privacies) {
        var termDictionary = new Dictionary<string, int>();
        var result = new List<int>();

        foreach (var term in terms) {
            var splitTerm = term.Split(' ');
            termDictionary[splitTerm[0]] = int.Parse(splitTerm[1]);
        }

        var todayDate = DateTime.ParseExact(today, "yyyy.MM.dd", null);

        for (int i = 0; i < privacies.Length; i++) {
            var splitPrivacy = privacies[i].Split(' ');
            var privacyDate = DateTime.ParseExact(splitPrivacy[0], "yyyy.MM.dd", null);
            var monthsToAdd = termDictionary[splitPrivacy[1]];
            var expiryDate = privacyDate.AddMonths(monthsToAdd);

            if (expiryDate <= todayDate) {
                result.Add(i + 1);
            }
        }

        return result.ToArray();
    }
}