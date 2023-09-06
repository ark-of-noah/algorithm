class Solution {

    val words = listOf(
        listOf('R', 'T'),
        listOf('C', 'F'),
        listOf('J', 'M'),
        listOf('A', 'N')
    )

    val points = listOf(
        mutableListOf(0, 0),
        mutableListOf(0, 0),
        mutableListOf(0, 0),
        mutableListOf(0, 0)
    )

    fun solution(
        survey: Array<String>,
        choices: IntArray
    ): String {
        // 비동의 동의
        // N1 C1 M2 T3 A1
        // TCMA

        for (i in survey.indices) {
            val no = survey[i][0]
            val yes = survey[i][1]
            val choice = choices[i]
            calculatePoint(no, yes, choice)
        }

        println(points.joinToString(" "))

        var result = ""

        for (i in 0..3) {
            val first = points[i][0]
            val second = points[i][1]

            if (first >= second) {
                result += words[i][0]
            } else {
                result += words[i][1]
            }
        }

        return result
    }

    fun calculatePoint(
        no: Char,
        yes: Char,
        choice: Int
    ) {
        when (choice) {
            1 -> add(no, 3)
            2 -> add(no, 2)
            3 -> add(no, 1)
            4 -> add(no, 0)
            5 -> add(yes, 1)
            6 -> add(yes, 2)
            else -> add(yes, 3)
        }
    }

    fun add(
        word: Char,
        point: Int
    ) {
        for (i in 0..3) {
            for (j in 0..1) {
                if (words[i][j] == word) {
                    points[i][j] += point
                }
            }
        }
    }

}