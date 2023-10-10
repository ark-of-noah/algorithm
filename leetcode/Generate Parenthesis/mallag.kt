class Solution {
    fun generateParenthesis(n: Int): List<String> {
        val result = mutableListOf<String>()
        dfs(n, "", 0, 0, result)
        return result
    }

    private fun dfs(
        n: Int,
        current: String,
        left: Int,
        right: Int,
        result: MutableList<String>
    ) {
        if (current.length == n * 2) {
            result.add(current)
            return
        }

        if (left < n) {
            dfs(n, "$current(", left + 1, right, result)
        }

        if (right < left) {
            dfs(n, "$current)", left, right + 1, result)
        }
    }
}