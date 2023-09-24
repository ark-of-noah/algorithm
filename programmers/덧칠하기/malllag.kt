class Solution {
    fun solution(
        n: Int,
        m: Int,
        section: IntArray
    ): Int {
        var result = 0
        var temp = 0
        for (i in section.indices) {
            val current = section[i]
            if (current > temp) {
                result++
                temp = current + m - 1
            }
        }

        return result
    }
}