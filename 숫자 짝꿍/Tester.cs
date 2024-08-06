public class Tester
{
    static void Main()
    {
        Solution sol = new();
        Console.WriteLine(sol.solution("100", "2345")); // -1
        Console.WriteLine(sol.solution("100", "203045")); // 0
        Console.WriteLine(sol.solution("100", "123450")); // 10
        Console.WriteLine(sol.solution("12321", "42531")); // 321
        Console.WriteLine(sol.solution("5525", "1255")); // 552
    }
}