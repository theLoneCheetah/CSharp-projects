using System;
using System.Collections.Generic;

class BinaryTreeNode
{
    private BinaryTreeNode left;
    private BinaryTreeNode right;
    private string value;

    public BinaryTreeNode(ref Queue<string> values)
    {
        if (values.Count == 0) return;

        this.value = values.Dequeue();

        if (this.value == ".")
        {
            this.left = null;
            this.right = null;
        }
        else
        {
            this.Add(ref values, false);
            this.Add(ref values, true);
        }
    }

    private void Add(ref Queue<string> values, bool is_right)
    {
        if (!is_right)
            this.left = new BinaryTreeNode(ref values);
        else
            this.right = new BinaryTreeNode(ref values);
    }

    public void PrintTree()
    {
        Console.WriteLine("Значение: {0}, левый: {1}, правый: {2}", this.value, this.left.value, this.right.value);

        if (this.left.value != ".")
            this.left.PrintTree();
        if (this.right.value != ".")
            this.right.PrintTree();
    }

    public void StraightTraversal(ref Queue<string> traversal)
    {
        traversal.Enqueue(this.value);
        if (this.left.value != ".")
            this.left.StraightTraversal(ref traversal);
        if (this.right.value != ".")
            this.right.StraightTraversal(ref traversal);
    }

    public void CenteredTraversal(ref Queue<string> traversal)
    {
        if (this.left.value != ".")
            this.left.CenteredTraversal(ref traversal);
        traversal.Enqueue(this.value);
        if (this.right.value != ".")
            this.right.CenteredTraversal(ref traversal);
    }

    public void ReversedTraversal(ref Queue<string> traversal)
    {
        if (this.left.value != ".")
            this.left.ReversedTraversal(ref traversal);
        if (this.right.value != ".")
            this.right.ReversedTraversal(ref traversal);
        traversal.Enqueue(this.value);
    }
}