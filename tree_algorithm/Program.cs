using System;
using System.Collections.Generic;


class Program
{
    private static void DifferentTraversals()
    {
        // a b d . . e . . c . f . .
        Console.WriteLine("Enter nodes' values starting from root and separated by space:");
        string[] input = Console.ReadLine().Split(' ');
        Console.WriteLine();

        Queue<string> values = new Queue<string>(input);
        BinaryTreeNode root = new BinaryTreeNode(ref values);

        Console.WriteLine("Detailed view of tree:");
        root.PrintTree();
        Console.WriteLine();

        Queue<string> traversal = new Queue<string>();

        Console.Write("Straight tree traversal:");
        root.StraightTraversal(ref traversal);
        while (traversal.Count > 0)
            Console.Write(" {0}", traversal.Dequeue());
        Console.WriteLine();

        Console.Write("Centered tree traversal:");
        root.CenteredTraversal(ref traversal);
        while (traversal.Count > 0)
            Console.Write(" {0}", traversal.Dequeue());
        Console.WriteLine();

        Console.Write("Reversed tree traversal:");
        root.ReversedTraversal(ref traversal);
        while (traversal.Count > 0)
            Console.Write(" {0}", traversal.Dequeue());
        Console.WriteLine();
    }

    private static void MathExpression()
    {
        // / * + 2 . . 3 . . - 7 . . 4 . . 3 . .
        Console.WriteLine("Enter nodes' values starting from root and separated by space:");
        string[] input = Console.ReadLine().Split(' ');
        Console.WriteLine();

        Queue<string> values = new Queue<string>(input);
        BinaryTreeNode root = new BinaryTreeNode(ref values);

        Console.WriteLine("Detailed view of tree:");
        root.PrintTree();
        Console.WriteLine();

        Queue<string> traversal = new Queue<string>();
        root.ReversedTraversal(ref traversal);

        Stack<int> calc = new Stack<int>();
        int temp, a, b;
        string sym;

        while (traversal.Count > 0)
        {
            sym = traversal.Dequeue();
            Console.Write("{0} ", sym);

            if (int.TryParse(sym, out temp))
                calc.Push(temp);

            else
            {
                b = calc.Pop();
                a = calc.Pop();

                switch (sym)
                {
                    case "+":
                        temp = a + b;
                        break;
                    case "-":
                        temp = a - b;
                        break;
                    case "*":
                        temp = a * b;
                        break;
                    case "/":
                        temp = a / b;
                        break;
                }

                calc.Push(temp);
            }
        }

        Console.WriteLine("= {0}", calc.Pop());
    }

    static void Main(string[] args)
    {
        Console.Write("Enter 0 to test different tree traversals, 1 to calculate math expression by tree: ");
        bool mode = Console.ReadLine() == "1";
        Console.WriteLine();

        if (!mode)
            DifferentTraversals();
        else
            MathExpression();
    }
}
