﻿using System;

public class Tester
{
    static void Main()
    {
        Solution sol = new();

        int[,] edge = new int[,]
        {
            {0, 1}, {1, 2}, {1, 4 }, {0, 8 }, {8, 7 }, {9, 10 }, {9, 11 }, {4, 3 }, {6, 5 }, {4, 6 }, {8, 9 }
        };
        Console.WriteLine(sol.solution([0, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1], edge));
    }
}