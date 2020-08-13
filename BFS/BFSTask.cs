using System;
using System.Collections.Generic;

namespace BFSTask
{

    public class TreeNode<T>
    {
        private T value;
        private bool hasParent;
        public List<TreeNode<T>> children;

        public TreeNode(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                      "Cannot insert null value!");
            }
            this.value = value;
            this.children = new List<TreeNode<T>>();
        }

        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
        public bool IsVisited { get; set; }
    }

    public static int BFS(TreeNode<T> start, TreeNode<T> end)
    {
        Queue<TreeNode<T>> queue = new Queue<TreeNode>();
        queue.Enqueue(start);

        while (queue.Count != 0)
        {
            TreeNode CurrentNode = queue.Dequeue();
            CurrentNode.IsVisited = true;

            foreach (Node Child in CurrentNode.Children.Keys)
            {
                if (Child.IsVisited == false)
                {
                    Child.IsVisited = true;
                    if (Child == end) return 1;
                }
                queue.Enqueue(Child);
            }
        }
        return 0;
    }
}