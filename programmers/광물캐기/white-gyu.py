# https://school.programmers.co.kr/learn/courses/30/lessons/172927
from collections import deque

DIAMOND, IRON, STONE = 'diamond', 'iron', 'stone'
NAMES = [DIAMOND, IRON, STONE]

RESOURCES = {
    (DIAMOND, DIAMOND): 1,
    (DIAMOND, IRON): 1,
    (DIAMOND, STONE): 1,
    (IRON, DIAMOND): 5,
    (IRON, IRON): 1,
    (IRON, STONE): 1,
    (STONE, DIAMOND): 25,
    (STONE, IRON): 5,
    (STONE, STONE): 1
}

REST_PICKS = 'rest_picks'  # 남은 곡괭이 수
CURRENT_PICK = 'current_pick'  # 현재 곡괭이
CURRENT_PICK_REST = 'current_pick_rest'  # 현재 곡갱이 잔여 횟수
CURRENT_MINERAL = 'current_mineral'  # 현재 광물
CURRENT_ANSWER = 'current_answer'  # 현재까지 피로도


def solution(picks, minerals):
    answer = 25 * 50

    queue = deque()
    queue.append({
        REST_PICKS: picks,
        CURRENT_PICK: None,
        CURRENT_PICK_REST: 0,
        CURRENT_MINERAL: 0,
        CURRENT_ANSWER: 0
    })
    while queue:
        rest_picks, current_pick, current_pick_rest, current_mineral, current_answer = tuple(queue.popleft().values())

        if current_mineral >= len(minerals) or not (any(rest_picks) or current_pick_rest):
            answer = min(answer, current_answer)
            continue

        if current_answer >= answer:
            continue

        if current_pick_rest > 0:
            next_rest_picks = [rest for rest in rest_picks]
            queue.append({
                REST_PICKS: next_rest_picks,
                CURRENT_PICK: current_pick,
                CURRENT_PICK_REST: current_pick_rest - 1,
                CURRENT_MINERAL: current_mineral + 1,
                CURRENT_ANSWER: current_answer + RESOURCES[(NAMES[current_pick], minerals[current_mineral])]
            })

        else:
            for pick, rest in enumerate(rest_picks):
                if rest == 0:
                    continue

                next_rest_picks = [rest for rest in rest_picks]
                next_rest_picks[pick] -= 1
                queue.append({
                    REST_PICKS: next_rest_picks,
                    CURRENT_PICK: pick,
                    CURRENT_PICK_REST: 4,
                    CURRENT_MINERAL: current_mineral + 1,
                    CURRENT_ANSWER: current_answer + RESOURCES[(NAMES[pick], minerals[current_mineral])]
                })

    return answer


if __name__ == '__main__':
    inputs = [
        (
            [1, 3, 2],
            ["diamond", "diamond", "diamond", "iron", "iron", "diamond", "iron", "stone"]
        ),
        (
            [0, 1, 1],
            ["diamond", "diamond", "diamond", "diamond", "diamond", "iron", "iron", "iron", "iron", "iron", "diamond"]
        )
    ]

    outputs = [
        12,
        50
    ]

    for input, output in zip(inputs, outputs):
        print(solution(*input) == output)
