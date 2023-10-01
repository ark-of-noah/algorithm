var orangesRotting = function (grid) {
  const dx = [0, 0, -1, 1];
  const dy = [-1, 1, 0, 0];
  const rotten_location = [];
  let tobe_rotten = 0;
  let minute = 0;

  for (let i = 0; i < grid.length; i++) {
    for (let j = 0; j < grid[i].length; j++) {
      // 썩은 오렌지 위치 push
      if (grid[i][j] === 2) rotten_location.push([i, j]);
      // 신선한 오렌지 개수 count
      if (grid[i][j] === 1) tobe_rotten++;
    }
  }

  while (rotten_location.length && tobe_rotten > 0) {
    // 현재 썩은 오렌지의 개수 (동시다발적으로 오렌지를 썩게 함)
    const size = rotten_location.length;

    for (let i = 0; i < size; i++) {
      const location = rotten_location.shift();

      for (let k = 0; k < 4; k++) {
        const nx = dx[k] + location[1];
        const ny = dy[k] + location[0];

        if (nx >= 0 && nx < grid[0].length && ny >= 0 && ny < grid.length) {
          if (grid[ny][nx] === 2 || grid[ny][nx] === 0) continue;

          if (grid[ny][nx] === 1) {
            grid[ny][nx] = 2;
            // 1분 뒤 퍼지게 될 오렌지 위치 push
            rotten_location.push([ny, nx]);
            // 신선한 오렌지 개수 - 1
            tobe_rotten--;
          }
        }
      }
    }

    ++minute;
  }

  return tobe_rotten > 0 ? -1 : minute;
};
