public class Tester
{
    static void Main()
    {
        Solution sol = new();
        Console.WriteLine(sol.solution(2, 4)); // 6
        Console.WriteLine(sol.solution(1, 5)); // 26
        Console.WriteLine(sol.solution(1, 1000));
    }
}