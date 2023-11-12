public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        var result = new List<string>();

        Generate("", 0, 0);

        return result;

        void Generate(string current, int open, int close)
        {
            if (current.Length == 2 * n)
            {
                result.Add(current);
                return;
            }

            if (open < n)
                Generate(current + "(", open + 1, close);

            if (close < open)
                Generate(current + ")", open, close + 1);
        }
    }
}