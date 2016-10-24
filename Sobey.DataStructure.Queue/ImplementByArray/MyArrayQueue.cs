using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobey.DataStructure.Queue
{
    /// <summary>
    /// 基于数组的队列实现
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public class MyArrayQueue<T>
    {
        private T[] items;
        private int size;
        private int head;
        private int tail;

        public MyArrayQueue(int capacity)
        {
            this.items = new T[capacity];
            this.size = 0;
            this.head = this.tail = 0;
        }

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="item">入队元素</param>
        public void EnQueue(T item)
        {
            if (Size == items.Length)
            {
                // 扩大数组容量
                ResizeCapacity(items.Length * 2);
            }

            items[tail] = item;
            tail++;
            
            size++;
        }

        /// <summary>v 
        /// 出队
        /// </summary>
        /// <returns>出队元素</returns>
        public T DeQueue()
        {
            if (Size == 0)
            {
                return default(T);
            }

            T item = items[head];
            items[head] = default(T);
            head++;
            
            if (head > 0 && Size == items.Length / 4)
            {
                // 缩小数组容量
                ResizeCapacity(items.Length / 2);
            }

            size--;
            return item;
        }

        /// <summary>
        /// 重置数组大小
        /// </summary>
        /// <param name="newCapacity">新的容量</param>
        private void ResizeCapacity(int newCapacity)
        {
            T[] newItems = new T[newCapacity];
            int index = 0;
            if (newCapacity > items.Length)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    newItems[index++] = items[i];
                }
            }
            else
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if (!items[i].Equals(default(T)))
                    {
                        newItems[index++] = items[i];
                    }
                }

                head = tail = 0;
            }

            items = newItems;
        }

        /// <summary>
        /// 栈是否为空
        /// </summary>
        /// <returns>true/false</returns>
        public bool IsEmpty()
        {
            return this.size == 0;
        }

        /// <summary>
        /// 栈中节点个数
        /// </summary>
        public int Size
        {
            get
            {
                return this.size;
            }
        }
    }
}
