using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sobey.DataStructure.LinkedList
{
    /// <summary>
    /// 循环链表节点定义
    /// </summary>
    public class CirNode<T>
    {
        public T Item { get; set; }
        public CirNode<T> Next { get; set; }

        public CirNode()
        {
        }

        public CirNode(T item)
        {
            this.Item = item;
        }
    }
}
