# https://leetcode.com/problems/substrings-of-size-three-with-distinct-characters/

class Solution:
    def countGoodSubstrings(self, s: str) -> int:
        return len([index for index in range(len(s) - 2) if len(list(s[index : index + 3])) == len(set(s[index : index + 3]))])


if __name__ == '__main__':
    inputs = [
        "xyzzaz",
        "aababcabc"
    ]

    outputs = [
        1,
        4
    ]

    for input, output in zip(inputs, outputs):
        print(Solution().countGoodSubstrings(input) == output)