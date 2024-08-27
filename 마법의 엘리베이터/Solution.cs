using System;

public class Solution
{
    public int solution(int storey)
    {
        int answer = 0;

        int next = storey % 10;
        int current = next;

        while (storey > 0)
        {
            // 다음 자릿수 확인
            storey /= 10;
            next = storey % 10;

            // 현재 자릿수를 내릴지 올릴지 판단
            bool under = true;

            if (current > 5)
            {
                under = false;
            }
            else if (current == 5 && next >= 5)
            {
                under = false;
            }

            // 내릴 경우 자릿수 값 만큼 사용
            if (under)
            {
                answer += current;
            }
            // 올릴 경우 (10 - 자릿수 값) 만큼 사용 후 다음 자릿수 올림
            else
            {
                answer += 10 - current;
                storey++;
                next = storey % 10;
            }

            // 다음 자릿수로 이동
            current = next;
        }

        // 마지막 자릿수 처리
        if (current <= 5)
        {
            answer += current;
        }
        else
        {
            answer += (10 - current) + 1;
        }

        return answer;
    }
}