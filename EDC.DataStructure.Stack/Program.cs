using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDC.DataStructure.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            // 01.基于链表的栈
            //StackWithLinkListTest();
            // 02.基于数组的栈
            //StackWithArrayTest();
            // 03.进制转换问题
            NumberConvertTest();

            Console.ReadKey();
        }

        #region Method01.基于链表的栈的测试
        /// <summary>
        /// 基于链表的栈的测试
        /// </summary>
        static void StackWithLinkListTest()
        {
            MyLinkStack<int> stack = new MyLinkStack<int>();
            Console.WriteLine("IsEmpty:{0}", stack.IsEmpty());

            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(rand.Next(1, 10));
            }
            Console.WriteLine("IsEmpty:{0}", stack.IsEmpty());
            Console.WriteLine("Size:{0}", stack.Size);
            Console.WriteLine("-------------------------------");

            for (int i = 0; i < 10; i++)
            {
                int node = stack.Pop();
                Console.Write(node + " ");
            }
            Console.WriteLine();
            Console.WriteLine("IsEmpty:{0}", stack.IsEmpty());
            Console.WriteLine("Size:{0}", stack.Size);
            Console.WriteLine("-------------------------------");

            for (int i = 0; i < 15; i++)
            {
                stack.Push(rand.Next(1, 15));
            }
            for (int i = 0; i < 15; i++)
            {
                int node = stack.Pop();
                Console.Write(node + " ");
            }
            Console.WriteLine();
        }
        #endregion

        #region Method02.基于数组的栈的测试
        /// <summary>
        /// 基于数组的栈的测试
        /// </summary>
        static void StackWithArrayTest()
        {
            MyArrayStack<int> stack = new MyArrayStack<int>(10);
            Console.WriteLine("IsEmpty:{0}", stack.IsEmpty());

            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(rand.Next(1, 10));
            }
            Console.WriteLine("IsEmpty:{0}", stack.IsEmpty());
            Console.WriteLine("Size:{0}", stack.Size);
            Console.WriteLine("-------------------------------");

            for (int i = 0; i < 10; i++)
            {
                int node = stack.Pop();
                Console.Write(node + " ");
            }
            Console.WriteLine();
            Console.WriteLine("IsEmpty:{0}", stack.IsEmpty());
            Console.WriteLine("Size:{0}", stack.Size);
            Console.WriteLine("-------------------------------");

            for (int i = 0; i < 15; i++)
            {
                stack.Push(rand.Next(1, 15));
            }
            for (int i = 0; i < 15; i++)
            {
                int node = stack.Pop();
                Console.Write(node + " ");
            }
            Console.WriteLine();
        }
        #endregion

        #region Method03:进制转换问题
        static void NumberConvertTest()
        {
            Console.WriteLine("请先输入要转换的十进制数：");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请再输入要转换的进制：(2进制、8进制、16进制)");
            int dec = Convert.ToInt32(Console.ReadLine());

            string result = DecConvert(num, dec);
            if (string.IsNullOrEmpty(result))
            {
                Console.WriteLine("#_#:转换出错，请重新再试！");
            }
            else
            {
                Console.WriteLine("^_^:({0})=({1})", num.ToString(), result);
            }
        }

        private static string DecConvert(int num, int dec)
        {
            if (dec < 2 || dec > 16)
            {
                throw new ArgumentOutOfRangeException("dec", "只支持将十进制数转换为二进制到十六进制数");
            }

            MyLinkStack<char> stack = new MyLinkStack<char>();
            int residue;
            // 余数入栈
            while (num != 0)
            {
                residue = num % dec;
                if (residue >= 10)
                {
                    // 如果是转换为16进制且余数大于10则需要转换为ABCDEF
                    residue = residue + 55;
                }
                else
                {
                    // 转换为ASCII码中的数字型字符1~9
                    residue = residue + 48;
                }
                stack.Push((char)residue);
                num = num / dec;
            }
            // 反序出栈
            string result = string.Empty;
            while (stack.Size > 0)
            {
                result += stack.Pop();
            }

            return result;
        }
        #endregion
    }
}
