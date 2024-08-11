public class Tester
{
    static void Main()
    {
        Solution sol = new();
        Console.WriteLine(sol.solution(3, 4, 2, 3, 3, 1, 5)); // "dllrl"
        Console.WriteLine(sol.solution(2, 2, 1, 1, 2, 2, 2)); // "dr"
        Console.WriteLine(sol.solution(3, 3, 1, 2, 3, 3, 4)); // "impossible"
    }
}