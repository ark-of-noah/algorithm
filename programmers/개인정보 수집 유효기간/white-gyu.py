# https://school.programmers.co.kr/learn/courses/30/lessons/150370

def solution(today, terms, privacies):
    terms = {term.split(" ")[0]: int(term.split(" ")[1]) * 28 for term in terms}

    return [index + 1 for index, privacy in enumerate(privacies)
            if to_days(privacy.split(" ")[0]) + terms[privacy.split(" ")[1]] <= to_days(today)]


def to_days(date):
    date = list(map(int, date.split(".")))
    return date[0] * 12 * 28 + date[1] * 28 + date[2]



if __name__ == '__main__':
    inputs = [
        (
            "2022.05.19",
            ["A 6", "B 12", "C 3"],
            ["2021.05.02 A", "2021.07.01 B", "2022.02.19 C", "2022.02.20 C"]
        ),
        (
            "2020.01.01",
            ["Z 3", "D 5"],
            ["2019.01.01 D", "2019.11.15 Z", "2019.08.02 D", "2019.07.01 D", "2018.12.28 Z"]
        )
    ]

    outpus = [
        [1, 3],
        [1, 4, 5]
    ]

    for input, output in zip(inputs, outpus):
        print(solution(*input) == output)
