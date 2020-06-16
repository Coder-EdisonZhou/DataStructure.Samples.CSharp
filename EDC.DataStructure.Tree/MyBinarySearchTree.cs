using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDC.DataStructure.Tree
{
    /// <summary>
    /// 二叉查找树的模拟实现
    /// </summary>
    public class MyBinarySearchTree
    {
        // 二叉树的根节点
        private Node root;
        public Node Root
        {
            get
            {
                return this.root;
            }
        }

        public MyBinarySearchTree() { }

        public MyBinarySearchTree(int data)
        {
            this.root = new Node(data);
        }

        #region 基本的创建与移除方法
        // Method:判断该二叉树是否是空树
        public bool IsEmpty()
        {
            return this.root == null;
        }

        // Method:插入一个新节点
        public void InsertNode(int data)
        {
            Node newNode = new Node();
            newNode.data = data;

            if (this.root == null)
            {
                this.root = newNode;
            }
            else
            {
                Node currentNode = this.root;
                Node parentNode = null;

                while (currentNode != null)
                {
                    parentNode = currentNode;
                    if (currentNode.data < data)
                    {
                        currentNode = currentNode.rchild;
                    }
                    else
                    {
                        currentNode = currentNode.lchild;
                    }
                }

                if (parentNode.data < data)
                {
                    // 若插入的元素值小于根节点值，则将元素插入到左子树中
                    parentNode.rchild = newNode;
                }
                else
                {
                    // 若插入的元素值不小于根节点值，则将元素插入到右子树中
                    parentNode.lchild = newNode;
                }
            }
        }

        // Method:移除一个旧节点
        public void RemoveNode(int key)
        {
            Node current = null, parent = null;

            // 定位节点位置
            current = FindNode(key);

            // 没找到data为key的节点
            if (current == null)
            {
                Console.WriteLine("没有找到data为{0}的节点!", key);
                return;
            }

            #region 1.如果该节点是叶子节点
            if (current.lchild == null && current.rchild == null) // 如果该节点是叶子节点
            {
                if (current == this.root) // 如果该节点为根节点
                {
                    this.root = null;
                }
                else if (parent.lchild == current) // 如果该节点为左孩子节点
                {
                    parent.lchild = null;
                }
                else if (parent.rchild == current) // 如果该节点为右孩子节点
                {
                    parent.rchild = null;
                }
            } 
            #endregion
            #region 2.如果该节点是单支节点
            else if (current.lchild == null || current.rchild == null) // 如果该节点是单支节点 (只有一个左孩子节点或者一个右孩子节点)
            {
                if (current == this.root) // 如果该节点为根节点
                {
                    if (current.lchild == null)
                    {
                        this.root = current.rchild;
                    }
                    else
                    {
                        this.root = current.lchild;
                    }
                }
                else
                {
                    if (parent.lchild == current && current.lchild != null)  // p是q的左孩子且p有左孩子
                    {
                        parent.lchild = current.lchild;
                    }
                    else if (parent.lchild == current && current.rchild != null) // p是q的左孩子且p有右孩子
                    {
                        parent.rchild = current.rchild;
                    }
                    else if (parent.rchild == current && current.lchild != null) // p是q的右孩子且p有左孩子
                    {
                        parent.rchild = current.lchild;
                    }
                    else // p是q的右孩子且p有右孩子
                    {
                        parent.rchild = current.rchild;
                    }
                }
            } 
            #endregion
            #region 3.如果该节点的左右子树均不为空 
            else // 如果该节点的左右子树均不为空 
            {
                Node t = current;
                Node s = current.lchild; // 从p的左子节点开始 
                // 找到p的前驱，即p左子树中值最大的节点 
                while(s.rchild != null)
                {
                    t = s;
                    s = s.rchild;
                }

                current.data = s.data; // 把节点s的值赋给p

                if (t == current)
                {
                    current.lchild = s.lchild;
                }
                else
                {
                    current.rchild = s.rchild;
                }
            } 
            #endregion
        }

        // Method:根据Key查找某个节点
        public Node FindNode(int key)
        {
            Node currentNode = this.root;
            while (currentNode != null && currentNode.data != key)
            {
                if (currentNode.data < key)
                {
                    currentNode = currentNode.rchild;
                }
                else if (currentNode.data > key)
                {
                    currentNode = currentNode.lchild;
                }
                else
                {
                    break;
                }
            }

            return currentNode;
        }

        // Method:查找最大值
        public int FindMaxData()
        {
            Node currentNode = this.root;
            while (currentNode != null)
            {
                currentNode = currentNode.rchild;
            }

            return currentNode.data;
        }

        // Method:判断节点p是否叶子节点
        public bool IsLeafNode(Node p)
        {
            if (p == null)
            {
                return false;
            }

            return p.lchild == null && p.rchild == null;
        }

        // Method:计算二叉树的深度
        public int GetDepth(Node root)
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

        #region 基本的遍历方法
        // Method01:前序遍历
        public void PreOrder(Node node)
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
        public void MidOrder(Node node)
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
        public void PostOrder(Node node)
        {
            if (node != null)
            {
                // 左->右->根
                PostOrder(node.lchild);
                PostOrder(node.rchild);
                Console.Write(node.data);
            }
        }

        // Method04:层次遍历（广度优先遍历）
        public void LevelOrder(Node node)
        {
            if (root == null)
            {
                return;
            }

            Queue<Node> queueNodes = new Queue<Node>();
            queueNodes.Enqueue(node);
            Node tempNode = null;
            // 利用队列先进先出的特性存储节点并输出
            while (queueNodes.Count > 0)
            {
                tempNode = queueNodes.Dequeue();
                Console.Write(tempNode.data + " ");

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

        #region 嵌套类：节点
        public class Node
        {
            public int data { get; set; }

            public Node lchild { get; set; }

            public Node rchild { get; set; }

            public Node()
            {
            }

            public Node(int data)
            {
                this.data = data;
            }

            public Node(int data, Node lchild, Node rchild)
            {
                this.data = data;
                this.lchild = lchild;
                this.rchild = rchild;
            }
        }
        #endregion
    }
}
