var generateParenthesis = function (n) {
  const answer = [];

  generate("", 0, 0, n, answer);

  return answer;
};

var generate = function (str, left, right, n, answer) {
  if (left < right) return;

  if (left === n && right === n) {
    answer.push(str);
    return;
  }

  if (left < n) {
    generate(str + "(", left + 1, right, n, answer);
  }

  if (right < n) {
    generate(str + ")", left, right + 1, n, answer);
  }
};
