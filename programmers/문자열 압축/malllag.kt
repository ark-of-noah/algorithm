class Solution {
    fun solution(s: String): Int {
        var result = s.length

        for (i in 1..s.length / 2) {
            val chunked = s.chunked(i)
            var previous = s.substring(0, i)
            var count = 0
            var word = ""

            chunked.forEach { current ->
                if (previous == current) {
                    count++
                } else {
                    word += if (count == 1) {
                        previous
                    } else {
                        "$count$previous"
                    }

                    previous = current
                    count = 1
                }
            }

            word += if (count == 1) {
                previous
            } else {
                "$count$previous"
            }

            result = minOf(result, word.length)
        }

        return result
    }
}