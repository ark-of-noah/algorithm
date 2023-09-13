//https://leetcode.com/problems/pascals-triangle/submissions/
public class Solution {
    public IList<IList<int>> Generate(int numRows) {
      var pascalsTriangle = new List<IList<int>>();
        
        for (int i = 0; i < numRows; i++) {
            var currentRow = new List<int>();
            
            for (int j = 0; j <= i; j++) {
                if (j == 0 || j == i) {
                    currentRow.Add(1);
                } else {
                    int value = pascalsTriangle[i - 1][j - 1] + pascalsTriangle[i - 1][j];
                    currentRow.Add(value);
                }
            }
            
            pascalsTriangle.Add(currentRow);
        }

        return pascalsTriangle;
    }
}