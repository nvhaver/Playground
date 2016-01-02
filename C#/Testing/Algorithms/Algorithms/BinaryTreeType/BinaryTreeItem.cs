using System;

namespace Algorithms.BinaryTreeType
{
    public class BinaryTreeItem<T> where T : IComparable
    {
        public T data;
        public BinaryTreeItem<T> left;
        public BinaryTreeItem<T> right;

        public BinaryTreeItem(T data)
        {
            this.data = data;
        }
    }
}
