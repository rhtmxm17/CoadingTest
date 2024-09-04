using System;
using System.Collections.Generic;

public class Solution
{
    public int[] solution(int[] progresses, int[] speeds)
    {
        if (progresses.Length == 0)
            return Array.Empty<int>();

        List<int> answer = new List<int>(progresses.Length);
        int dayElapsed = 0;
        int lastCompletedIndex = 0;

        // 첫번째 작업 소요 일 수
        int todo = (100 - progresses[0]);
        dayElapsed = todo / speeds[0] + (todo % speeds[0] > 0 ? 1 : 0);
        for (int i = 1; i < progresses.Length; i++)
        {
            todo = (100 - progresses[i]);
            int dayspan = todo / speeds[i] + (todo % speeds[i] > 0 ? 1 : 0);
            if (dayspan <= dayElapsed) // 이미 완료된 작업이면 다음 작업 확인
                continue;

            dayElapsed = dayspan; // 배포된 날짜 누적

            answer.Add(i - lastCompletedIndex);
            lastCompletedIndex = i;
        }
        answer.Add(progresses.Length - lastCompletedIndex);

        return answer.ToArray();
    }
}