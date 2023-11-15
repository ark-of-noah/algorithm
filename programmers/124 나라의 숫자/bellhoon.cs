using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Solution.solution(1));
        Console.WriteLine(Solution.solution(2));
        Console.WriteLine(Solution.solution(3));
        Console.WriteLine(Solution.solution(4));
    }
}
class Solution
{
    public static string solution(int n)
    {
        string answer = "";
        while (n > 0)
        {
            int remainder = n % 3;
            n /= 3;

            if (remainder == 0)
            {
                remainder = 4;
                n -= 1;
            }

            answer = remainder + answer;
        }

        return answer;
    }
}