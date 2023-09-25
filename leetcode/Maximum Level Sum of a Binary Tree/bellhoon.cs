// https://leetcode.com/problems/maximum-level-sum-of-a-binary-tree
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution 
{
    public int MaxLevelSum(TreeNode root) 
    {
        var valuesByLevel = new List<List<int>>();
        DFS(root, 0, valuesByLevel);

        int maxSum = int.MinValue;
        int maxLevel = 0;  

        for (int level = 0; level < valuesByLevel.Count; level++) 
        {
            int currentLevelSum = valuesByLevel[level].Sum();
            if (currentLevelSum > maxSum) 
            {
                maxSum = currentLevelSum;
                maxLevel = level + 1;  
            }
        }

        return maxLevel;
    }

    private void DFS(TreeNode node, int level, List<List<int>> valuesByLevel) 
    {
        if (node == null) return;

        while (valuesByLevel.Count <= level) 
        {
            valuesByLevel.Add(new List<int>());
        }

        valuesByLevel[level].Add(node.val);

        DFS(node.left, level + 1, valuesByLevel);
        DFS(node.right, level + 1, valuesByLevel);
    }
}