// 첫번째 풀이
function solution(id_list, report, k) {
  var answer = [];

  const uniqueReport = [...new Set(report)];

  const accReport = uniqueReport.reduce((prev, curr) => {
    const reported = curr.split(" ")[1];

    prev[reported] = (prev[reported] || 0) + 1;

    return prev;
  }, {});

  const reporterState = uniqueReport.reduce((prev, curr) => {
    const [reporter, reported] = curr.split(" ");

    prev[reporter] = [...(prev[reporter] || []), reported];

    return prev;
  }, {});

  for (let i = 0; i < id_list.length; i++) {
    const history = reporterState[id_list[i]];

    let count = 0;
    if (history) {
      for (let j = 0; j < history.length; j++) {
        if (accReport[history[j]] >= k) count++;
      }
    }

    answer.push(count);
  }

  return answer;
}

// 두번째 풀이
function solution(id_list, report, k) {
  const uniqueReport = [...new Set(report)].map((a) => {
    return a.split(" ");
  });

  let badCount = {};
  for (const bad of uniqueReport) {
    badCount[bad[1]] = (badCount[bad[1]] || 0) + 1;
  }

  let acceptCount = {};
  for (const report of uniqueReport) {
    if (badCount[report[1]] >= k) {
      acceptCount[report[0]] = (acceptCount[report[0]] || 0) + 1;
    }
  }

  const answer = id_list.map((user) => acceptCount[user] || 0);

  return answer;
}
