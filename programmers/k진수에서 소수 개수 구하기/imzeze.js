function solution(n, k) {
  let convert = "";
  let rest = n;

  while (rest >= k) {
    const value = rest % k;
    convert = value + convert;
    rest = Math.floor(rest / k);
  }
  convert = rest + convert;

  let count = 0;
  const nums = convert.split("0");
  for (let i = 0; i < nums.length; i++) {
    const num = nums[i];
    count += checkPrime(num);
  }

  return count;
}

function checkPrime(num) {
  if (num < 2) return false;

  for (let i = 3; i * i <= num; i++) {
    if (num % i === 0) return false;
  }

  return true;
}
