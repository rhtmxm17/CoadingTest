public class Tester
{
    static void Main()
    {
        Solution sol = new();
        Console.WriteLine(sol.solution(10, 10, [100], [100], [7], [10])); // 50
        Console.WriteLine(sol.solution(90, 500, [70, 70, 0], [0, 0, 500], [100, 100, 2], [4, 8, 1])); // 499
    }
}