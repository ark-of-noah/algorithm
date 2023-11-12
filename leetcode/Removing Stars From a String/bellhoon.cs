public class Solution
{
    public string RemoveStars(string s)
    {
        Stack<char> stack = new();

        foreach (var c in s)
        {
            if (c == '*')
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }
            else
            {
                stack.Push(c);
            }
        }

        StringBuilder sb = new();
        while (stack.Count > 0)
        {
            sb.Insert(0, stack.Pop());
        }
        return sb.ToString();
    }
}