using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace DavidMeeting
{
    /// <summary>
    /// 学生类
    /// </summary>
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }

    /// <summary>
    /// 顺序表
    /// </summary>
    public class SeqListType<T>
    {
        /// <summary>
        /// 初始化长度
        /// </summary>
        private const int maxSize = 100;

        /// <summary>
        /// 返回最大长度
        /// </summary>
        public int MaxSize { get { return maxSize; } }

        /// <summary>
        /// 顺序表长度
        /// </summary>
        public int ListLength { get; set; }

        /// <summary>
        /// 初始化数组长度
        /// </summary>
        public T[] ListData = new T[maxSize];
    }

    public class LinearList
    {
        /// <summary>
        /// 初始化列表
        /// </summary>
        public void LinearListInit<T>(SeqListType<T> list)
        {
            list.ListLength = 0;
        }

        /// <summary>
        /// 获取初始化表格的长度
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public int GetLinearListLen<T>(SeqListType<T> list)
        {
            return list.ListLength;
        }

        /// <summary>
        /// 顺序表添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool LinearListAdd<T>(SeqListType<T> list, T obj)
        {
            if (list.ListLength == list.MaxSize)
                return false;

            list.ListData[list.ListLength++] = obj;
            return true;
        }

        /// <summary>
        /// 顺序表添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="n"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool LinearListInsert<T>(SeqListType<T> list, int n, T data)
        {
            if (n < 0 || n > list.ListLength - 1)
                return false;

            if (list.ListLength == list.MaxSize)
                return false;

            for (int i = list.ListLength - 1; i >= n; i--)
            {
                list.ListData[i + 1] = list.ListData[i];
            }

            list.ListData[n] = data;
            list.ListLength++;
            return true;
        }

        /// <summary>
        /// 顺序表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool LinearListDelete<T>(SeqListType<T> list, int n)
        {
            if (n < 0 || n > list.ListLength - 1)
                return false;

            if (list.ListLength == list.MaxSize)
                return false;

            for (int i = n; i < list.ListLength; i++)
            {
                list.ListData[n] = list.ListData[n + 1];
            }

            --list.ListLength;
            return true;
        }

        /// <summary>
        /// 搜寻顺序表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public T LinearListSearch<T>(SeqListType<T> list, int n)
        {
            if (n < 0 || n > list.ListLength - 1)
                return default(T); //泛型中对于不知道具体为值类型还是引用类型的情况下使用default(T)来初始化

            return list.ListData[n];
        }

        /// <summary>
        /// 泛型根据Key查找
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="W"></typeparam>
        /// <param name="list"></param>
        /// <param name="key"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public T LinearListSearchByKey<T, W>(SeqListType<T> list, string key, Func<T, W> where) where W : IComparable
        {
            for (int i = 0; i < list.ListLength; i++)
            {
                if (where(list.ListData[i]).CompareTo(key) == 0)
                {
                    return list.ListData[i];
                }
            }

            return default(T);
        }
    }

    /// <summary>
    /// 单链表
    /// </summary>
    public class LinkList
    {
        /// <summary>
        /// 新增节点至最后一个位置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="head"></param>
        /// <param name="tempData"></param>
        /// <returns></returns>
        public Node<T> LinkListAddToEnd<T>(Node<T> head, T tempData)
        {
            Node<T> node = new Node<T>()
            {
                data = tempData,
                next = null
            };

            if (head == null)
            {
                head = node;
                return head;
            }

            Node<T> lastNode = GetLastNdoe<T>(head);

            lastNode.next = node;
            return head;
        }

        /// <summary>
        /// 添加头结点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="head"></param>
        /// <param name="tempData"></param>
        /// <returns></returns>
        public Node<T> LinkListAddToFirst<T>(Node<T> head, T tempData)
        {
            Node<T> node = new Node<T>()
            {
                data = tempData,
                next = head
            };

            head = node;

            return head;
        }

        /// <summary>
        /// 将链表插入到某个位置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="W"></typeparam>
        /// <param name="head"></param>
        /// <param name="key"></param>
        /// <param name="where"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public Node<T> LinkListInsert<T, W>(Node<T> head, string key, Func<T, W> where, T tempData) where W : IComparable
        {
            if (head == null)
                return null;

            if (where(head.data).CompareTo(key) == 0)
            {
                Node<T> node = new Node<T>();
                node.data = tempData;
                node.next = head.next;

                head.next = node;
            }

            LinkListInsert(head.next, key, where, tempData);

            return head;
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="W"></typeparam>
        /// <param name="head"></param>
        /// <param name="key"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public Node<T> LinkListDelete<T, W>(Node<T> head, string key, Func<T, W> where) where W : IComparable
        {
            if (head == null)
                return null;

            //针对只有一个节点
            if (where(head.data).CompareTo(key) == 0)
            {
                if (head.next != null)
                    head = head.next;
                else
                    return head = null;
            }
            else
            {
                while (head.next != null && where(head.next.data).CompareTo(key) == 0)
                {
                    head.next = head.next.next;
                }
            }

            return LinkListDelete(head, key, where);
        }

        /// <summary>
        /// 根据关键词查找KEY
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="W"></typeparam>
        /// <param name="head"></param>
        /// <param name="key"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public Node<T> LinkListSearchByKey<T, W>(Node<T> head, string key, Func<T, W> where) where W : IComparable
        {
            if (head == null)
                return null;

            if (where(head.data).CompareTo(key) == 0)
            {
                return head;
            }

            return LinkListSearchByKey(head.next, key, where);
        }

        /// <summary>
        /// 获取链表长度
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="head"></param>
        /// <returns></returns>
        public int LinkListLength<T>(Node<T> head)
        {
            int count = 0;
            while (head != null)
            {
                count++;
                //LinkListLength(head.next);
                head = head.next;
            }

            return count;
        }

        /// <summary>
        /// 找到最后一个节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="head"></param>
        /// <returns></returns>
        private Node<T> GetLastNdoe<T>(Node<T> head)
        {
            if (head.next == null)
                return head;

            return GetLastNdoe<T>(head.next);
        }
    }

    /// <summary>
    /// 节点类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        public T data { get; set; }

        public Node<T> next { get; set; }
    }
}
