using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDC.DataStructure.LinkedList
{
    /// <summary>
    /// 链表节点定义
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public class Node<T>
    {
        // 数据域
        public T Item { get; set; }
        // 指针域
        public Node<T> Next { get; set; }

        public Node()
        {
        }

        public Node(T item)
        {
            this.Item = item;
        }
    }
}
