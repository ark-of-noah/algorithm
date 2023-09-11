import kotlin.math.*

val dx = intArrayOf(1, 0, 0, -1)
val dy = intArrayOf(0, -1, 1, 0)
val paths = arrayOf("d", "l", "r", "u")
var grid = arrayOf<IntArray>()
var result = ""

class Solution {
    fun solution(
        n: Int,
        m: Int,
        x: Int,
        y: Int,
        r: Int,
        c: Int,
        k: Int
    ): String {
        grid = Array(n) { IntArray(m) {0} }

        grid[x - 1][y - 1] = 1
        grid[r - 1][c - 1] = 2

        val distance = abs(r - x) + abs(c - y)

        if (distance > k || distance % 2 != k % 2) {
            return "impossible"
        }

        dfs(0, k, "", x - 1, y - 1, r, c)

        return if (result.isNotEmpty()) {
            result
        } else {
            "impossible"
        }
    }

    fun dfs(
        index: Int,
        k: Int,
        path: String,
        currentX: Int,
        currentY: Int,
        r: Int,
        c: Int
    ) {
        if (result.isNotEmpty()) {
            return
        }

        if (index > k) {
            return
        }

        if (index == k) {
            if (grid[currentX][currentY] == 2) {
                result += path
            }
            return
        }

        for (i in 0..3) {
            val nx = currentX + dx[i]
            val ny = currentY + dy[i]

            if (nx < 0 || nx >= grid.size || ny < 0 || ny >= grid[0].size) {
                continue
            }

            val distance = abs(r - 1 - nx) + abs(c - 1 - ny)

            if (distance > k - index) {
                continue
            }

            dfs(index + 1, k, path + paths[i], nx, ny, r, c)
        }
    }
}