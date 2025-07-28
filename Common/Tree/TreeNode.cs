using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Common.Tree
{
    public delegate void TreeVisitor<in T>(T nodeData);

    public class TreeNode<T> where T : class
    {
        private readonly List<TreeNode<T>> _children;

        public TreeNode(T data)
        {
            Data = data;
            _children = new List<TreeNode<T>>();
        }

        public T Data { get; }

        public void AddChild(T data)
        {
            _children.Add(new TreeNode<T>(data));
        }

        public void HookChild(TreeNode<T> node)
        {
            _children.Add(node);
        }

        public TreeNode<T> GetChild(int i)
        {
            return _children.Count > i ? _children[i] : null;
        }

        public IEnumerable<TreeNode<T>> GetChildren()
        {
            return _children;
        }

        public static void Traverse(TreeNode<T> node, TreeVisitor<T> visitor)
        {
            visitor(node.Data);
            foreach (var child in node._children)
                Traverse(child, visitor);
        }

        public TreeNode<T> Find(T search)
        {
            return Data == search
                ? this
                : _children.Select(item => item.Find(search))
                    .FirstOrDefault(find => find != null);
        }

        public TreeNode<T> Find(Func<T, bool> predicate)
        {
            return predicate(Data)
                ? this
                : _children.Select(child => child.Find(predicate))
                    .FirstOrDefault(find => find != null);
        }
    }
}
