//https://school.programmers.co.kr/learn/courses/30/lessons/81302
using System;

public class Solution {
   public int[] solution(string[,] places) {
        int[] answer = new int[5];

        for(int i = 0; i < 5; i++) {
            if (CheckRestriction(places, i)) {
                answer[i] = 1;
            } else {
                answer[i] = 0;
            }
        }
        return answer;
    }

    public bool CheckRestriction (string[,] places, int room) {
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                if (places[room, i][j] == 'P') {
                    if ((i > 0 && places[room, i-1][j] == 'P') ||
                        (i < 4 && places[room, i+1][j] == 'P') ||
                        (j > 0 && places[room, i][j-1] == 'P') ||
                        (j < 4 && places[room, i][j+1] == 'P')) {
                        return false;
                    }
                    
                    if ((i > 1 && places[room, i-2][j] == 'P' && places[room, i-1][j] != 'X') ||
                        (i < 3 && places[room, i+2][j] == 'P' && places[room, i+1][j] != 'X') ||
                        (j > 1 && places[room, i][j-2] == 'P' && places[room, i][j-1] != 'X') ||
                        (j < 3 && places[room, i][j+2] == 'P' && places[room, i][j+1] != 'X')) {
                        return false;
                    }
                    
                    if (i > 0 && j > 0 && places[room, i-1][j-1] == 'P' && (places[room, i-1][j] != 'X' || places[room, i][j-1] != 'X')) return false;
                    if (i > 0 && j < 4 && places[room, i-1][j+1] == 'P' && (places[room, i-1][j] != 'X' || places[room, i][j+1] != 'X')) return false;
                    if (i < 4 && j > 0 && places[room, i+1][j-1] == 'P' && (places[room, i][j-1] != 'X' || places[room, i+1][j] != 'X')) return false;
                    if (i < 4 && j < 4 && places[room, i+1][j+1] == 'P' && (places[room, i][j+1] != 'X' || places[room, i+1][j] != 'X')) return false;
                }
            }
        }
        return true;
    }
}