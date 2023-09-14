class Solution {
    fun countGoodSubstrings(s: String): Int {
        var lt = 0
        var rt = 2
        val words = mutableListOf<String>()

        while (rt < s.length) {
            val word = s.substring(lt..rt)

            if (isGoodWord(word)) {
                words.add(word)
            }

            lt++
            rt++
        }

        return words.size
    }

    private fun isGoodWord(word: String): Boolean {
        val first = word[0]
        val second = word[1]
        val third = word[2]

        return first != second && second != third && third != first
    }
}