var uniquePathsIII = function (grid) {
  let answer = 0;

  const rowLength = grid.length;
  const ceilLength = grid[0].length;
  const startPoint = [];
  const endPoint = [];
  let emptySpace = 0;

  for (let i = 0; i < rowLength; i++) {
    for (let j = 0; j < ceilLength; j++) {
      const status = grid[i][j];
      if (status === 0) emptySpace = emptySpace + 1;
      else if (status === 1) startPoint.push(i, j);
      else if (status === 2) endPoint.push(i, j);
    }
  }

  const dfs = (x, y, remainSpace) => {
    if (
      x < 0 ||
      x >= rowLength ||
      y < 0 ||
      y >= ceilLength ||
      grid[x][y] === -1
    )
      return;
    if (x === endPoint[0] && y === endPoint[1] && remainSpace === 0) {
      answer = answer + 1;
      return;
    }

    const xDirection = [0, 0, 1, -1];
    const yDirection = [1, -1, 0, 0];

    let temp = grid[x][y];
    grid[x][y] = -1;
    remainSpace = remainSpace - 1;

    for (let i = 0; i < 4; i++) {
      dfs(x + xDirection[i], y + yDirection[i], remainSpace);
    }

    grid[x][y] = temp;
    remainSpace = remainSpace + 1;

    return;
  };

  dfs(startPoint[0], startPoint[1], emptySpace + 1);

  return answer;
};
