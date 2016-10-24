using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sobey.DataStructure.Tree
{
    /// <summary>
    /// 二叉表达式树求解四则运算
    /// </summary>
    public class MyBinaryExprTree
    {
        private Node _head;         // 头结点指针
        private string _expression; // 构造二叉树的字符串
        private int _pos;           // 当前解析的字符所在的位置

        public MyBinaryExprTree(string constructStr)
        {
            this._expression = constructStr;
            this._head = CreateTree();
        }

        // 创建表达式树
        private Node CreateTree()
        {
            Node head = null;
            
            while(_pos < _expression.Length)
            {
                Node node = GetNode(); // 将当前解析字符转换为节点
                if(head == null)
                {
                    head = node;
                }
                else if (head.IsOptr == false) // 根节点为数字，当前节点为根，原根节点变为左孩子
                {
                    node.Left = head;
                    head = node;
                }
                else if (node.IsOptr == false) // 如果当前节点是数字
                {
                    // 当前节点沿右路插入最右边成为右孩子
                    Node tempNode = head;
                    while(tempNode.Right != null)
                    {
                        tempNode = tempNode.Right;
                    }
                    tempNode.Right = node;
                }
                else // 如果当前节点是运算符
                {
                    if (GetPriority((char)node.Data) <= GetPriority((char)head.Data)) // 优先级低则成为根，原二叉树成为插入节点的左子树
                    {
                        node.Left = head;
                        head = node;
                    }
                    else // 优先级高则成为根节点的右子树，原右子树成为插入节点的左子树
                    {
                        node.Left = head.Right;
                        head.Right = node;
                    }
                }
            }

            return head;
        }

        // 创建指定规范节点
        private Node GetNode()
        {
            char ch = _expression[_pos];
            if (char.IsDigit(ch))  // 字符为数字时
            {
                // 当操作数为2位及以上整数时,需要使用循环获取
                StringBuilder sbNumber = new StringBuilder();
                while (_pos < _expression.Length && char.IsDigit(ch = _expression[_pos]))
                {
                    sbNumber.Append(ch);
                    _pos++;
                }

                return new Node(Convert.ToInt32(sbNumber.ToString()));
            }
            else // 字符为运算符时
            {
                _pos++;
                return new Node(ch);
            }
        }

        // 先序遍历进行表达式求值
        private int PreOrderCalc(Node node)
        {
            int num1, num2;
            if (node.IsOptr)
            {
                // 递归先序遍历计算num1
                num1 = PreOrderCalc(node.Left);
                // 递归先序遍历计算num2
                num2 = PreOrderCalc(node.Right);
                char optr = (char)node.Data;

                switch (optr)
                {
                    case '+':
                        node.Data = num1 + num2;
                        break;
                    case '-':
                        node.Data = num1 - num2;
                        break;
                    case '*':
                        node.Data = num1 * num2;
                        break;
                    case '/':
                        if (num2 == 0)
                        {
                            throw new DivideByZeroException("除数不能为0！");
                        }
                        node.Data = num1 / num2;
                        break;
                }
            }

            return node.Data;
        }

        // 获取运算符的优先级
        private int GetPriority(char optr)
        {
            if (optr == '+' || optr == '-')
            {
                return 1;
            }
            else if (optr == '*' || optr == '/')
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }

        // 获取四则运算表达式的值
        public int GetResult()
        {
            return PreOrderCalc(this._head);
        }

        #region 内部类：二叉表达式树节点
        /// <summary>
        /// 内部类：二叉表达式树节点
        /// </summary>
        private class Node
        {
            private bool _isOptr;

            public bool IsOptr
            {
                get { return _isOptr; }
                set { _isOptr = value; }
            }
            private int _data;

            public int Data
            {
                get { return _data; }
                set { _data = value; }
            }
            private Node _left;

            public Node Left
            {
                get { return _left; }
                set { _left = value; }
            }
            private Node _right;

            public Node Right
            {
                get { return _right; }
                set { _right = value; }
            }

            public Node(int data)
            {
                this._data = data;
                this._isOptr = false;
            }

            public Node(char optr)
            {
                this._isOptr = true;
                this._data = optr;
            }

            public override string ToString()
            {
                if (this._isOptr)
                {
                    return Convert.ToString((char)this._data);
                }
                else
                {
                    return this._data.ToString();
                }
            }
        }
        #endregion
    }
}
