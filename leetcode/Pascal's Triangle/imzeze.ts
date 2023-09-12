var generate = function (numRows) {
  const rows = [[1]];
  if (numRows === 1) return rows;

  for (let i = 1; i < numRows; i++) {
    const row = [1];
    let prevRow = rows[i - 1];

    for (let j = 1; j < prevRow.length; j++) {
      row.push(prevRow[j - 1] + prevRow[j]);
    }

    row.push(1);
    rows.push(row);
  }

  return rows;
};
