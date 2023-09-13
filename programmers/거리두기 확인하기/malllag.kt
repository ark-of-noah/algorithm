import java.util.*

class Solution {
    fun solution(
        places: Array<Array<String>>
    ): IntArray {
        // P 사람
        // O 빈 테이블
        // X 파티션
        val result = mutableListOf(1, 1, 1, 1, 1)
        val dx = intArrayOf(1, -1, 0, 0)
        val dy = intArrayOf(0, 0, 1, -1)

        for (i in places.indices) {
            val grid = Array(5) { CharArray(5) }
            val visited = Array(5) { BooleanArray(5) }

            for (j in places[i].indices) {
                grid[j] = places[i][j].split("")
                    .filter { it.isNotEmpty() }
                    .map { it.single() }
                    .toCharArray()
            }

            for (k in 0..4) {
                for (p in 0..4) {
                    var count = 0

                    for (l in 0..3) {
                        val nx = k + dx[l]
                        val ny = p + dy[l]

                        if (nx < 0 || nx >= 5 || ny < 0 || ny >= 5) {
                            continue
                        }

                        if (grid[k][p] == 'O') {
                            if (grid[nx][ny] == 'P') {
                                count++
                                if (count >= 2) {
                                    result[i] = 0
                                    break
                                }
                            }
                        }

                        if (grid[k][p] == 'P' && grid[nx][ny] == 'P') {
                            result[i] = 0
                            break
                        }
                    }
                }
            }
        }

        return result.toIntArray()
    }
}