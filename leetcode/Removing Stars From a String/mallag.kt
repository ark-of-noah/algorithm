import java.util.*

class Solution {
    fun removeStars(s: String): String {
        var result = ""
        val stack = Stack<Char>()
        s.toCharArray()
            .forEach {
                when (it) {
                    '*' -> if (stack.isNotEmpty()) stack.pop()
                    else -> stack.push(it)
                }
            }

        return stack.joinToString("")
    }
}