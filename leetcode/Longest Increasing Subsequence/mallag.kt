class Solution {
    fun lengthOfLIS(nums: IntArray): Int {
        val dp = IntArray(nums.size) { 1 }
        var max = 1

        for(i in 1 until nums.size) {
            for(j in 0 until i) {
                if(nums[i] > nums[j]) {
                    dp[i] = maxOf(dp[j] + 1, dp[i])
                }
            }

            max = maxOf(max, dp[i])
        }

        return max
    }
}