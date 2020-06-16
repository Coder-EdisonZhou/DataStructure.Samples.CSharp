using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDC.DataStructure.LinkedList
{
    /// <summary>
    /// 单向循环链表的模拟实现
    /// </summary>
    public class MyCircularLinkedList<T>
    {
        private int count; // 字段：记录数据元素个数
        private CirNode<T> tail; // 字段：记录尾节点的指针
        private CirNode<T> currentPrev; // 字段：使用前驱节点标识当前节点

        // 属性：指示链表中元素的个数
        public int Count
        {
            get
            {
                return this.count;
            }
        }

        // 属性：指示当前节点中的元素值
        public T CurrentItem
        {
            get
            {
                return this.currentPrev.Next.Item;
            }
        }

        public MyCircularLinkedList()
        {
            this.count = 0;
            this.tail = null;
        }

        public bool IsEmpty()
        {
            return this.tail == null;
        }

        // Method01:根据索引获取节点
        private CirNode<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            }

            CirNode<T> tempNode = this.tail.Next;
            for (int i = 0; i < index; i++)
            {
                tempNode = tempNode.Next;
            }

            return tempNode;
        }

        // Method02:在尾节点后插入新节点
        public void Add(T value)
        {
            CirNode<T> newNode = new CirNode<T>(value);
            if (this.tail == null)
            {
                // 如果链表当前为空则新元素既是尾头结点也是头结点
                this.tail = newNode;
                this.tail.Next = newNode;
                this.currentPrev = newNode;
            }
            else
            {
                // 插入到链表末尾处
                newNode.Next = this.tail.Next;
                this.tail.Next = newNode;
                // 改变当前节点
                if (this.currentPrev == this.tail)
                {
                    this.currentPrev = newNode;
                }
                // 重新指向新的尾节点
                this.tail = newNode;
            }

            this.count++;
        }

        // Method03:移除当前所在节点
        public void Remove()
        {
            if (this.tail == null)
            {
                throw new NullReferenceException("链表中没有任何元素");
            }
            else if (this.count == 1)
            {
                // 只有一个元素时将两个指针置为空
                this.tail = null;
                this.currentPrev = null;
            }
            else
            {
                if (this.currentPrev.Next == this.tail)
                {
                    // 当删除的是尾指针所指向的节点时
                    this.tail = this.currentPrev;
                }
                // 移除当前节点
                this.currentPrev.Next = this.currentPrev.Next.Next;
            }

            this.count--;
        }

        // Method04:获取所有节点信息
        public string GetAllNodes()
        {
            if (this.count == 0)
            {
                throw new NullReferenceException("链表中没有任何元素");
            }
            else
            {
                CirNode<T> tempNode = this.tail.Next;
                string result = string.Empty;
                for (int i = 0; i < this.count; i++)
                {
                    result += tempNode.Item + " ";
                    tempNode = tempNode.Next;
                }

                return result;
            }
        }

        // Method05:让当前节点向前移动指定步数
        public void Move(int step = 1)
        {
            if (step < 1)
            {
                throw new ArgumentOutOfRangeException("step", "移动步数不能小于1");
            }

            for (int i = 1; i < step; i++)
            {
                currentPrev = currentPrev.Next;
            }
        }
    }
}
