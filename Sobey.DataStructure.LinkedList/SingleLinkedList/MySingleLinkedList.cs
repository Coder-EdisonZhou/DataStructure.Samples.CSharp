using System;
using System.Collections.Generic;
using System.Text;

namespace Sobey.DataStructure.LinkedList
{
    /// <summary>
    /// 单链表实现
    /// </summary>
    public class MySingleLinkedList<T>
    {
        private int count; // 字段：当前链表节点个数
        private Node<T> head; // 字段：当前链表的头结点

        // 属性：当前链表节点个数
        public int Count
        {
            get
            {
                return this.count;
            }
        }

        // 索引器
        public T this[int index]
        {
            get
            {
                return this.GetNodeByIndex(index).Item;
            }
            set
            {
                this.GetNodeByIndex(index).Item = value;
            }
        }

        public MySingleLinkedList()
        {
            this.count = 0;
            this.head = null;
        }

        // Method01:根据索引获取节点
        private Node<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            }

            Node<T> tempNode = this.head;
            for (int i = 0; i < index; i++)
            {
                tempNode = tempNode.Next;
            }

            return tempNode;
        }

        // Method02:在尾节点后插入新节点
        public void Add(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (this.head == null)
            {
                // 如果链表当前为空则置为头结点
                this.head = newNode;
            }
            else
            {
                Node<T> prevNode = this.GetNodeByIndex(this.count - 1);
                prevNode.Next = newNode;
            }

            this.count++;
        }

        // Method03:在指定位置插入新节点
        public void Insert(int index, T value)
        {
            Node<T> tempNode = null;
            if (index < 0 || index > this.count)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            }
            else if (index == 0)
            {
                if (this.head == null)
                {
                    tempNode = new Node<T>(value);
                    this.head = tempNode;
                }
                else
                {
                    tempNode = new Node<T>(value);
                    tempNode.Next = this.head;
                    this.head = tempNode;
                }
            }
            else
            {
                Node<T> prevNode = GetNodeByIndex(index - 1);
                tempNode = new Node<T>(value);
                tempNode.Next = prevNode.Next;
                prevNode.Next = tempNode;
            }

            this.count++;
        }

        // Method04：移除指定位置的节点
        public void RemoveAt(int index)
        {
            if (index == 0)
            {
                this.head = this.head.Next;
            }
            else
            {
                Node<T> prevNode = GetNodeByIndex(index - 1);
                if (prevNode.Next == null)
                {
                    throw new ArgumentOutOfRangeException("index", "索引超出范围");
                }

                Node<T> deleteNode = prevNode.Next;
                prevNode.Next = deleteNode.Next;

                deleteNode = null;
            }

            this.count--;
        }
    }
}
