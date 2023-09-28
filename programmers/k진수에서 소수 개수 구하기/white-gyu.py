# https://school.programmers.co.kr/learn/courses/30/lessons/92335

def solution(n, k):
    word = ""
    while n:
        word = str(n % k) + word
        n //= k

    word = word.split("0")

    count = 0
    for w in word:
        if len(w) == 0:
            continue

        if int(w) < 2:
            continue

        is_prime = True

        for i in range(2, int(int(w) ** 0.5) + 1):
            if int(w) % i == 0:
                is_prime = False
                break

        if is_prime:
            count += 1

    return count
