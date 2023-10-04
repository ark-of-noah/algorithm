var maxLevelSum = function (root) {
  let max = root.val;
  const sum = [root.val];

  var bfs = function (node, depth) {
    if (!node) return 0;
    if (!node.left && !node.right) return node.val;

    depth++;
    const left = bfs(node.left, depth);
    const right = bfs(node.right, depth);
    sum[depth - 1] = (sum[depth - 1] || 0) + left + right;

    return node.val;
  };

  bfs(root, 1);

  max = Math.max(max, ...sum);
  const answer = sum.findIndex((e) => e === max) + 1;

  return answer;
};
