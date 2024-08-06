public class Tester
{
    static void Main()
    {
        Solution sol = new();
        Console.WriteLine(sol.solution([1, 1, 1, 1, 1], 3)); // 5
        Console.WriteLine(sol.solution([4, 1, 2, 1], 4)); // 2
    }
}