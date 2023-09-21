# https://leetcode.com/problems/rotting-oranges/?envType=study-plan-v2&envId=leetcode-75
from typing import List


class Solution:
    def orangesRotting(self, grid: List[List[int]]) -> int:
        minutes, directions = 0, [[0, 1], [1, 0], [-1, 0], [0, -1]]

        fresh = {(x, y) for x in range(len(grid)) for y in range(len(grid[0])) if grid[x][y] == 1}
        rotten = {(x, y) for x in range(len(grid)) for y in range(len(grid[0])) if grid[x][y] == 2}

        while fresh:
            infected = set()

            for x, y in rotten:
                for direction in directions:
                    next_x, next_y = x + direction[0], y + direction[1]

                    if (next_x, next_y) in fresh:
                        fresh.remove((next_x, next_y))
                        infected.add((next_x, next_y))

            if not infected:
                return -1

            rotten = infected
            minutes += 1

        return minutes
