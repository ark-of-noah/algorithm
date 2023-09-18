function solution(today, terms, privacies) {
  const answer = [];
  const periodOfTerms = {};

  for (let i = 0; i < terms.length; i++) {
    const [type, period] = terms[i].split(" ");
    periodOfTerms[type] = period * 28 - 1;
  }

  for (let i = 0; i < privacies.length; i++) {
    const [agreeDate, type] = privacies[i].split(" ");
    const [prevYear, prevMonth, prevDate] = agreeDate.split(".");
    const [todayYear, todayMonth, todayDate] = today.split(".");

    const todaytoNumber = todayYear * 28 * 12 + todayMonth * 28 + todayDate * 1;
    const expireDateToNumber =
      prevYear * 28 * 12 + prevMonth * 28 + prevDate * 1 + periodOfTerms[type];

    if (todaytoNumber > expireDateToNumber) answer.push(i + 1);
  }

  return answer;
}
