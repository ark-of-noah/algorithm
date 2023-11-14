using System;

public class Solution
{
    public int[] solution(int[] sequence, int k)
    {
        int start = 0, end = 0, sum = 0;
        int[] answer = new int[2];
        int minLength = int.MaxValue;

        while (end < sequence.Length)
        {
            sum += sequence[end];

            while (sum >= k)
            {
                if (sum == k && end - start + 1 < minLength)
                {
                    minLength = end - start + 1;
                    answer[0] = start;
                    answer[1] = end;
                }
                sum -= sequence[start++];
            }
            end++;
        }

        return answer;
    }
}