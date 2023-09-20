# problem: https://programmers.co.kr/learn/courses/30/lessons/60057

def solution(s):
    answer = len(s)

    for length in range(1, len(s) // 2 + 1):
        divided_str = s[:length]
        count, tmp_s = 1, ''

        for index in range(length, len(s), length):
            if divided_str == s[index: length + index]:
                count += 1
            else:
                if count == 1:
                    tmp_s += divided_str
                else:
                    tmp_s += str(count) + divided_str
                divided_str = s[index: length + index]
                count = 1

        if count == 1:
            tmp_s += divided_str
        else:
            tmp_s += str(count) + divided_str

        answer = min(answer, len(tmp_s))

    return answer


if __name__ == '__main__':
    inputs = [
        "aabbaccc",
        "ababcdcdababcdcd",
        "abcabcdede",
        "abcabcabcabcdededededede",
        "xababcdcdababcdcd"
    ]

    outputs = [
        7,
        9,
        8,
        14,
        17
    ]

    for input, output in zip(inputs, outputs):
        print(solution(input) == output)
