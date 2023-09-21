import java.util.*

class Solution {
    fun orangesRotting(grid: Array<IntArray>): Int {
        var result = 0

        val dx = intArrayOf(1, -1, 0, 0)
        val dy = intArrayOf(0, 0, 1, -1)
        val queue: Queue<Pair<Int, Int>> = LinkedList()
        var fresh = 0

        for (i in grid.indices) {
            for (j in grid[0].indices) {
                if (grid[i][j] == 2) {
                    queue.offer(Pair(i, j))
                }
                if (grid[i][j] == 1) {
                    fresh++
                }
            }
        }

        while (queue.isNotEmpty() && fresh > 0) {
            for (i in 0 until queue.size) {
                val current = queue.poll()

                for (j in 0..3) {
                    val nx = current.first + dx[j]
                    val ny = current.second + dy[j]

                    if (nx < 0 || nx >= grid.size || ny < 0 || ny >= grid[0].size) {
                        continue
                    }

                    if (grid[nx][ny] == 0) {
                        continue
                    }

                    if (grid[current.first][current.second] == 2 && grid[nx][ny] == 1) {
                        grid[nx][ny] = 2
                        fresh--
                        queue.offer(Pair(nx, ny))
                    }
                }
            }

            result++
        }

        return if (fresh == 0) result else -1
    }
}