function solution(survey, choices) {
  let answer = "";
  const NOTHING = 4;
  const types = ["R", "T", "C", "F", "J", "M", "A", "N"];
  const characters = {};

  for (let i = 0; i < survey.length; i++) {
    const character = survey[i];
    const score = Math.abs(choices[i] - NOTHING);
    const type =
      choices[i] > NOTHING ? character.slice(1) : character.slice(0, 1);
    characters[type] = (characters[type] || 0) + score;
  }

  for (let i = 0; i < types.length; i = i + 2) {
    const result =
      (characters[types[i]] || 0) < (characters[types[i + 1]] || 0)
        ? types[i + 1]
        : types[i];
    answer += result;
  }

  return answer;
}
