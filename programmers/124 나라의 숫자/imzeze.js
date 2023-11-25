function solution(n) {
  var answer = "";

  let quo = n;
  while (quo > 0) {
    const rest = quo % 3;

    if (rest) {
      answer = rest + answer;
      quo = Math.floor(quo / 3);
    } else {
      answer = "4" + answer;
      quo = Math.floor(quo / 3) - 1;
    }
  }

  return answer;
}
