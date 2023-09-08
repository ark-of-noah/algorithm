# https://school.programmers.co.kr/learn/courses/30/lessons/150365
from collections import defaultdict


def solution(n, m, x, y, r, c, k):
    directions = defaultdict(int)
    distance = abs(x - r) + abs(y - c)

    if distance > k or (distance - k) % 2:
        return "impossible"

    necessary_x, necessary_y = x - r, y - c
    left_distance = k - distance

    if necessary_x > 0:
        directions['u'] += necessary_x
    else:
        directions['d'] -= necessary_x
    if necessary_y > 0:
        directions['l'] += necessary_y
    else:
        directions['r'] -= necessary_y

    directions['d'] += left_distance // 2
    directions['u'] += left_distance // 2

    answer = 'd' * min(n - x, directions['d'])
    if directions['d'] - n + x > 0:
        directions['l'] += directions['d'] - n + x
        directions['r'] += directions['d'] - n + x
        directions['u'] = n - r

    answer += 'l' * min(y - 1, directions['l'])
    if directions['l'] - y + 1 > 0:
        directions['l'] -= y - 1
        answer += 'rl' * directions['l'] + 'r' * (directions['r'] - directions['l'])
    else:
        answer += 'r' * directions['r']

    answer += 'u' * directions['u']

    return answer


if __name__ == '__main__':
    inputs = [
        (3, 4, 2, 3, 3, 1, 5),
        (2, 2, 1, 1, 2, 2, 2),
        (3, 3, 1, 2, 3, 3, 4)
    ]

    outputs = [
        "dllrl",
        "dr",
        "impossible"
    ]

    for input, output in zip(inputs, outputs):
        print(solution(*input) == output)
