/**
 * Example:
 * var ti = TreeNode(5)
 * var v = ti.`val`
 * Definition for a binary tree node.
 * class TreeNode(var `val`: Int) {
 *     var left: TreeNode? = null
 *     var right: TreeNode? = null
 * }
 */
class Solution {
    fun maxLevelSum(root: TreeNode?): Int {
        var max = root?.`val` ?: 0
        var result = 1
        var level = 0

        val queue: Queue<TreeNode> = LinkedList()
        queue.offer(root)

        while (queue.isNotEmpty()) {
            level++
            var tempSum = 0

            repeat(queue.size) {
                val current = queue.poll()
                tempSum += current.`val`

                if (current.left != null) {
                    queue.offer(current.left)
                }

                if (current.right != null) {
                    queue.offer(current.right)
                }
            }

            if (max < tempSum) {
                result = level
                max = tempSum
            }
        }

        return result
    }
}