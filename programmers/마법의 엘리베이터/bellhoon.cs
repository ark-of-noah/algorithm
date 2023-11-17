using System;

public class Solution
{
    public int solution(int storey)
    {
        int answer = 0;
        int carry = 0;

        while (storey > 0 || carry > 0)
        {
            int digit = (storey % 10) + carry;
            carry = 0;

            if (digit >= 6)
            {
                answer += 10 - digit;
                carry = 1;
            }
            else if (digit == 5 && ((storey / 10) % 10) >= 5)
            {
                answer += 5;
                carry = 1;
            }
            else
            {
                answer += digit;
            }

            storey /= 10;
        }

        return answer;
    }
}