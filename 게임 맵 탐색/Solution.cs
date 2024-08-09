using System;
using System.Collections.Generic;

public class Solution
{
    enum Dir { Left, Right, Up, Down, END, FAIL = -1 };
    public struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }

    private bool TryNext(Point pt, Dir dir, out Point next)
    {
        switch (dir)
        {
            case Dir.Left:
                next = new Point(pt.x - 1, pt.y);
                if (next.x >= 0)
                    return true;
                else
                    return false;
            case Dir.Right:
                next = new Point(pt.x + 1, pt.y);
                if (next.x < mapX)
                    return true;
                else
                    return false;
            case Dir.Up:
                next = new Point(pt.x, pt.y - 1);
                if (next.y >= 0)
                    return true;
                else
                    return false;
            case Dir.Down:
                next = new Point(pt.x, pt.y + 1);
                if (next.y < mapY)
                    return true;
                else
                    return false;
            default:
                next = new Point();
                return false;
        }
    }

    private int mapX;
    private int mapY;

    public int solution(int[,] maps)
    {
        mapX = maps.GetLength(1);
        mapY = maps.GetLength(0);
        int[,] distanceMap = new int[maps.GetLength(0), maps.GetLength(1)];
        Queue<Point> queue = new Queue<Point>();

        distanceMap[0, 0] = 1;
        queue.Enqueue(new Point(0, 0));

        while (queue.Count > 0)
        {
            Point node = queue.Dequeue();
            for (Dir dir = 0; dir < Dir.END; dir++)
            {
                Point next;

                // 해당 방향이 맵 바깥
                if (false == TryNext(node, dir, out next))
                    continue;

                // 해당 방향이 벽
                if (maps[next.y, next.x] == 0)
                    continue;

                // 해당 방향이 이미 탐색됨
                if (distanceMap[next.y, next.x] > 0)
                    continue;

                distanceMap[next.y, next.x] = distanceMap[node.y, node.x] + 1;
                queue.Enqueue(next);
            }
        }

        if (distanceMap[mapY - 1, mapX - 1] == 0)
            return -1;
        else
            return distanceMap[mapY - 1, mapX - 1];
    }
}