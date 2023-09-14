function solution(places) {
  const answer = [];
  const room = [];
  const xd = [0, 0, -1, 1];
  const yd = [-1, 1, 0, 0];

  for (let i = 0; i < places.length; i++) {
    const row = [];
    for (let j = 0; j < 5; j++) {
      row.push(places[i][j].split(""));
    }
    room.push(row);
  }

  for (let i = 0; i < room.length; i++) {
    let result = 1;
    const field = room[i];
    for (let y = 0; y < 5; y++) {
      for (let x = 0; x < 5; x++) {
        const status = field[y][x];

        let isPerson = false;
        for (let k = 0; k < 4; k++) {
          const nx = x + xd[k];
          const ny = y + yd[k];

          if (nx >= 0 && nx < 5 && ny >= 0 && ny < 5) {
            if (status === "P" && field[ny][nx] === "P") {
              result = 0;
              break;
            }
            if (status === "O" && field[ny][nx] === "P") {
              if (isPerson === true) {
                result = 0;
                break;
              } else {
                isPerson = true;
              }
            }
          }
        }
      }
    }

    answer.push(result);
  }

  return answer;
}
