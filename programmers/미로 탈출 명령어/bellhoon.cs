//https://school.programmers.co.kr/learn/courses/30/lessons/150365
using System;
using System.Collections.Generic;

public class Solution {
    public string solution(int n, int m, int x, int y, int r, int c, int k) {
        int[] rowDirection = { 1, 0, 0, -1 }; 
        int[] columnDirection = { 0, -1, 1, 0 };
        char[] directionChars = { 'd', 'l', 'r', 'u' };

        int minDistanceToTarget = Math.Abs(x - r) + Math.Abs(y - c);
        if (minDistanceToTarget > k || (minDistanceToTarget % 2 != k % 2)) {
            return "impossible";
        }

        Queue<(int, int, string)> positionsQueue = new Queue<(int, int, string)>();
        bool[,,] hasVisited = new bool[n + 1, m + 1, k + 1];

        positionsQueue.Enqueue((x, y, ""));
        hasVisited[x, y, 0] = true;

        while (positionsQueue.Count > 0) {
            var (currentRow, currentColumn, currentPath) = positionsQueue.Dequeue();

            if (currentRow == r && currentColumn == c && currentPath.Length == k) {
                return currentPath;
            }

            for (int i = 0; i < 4; i++) {
                int nextRow = currentRow + rowDirection[i];
                int nextColumn = currentColumn + columnDirection[i];
                int nextPathLength = currentPath.Length + 1;

                if (nextRow >= 1 && nextRow <= n && nextColumn >= 1 && nextColumn <= m && nextPathLength <= k && !hasVisited[nextRow, nextColumn, nextPathLength]) {
                    hasVisited[nextRow, nextColumn, nextPathLength] = true;
                    positionsQueue.Enqueue((nextRow, nextColumn, currentPath + directionChars[i]));
                }
            }
        }

        return "impossible";
    }
}
