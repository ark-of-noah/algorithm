# https://leetcode.com/problems/pascals-triangle/
from typing import List


class Solution:
    def generate(self, numRows: int) -> List[List[int]]:
        dp = [[0] * n for n in range(1, numRows + 1)]

        for i in range(numRows):
            dp[i][0], dp[i][-1] = 1, 1

        for i in range(2, numRows):
            for j in range(1, i):
                dp[i][j] = dp[i - 1][j - 1] + dp[i - 1][j]

        return dp


if __name__ == '__main__':
    inputs = [5, 1]
    outputs = [
        [[1], [1, 1], [1, 2, 1], [1, 3, 3, 1], [1, 4, 6, 4, 1]],
        [[1]]
    ]

    for input, output in zip(inputs, outputs):
        print(Solution().generate(input) == output)
