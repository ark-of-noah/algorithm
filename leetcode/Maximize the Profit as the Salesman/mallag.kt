class Solution {
    fun maximizeTheProfit(
        n: Int,
        offers: List<List<Int>>
    ): Int {
        val dp = IntArray(n)
        var result = 0

        val sortedOffers =  offers.sortedBy { it[1] }

        for (i in offers.indices) {
            var start = sortedOffers[i][0]
            val end = sortedOffers[i][1]
            val gold = sortedOffers[i][2]

            if (start >= 1) {
                while (start >= 1 && dp[start - 1] == 0) {
                    start--
                }
            }

            if (start >= 1) {
                dp[end] = dp[start - 1] + gold
            } else {
                dp[end] = gold
            }

            if (dp[end] > result) {
                result = dp[end]
            } else{
                dp[end] = result
            }
        }

        return result
    }
}