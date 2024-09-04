internal class Tester
{
    static void Main()
    {
        Solution sol = new();
        System.Console.WriteLine(string.Join(',', sol.solution([93, 30, 55], [1, 30, 5])));
        System.Console.WriteLine(string.Join(',', sol.solution([95, 90, 99, 99, 80, 99], [1, 1, 1, 1, 1, 1])));
    }
}
