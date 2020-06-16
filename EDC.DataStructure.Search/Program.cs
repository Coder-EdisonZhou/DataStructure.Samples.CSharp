using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDC.DataStructure.Search
{
    class Program
    {
        static void Main(string[] args)
        {
            //SequenceSearchDemo();
            //SeqSearchDemo();
            //ArrayBinarySearchDemo();
            //SortedListDemo();

            //SortedAddInTest();
            //SortedQueryInTest();
            SortedDeleteInTest();

            Console.ReadKey();
        }

        #region 00.顺序查找
        static void SequenceSearchDemo()
        {
            int[] seqList = { 2, 8, 10, 13, 21, 36, 51, 57, 62, 69 };

            Console.WriteLine("-------------基本顺序查找-------------");
            Console.WriteLine("查找51：{0}", SequenceSearch(seqList, 51));
            Console.WriteLine("查找8：{0}", SequenceSearch(seqList, 8));
            Console.WriteLine("查找15：{0}", SequenceSearch(seqList, 15));
        }

        static int SequenceSearch(int[] seqList, int key)
        {
            int index = -1;
            for (int i = 0; i < seqList.Length; i++)
            {
                if (seqList[i] == key)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
        #endregion

        #region 01.普通二分查找示例
        static void SeqSearchDemo()
        {
            int[] seqList = { 2, 8, 10, 13, 21, 36, 51, 57, 62, 69 };

            Console.WriteLine("-------------基本二分查找-------------");
            Console.WriteLine("查找51：{0}", SeqSearch(seqList, 51));
            Console.WriteLine("查找8：{0}", SeqSearch(seqList, 8));
            Console.WriteLine("查找15：{0}", SeqSearch(seqList, 15));
        }

        static int SeqSearch(int[] seqList, int key)
        {
            int low = 0;
            int high = seqList.Length - 1;
            int mid;

            while (low <= high)
            {
                mid = (low + high) / 2;
                if (seqList[mid] == key)
                {
                    return mid;
                }
                else if (seqList[mid] < key)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return -1;
        }
        #endregion

        #region 02.使用Array.BinarySearch进行二分查找
        static void ArrayBinarySearchDemo()
        {
            int[] seqList = { 32, 25, 8, 10, 13, 21, 36, 51, 57, 62, 69 };

            Console.WriteLine("-------------Array.BinarySearch-------------");
            Array.Sort(seqList);
            Console.WriteLine("查找51：{0}", Array.BinarySearch(seqList, 51));
            Console.WriteLine("查找69：{0}", Array.BinarySearch(seqList, 69));
            Console.WriteLine("查找15：{0}", Array.BinarySearch(seqList, 15));
            // Array.BinarySearch内部求mid值的公式为：mid=low+((high-low)>>1)
            // 整数右移一位相当于整数除2操作，但位移运算的速度快于除法运算
        }
        #endregion

        #region 03.使用SortedList进行数据存储：内部使用二分查找插入位置
        static void SortedListDemo()
        {
            SortedList<string, string> studentList = new SortedList<string, string>();
            studentList.Add("005", "张三");
            studentList.Add("004", "李四");
            studentList.Add("006", "王五");
            studentList.Add("012", "马六");
            studentList.Add("002", "钱七");
            studentList.Add("009", "刘八");

            foreach (var item in studentList)
            {
                Console.WriteLine("{0}:{1}", item.Key, item.Value);
            }
        }
        #endregion

        #region 04.使用SortedDictionary进行数据存储：内部是红黑树结构
        static void SortedDictionaryTest()
        {
            Random random = new Random();
            int array_count = 100000;
            List<int> intList = new List<int>();
            for (int i = 0; i <= array_count; i++)
            {
                int ran = random.Next();
                intList.Add(ran);
            }

            SortedDictionary<int, int> dic_int = new SortedDictionary<int, int>();
            foreach (var item in intList)
            {
                if (dic_int.ContainsKey(item) == false)
                {
                    dic_int.Add(item, item);
                }
            }
        }
        #endregion

        #region 05.SortedList与SortedDictionary的对比测试
        static void SortedAddInTest()
        {
            Random random = new Random();
            int array_count = 100000;
            List<int> intList = new List<int>();
            for (int i = 0; i <= array_count; i++)
            {
                int ran = random.Next();
                intList.Add(ran);
            }

            SortedList<int, string> sortedlist_int = new SortedList<int, string>();
            SortedDictionary<int, string> dic_int = new SortedDictionary<int, string>();
            CodeTimer.Time("sortedList_Add_int", 1, () =>
            {
                foreach (var item in intList)
                {
                    if (sortedlist_int.ContainsKey(item) == false)
                        sortedlist_int.Add(item, "test" + item.ToString());
                }
            });
            CodeTimer.Time("sortedDictionary_Add_int", 1, () =>
            {
                foreach (var item in intList)
                {
                    if (dic_int.ContainsKey(item) == false)
                        dic_int.Add(item, "test" + item.ToString());
                }
            });
        }

        static void SortedQueryInTest()
        {
            Random random = new Random();
            int array_count = 100000;
            List<int> intList = new List<int>();
            for (int i = 0; i <= array_count; i++)
            {
                int ran = random.Next();
                intList.Add(ran);
            }

            SortedList<int, string> sortedlist_int = new SortedList<int, string>();
            SortedDictionary<int, string> dic_int = new SortedDictionary<int, string>();

            foreach (var item in intList)
            {
                if (sortedlist_int.ContainsKey(item) == false)
                    sortedlist_int.Add(item, "test" + item.ToString());
            }

            foreach (var item in intList)
            {
                if (dic_int.ContainsKey(item) == false)
                    dic_int.Add(item, "test" + item.ToString());
            }

            CodeTimer.Time("sortedList_Search_int", 1, () =>
            {
                foreach (var item in intList)
                {
                    sortedlist_int.ContainsKey(item);
                }
            });

            CodeTimer.Time("sortedDictionary_Search_int", 1, () =>
            {
                foreach (var item in intList)
                {
                    dic_int.ContainsKey(item);
                }
            });
        }

        static void SortedDeleteInTest()
        {
            Random random = new Random();
            int array_count = 100000;
            List<int> intList = new List<int>();
            for (int i = 0; i <= array_count; i++)
            {
                int ran = random.Next();
                intList.Add(ran);
            }

            SortedList<int, string> sortedlist_int = new SortedList<int, string>();
            SortedDictionary<int, string> dic_int = new SortedDictionary<int, string>();

            foreach (var item in intList)
            {
                if (sortedlist_int.ContainsKey(item) == false)
                    sortedlist_int.Add(item, "test" + item.ToString());
            }

            foreach (var item in intList)
            {
                if (dic_int.ContainsKey(item) == false)
                    dic_int.Add(item, "test" + item.ToString());
            }

            CodeTimer.Time("sortedList_Delete_String", 1, () =>
            {
                foreach (var item in intList)
                {
                    sortedlist_int.Remove(item);
                }
            });

            CodeTimer.Time("sortedDictionary_Delete_String", 1, () =>
            {
                foreach (var item in intList)
                {
                    dic_int.Remove(item);
                }
            });
        }
        #endregion
    }
}
