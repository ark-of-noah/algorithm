# https://school.programmers.co.kr/learn/courses/30/lessons/81302
from itertools import combinations

PERSON = 'P'
PARTITION = 'X'
SAFE_DISTANCE = 3


def solution(places):
    answer = [0] * len(places)

    for index, place in enumerate(places):
        persons = [(x_index, y_index) for y_index, y in enumerate(place) for x_index, type in enumerate(y) if type == PERSON]
        person_pairs_in_danger = [(a_person, b_person) for a_person, b_person in list(combinations(persons, 2)) if is_in_danger(a_person, b_person)]

        is_safe = 1

        for (a_person_x, a_person_y), (b_person_x, b_person_y) in person_pairs_in_danger:
            if a_person_x == b_person_x:
                is_safe *= place[b_person_y - 1][a_person_x] == PARTITION
            elif a_person_y == b_person_y:
                is_safe *= place[b_person_y][b_person_x - 1] == PARTITION
            else:
                is_safe *= place[b_person_y][a_person_x] == PARTITION and place[a_person_y][b_person_x] == PARTITION

        answer[index] = is_safe

    return answer


def is_in_danger(pair1, pair2):
    return calculate_distance(pair1, pair2) < SAFE_DISTANCE


def calculate_distance(pair1, pair2):
    return abs(pair1[0] - pair2[0]) + abs(pair1[1] - pair2[1])


if __name__ == '__main__':
    inputs = [
        [["POOOP", "OXXOX", "OPXPX", "OOXOX", "POXXP"],
         ["POOPX", "OXPXP", "PXXXO", "OXXXO", "OOOPP"],
         ["PXOPX", "OXOXP", "OXPOX", "OXXOP", "PXPOX"],
         ["OOOXX", "XOOOX", "OOOXX", "OXOOX", "OOOOO"],
         ["PXPXP", "XPXPX", "PXPXP", "XPXPX", "PXPXP"]]
    ]

    outputs = [
        [1, 0, 1, 1, 1]
    ]

    for input, output in zip(inputs, outputs):
        print(solution(input) == output)
