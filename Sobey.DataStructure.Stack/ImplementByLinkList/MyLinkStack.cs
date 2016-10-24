using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobey.DataStructure.Stack
{
    /// <summary>
    /// 基于链表的栈节点
    /// </summary>
    /// <typeparam name="T">元素类型</typeparam>
    public class Node<T>
    {
        public T Item { get; set; }
        public Node<T> Next { get; set; }

        public Node(T item)
        {
            this.Item = item;
        }

        public Node()
        { }
    }

    /// <summary>
    /// 基于链表的栈实现
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public class MyLinkStack<T>
    {
        private Node<T> first;
        private int index;

        public MyLinkStack()
        {
            this.first = null;
            this.index = 0;
        }

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="item">新节点</param>
        public void Push(T item)
        {
            Node<T> oldNode = first;
            first = new Node<T>();
            first.Item = item;
            first.Next = oldNode;

            index++;
        }

        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns>出栈元素</returns>
        public T Pop()
        {
            T item = first.Item;
            first = first.Next;
            index--;

            return item;
        }

        /// <summary>
        /// 是否为空栈
        /// </summary>
        /// <returns>true/false</returns>
        public bool IsEmpty()
        {
            return this.index == 0;
        }

        /// <summary>
        /// 栈中节点个数
        /// </summary>
        public int Size
        {
            get
            {
                return this.index;
            }
        }
    }
}
