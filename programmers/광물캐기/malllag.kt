class Solution {
    var result = Integer.MAX_VALUE

    fun solution(
        picks: IntArray,
        minerals: Array<String>
    ): Int {
        val diamond = picks[0]
        val iron = picks[1]
        val stone = picks[2]

        if (diamond > 0) {
            dfs(0, "diamond", 0, minerals, diamond - 1, iron, stone)
        }

        if (iron > 0) {
            dfs(0, "iron", 0, minerals, diamond, iron - 1, stone)
        }

        if (stone > 0) {
            dfs(0, "stone", 0, minerals, diamond, iron, stone - 1)
        }

        return result
    }

    fun dfs(
        fatigue: Int,
        tool: String,
        index: Int,
        minerals: Array<String>,
        diamond: Int,
        iron: Int,
        stone: Int
    ) {
        var fatigue = fatigue

        if (index >= minerals.size) {
            result = minOf(result, fatigue)
            return
        }

        when (minerals[index]) {
            "diamond" -> {
                fatigue += when (tool) {
                    "diamond" -> 1
                    "iron" -> 5
                    else -> 25
                }
            }
            "iron" -> {
                fatigue += when (tool) {
                    "diamond" -> 1
                    "iron" -> 1
                    else -> 5
                }
            }
            else -> {
                fatigue += when (tool) {
                    "diamond" -> 1
                    "iron" -> 1
                    else -> 1
                }
            }
        }

        if ((index + 1) % 5 == 0) {
            if (diamond == 0 && iron == 0 && stone == 0) {
                result = minOf(result, fatigue)
                return
            }

            if (diamond > 0) {
                dfs(fatigue, "diamond", index + 1, minerals, diamond - 1, iron, stone)
            }

            if (iron > 0) {
                dfs(fatigue, "iron", index + 1, minerals, diamond, iron - 1, stone)
            }

            if (stone > 0) {
                dfs(fatigue, "stone", index + 1, minerals, diamond, iron, stone - 1)
            }
        } else {
            dfs(fatigue, tool, index + 1, minerals, diamond, iron, stone)
        }
    }
}