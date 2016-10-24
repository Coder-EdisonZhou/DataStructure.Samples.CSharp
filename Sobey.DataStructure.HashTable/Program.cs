using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sobey.DataStructure.HashTable.Common;
using Sobey.DataStructure.HashTable.Model;

namespace Sobey.DataStructure.HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            //StudentInfo[] arrStudent = InitialStudents();
            // 01.普通数组遍历查找
            //NormalSearch(arrStudent, "200807005");
            //Console.WriteLine("--------------------------");
            // 02.哈希函数高效查找
            //HashSearch(arrStudent, "200807005");
            //HashSearch(arrStudent, "200807001");
            // 03.Hashtable基本用法
            //HashtableTest();
            // 04.Dictionary基本用法
            //DictionaryTest();
            // 05.三种类型的测试对比
            DifferentSearchTypeTest();

            Console.ReadKey();
        }

        #region Test01:哈希概念的引入例子
        static StudentInfo[] InitialStudents()
        {
            StudentInfo[] arrStudent = {
                new StudentInfo("200807001","四川达州"),
                new StudentInfo("200807002","四川成都"),
                new StudentInfo("200807003","山东青岛"),
                new StudentInfo("200807004","河南郑州"),
                new StudentInfo("200807005","江苏徐州")
            };

            return arrStudent;
        }

        static void NormalSearch(StudentInfo[] arrStudent, string searchNumber)
        {
            bool isFind = false;
            foreach (var student in arrStudent)
            {
                if (student.Number == searchNumber)
                {
                    isFind = true;
                    Console.WriteLine("Search successfully!{0} address:{1}", searchNumber, student.Address);
                }
            }

            if (!isFind)
            {
                Console.WriteLine("Search {0} failed!", searchNumber);
            }
        }

        static int GetHashCode(string number)
        {
            string index = number.Substring(6);
            return Convert.ToInt32(index) - 1;
        }

        static void HashSearch(StudentInfo[] arrStudent, string searchNumber)
        {
            Console.WriteLine("{0} address:{1}", searchNumber, arrStudent[GetHashCode(searchNumber)].Address);
        }
        #endregion

        #region Test02:Hashtable的基本使用例子
        static void HashtableTest()
        {
            // 创建一个Hashtable实例
            Hashtable ht = new Hashtable();
            // 添加key/value键值对
            ht.Add("北京", "帝都");
            ht.Add("上海", "魔都");
            ht.Add("广州", "省会");
            ht.Add("深圳", "特区");

            // 根据key获取value
            string capital = (string)ht["北京"];
            Console.WriteLine("北京：{0}", capital);
            Console.WriteLine("--------------------");
            // 判断哈希表是否包含特定键,其返回值为true或false
            Console.WriteLine("包含上海吗？{0}", ht.Contains("上海"));
            Console.WriteLine("--------------------");
            // 移除一个key/value键值对
            ht.Remove("深圳");
            // 遍历哈希表
            foreach (DictionaryEntry de in ht)
            {
                Console.WriteLine("{0}:{1}", de.Key, de.Value);
            }
            Console.WriteLine("--------------------");
            // 移除所有元素
            ht.Clear();
            // 遍历哈希表
            foreach (DictionaryEntry de in ht)
            {
                Console.WriteLine("{0}:{1}", de.Key, de.Value);
            }
        }
        #endregion

        #region Test03:Dictionary的基本使用例子
        static void DictionaryTest()
        {
            Dictionary<string, StudentInfo> dict = new Dictionary<string, StudentInfo>();
            for (int i = 0; i < 10; i++)
            {
                StudentInfo stu = new StudentInfo()
                {
                    Number = "200807" + i.ToString().PadLeft(3, '0'),
                    Name = "Student" + i.ToString()
                };
                dict.Add(i.ToString(), stu);
            }

            // 判断是否包含某个key
            if (dict.ContainsKey("1"))
            {
                Console.WriteLine("已经存在key为{0}的键值对了，它是{1}", 1, dict["1"].Name);
            }
            Console.WriteLine("--------------------------------");
            // 遍历键值对
            foreach (var de in dict)
            {
                Console.WriteLine("Key:{0},Value:[Number:{1},Name:{2}]", de.Key, de.Value.Number, de.Value.Name);
            }
            // 移除一个键值对
            if (dict.ContainsKey("5"))
            {
                dict.Remove("5");
            }
            Console.WriteLine("--------------------------------");
            // 遍历键值对
            foreach (var de in dict)
            {
                Console.WriteLine("Key:{0},Value:[Number:{1},Name:{2}]", de.Key, de.Value.Number, de.Value.Name);
            }
            // 清空键值对
            dict.Clear();
            Console.WriteLine("--------------------------------");
            // 遍历键值对
            foreach (var de in dict)
            {
                Console.WriteLine("Key:{0},Value:[Number:{1},Name:{2}]", de.Key, de.Value.Number, de.Value.Name);
            }
        }
        #endregion

        #region Test04:三种高效查找表的测试
        static void DifferentSearchTypeTest()
        {
            int length = 1000000;
            int[] arrNumber = new int[length];
            // 首先生成有序数组进行初始化
            for (int i = 0; i < length; i++)
            {
                arrNumber[i] = i;
            }
            Random rand = new Random();
            // 随机将数组中的数字打乱顺序
            for (int i = 0; i < length; i++)
            {
                int randIndex = rand.Next(i,length);
                // 交换两个数字
                int temp = arrNumber[i];
                arrNumber[i] = arrNumber[randIndex];
                arrNumber[randIndex] = temp;
            }

            // Test1:SortedDictionary类型测试
            SortedDictionary<int, int> sd = new SortedDictionary<int, int>();
            Console.WriteLine("SortedDictionary插入测试开始：");
            CodeTimer.Time("SortedDictionary_Insert_Test", 1, () =>
            {
                for (int i = 0; i < length; i++)
                {
                    sd.Add(arrNumber[i], arrNumber[i]);
                }
            });
            Console.WriteLine("SortedDictionary插入测试结束；");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("SortedDictionary删除测试开始：");
            CodeTimer.Time("SortedDictionary_Delete_Test", 1, () =>
            {
                for (int i = 0; i < length; i++)
                {
                    sd.Remove(arrNumber[i]);
                }
            });
            Console.WriteLine("SortedDictionary删除测试结束；");
            Console.WriteLine("-----------------------------");
            // Test2:Hashtable类型测试
            Hashtable ht = new Hashtable();
            Console.WriteLine("Hashtable插入测试开始：");
            CodeTimer.Time("Hashtable_Insert_Test", 1, () =>
            {
                for (int i = 0; i < length; i++)
                {
                    ht.Add(arrNumber[i], arrNumber[i]);
                }
            });
            Console.WriteLine("Hashtable插入测试结束；");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Hashtable删除测试开始：");
            CodeTimer.Time("Hashtable_Delete_Test", 1, () =>
            {
                for (int i = 0; i < length; i++)
                {
                    ht.Remove(arrNumber[i]);
                }
            });
            Console.WriteLine("Hashtable删除测试结束；");
            Console.WriteLine("-----------------------------");
            // Test3:Dictionary类型测试
            Dictionary<int, int> dict = new Dictionary<int, int>();
            Console.WriteLine("Dictionary插入测试开始：");
            CodeTimer.Time("Dictionary_Insert_Test", 1, () =>
            {
                for (int i = 0; i < length; i++)
                {
                    dict.Add(arrNumber[i], arrNumber[i]);
                }
            });
            Console.WriteLine("Dictionary插入测试结束；");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Dictionary删除测试开始：");
            CodeTimer.Time("Dictionary_Delete_Test", 1, () =>
            {
                for (int i = 0; i < length; i++)
                {
                    dict.Remove(arrNumber[i]);
                }
            });
            Console.WriteLine("Dictionary删除测试结束；");
            Console.WriteLine("-----------------------------");
        }
        #endregion
    }
}
