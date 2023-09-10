function solution(n, m, x, y, r, c, k) {
  const minLength = Math.abs(x - r) + Math.abs(y - c);
  if (k < minLength || (k - minLength) % 2 > 0) return "impossible";

  return dfs(n, m, x, y, r, c, k, "");
}

function dfs(n, m, x, y, r, c, k, answer) {
  if (k === 0) return answer;

  const directionX = [1, 0, 0, -1];
  const directionY = [0, -1, 1, 0];
  const direction = ["d", "l", "r", "u"];

  for (let i = 0; i < 4; i++) {
    const nextX = x + directionX[i];
    const nextY = y + directionY[i];
    const path = Math.abs(nextX - r) + Math.abs(nextY - c);

    if (nextX > 0 && nextY > 0 && nextX <= n && nextY <= m && path < k) {
      return dfs(n, m, nextX, nextY, r, c, k - 1, answer + direction[i]);
    }
  }
}
