public class Solution
{
    public long MinimumCost(string s)
    {
        return Enumerable.Range(1, s.Length - 1)
            .Where(i => s[i - 1] != s[i])
            .Select(i => (long)Math.Min(i, s.Length - i))
            .Sum();
    }
}