using System;

public class Solution
{
    // parametric search

    public long solution(int a, int b, int[] g, int[] s, int[] w, int[] t)
    {
        long begin = 0; 
        long end = long.MaxValue >> 1; // 성공한 케이스의 시간을 저장
        long middle = (begin + end) >> 1; // 실패한 케이스의 시간을 저장

        // begin + 1 == end 와 같은 조건
        // 실패한 케이스와 성공한 케이스가 인접했으므로
        // begin은 실패하는 최대 시간
        // end는 성공하는 최소 시간을 의미한다.
        while (begin != middle)
        {
            if(TryIt(middle, a, b, g, s, w, t))
            {
                end = middle;
                middle = (begin + end) >> 1;
            }
            else
            {
                begin = middle;
                middle = (begin + end) >> 1;
            }
        }

        return end;
    }

    /// <param name="timeout">검사할 시간값</param>
    /// <param name="goldReq">금 요구량</param>
    /// <param name="silvReq">은 요구량</param>
    /// <param name="gold">각 도시의 금 보유량</param>
    /// <param name="silver">각 도시의 은 보유량</param>
    /// <param name="weight">각 트럭의 하중</param>
    /// <param name="timeReq">각 트럭의 편도 소요시간</param>
    /// <returns>수행 가능여부. 가능할 경우 true.</returns>
    static bool TryIt(long timeout, int goldReq, int silvReq, int[] gold, int[] silver, int[] weight, int[] timeReq)
    {
        int total_req = goldReq + silvReq;
        int index = gold.Length;
        for (int i = 0; i < index; i++)
        {
            long numOfCycle = Smoller((timeReq[i] + timeout) / (2 * timeReq[i]), int.MaxValue); // 시간 내 운반 가능 횟수
            int canCarryWeight = Smoller(numOfCycle * weight[i], int.MaxValue); // 시간 내 운반 가능 양

            // 보유량과 운반 가능량을 비교해 작은쪽이 최종적으로 배송 가능한 양
            total_req -= Smoller(canCarryWeight, (gold[i] + silver[i]));
            goldReq -= Smoller(canCarryWeight , gold[i]);
            silvReq -= Smoller(canCarryWeight, silver[i]); 

            if (total_req <= 0 && goldReq <= 0 && silvReq <= 0) // 모든 요구량 충족시
                return true;
        }
        return false;
    }

    static int Smoller(long a, int b)
    {
        return a < b ? (int)a : b;
    }

    static int Smoller(int a, int b)
    {
        return a < b ? a : b;
    }
}