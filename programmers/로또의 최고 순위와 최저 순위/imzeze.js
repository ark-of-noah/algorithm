// 첫번째 풀이
function solution(lottos, win_nums) {
  const ranking = [6, 6, 5, 4, 3, 2, 1];

  let matchCount = 0;
  let missingCount = 0;
  for (let i = 0; i < 6; i++) {
    if (lottos[i] === 0) {
      missingCount++;
      continue;
    }

    for (let j = 0; j < 6; j++) {
      if (lottos[i] === win_nums[j]) {
        matchCount++;
        break;
      }
    }
  }

  return [ranking[matchCount + missingCount], ranking[matchCount]];
}
