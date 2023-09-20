//https://leetcode.com/problems/rotting-oranges
public class Solution 
{
    public int OrangesRotting(int[][] grid) 
    {
        int rowCount = grid.Length;
        int colCount = grid[0].Length;

        Queue<(int Row, int Col)> rottenQueue = new Queue<(int Row, int Col)>();
        int freshOrangeCount = 0;

        for (int i = 0; i < rowCount; i++) 
        {
            for (int j = 0; j < colCount; j++) 
            {
                if (grid[i][j] == 2) 
                {
                    rottenQueue.Enqueue((i, j));
                } 
                else if (grid[i][j] == 1) 
                {
                    freshOrangeCount++;
                }
            }
        }

        if (freshOrangeCount == 0) return 0;

        int minutes = 0;

        int[][] directions = new int[][] 
        { 
            new int[] { -1, 0 }, 
            new int[] { 1, 0 }, 
            new int[] { 0, -1 }, 
            new int[] { 0, 1 } 
        };

        while (rottenQueue.Count > 0) 
        {
            int currentQueueSize = rottenQueue.Count;
            bool hasRotten = false;

            for (int i = 0; i < currentQueueSize; i++) 
            {
                var (currentRow, currentCol) = rottenQueue.Dequeue();

                foreach (var direction in directions) 
                {
                    int newRow = currentRow + direction[0];
                    int newCol = currentCol + direction[1];

                    if (newRow >= 0 && newRow < rowCount && newCol >= 0 && newCol < colCount && grid[newRow][newCol] == 1) 
                    {
                        grid[newRow][newCol] = 2;
                        rottenQueue.Enqueue((newRow, newCol));
                        freshOrangeCount--;
                        hasRotten = true;
                    }
                }
            }

            if (hasRotten) 
            {
                minutes++;
            }
        }

        return freshOrangeCount == 0 ? minutes : -1;
    }
}
