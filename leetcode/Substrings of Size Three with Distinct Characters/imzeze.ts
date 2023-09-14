var countGoodSubstrings = function (s) {
  let answer = 0;

  for (let i = 0; i < s.length - 2; i++) {
    const unique = {};
    const substring = s.substr(i, 3).split("");

    substring.forEach((char) => (unique[char] = (unique[char] || 0) + 1));
    if (Object.keys(unique).length === 3) answer++;
  }

  return answer;
};
