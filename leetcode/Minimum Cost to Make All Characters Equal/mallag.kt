class Solution {
    fun minimumCost(s: String): Long {
        var result = 0L
        for (i in 1 until s.length) {
            if (s[i] != s[i - 1]) {
                result += minOf(i, s.length - i)
            }
        }
        return result
    }
}