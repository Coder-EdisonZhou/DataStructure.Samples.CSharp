using System;
using System.Collections.Generic;
using System.Text;

namespace Sobey.DataStructure.Sorting
{
    public static class SortingHelper<T> where T : IComparable
    {
        #region 1.1 直接插入排序
        /// <summary>
        /// 普通版直接插入排序
        /// </summary>
        /// <param name="arr">待排序数组</param>
        public static void StraightInsertSort(T[] arr)
        {
            int i, j;
            T temp;

            for (i = 1; i < arr.Length; i++)
            {
                j = i - 1;
                temp = arr[i];

                while (j >= 0 && temp.CompareTo(arr[j]) < 0)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = temp;
            }
        }

        /// <summary>
        /// 加入哨兵版直接插入排序
        /// </summary>
        /// <param name="arr">待排序数组</param>
        public static void StraightInsertSortWithSentry
(T[] arr)
        {
            int i, j;

            for (i = 1; i < arr.Length; i++)
            {
                j = i - 1;
                arr[0] = arr[i]; // 将插入元素存放于监哨arr[0]中

                while (arr[0].CompareTo(arr[j]) < 0)
                {
                    arr[j + 1] = arr[j]; // 移动记录
                    j--;
                }

                arr[j + 1] = arr[0]; // 将插入元素插入到合适的位置
            }
        }
        #endregion

        #region 1.2 希尔排序
        public static void ShellSort(T[] arr)
        {
            int i, j, d;
            T temp;

            for (d = arr.Length / 2; d >= 1; d = d / 2)
            {
                for (i = d; i < arr.Length; i++)
                {
                    j = i - d;
                    temp = arr[i];

                    while (j >= 0 && temp.CompareTo(arr[j]) < 0)
                    {
                        arr[j + d] = arr[j];
                        j = j - d;
                    }

                    arr[j + d] = temp;
                }
            }
        }
        #endregion

        #region 1.3 冒泡排序
        public static void BubbleSort(T[] arr)
        {
            int i, j;
            T temp;
            bool isExchanged = true;

            for (j = 1; j < arr.Length && isExchanged; j++)
            {
                isExchanged = false;
                for (i = 0; i < arr.Length - j; i++)
                {
                    if (arr[i].CompareTo(arr[i + 1]) > 0)
                    {
                        // 核心操作：交换两个元素
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        // 附加操作：改变标志
                        isExchanged = true;
                    }
                }
            }
        }

        public static void BubbleSort(T[] arr, Comparison<T> comp)
        {
            int i, j;
            T temp;
            bool isExchanged = true;

            for (j = 1; j < arr.Length && isExchanged; j++)
            {
                isExchanged = false;
                for (i = 0; i < arr.Length - j; i++)
                {
                    if (comp(arr[i], arr[i + 1]) > 0)
                    {
                        // 核心操作：交换两个元素
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        // 附加操作：改变标志
                        isExchanged = true;
                    }
                }
            }
        }
        #endregion

        #region 1.4 快速排序
        public static void QuickSort(T[] arr, int low, int high)
        {
            if (low < high)
            {
                int index = Partition(arr, low, high);
                // 对左区间递归排序
                QuickSort(arr, low, index - 1);
                // 对右区间递归排序
                QuickSort(arr, index + 1, high);
            }
        }

        private static int Partition(T[] arr, int low, int high)
        {
            int i = low, j = high;
            T temp = arr[i]; // 确定第一个元素作为"基准值"

            while (i < j)
            {
                // Stage1:从右向左扫描直到找到比基准值小的元素
                while (i < j && arr[j].CompareTo(temp) >= 0)
                {
                    j--;
                }
                // 将比基准值小的元素移动到基准值的左端
                arr[i] = arr[j];

                // Stage2:从左向右扫描直到找到比基准值大的元素
                while (i < j && arr[i].CompareTo(temp) <= 0)
                {
                    i++;
                }
                // 将比基准值大的元素移动到基准值的右端
                arr[j] = arr[i];
            }

            // 记录归位
            arr[i] = temp;

            return i;
        }
        #endregion

        #region 1.5 简单选择排序
        public static void SimpleSelectSort(T[] arr)
        {
            int i, j, k;
            T temp;

            for (i = 0; i < arr.Length - 1; i++)
            {
                k = i; // k用于记录每一趟排序中最小元素的索引号
                for (j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j].CompareTo(arr[k]) < 0)
                    {
                        k = j;
                    }
                }

                if (k != i)
                {
                    // 交换arr[k]和arr[i]
                    temp = arr[k];
                    arr[k] = arr[i];
                    arr[i] = temp;
                }
            }
        }
        #endregion

        #region 1.6 堆排序
        public static void HeapSort(T[] arr)
        {
            int n = arr.Length; // 获取序列的长度
            // 构造初始堆
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Sift(arr, i, n - 1);
            }
            // 进行堆排序
            T temp;
            for (int i = n - 1; i >= 1; i--)
            {
                temp = arr[0];       // 获取堆顶元素
                arr[0] = arr[i];     // 将堆中最后一个元素移动到堆顶
                arr[i] = temp;       // 最大元素归位,下一次不会再参与计算

                Sift(arr, 0, i - 1); // 重新递归调整堆
            }
        }

        private static void Sift(T[] arr, int low, int high)
        {
            // i为欲调整子树的根节点索引号，j为这个节点的左孩子
            int i = low, j = 2 * i + 1;
            // temp记录根节点的值
            T temp = arr[i];

            while (j <= high)
            {
                // 如果左孩子小于右孩子，则将要交换的孩子节点指向右孩子
                if (j < high && arr[j].CompareTo(arr[j + 1]) < 0)
                {
                    j++;
                }
                // 如果根节点小于它的孩子节点
                if (temp.CompareTo(arr[j]) < 0)
                {
                    arr[i] = arr[j]; // 交换根节点与其孩子节点
                    i = j;  // 以交换后的孩子节点作为根节点继续调整其子树
                    j = 2 * i + 1;  // j指向交换后的孩子节点的左孩子
                }
                else
                {
                    // 调整完毕，可以直接退出
                    break;
                }
            }
            // 使最初被调整的节点存入正确的位置
            arr[i] = temp;
        }
        #endregion

        #region 1.7 二路归并排序
        public static void MergeSort(T[] arr, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                MergeSort(arr, low, mid);       // 归并左边的子序列（递归）
                MergeSort(arr, mid + 1, high);  // 归并右边的子序列（递归）
                Merge(arr, low, mid, high);     // 归并当前前序列
            }
        }

        private static void Merge(T[] arr, int low, int mid, int high)
        {
            // result为临时空间，用于存放合并后的序列
            T[] result = new T[high - low + 1];
            int i = low, j = mid + 1, k = 0;
            // 合并两个子序列
            while (i <= mid && j <= high)
            {
                if (arr[i].CompareTo(arr[j]) < 0)
                {
                    result[k++] = arr[i++];
                }
                else
                {
                    result[k++] = arr[j++];
                }
            }
            // 将左边子序列的剩余部分复制到合并后的序列
            while (i <= mid)
            {
                result[k++] = arr[i++];
            }
            // 将右边子序列的剩余部分复制到合并后的序列
            while (j <= high)
            {
                result[k++] = arr[j++];
            }
            // 将合并后的序列覆盖合并前的序列
            for (k = 0, i = low; i <= high; k++, i++)
            {
                arr[i] = result[k];
            }
        }
        #endregion
    }
}
