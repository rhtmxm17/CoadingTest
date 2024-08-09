public class Tester
{
    static void Main()
    {
        Solution sol = new();
        Console.WriteLine(sol.solution(new int[,] { { 1, 0 }, { 0, 1 } }));
        Console.WriteLine(sol.solution(new int[,] { { 1, 1, 1 } }));
    }
}