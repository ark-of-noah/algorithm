import kotlin.math.sqrt

class Solution {
    fun solution(
        n: Int,
        k: Int
    ): Int {
        var answer = 0
        var num = 0L

        val convert = convert(n, k)

        for (c in convert) {
            if (c == '0') {
                if (isPrime(num)) {
                    answer++
                }
                num = 0
            } else {
                num = num * 10 + Character.getNumericValue(c)
            }
        }

        if (isPrime(num)) {
            answer++
        }

        return answer
    }

    private fun isPrime(
        num: Long
    ): Boolean {
        if (num <= 1) {
            return false
        }

        for (i in 2 ..sqrt(num.toDouble()).toInt()) {
            if (num % i == 0L) {
                return false
            }
        }

        return true
    }

    private fun convert(
        n: Int,
        k: Int
    ): String {
        val stringBuilder = StringBuilder()
        var num = n

        while (num != 0) {
            stringBuilder.append(num % k)
            num /= k
        }
        return stringBuilder.reverse().toString()
    }
}