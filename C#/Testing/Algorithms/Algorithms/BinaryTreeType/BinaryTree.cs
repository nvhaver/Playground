using System;

namespace Algorithms.BinaryTreeType
{
    public class BinaryTree<T> where T : IComparable
    {
        public BinaryTreeItem<T> root;

        public BinaryTree()
        {
            root = null;
        }

        public void Add(T toAdd)
        {
            BinaryTreeItem<T> newItem = new BinaryTreeItem<T>(toAdd);

            if (root == null)
            {
                root = newItem;
                return;
            }

            var current = root;
            while (true)
            {
                int compare = toAdd.CompareTo(current.data);
                switch (compare)
                {
                    case -1: // Add left
                        if (current.left != null)
                        {
                            current = current.left;
                        }
                        else
                        {
                            current.left = newItem;
                            return;
                        }
                        break;
                    case 0: // Do not add
                        return;
                    case 1: // Add right
                        if (current.right != null)
                        {
                            current = current.right;
                        }
                        else
                        {
                            current.right = newItem;
                            return;
                        }
                        break;
                }
            }
        }

        public void AddRecur(T data)
        {
            if (root == null)
            {
                root = new BinaryTreeItem<T>(data);
            }
            else {
                AddRecur(root, data);
            }
        }

        private void AddRecur(BinaryTreeItem<T> tree, T data)
        {
            var compare = data.CompareTo(tree.data);
            if (compare == -1)
            {
                if (tree.left != null)
                {
                    AddRecur(tree.left, data);
                }
                else
                {
                    tree.left = new BinaryTreeItem<T>(data);
                }
            }
            else if (compare == 1)
            {
                if (tree.right != null)
                {
                    AddRecur(tree.right, data);
                }
                else
                {
                    tree.right = new BinaryTreeItem<T>(data);
                }
            }
        }


        public void Print()
        {
            if(root != null) PrintRecur(root);
        }

        private void PrintRecur(BinaryTreeItem<T> tree)
        {
            if(tree.left != null) PrintRecur(tree.left);
            Console.Write($"{tree.data} ");
            if (tree.right != null) PrintRecur(tree.right);
        }

    }
}
