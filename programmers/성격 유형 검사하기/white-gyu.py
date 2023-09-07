# https://school.programmers.co.kr/learn/courses/30/lessons/118666
import itertools


def solution(survey, choices):
    answer = ''
    character_types = [("R", "T"), ("C", "F"), ("J", "M"), ("A", "N")]
    character_score_board = dict.fromkeys(itertools.chain.from_iterable(character_types), 0)
    INVALID_SCORE = 4

    for each_survey, each_choice in zip(survey, choices):
        character_score_board[each_survey[each_choice >= INVALID_SCORE]] += abs(each_choice - INVALID_SCORE)

    for character_pair in character_types:
        survey_target = {character: character_score_board[character] for character in character_pair}
        answer += max(survey_target, key=survey_target.get)

    return answer


if __name__ == '__main__':
    surveys = [["AN", "CF", "MJ", "RT", "NA"], ["TR", "RT", "TR"]]
    choices = [[5, 3, 2, 7, 5], [7, 1, 3]]
    results = ["TCMA", "RCJA"]

    for survey, choice, result in zip(surveys, choices, results):
        print(solution(survey, choice) == result)
