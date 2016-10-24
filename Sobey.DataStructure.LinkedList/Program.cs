using System;
using System.Collections.Generic;
using System.Text;

namespace Sobey.DataStructure.LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            // 自己模拟的单链表的测试
            //MySingleLinkedListTest();
            // 自己模拟的双链表的实现
            //MyDoubleLinkedListTest();
            // .NET中的双链表的应用
            //LinkedListInDotNetTest();
            // 自己模拟的单循环链表的测试
            //MyCircularLinkedListTest();
            // 约瑟夫问题-自定义单循环链表
            //JosephusTest();
            // 约瑟夫问题-LinkedList
            JosephusTestWithLinkedList();

            Console.ReadKey();
        }

        #region Method01.自己模拟的单链表的测试
        static void MySingleLinkedListTest()
        {
            MySingleLinkedList<int> linkedList = new MySingleLinkedList<int>();
            // Test1:顺序插入4个节点
            linkedList.Add(0);
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);

            Console.WriteLine("The nodes in the linkedList:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            Console.WriteLine("----------------------------");

            // Test2.1:在索引为0(即第1个节点)的位置插入单个节点
            linkedList.Insert(0, 10);
            Console.WriteLine("After insert 10 in index of 0:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            // Test2.2:在索引为2(即第3个节点)的位置插入单个节点
            linkedList.Insert(2, 20);
            Console.WriteLine("After insert 20 in index of 2:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            // Test2.3:在索引为5（即最后一个节点）的位置插入单个节点
            linkedList.Insert(5, 30);
            Console.WriteLine("After insert 30 in index of 5:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            Console.WriteLine("----------------------------");

            // Test3.1:移除索引为5（即最后一个节点）的节点
            linkedList.RemoveAt(5);
            Console.WriteLine("After remove an node in index of 5:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            // Test3.2:移除索引为0（即第一个节点）的节点
            linkedList.RemoveAt(0);
            Console.WriteLine("After remove an node in index of 0:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            // Test3.3:移除索引为2（即第三个节点）的节点
            linkedList.RemoveAt(2);
            Console.WriteLine("After remove an node in index of 2:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            Console.WriteLine("----------------------------");
        }
        #endregion

        #region Method02.自己模拟的双链表的测试
        static void MyDoubleLinkedListTest()
        {
            MyDoubleLinkedList<int> linkedList = new MyDoubleLinkedList<int>();
            // Test1:顺序插入4个节点
            linkedList.AddAfter(0);
            linkedList.AddAfter(1);
            linkedList.AddAfter(2);
            linkedList.AddAfter(3);

            Console.WriteLine("The nodes in the DoubleLinkedList:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.Write(linkedList[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------");
            // Test2.1:在尾节点之前插入2个节点
            linkedList.AddBefore(10);
            linkedList.AddBefore(20);
            Console.WriteLine("After add 10 and 20:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.Write(linkedList[i] + " ");
            }
            Console.WriteLine();
            // Test2.2:在索引为2(即第3个节点)的位置之后插入单个节点
            linkedList.InsertAfter(2, 50);
            Console.WriteLine("After add 50:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.Write(linkedList[i] + " ");
            }
            Console.WriteLine();
            // Test2.3:在索引为2(即第3个节点)的位置之前插入单个节点
            linkedList.InsertBefore(2, 40);
            Console.WriteLine("After add 40:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.Write(linkedList[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------");
            // Test3.1:移除索引为7(即最后一个节点)的位置的节点
            linkedList.RemoveAt(7);
            Console.WriteLine("After remove an node in index of 7:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.Write(linkedList[i] + " ");
            }
            Console.WriteLine();
            // Test3.2:移除索引为0(即第一个节点)的位置的节点的值
            linkedList.RemoveAt(0);
            Console.WriteLine("After remove an node in index of 0:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.Write(linkedList[i] + " ");
            }
            Console.WriteLine();
            // Test3.3:移除索引为2(即第3个节点)的位置的节点
            linkedList.RemoveAt(2);
            Console.WriteLine("After remove an node in index of 2:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.Write(linkedList[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------");
            // Test4:修改索引为2(即第3个节点)的位置的节点的值
            linkedList[2] = 9;
            Console.WriteLine("After update the value of node in index of 2:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.Write(linkedList[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------");
        }
        #endregion

        #region Method03.系统自带双链表的测试
        static void LinkedListInDotNetTest()
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            LinkedListNode<int> firstNode = new LinkedListNode<int>(0);
            linkedList.AddFirst(firstNode);

            var secondNode = linkedList.AddAfter(firstNode, 1);
            var thirdNode = linkedList.AddAfter(secondNode, 2);
            var fourthNode = linkedList.AddAfter(thirdNode, 3);
            var fifthNode = linkedList.AddAfter(fourthNode, 4);
        }
        #endregion

        #region Method04:自己模拟的单循环链表的测试
        static void MyCircularLinkedListTest()
        {
            MyCircularLinkedList<int> linkedList = new MyCircularLinkedList<int>();
            // 顺序插入5个节点
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Add(5);

            Console.WriteLine("All nodes in the circular linked list:");
            Console.WriteLine(linkedList.GetAllNodes());
            Console.WriteLine("--------------------------------------");
            // 当前节点：第一个节点
            Console.WriteLine("Current node in the circular linked list:");
            Console.WriteLine(linkedList.CurrentItem);
            Console.WriteLine("--------------------------------------");
            // 移除当前节点(第一个节点)
            linkedList.Remove();
            Console.WriteLine("After remove the current node:");
            Console.WriteLine(linkedList.GetAllNodes());
            Console.WriteLine("Current node in the circular linked list:");
            Console.WriteLine(linkedList.CurrentItem);
            // 移除当前节点(第二个节点)
            linkedList.Remove();
            Console.WriteLine("After remove the current node:");
            Console.WriteLine(linkedList.GetAllNodes());
            Console.WriteLine("Current node in the circular linked list:");
            Console.WriteLine(linkedList.CurrentItem);
            Console.WriteLine("--------------------------------------");
        }
        #endregion

        #region Method05:约瑟夫问题-自定义循环链表
        static void JosephusTest()
        {
            MyCircularLinkedList<int> linkedList = new MyCircularLinkedList<int>();
            string result = string.Empty;

            Console.WriteLine("Step1:请输入人数N");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Step2:请输入数字M");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Step3:报数游戏开始");
            // 添加参与人员元素
            for (int i = 1; i <= n; i++)
            {
                linkedList.Add(i);
            }
            // 打印所有参与人员
            Console.Write("所有参与人员：{0}", linkedList.GetAllNodes());
            Console.Write("\r\n" + "-------------------------------------");
            result = string.Empty;

            while (linkedList.Count > 1)
            {
                // 依次报数：移动
                linkedList.Move(m);
                // 记录出队人员
                result += linkedList.CurrentItem + " ";
                // 移除人员出队
                linkedList.Remove();
                Console.WriteLine();
                Console.Write("剩余报数人员：{0}", linkedList.GetAllNodes());
                Console.Write("  开始报数人员：{0}", linkedList.CurrentItem);
            }
            Console.WriteLine("\r\n" + "Step4:报数游戏结束");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("出队人员顺序：{0}", result + linkedList.CurrentItem);
        }
        #endregion

        #region Method06:约瑟夫问题-LinkedList<T>
        static void JosephusTestWithLinkedList()
        {
            Console.WriteLine("请输入人数N");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入数字M");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("-------------------------------------");

            LinkedList<Person> linkedList = InitPersonList(n);
            // 记录开始报数人员节点
            LinkedListNode<Person> startNode = linkedList.First;
            // 记录出队人员节点
            LinkedListNode<Person> removeNode;

            Console.Write("出队顺序：");
            while(linkedList.Count >= 1)
            {
                for (int i = 1; i < m; i++)
                {
                    if (startNode != linkedList.Last)
                    {
                        startNode = startNode.Next;
                    }
                    else
                    {
                        startNode = linkedList.First;
                    }
                }
                // 记录出队人员节点
                removeNode = startNode;
                // 打印出队人员ID号
                Console.Write(removeNode.Value.Id + " ");
                // 确定下一个开始报数人员
                if (startNode == linkedList.Last)
                {
                    startNode = linkedList.First;
                }
                else
                {
                    startNode = startNode.Next;
                }
                // 移除出队人员节点
                linkedList.Remove(removeNode);
            }
            Console.WriteLine();
        }

        static LinkedList<Person> InitPersonList(int count)
        {
            LinkedList<Person> personList = new LinkedList<Person>();
            for (int i = 1; i <= count; i++)
            {
                Person person = new Person();
                person.Id = i;
                person.Name = "Counter-" + i.ToString();

                personList.AddLast(person);
            }

            return personList;
        }
        #endregion
    }
}
