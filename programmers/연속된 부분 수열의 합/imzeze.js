function solution(sequence, k) {
  let answer = [];

  let minLength = sequence.length;
  let left = sequence.length - 1;
  let right = sequence.length - 1;
  let sum = 0;

  while (left >= 0) {
    if (sum <= k) {
      sum += sequence[left];
      left--;
    }

    if (sum > k) {
      sum -= sequence[right];
      right--;
    }

    if (sum === k && minLength >= right - left) {
      minLength = right - left;
      answer = [left + 1, right];
    }
  }

  return answer;
}
