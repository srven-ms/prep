using System;
using System.Xml.Linq;

public class TreeNode
{
    public int val { get; set; }
    public TreeNode left { get; set; }
    public TreeNode right { get; set; }

    public TreeNode(int value = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = value;
        this.left = left;
        this.right = right;
    }
}

public class Tree
{
    public TreeNode? root { get; set; }

    public Tree()
    {
        root = null;
    }

    public void Inorder(TreeNode node)
    {
        if (node == null)
        {
            return;
        }

        Inorder(node.left);
        Console.Write(node.val + "->");
        Inorder(node.right);
    }

    // 563: https://leetcode.com/problems/binary-tree-tilt/
    public int FindTilt(TreeNode? root)
    {
        TreeNode node = ConvertTreeIntoTiltedTree(root);

        return FindSum(node);
    }

    public TreeNode? ConvertTreeIntoTiltedTree(TreeNode? node)
    {
        if (node == null)
        {
            return null;
        }

        if (!this.IsLeafNode(node))
        {
            int l_sum = FindSum(node.left);
            int r_sum = FindSum(node.right);

            node.val = l_sum > r_sum ? (l_sum-r_sum) : (r_sum-l_sum);
        }
        else
        {
            node.val = 0;
        }

        ConvertTreeIntoTiltedTree(node.left);
        ConvertTreeIntoTiltedTree(node.right);

        return node;
    }

    public int FindSum(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }

        return node.val + FindSum(node.left) + FindSum(node.right);
    }

    public int SumOfLeftLeaves(TreeNode root)
    {
        int sum = 0;

        if (root == null)
        {
            return sum;
        }

        Queue<TreeNode> q1 = new Queue<TreeNode>();
        Queue<TreeNode> q2 = new Queue<TreeNode>();

        q1.Enqueue(root);

        while (q1.Count > 0 || q2.Count >0)
        {
            while (q1.Count > 0)
            {
                TreeNode q1Node = q1.Dequeue();

                if (q1Node.left != null)
                {
                    TreeNode leftNode = q1Node.left;

                    if (leftNode.left == null && leftNode.right == null)
                    {
                        sum += leftNode.val;
                    }

                    q2.Enqueue(leftNode);
                }

                if (q1Node.right != null)
                {
                    q2.Enqueue(q1Node.right);
                }
            }

            while (q2.Count > 0)
            {
                TreeNode q2Node = q2.Dequeue();

                if (q2Node.left != null)
                {
                    TreeNode leftNode = q2Node.left;

                    if (leftNode.left == null && leftNode.right == null)
                    {
                        sum += leftNode.val;
                    }

                    q1.Enqueue(q2Node.left);
                }

                if (q2Node.right != null)
                {
                    q1.Enqueue(q2Node.right);
                }
            }
        }

        return sum;
    }

    // Helper methods
    private bool IsLeafNode(TreeNode node)
    {
        return node != null && node.left == null && node.right == null;
    }
}