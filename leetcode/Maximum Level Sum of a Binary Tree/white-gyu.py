import collections
from cmath import inf


class Solution:
    def maxLevelSum(self, root) -> int:
        max, level, max_level = float(-inf), 0, 0

        deque = collections.deque()
        deque.append(root)
        while deque:
            level += 1

            sum = 0
            for _ in range(len(deque)):
                node = deque.popleft()
                sum += node.val

                if node.left:
                    deque.append(node.left)
                if node.right:
                    deque.append(node.right)

            if max < sum:
                max, max_level = sum, level

        return max_level