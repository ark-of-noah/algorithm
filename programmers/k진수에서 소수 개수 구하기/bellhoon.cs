using System;

class Solution
{
    public int Solution(int n, int k)
    {
        string converted = ConvertToBase(n, k);
        string[] parts = converted.Split('0');
        int count = 0;

        foreach (string part in parts)
        {
            if (IsPrime(part))
            {
                count++;
            }
        }

        return count;
    }

    private string ConvertToBase(int number, int baseNum)
    {
        string result = "";
        while (number > 0)
        {
            result = (number % baseNum).ToString() + result;
            number /= baseNum;
        }
        return result;
    }

    private bool IsPrime(string numberStr)
    {
        if (string.IsNullOrEmpty(numberStr))
        {
            return false;
        }
        int number = int.Parse(numberStr);
        if (number < 2)
        {
            return false;
        }
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}
