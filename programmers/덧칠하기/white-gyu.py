# https://school.programmers.co.kr/learn/courses/30/lessons/161989

def solution(n, m, section):
    paint = section[0]

    return sum(1 for i in range(1, len(section)) if section[i] - paint >= m and (paint := section[i])) + 1