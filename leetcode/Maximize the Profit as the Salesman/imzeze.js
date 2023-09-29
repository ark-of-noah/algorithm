const maximizeTheProfit = function (n, offers) {
  let result = 0;
  const dp = [];

  // end point를 기준으로 정렬
  // end point까지의 최대 이익을 구하기 위함
  offers.sort((a, b) => a[1] - b[1]);

  for (offer of offers) {
    let [start, end, profit] = offer;

    // start point의 이전 point가 0인 경우 start를 이전 point로 조정
    while (start > 0 && !dp[start - 1]) {
      start--;
    }

    // start point가 0인 경우 start point가 0인 다른 offer와 겹칠 수 있으므로 분기 처리 필요
    if (start > 0) {
      // start point 이전의 profit과 현재 offer의 profit을 더하게 됌
      dp[end] = (dp[start - 1] || 0) + profit;
    } else {
      dp[end] = profit;
    }

    // offer의 end point가 항상 최대값을 갖게 됌 (누적)
    if (dp[end] < result) {
      dp[end] = result;
    } else {
      result = dp[end];
    }
  }

  return result;
};
