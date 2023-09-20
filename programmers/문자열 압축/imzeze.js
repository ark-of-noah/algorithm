function solution(s) {
  const slength = [];
  if (s.length === 1) return 1;

  for (let i = 1; i < s.length; i++) {
    slength.push(pressure(i, s));
  }

  return Math.min(...slength);
}

function pressure(range, s) {
  let result = "";

  let count = 0;
  for (let i = 0; i < s.length; i += range) {
    const target = s.substr(i, range);
    const next = s.substr(i + range, range);

    if (target === next) count++;
    else {
      result += (count ? ++count : "") + target;
      count = 0;
    }
  }

  return result.length;
}
