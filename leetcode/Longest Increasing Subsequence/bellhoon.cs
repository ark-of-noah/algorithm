using System;
using System.Collections.Generic;

public class Solution 
{
    public int LengthOfLIS(int[] nums) 
    {
        List<int> lis = new List<int>();
        foreach (int currentNumber in nums) 
        {
            int position = lis.BinarySearch(currentNumber);
            if (position < 0) 
            {
                position = ~position; 
            }
            if (position == lis.Count) 
            {
                lis.Add(currentNumber);
            } 
            else 
            {
                lis[position] = currentNumber;
            }
        }
        return lis.Count;
    }
}
