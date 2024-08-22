using System;

public class Solution
{
    const int LargeByteOne = 0x40000000;

    public class Node
    {
        public int number;
        public bool isSheep = false;
        private Node parent = null;

        // 부모노드 변경시 우선순위 갱신
        public Node Parent
        {
            get => parent;
            set
            {
                if (parent == value)
                    return;

                if (parent != null)
                {
                    int subScore = this.score;

                    for (Node subFrom = parent; subFrom != null; subFrom = subFrom.Parent)
                    {
                        subScore >>= 2;

                        subFrom.score -= subScore;
                    }
                }

                if (value != null)
                {
                    int addScore = this.score;

                    for (Node addTo = value; addTo != null; addTo = addTo.Parent)
                    {
                        addScore >>= 2;

                        addTo.score += addScore;
                    }
                }

                parent = value;
            }
        }
        public Node left = null;
        public Node right = null;

        // 우선순위
        public int score = 0;
    }

    // 좌우를 비교해서 우선순위가 높은 노드를 당겨올림
    public Node PullUp(Node node, Func<Node, Node, bool> super)
    {
        if (node.left == null)
            return null;

        if (node.right == null)
        {
            PullUp(node.left, super);
            return node.left;
        }

        Node higher;
        Node lower;
        if (super(node.left, node.right))
        {
            higher = node.left;
            lower = node.right;
        }
        else
        {
            higher = node.right;
            lower = node.left;
        }

        PullUp(higher, super);

        if (higher.left == null)
            higher.left = lower;
        else
            higher.right = lower;

        lower.Parent = higher;

        node.left = higher;
        node.right = null;
        return higher;
    }

    public bool PriorityScore(Node left, Node right)
    {
        return left.score > right.score;
    }

    public int solution(int[] info, int[,] edges)
    {
        Node[] nodes = new Node[info.Length];

        for (int i = 0; i < info.Length; i++)
        {
            nodes[i] = new Node();
            nodes[i].number = i;

            if (info[i] == 0)
            {
                nodes[i].isSheep = true;
                nodes[i].score = LargeByteOne;
            }
        }

        // 노드 연결
        for (int i = 0; i < edges.GetLength(0); i++)
        {
            Node pnode = nodes[edges[i, 0]];
            Node cnode = nodes[edges[i, 1]];

            // 노드 링크
            if (pnode.left == null)
                pnode.left = cnode;
            else
                pnode.right = cnode;

            cnode.Parent = pnode;

        }

        // 순수 늑대 분기 폐기
        for (int i = 0; i < nodes.Length; i++)
        {
            if (nodes[i].score == 0)
            {
                Node parent = nodes[i].Parent;
                nodes[i].Parent = null;

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
            }
        }

        int sheepCount = 0;
        int wolfCount = 0;
        for (Node head = nodes[0]; head != null; head = PullUp(head, PriorityScore))
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