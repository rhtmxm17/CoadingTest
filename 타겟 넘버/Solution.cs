public class Solution
{

    public int solution(int[] numbers, int target)
    {
        return Check(numbers, target, 0, 0);
    }

    static int Check(int[] numbers, int target, int currentIndex, int currentValue)
    {
        if(currentIndex == numbers.Length) // 해당 경로를 순회 완료한 경우
        {
            if (currentValue == target)
                return 1;
            else
                return 0;
        }

        int checkLeft = Check(numbers, target, currentIndex + 1, currentValue - numbers[currentIndex]);
        int checkRight = Check(numbers, target, currentIndex + 1, currentValue + numbers[currentIndex]);

        return checkLeft + checkRight;
    }
}