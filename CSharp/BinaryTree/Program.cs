using System;

namespace BinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyBinaryTree<int> tree = new MyBinaryTree<int>();

            tree.Add(5);
            tree.Add(3);
            tree.Add(4);
            tree.Add(7);
            tree.Add(6);    
            tree.Add(8);
            tree.Add(9);

            Console.WriteLine(tree.Root.Value);
            Console.WriteLine(tree.Root.Left.Value);
            Console.WriteLine(tree.Root.Left.Right.Value);
            Console.WriteLine(tree.Root.Right.Value);
            Console.WriteLine(tree.Root.Right.Left.Value);
            Console.WriteLine(tree.Root.Right.Right.Value);
            Console.WriteLine(tree.Root.Right.Right.Right.Value);

            tree.Remove(7);
            Console.WriteLine(tree.Root.Right.Right.Value);
        }
    }
}
