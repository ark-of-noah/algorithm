// https://school.programmers.co.kr/learn/courses/30/lessons/161989

using System;

public class Solution {
    public int solution(int n, int m, int[] section) 
    {
        int count = 0;
        int idx = 0;
        
        while (idx < section.Length) 
        {
            int last = section[idx] + m - 1;
            count++;
            
            while (idx < section.Length && section[idx] <= last) 
            {
                idx++;
            }
        }
        
        return count;
    }
}