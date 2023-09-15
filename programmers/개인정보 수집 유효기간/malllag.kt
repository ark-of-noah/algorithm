import java.time.LocalDate
import java.time.format.DateTimeFormatter

class Solution {
    fun solution(
        today: String,
        terms: Array<String>,
        privacies: Array<String>
    ): IntArray {
        val result = mutableListOf<Int>()
        val (todayYear, todayMonth, todayDay) = today.split(".").map { it.toInt() }
        val map = mutableMapOf<String, Long>()

        val todayDateTime = LocalDate.parse(today, DateTimeFormatter.ofPattern("yyyy.MM.dd"))

        for (term in terms) {
            val (a, b) = term.split(" ")
            map.put(a, b.toLong())
        }

        for (i in privacies.indices) {
            val (date, term) = privacies[i].split(" ")
            var dateTime = LocalDate.parse(date, DateTimeFormatter.ofPattern("yyyy.MM.dd"))

            if (!dateTime.plusMonths(map[term]!!).isAfter(todayDateTime)) {
                result.add(i + 1)
            }
        }

        return result.toIntArray()
    }
}