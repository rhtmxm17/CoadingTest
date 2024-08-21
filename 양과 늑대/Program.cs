using System;

public class Solution
{
    public class Node
    {
        public bool isSheep = false;
        public int childSheep = 0;  // 해당 분기에 포함된 모든 양 개수
        public int childWolf = 1;   // 해당 분기에 포함된 모든 늑대 개수
        public Node? parent = null;
        public Node? left = null;
        public Node? right = null;
    }

    // 좌우를 비교해서 우선순위가 높은 노드를 당겨올림
    public Node? PullUp(Node node, Func<Node, Node, bool> super)
    {
        if (node.left == null)
            return null;

        if (node.right == null)
        {
            PullUp(node.left, super);
            return node.left;
        }

        if (super(node.left, node.right))
        {
            PullUp(node.left, super);

            if (node.left.left == null)
                node.left.left = node.right;
            else
                node.left.right = node.right;

            node.right.parent = node.left;
            return node.left;
        }
        else
        {
            PullUp(node.right, super);

            if (node.right.left == null)
                node.right.left = node.left;
            else
                node.right.right = node.left;

            node.left.parent = node.right;
            return node.right;
        }
    }

    public bool Priority(Node left, Node right)
    {
        if (left.isSheep)
            return true;

        if (right.isSheep)
            return false;

        return (left.childSheep - left.childWolf) > (right.childSheep - right.childWolf);
    }

    public int solution(int[] info, int[,] edges)
    {
        Node[] nodes = new Node[info.Length];

        for (int i = 0; i < info.Length; i++)
        {
            nodes[i] = new Node();

            if (info[i] == 0)
            {
                nodes[i].isSheep = true;
                nodes[i].childSheep = 1;
                nodes[i].childWolf = 0;
            }
        }

        // 노드 연결
        for (int i = 0; i < edges.GetLength(0); i++)
        {
            Node pnode = nodes[edges[i, 0]];
            Node cnode = nodes[edges[i, 1]];

            if (pnode.left == null)
                pnode.left = cnode;
            else
                pnode.right = cnode;

            pnode.childSheep += cnode.childSheep;
            pnode.childWolf += cnode.childWolf;

            for (Node? grand = pnode.parent; grand != null; grand = grand.parent)
            {
                grand.childSheep += cnode.childSheep;
                grand.childWolf += cnode.childWolf;
            }
        }

        // 순수 늑대 분기 폐기
        for (int i = 0; i < nodes.Length; i++)
        {
            if (nodes[i].childSheep == 0)
            {
                Node? parent = nodes[i].parent;
                nodes[i].parent = null;

                if (parent == null)
                    continue;

                if (parent.left == nodes[i])
                {
                    parent.left = parent.right;
                    parent.right = null;
                }
                else
                {
                    parent.right = null;
                }

                parent.childWolf -= nodes[i].childWolf;
                for (Node? grand = parent.parent; grand != null; grand = grand.parent)
                {
                    grand.childWolf -= nodes[i].childWolf;
                }

            }
        }

        int sheepCount = 0;
        int wolfCount = 0;
        for (Node? head = nodes[0]; head != null; head = PullUp(head, Priority))
        {
            if (head.isSheep)
                sheepCount++;
            else
                wolfCount++;

            Console.WriteLine($"{sheepCount}, {wolfCount}");

            if (sheepCount <= wolfCount)
                break;
        }

        return sheepCount;
    }
}