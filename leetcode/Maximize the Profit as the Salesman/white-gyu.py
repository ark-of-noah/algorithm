# https://leetcode.com/problems/maximize-the-profit-as-the-salesman/
from collections import defaultdict
from typing import List


class Solution:
    def maximizeTheProfit(self, n: int, offers: List[List[int]]) -> int:
        dp = [0] * (n + 1)
        m = defaultdict(list)

        for start, end ,gold in offers:
            m[end].append([start, gold])

        for end in range(1, n + 1):
            dp[end] = dp[end - 1]

            for start, gold in m[end - 1]:
                dp[end] = max(dp[end], dp[start] + gold)

        return dp[-1]


if __name__ == '__main__':
    inputs = [
        (5, [[0, 0, 1], [0, 2, 2], [1, 3, 2]]),
        (5, [[0, 0, 1], [0, 2, 10], [1, 3, 2]]),
        (4, [[1, 3, 10], [1, 3, 3], [0, 0, 1], [0, 0, 7]]),
        (4, [[0, 0, 6], [1, 2, 8], [0, 3, 7], [2, 2, 5], [0, 1, 5], [2, 3, 2], [0, 2, 8], [2, 3, 10], [0, 3, 2]])
    ]
    outputs = [3, 10, 17, 16]

    for input, output in zip(inputs, outputs):
        print(Solution().maximizeTheProfit(*input) == output)
