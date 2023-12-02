var minFlips = function (target) {
  let count = 0;
  let current = false;

  for (let i = 0; i < target.length; i++) {
    if (target[i] != current) {
      current = !current;
      count++;
    }
  }

  return count;
};
