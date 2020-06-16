using System;

namespace EDC.DataStructure.Tree
{
    /// <summary>
    /// 二叉树的节点定义
    /// </summary>
    /// <typeparam name="T">数据具体类型</typeparam>
    public class Node<T>
    {
        public T data { get; set; }

        public Node<T> lchild { get; set; }

        public Node<T> rchild { get; set; }

        public Node()
        {
        }

        public Node(T data)
        {
            this.data = data;
        }

        public Node(T data, Node<T> lchild, Node<T> rchild)
        {
            this.data = data;
            this.lchild = lchild;
            this.rchild = rchild;
        }
    }
}
