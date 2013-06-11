using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DavidMeeting
{
    /// <summary>
    /// 算法排序类
    /// </summary>
    public class AlgorithmSort
    {
        #region 私有变量

        public delegate int[] SortAlgorithm(int[] arr, bool hasStep);
        public delegate void ExecuteSortMethodHandler(SortAlgorithm sortMethod, int[] arr, bool hasStep, SortTypeEnum typeEnum);
        private int[] testArr;

        #endregion

        #region 构造方法

        public AlgorithmSort() { }

        #endregion

        #region 七个基本排序

        /// <summary>
        /// 冒泡排序-长度为N的数组总排序次数N-1,内部循环比较次数N-1次
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] BubbleSort(int[] arr, bool hasStep)
        {
            int temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
                if (hasStep)
                    PrintSingeStepArray(i + 1, arr);
            }

            return arr;
        }

        /// <summary>
        /// 重载该方法方便使用委托调用
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="hasStep"></param>
        /// <returns></returns>
        public int[] QuickSort(int[] arr, bool hasStep)
        {
            return QuickSort(arr, 0, arr.Length - 1);
        }

        /// <summary>
        /// 快速排序-分治思想，先从右边开始找比基准数小的放到左边，在找比从左边开始找比基准数大的放到右边
        /// 然后当左右索引相等填充基准数，然后在递归执行左半部分和右半部直到两边都只剩下一个数
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] QuickSort(int[] arr, int left, int right)
        {
            //初始化基准数一般取第一个
            if (left < right)
            {
                int i = left, j = right, pivot = arr[left];
                while (i < j)
                {
                    while (i < j && arr[j] >= pivot)
                    {
                        j--;
                    }

                    if (i < j)
                    {
                        arr[i] = arr[j];
                        i++;
                    }

                    while (i < j && arr[i] <= pivot)
                    {
                        i++;
                    }

                    if (i < j)
                    {
                        arr[j] = arr[i];
                        j--;
                    }
                }
                arr[i] = pivot;
                QuickSort(arr, left, i - 1);
                QuickSort(arr, i + 1, right);
            }

            return arr;
        }

        /// <summary>
        /// 确定快排分割索引
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public int Division(List<int> arr, int left, int right)
        {
            int baseNum = arr[left];
            while (left < right)
            {
                //从右边开始找比基准数小的数丢到左边
                while (left < right && arr[right] >= baseNum)
                    right = right - 1;

                arr[left] = arr[right];

                //从左边开始找比基准数大的丢到右边
                while (left < right && arr[left] <= baseNum)
                    left = left + 1;

                arr[right] = arr[left];
            }
            arr[left] = baseNum;

            return left;
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="list"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public int[] QuickSort(List<int> list, int left, int right)
        {
            if (left < right)
            {
                int index = Division(list, left, right);
                QuickSort(list, left, index - 1);
                QuickSort(list, index + 1, right);
            }

            return list.ToArray();
        }

        /// <summary>
        /// 快速排序法
        /// </summary>
        /// <param name="arr"></param>
        public int[] SelectSort(int[] arr, bool hasStep)
        {
            int temp = 0; ;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int min = i;
                //查找数组中最小的元素
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                        min = j;
                }
                //如果最小值不在当前需要排的位置上需要进行交换
                if (i != min)
                {
                    temp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = temp;
                }
                if (hasStep)
                    PrintSingeStepArray(i + 1, arr);
            }
            return arr;
        }

        /// <summary>
        /// 插入排序，从前2个开始比较，然后每次比较将对应的数值插入对应位置
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="hasStep"></param>
        /// <returns></returns>
        public int[] InsertSort(int[] arr, bool hasStep)
        {
            //无序数组
            for (int i = 1; i < arr.Length; i++)
            {
                int temp = arr[i];
                int j;
                //有序组
                for (j = i - 1; j >= 0 && temp < arr[j]; j--)
                {
                    arr[j + 1] = arr[j];
                }

                #region 另一种写法

                //int j = i - 1;
                //while (j >= 0 && temp < arr[j])
                //{
                //    arr[j + 1] = arr[j];
                //    j--;
                //}

                #endregion

                arr[j + 1] = temp;

                if (hasStep)
                    PrintSingeStepArray(i + 1, arr);
            }

            return arr;
        }

        /// <summary>
        /// 堆调整
        /// </summary>
        /// <param name="arrLs"></param>
        /// <param name="parent"></param>
        /// <param name="length"></param>
        public void HeapAjust(int[] arrLs, int parent, int length)
        {
            //存取父亲节点
            int temp = arrLs[parent];

            int child = parent * 2 + 1;

            while (child < length)
            {
                //如果拥有右孩子，比较左右孩子取得较大的那个准备交换节点
                if (child + 1 < length && arrLs[child] < arrLs[child + 1])
                    child++;

                if (temp > arrLs[child])
                    break;

                arrLs[parent] = arrLs[child];

                //然后将子节点赋值给父节点，已防止根堆被破坏时重新构造堆
                parent = child;

                child = parent * 2 + 1;
            }

            arrLs[parent] = temp;
        }

        /// <summary>
        /// 堆排序
        /// </summary>
        /// <param name="arrLs"></param>
        /// <returns></returns>
        public int[] HeapSort(int[] arrLs, bool hasStep)
        {
            for (int index = arrLs.Length / 2 - 1; index >= 0; index--)
            {
                HeapAjust(arrLs, index, arrLs.Length);
            }

            for (int i = arrLs.Length - 1; i > 0; i--)
            {
                int temp = arrLs[0];
                arrLs[0] = arrLs[i];
                arrLs[i] = temp;

                if (hasStep)
                    PrintSingeStepArray(arrLs.Length - i, arrLs);

                HeapAjust(arrLs, 0, i);
            }

            return arrLs;
        }

        /// <summary>
        /// 希尔排序法-减小增量排序法
        /// </summary>
        /// <param name="arrLs"></param>
        /// <param name="hasStep"></param>
        /// <returns></returns>
        public int[] ShellSort(int[] arrLs, bool hasStep)
        {
            //增量的取法每次取一半
            int step = arrLs.Length / 2;

            while (step >= 1)
            {
                for (int i = step; i < arrLs.Length; i++)
                {
                    int temp = arrLs[i]; //a[3]
                    int j;
                    for (j = i - step; j >= 0 && temp < arrLs[j]; j = j - step)
                    {
                        arrLs[j + step] = arrLs[j]; //a[0]->a[3]
                    }

                    arrLs[j + step] = temp;
                }

                step = step / 2;

            }

            return arrLs;
        }

        /// <summary>
        /// 打印数组
        /// </summary>
        /// <param name="sortedArr"></param>
        /// <param name="hasSperateLine">是否有分割线</param>
        public void PrintArray(int[] sortedArr, bool hasSperateLine)
        {
            Console.WriteLine(string.Join(",", sortedArr));
            if (hasSperateLine)
                Console.WriteLine("------------分割线-----------");
        }

        /// <summary>
        /// 但应单步排序
        /// </summary>
        /// <param name="sortedArr"></param>
        private void PrintSingeStepArray(int i, int[] sortedArr)
        {
            Console.WriteLine("第{0}步排序结果:\n", i);
            PrintArray(sortedArr, false);
        }

        /// <summary>
        /// 执行排序方法
        /// </summary>
        /// <param name="sortMethod"></param>
        /// <param name="arr"></param>
        /// <param name="hasStep"></param>
        /// <param name="typeEnum"></param>
        public void ExecuteSortMethod(SortAlgorithm sortMethod, int[] arr, bool hasStep, SortTypeEnum typeEnum)
        {

            Console.WriteLine("---------{0}----------", typeEnum.ToString());
            Console.WriteLine("排序前：\n");
            PrintArray(arr, hasStep);
            testArr = sortMethod(arr, hasStep);
            Console.WriteLine("排序后：\n");
            PrintArray(testArr, hasStep);
        }

        #endregion        
    }

    /// <summary>
    /// 排序类型枚举
    /// </summary>
    [Serializable]
    public enum SortTypeEnum
    {
        冒泡排序 = 0,
        快速排序,
        选择排序,
        插入排序,
        根堆排序,
        希尔排序
    }
}
