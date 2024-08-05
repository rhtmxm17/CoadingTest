namespace 소수_만들기
{
    internal class Solution
    {
        // 입력값 범위를 넘어서면 잘못된 결과 발생 가능
        private int[] primes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, int.MaxValue };
        
        private bool IsPrime(int value)
        {
            int range = (int)Math.Sqrt(value);
            for (int i = 0; primes[i] <= range; i++)
            {
                if (value % primes[i] == 0)
                    return false;
            }
            return true;
        }

        public int solution(int[] nums)
        {
            int answer = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        if (IsPrime(nums[i] + nums[j] + nums[k]))
                            answer++;
                    }
                }
            }

            return answer;
        }
    }
}
