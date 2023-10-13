var removeStars = function (s) {
  const arr = s.split("");
  const answer = [];

  for (let i = 0; i < arr.length; i++) {
    const left = arr[i];

    if (left !== "*") {
      answer.push(left);
    } else {
      answer.pop();
    }
  }

  return answer.join("");
};
