using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobey.DataStructure.Stack
{
    /// <summary>
    /// 基于数组的栈实现
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public class MyArrayStack<T>
    {
        private T[] nodes;
        private int index;

        public MyArrayStack(int capacity)
        {
            this.nodes = new T[capacity];
            this.index = 0;
        }

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="node">节点元素</param>
        public void Push(T node)
        {
            if (index == nodes.Length)
            {
                // 增大数组容量
                ResizeCapacity(nodes.Length * 2);
            }

            nodes[index] = node;
            index++;
        }

        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns>出栈节点元素</returns>
        public T Pop()
        {
            if(index == 0)
            {
                return default(T);
            }

            T node = nodes[index - 1];
            index--;
            nodes[index] = default(T);

            if (index > 0 && index == nodes.Length / 4)
            {
                // 缩小数组容量
                ResizeCapacity(nodes.Length / 2);
            }
            return node;
        }

        /// <summary>
        /// 重置数组大小
        /// </summary>
        /// <param name="newCapacity">新的容量</param>
        private void ResizeCapacity(int newCapacity)
        {
            T[] newNodes = new T[newCapacity];
            if(newCapacity > nodes.Length)
            {
                for (int i = 0; i < nodes.Length; i++)
                {
                    newNodes[i] = nodes[i];
                }
            }
            else
            {
                for (int i = 0; i < newCapacity; i++)
                {
                    newNodes[i] = nodes[i];
                }
            }

            nodes = newNodes;
        }

        /// <summary>
        /// 栈是否为空
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
