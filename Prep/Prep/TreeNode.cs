using System;

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
    public TreeNode root { get; set; }

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
}