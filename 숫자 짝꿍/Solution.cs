using System;
using System.Text;

public class Solution
{
    public string solution(string X, string Y)
    {
        StringBuilder sb = new StringBuilder();

        int[] digitX = new int[10];
        int[] digitY = new int[10];

        foreach(char c in X)
        {
            digitX[c - '0']++;
        }

        foreach(char c in Y)
        {
            digitY[c - '0']++;
        }

        for (int i = 10 - 1; i >= 0; i--)
        {
            int pair = (digitX[i] < digitY[i]) ? digitX[i] : digitY[i];

            for (int j = 0; j < pair; j++)
                sb.Append(i);
        }

        if (sb.Length == 0) // 짝이 이루어지지 않은 경우
            return "-1";
        else if (sb[0] == '0') // 가장 앞의 값이 0이라면 전부 0임을 의미
            return "0";
        else
            return sb.ToString();
    }
}