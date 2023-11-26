// 첫번째 풀이
function solution1(storey) {
  let answer = 0;

  while (storey > 5) {
    let rest = storey % 10;
    const quo = Math.floor((storey % 100) / 10);

    if (rest > 5 || (rest === 5 && quo >= 5)) {
      storey += 10 - rest;
      answer += 10 - rest;
    } else {
      storey -= rest;
      answer += rest;
    }

    storey /= 10;
  }

  answer += storey;

  return answer;
}

// 두번째 풀이
function solution2(storey) {
  if (storey < 5) return storey;

  const rest = storey % 10;
  const quo = (storey - rest) / 10;

  return Math.min(rest + solution2(quo), 10 - rest + solution2(quo + 1));
}
