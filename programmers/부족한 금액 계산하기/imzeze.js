function solution(price, money, count) {
  const totalPrice = (price * count * (count + 1)) / 2;
  return totalPrice - money > 0 ? totalPrice - money : 0;
}
