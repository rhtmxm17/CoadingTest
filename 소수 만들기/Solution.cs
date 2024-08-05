namespace 소수_만들기
{
    internal class Solution
    {
        private List<int> primes = new List<int>() { 2 };
        private int checkedRange = 2;

        private void PrimeCheckRange(int max)
        {
            for (int i = checkedRange + 1; i <= max; i++)
            {

            }
        }

        private bool IsPrime(int value)
        {
            int range = (int)Math.Sqrt(value);
            for (int i = 2; i <= range; i++)
            {
                if (value % i == 0)
                    return false;
            }
            return true;
        }

        public int solution(int[] nums)
        {
            int answer = 0;

            //int cases = nums.Length * (nums.Length - 1) * (nums.Length - 2);
            //int[] sum = new int[cases];
            //int index = 0;
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
