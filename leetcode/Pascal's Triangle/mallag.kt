class Solution {
    fun generate(numRows: Int): List<List<Int>> {
        // dp[1] = [1]
        // dp[2] = [1], [1, 1]
        // dp[3] = [1], [1, 1], [1, 2, 1]
        // dp[4] = [1], [1, 1], [1, 2, 1], [1, 3, 3, 1]
        // dp[5] = [1], [1, 1], [1, 2, 1], [1, 3, 3, 1], [1, 4, 6, 4, 1]

        val dp = mutableListOf<List<Int>>()

        for (i in 1..numRows) {
            val list = mutableListOf<Int>()

            for (j in 1..i) {
                if (j == 1 || i == j) {
                    list.add(1)
                } else {
                    val sum = dp[i - 2][j - 2] + dp[i - 2][j - 1]
                    list.add(sum)
                }
            }

            dp.add(list)
        }

        return dp
    }
}
