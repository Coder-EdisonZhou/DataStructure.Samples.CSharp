using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobey.DataStructure.Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            // 01.基于链表的队列
            QueueWithLinkListTest();
            // 02.基于数组的队列
            //QueueWithArrayTest();

            Console.ReadKey();
        }

        #region Method01.基于链表的队列的测试
        /// <summary>
        /// 基于链表的队列的测试
        /// </summary>
        static void QueueWithLinkListTest()
        {
            MyLinkQueue<int> queue = new MyLinkQueue<int>();
            Console.WriteLine("Is Empty:{0}", queue.IsEmpty());
            Random rand = new Random();
            // 顺序插入5个元素
            for (int i = 0; i < 5; i++)
            {
                int num = rand.Next(1, 10);
                queue.EnQueue(num);
                Console.WriteLine("{0} enqueue.", num);
            }
            Console.WriteLine("Size:{0}", queue.Size);
            Console.WriteLine("-------------------------");
            // 5个元素依次出队
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("{0} dequeue.", queue.DeQueue());
            }
            Console.WriteLine("Size:{0}", queue.Size);
            Console.WriteLine("-------------------------");
            // 顺序插入10个元素
            for (int i = 0; i < 10; i++)
            {
                int num = rand.Next(1, 10);
                queue.EnQueue(num);
                Console.WriteLine("{0} enqueue.", num);
            }
            Console.WriteLine("Size:{0}", queue.Size);
            Console.WriteLine("-------------------------");
            // 10个元素依次出队
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0} dequeue.", queue.DeQueue());
            }
            Console.WriteLine("Size:{0}", queue.Size);
        }
        #endregion

        #region Method02.基于数组的队列的测试
        /// <summary>
        /// 基于数组的队列的测试
        /// </summary>
        static void QueueWithArrayTest()
        {
            MyArrayQueue<int> queue = new MyArrayQueue<int>(5);
            Console.WriteLine("Is Empty:{0}", queue.IsEmpty());
            Console.WriteLine("Size:{0}", queue.Size);

            Random rand = new Random();
            // Test1.1:顺序插入5个数据元素
            for (int i = 0; i < 5; i++)
            {
                int num = rand.Next(1, 10);
                queue.EnQueue(num);
                Console.WriteLine("{0} enqueue.", num);
            }
            Console.WriteLine("Is Empty:{0}", queue.IsEmpty());
            Console.WriteLine("Size:{0}", queue.Size);
            // Test1.2:临时插入1个数据元素验证数组是否扩容
            queue.EnQueue(rand.Next(1,20));
            Console.WriteLine("Size:{0}", queue.Size);
            Console.WriteLine("-------------------------");
            // Test2.1:前5个元素出队
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("{0} dequeue.", queue.DeQueue());
            }
            Console.WriteLine("Is Empty:{0}", queue.IsEmpty());
            Console.WriteLine("Size:{0}", queue.Size);
            Console.WriteLine("-------------------------");
            // Test2.2:最后一个数据元素出队验证数组是否收缩容量
            queue.DeQueue();
            Console.WriteLine("Size:{0}", queue.Size);
            Console.WriteLine("-------------------------");
            queue.DeQueue();
        }
        #endregion
    }
}
