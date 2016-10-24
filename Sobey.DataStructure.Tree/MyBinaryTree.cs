using System;
using System.Collections.Generic;

namespace Sobey.DataStructure.Tree
{
    /// <summary>
    /// 二叉树的模拟实现
    /// </summary>
    /// <typeparam name="T">数据具体类型</typeparam>
    public class MyBinaryTree<T>
    {
        // 二叉树的根节点
        private Node<T> root;
        public Node<T> Root
        {
            get
            {
                return this.root;
            }
        }

        public MyBinaryTree() { }

        public MyBinaryTree(T data)
        {
            this.root = new Node<T>(data);
        }

        #region 基本的创建与移除方法
        // Method01:判断该二叉树是否是空树
        public bool IsEmpty()
        {
            return this.root == null;
        }

        // Method02:在节点p下插入左孩子节点的data
        public void InsertLeft(Node<T> p, T data)
        {
            Node<T> tempNode = new Node<T>(data);
            tempNode.lchild = p.lchild;

            p.lchild = tempNode;
        }

        // Method03:在节点p下插入右孩子节点的data
        public void InsertRight(Node<T> p, T data)
        {
            Node<T> tempNode = new Node<T>(data);
            tempNode.rchild = p.rchild;

            p.rchild = tempNode;
        }

        // Method04:删除节点p下的左子树
        public Node<T> RemoveLeft(Node<T> p)
        {
            if (p == null || p.lchild == null)
            {
                return null;
            }

            Node<T> tempNode = p.lchild;
            p.lchild = null;
            return tempNode;
        }

        // Method05:删除节点p下的右子树
        public Node<T> RemoveRight(Node<T> p)
        {
            if (p == null || p.rchild == null)
            {
                return null;
            }

            Node<T> tempNode = p.rchild;
            p.rchild = null;
            return tempNode;
        }

        // Method06:判断节点p是否叶子节点
        public bool IsLeafNode(Node<T> p)
        {
            if (p == null)
            {
                return false;
            }

            return p.lchild == null && p.rchild == null;
        }

        // Method07:计算二叉树的深度
        public int GetDepth(Node<T> root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftDepth = GetDepth(root.lchild);
            int rightDepth = GetDepth(root.rchild);

            if (leftDepth > rightDepth)
            {
                return leftDepth + 1;
            }
            else
            {
                return rightDepth + 1;
            }
        }
        #endregion

        #region 基本的递归遍历方法
        // Method01:前序遍历
        public void PreOrder(Node<T> node)
        {
            if (node != null)
            {
                // 根->左->右
                Console.Write(node.data);
                PreOrder(node.lchild);
                PreOrder(node.rchild);
            }
        }

        // Method02:中序遍历
        public void MidOrder(Node<T> node)
        {
            if (node != null)
            {
                // 左->根->右
                MidOrder(node.lchild);
                Console.Write(node.data);
                MidOrder(node.rchild);
            }
        }

        // Method03:后序遍历
        public void PostOrder(Node<T> node)
        {
            if (node != null)
            {
                // 左->右->根
                PostOrder(node.lchild);
                PostOrder(node.rchild);
                Console.Write(node.data);
            }
        }
        #endregion

        #region 基本的非递归遍历方法
        // Method01:前序遍历
        public void PreOrderNoRecurise(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            // 根->左->右
            Stack<Node<T>> stack = new Stack<Node<T>>();
            stack.Push(node);
            Node<T> tempNode = null;

            while (stack.Count > 0)
            {
                // 1.遍历根节点
                tempNode = stack.Pop();
                Console.Write(tempNode.data);
                // 2.右子树压栈
                if (tempNode.rchild != null)
                {
                    stack.Push(tempNode.rchild);
                }
                // 3.左子树压栈(目的：保证下一个出栈的是左子树的节点)
                if (tempNode.lchild != null)
                {
                    stack.Push(tempNode.lchild);
                }
            }
        }

        // Method02:中序遍历
        public void MidOrderNoRecurise(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            // 左->根->右
            Stack<Node<T>> stack = new Stack<Node<T>>();
            Node<T> tempNode = node;

            while (tempNode != null || stack.Count > 0)
            {
                // 1.依次将所有左子树节点压栈
                while (tempNode != null)
                {
                    stack.Push(tempNode);
                    tempNode = tempNode.lchild;
                }
                // 2.出栈遍历节点
                tempNode = stack.Pop();
                Console.Write(tempNode.data);
                // 3.左子树遍历结束则跳转到右子树
                tempNode = tempNode.rchild;
            }
        }

        // Method03:后序遍历
        public void PostOrderNoRecurise(Node<T> node)
        {
            if (root == null)
            {
                return;
            }

            // 两个栈：一个存储，一个输出
            Stack<Node<T>> stackIn = new Stack<Node<T>>();
            Stack<Node<T>> stackOut = new Stack<Node<T>>();
            Node<T> currentNode = null;
            // 根节点首先压栈
            stackIn.Push(node);
            // 左->右->根
            while (stackIn.Count > 0)
            {
                currentNode = stackIn.Pop();
                stackOut.Push(currentNode);
                // 左子树压栈
                if (currentNode.lchild != null)
                {
                    stackIn.Push(currentNode.lchild);
                }
                // 右子树压栈
                if (currentNode.rchild != null)
                {
                    stackIn.Push(currentNode.rchild);
                }
            }

            while (stackOut.Count > 0)
            {
                // 依次遍历各节点
                Node<T> outNode = stackOut.Pop();
                Console.Write(outNode.data);
            }
        }

        // Method04:层次遍历（广度优先遍历）
        public void LevelOrder(Node<T> node)
        {
            if (root == null)
            {
                return;
            }

            Queue<Node<T>> queueNodes = new Queue<Node<T>>();
            queueNodes.Enqueue(node);
            Node<T> tempNode = null;
            // 利用队列先进先出的特性存储节点并输出
            while (queueNodes.Count > 0)
            {
                tempNode = queueNodes.Dequeue();
                Console.Write(tempNode.data);

                if (tempNode.lchild != null)
                {
                    queueNodes.Enqueue(tempNode.lchild);
                }

                if (tempNode.rchild != null)
                {
                    queueNodes.Enqueue(tempNode.rchild);
                }
            }
        }
        #endregion
    }
}
