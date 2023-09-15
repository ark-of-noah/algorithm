https://leetcode.com/problems/substrings-of-size-three-with-distinct-characters/
public int CountGoodSubstrings(string s) {
    int count = 0;
    for (int i = 0; i < s.Length - 2; i++) 
    {
        HashSet<char> set = new HashSet<char> { s[i], s[i+1], s[i+2] };
        if (set.Count == 3) 
        {
            count++;
        }
    }
    return count;
}