var maxIncreaseKeepingSkyline = function (grid) {
  let answer = 0;

  for (let i = 0; i < grid.length; i++) {
    const maxRow = Math.max(...grid[i]);

    for (let j = 0; j < grid.length; j++) {
      const maxCeil = getMaxCeil(grid, 0, j, grid.length);
      answer += Math.min(maxRow, maxCeil) - grid[i][j];
    }
  }

  return answer;
};

const getMaxCeil = (grid, i, j, length) => {
  if (i >= length || i < 0) return 0;

  return Math.max(grid[i][j], getMaxCeil(grid, i + 1, j, length));
};

// 두번째 코드
var maxIncreaseKeepingSkyline = function (grid) {
  let result = 0;
  let n = grid.length;
  let rMax = new Array(grid.length).fill(0);
  let cMax = new Array(grid.length).fill(0);

  for (let i = 0; i < n; i++) {
    for (let j = 0; j < n; j++) {
      rMax[i] = Math.max(rMax[i], grid[i][j]);
      cMax[j] = Math.max(cMax[j], grid[i][j]);
    }
  }

  for (let i = 0; i < n; i++) {
    for (let j = 0; j < n; j++) {
      result += Math.min(rMax[i], cMax[j]) - grid[i][j];
    }
  }

  return result;
};
