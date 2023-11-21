public class Solution
{
    public int MinFlips(string target)
    {
        int flips = 0;
        char prev = '0';

        for (int i = 0; i < target.Length; i++)
        {
            if (target[i] != prev)
            {
                flips++;
                prev = target[i];
            }
        }

        return flips;
    }
}