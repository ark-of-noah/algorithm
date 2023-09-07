using System;
using System.Collections.Generic;

public class Solution {
  public string solution(string[] survey, int[] choices)
  {
    var answer = "";
    int[] score = { 3, 2, 1, 0, 1, 2, 3 };
    var personality = new Dictionary<char, int>()
      {
        {'R', 0},{'T', 0},
        {'C', 0},{'F', 0},
        {'J', 0},{'M', 0},
        {'A', 0},{'N', 0},
    };

    for (int i = 0; i < survey.Length; i++)
    {
        var first = survey[i][0];
        var second = survey[i][1];
        var selectedScore = score[choices[i] - 1];

        if (choices[i] <= 3)
            personality[first] += selectedScore;
        else if (choices[i] > 4)
            personality[second] += selectedScore;
    }

    answer += CaculatePersonality(personality, 'R', 'T');
    answer += CaculatePersonality(personality, 'C', 'F');
    answer += CaculatePersonality(personality, 'J', 'M');
    answer += CaculatePersonality(personality, 'A', 'N');

    return answer;
  }

  public char CaculatePersonality(Dictionary<char, int> personality, char firstType, char secondType)
  {
      if (personality[firstType] > personality[secondType])
          return firstType;
      else if(personality[firstType] < personality[secondType])
          return secondType;
      else
          return firstType;
  }
}