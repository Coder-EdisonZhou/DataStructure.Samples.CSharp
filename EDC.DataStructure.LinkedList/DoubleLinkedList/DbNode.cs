using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDC.DataStructure.LinkedList
{
    /// <summary>
    /// 双链表的节点
    /// </summary>
    public class DbNode<T>
    {
        public T Item { get; set; }
        public DbNode<T> Prev { get; set; }
        public DbNode<T> Next { get; set; }

        public DbNode()
        {
        }

        public DbNode(T item)
        {
            this.Item = item;
        }
    }
}
