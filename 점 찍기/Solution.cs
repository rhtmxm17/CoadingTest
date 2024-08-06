using System;

public class Solution
{
    public long solution(int k, int d)
    {
        long answer = 0;
        long dPow = (long)d * (long)d;

        for (int a = 0; ; a++)
        {
            int x = k * a;  // x길이
            if(x > d)       // x길이가 이미 제한거리를 넘었을 경우
                break;

            long maxYPow = dPow - (long)x * x;
            int maxY = (int)Math.Sqrt(maxYPow); // 최대 y 길이
            int maxB = maxY / k; // 최대 b값
            answer += maxB + 1;  // b == 0일 경우를 포함해야 한다
        }

        return answer;
    }
}
