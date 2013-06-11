using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DavidMeeting;
using System.Reflection;
using System.Diagnostics;
using System.Data;

namespace DavidMeeting
{
    static class Program
    {
        static void Main()
        {
            #region 比较两个类集合是否相等

            //List<TestModel> LsOne = new List<TestModel>(){new TestModel(){ Id=1,Name="aa",IsStudent=false},
            //new TestModel(){ Id=2,Name="bb",IsStudent=false},new TestModel(){ Id=3,Name="cc",IsStudent=false},
            //new TestModel(){ Id=4,Name="dd",IsStudent=false},new TestModel(){ Id=5,Name="ee",IsStudent=false}};

            //List<TestModel> LsTwo = new List<TestModel>(){new TestModel(){ Id=1,Name="aa",IsStudent=false},
            //new TestModel(){ Id=4,Name="dd",IsStudent=false},new TestModel(){ Id=2,Name="bb",IsStudent=false},
            //new TestModel(){ Id=3,Name="cc",IsStudent=false},new TestModel(){ Id=5,Name="ee",IsStudent=false}};

            //List<TestModel> LsThree = new List<TestModel>(){new TestModel(){ Id=1,Name="aa",IsStudent=false},
            //new TestModel(){ Id=2,Name="bb",IsStudent=false},new TestModel(){ Id=3,Name="cc",IsStudent=false},
            //new TestModel(){ Id=4,Name="dd",IsStudent=false},new TestModel(){ Id=5,Name="ff",IsStudent=false}};

            //List<TestModel> studnetsCommon = LsOne.Intersect(LsTwo, new TestModelListEquality()).ToList();
            //List<TestModel> studnetsCommon2 = LsOne.Intersect(LsThree, new TestModelListEquality()).ToList();

            //if (studnetsCommon.Count == LsOne.Count)
            //    Console.WriteLine(true);
            //else
            //    Console.WriteLine(false);

            //if (studnetsCommon2.Count == LsOne.Count)
            //    Console.WriteLine(true);
            //else
            //    Console.WriteLine(false);

            #endregion

            #region 构造方法顺序

            //所有静态方法都是先调用
            //b1,b3,b2,a1,a3,a2,a4,b2,b4,b5

            //BaseB baseb = new BaseB();
            //baseb.MyFun();

            #endregion

            #region 对象比较

            //var obj1 = new { id = 1, name = "david" };
            //var obj2 = new { id = 1, name = "david" };
            //var obj3 = new { id = 2, name = "david" };

            //Console.WriteLine("ob1对象是否与obj2对象相等：" + obj1.Equals(obj2));
            //Console.WriteLine("ob1对象是否与obj3对象相等：" + obj1.Equals(obj3));

            #endregion

            #region 递归应用查找并输出当前目录下的所有文件名
            //DavidTest testObj = new DavidTest();
            //string discPath = @"H:\";
            //string directoryPath = @"H:\DataTables-1.9.4";
            //string filePath = @"H:\DataTables-1.9.4\license-bsd.txt";

            //Dictionary<string, HashSet<string>> fileRecords = testObj.FindFile(filePath);
            //testObj.ShowRecords(fileRecords);
            //new DavidTest().FindFile(filePath);

            #endregion

            #region 装箱拆箱

            //int i = 2000;
            //object o = i;
            //i = 2001;
            //int j = (int)o;

            //Console.WriteLine("i={0},o={1}, j={2}", i, o, j);

            #endregion

            #region 委托和事件概念

            //常规委托使用方法相当于用委托创建一个对象然后用这个对象在进行相应的方法调用
            //DelegateTest dt = new DelegateTest();
            //DelegateTest.ShowMessage showLower = new DelegateTest.ShowMessage(dt.ShowLowerMessage);
            //showLower("david");
            //DelegateTest.ShowMessage showUpper = new DelegateTest.ShowMessage(dt.ShowUpperMessage);
            //showUpper("david");

            //事件的会怎么调用方法
            //dt.ShowMessageEventHandler += new DelegateTest.ShowMessageEvent(dt.ShowLowerHandlerMessage);
            //dt.ShowMessageEventHandler += new DelegateTest.ShowMessageEvent(dt.ShowUpperHandlerMessage);
            //dt.ShowLowerHandlerMessage("DDDDD", null);
            //dt.ShowUpperHandlerMessage("aaaaa", null);


            #endregion

            #region 常用测试
            //DavidArray.TestMixArray();
            //new LinqHelper().TestLinqQueryXml();

            //string testStr = "1,2,34,5";
            //string[] charLs = testStr.Split(',');
            //int searchIndex = new AlgorithmSearch().RecursionSearch(0, charLs, "6");
            //Console.WriteLine(searchIndex != -1 ? string.Format("被查找元素：{0}，索引下标为：{1}", charLs[searchIndex], searchIndex) : "查无此元素");
            //DavidTest.FindXmlNode();

            #endregion

            #region 排序

            AlgorithmSort sort = new AlgorithmSort();
            int[] testArr = new int[] { 9, 12, 54, 6, 13, 4, 8, 2, 1 };

            List<AlgorithmSort.SortAlgorithm> sortMethodLs = new List<AlgorithmSort.SortAlgorithm>(){
                new AlgorithmSort.SortAlgorithm(sort.BubbleSort),
                new AlgorithmSort.SortAlgorithm(sort.QuickSort),
                new AlgorithmSort.SortAlgorithm(sort.SelectSort),
                new AlgorithmSort.SortAlgorithm(sort.InsertSort),
                new AlgorithmSort.SortAlgorithm(sort.HeapSort),
                new AlgorithmSort.SortAlgorithm(sort.ShellSort)
            };

            Stopwatch stopWatch = new Stopwatch();

            //stopWatch.Start();
            //sort.ExecuteSortMethod(sortMethodLs[0], testArr, false, SortTypeEnum.冒泡排序);
            //stopWatch.Stop();
            //Console.WriteLine("{0}花费了{1}秒", SortTypeEnum.冒泡排序.ToString(), stopWatch.ElapsedMilliseconds);

            //stopWatch.Start();
            //sort.ExecuteSortMethod(sortMethodLs[1], testArr, false, SortTypeEnum.快速排序);
            //sort.PrintArray(testArr, true);
            //testArr = sort.QuickSort(testArr.ToList<int>(), 0, testArr.Length - 1);
            //sort.PrintArray(testArr, true);
            //stopWatch.Stop();
            //Console.WriteLine("{0}花费了{1}秒", SortTypeEnum.快速排序.ToString(), stopWatch.ElapsedMilliseconds);

            //stopWatch.Start();
            //sort.ExecuteSortMethod(sortMethodLs[2], testArr, false, SortTypeEnum.选择排序);
            //stopWatch.Stop();
            //Console.WriteLine("{0}花费了{1}秒", SortTypeEnum.选择排序.ToString(), stopWatch.ElapsedMilliseconds);

            //stopWatch.Start();
            //sort.ExecuteSortMethod(sortMethodLs[3], testArr, false, SortTypeEnum.插入排序);
            //stopWatch.Stop();
            //Console.WriteLine("{0}花费了{1}秒", SortTypeEnum.插入排序.ToString(), stopWatch.ElapsedMilliseconds);

            //stopWatch.Start();
            //sort.ExecuteSortMethod(sortMethodLs[4], testArr, true, SortTypeEnum.根堆排序);
            //stopWatch.Stop();
            //Console.WriteLine("{0}花费了{1}秒", SortTypeEnum.根堆排序.ToString(), stopWatch.ElapsedMilliseconds);

            //stopWatch.Start();
            //sort.ExecuteSortMethod(sortMethodLs[5], testArr, true, SortTypeEnum.希尔排序);
            //stopWatch.Stop();
            //Console.WriteLine("{0}花费了{1}秒", SortTypeEnum.希尔排序.ToString(), stopWatch.ElapsedMilliseconds);

            #endregion

            #region 查找

            //AlgorithmSearch search = new AlgorithmSearch();
            //int[] testArr2 = new int[] { 9, 12, 54, 6, 13, 4, 8, 2, 1 };
            //int[] randomArr = DavidArray.GenerateRandomArray(0, 100, 10);
            //int result;
            //result = search.SequenceSearch(testArr.ToList<int>(), 99);

            //testArr2 = sort.QuickSort(testArr2, false);
            //sort.PrintArray(testArr2, true);
            //result = search.BinarySearch(testArr2.ToList<int>(), 9);

            //Console.WriteLine("该数值索引：{0}", result);         
            //search.HashSearch(randomArr);

            //new BinaryTree().GenerateTree();

            #endregion

            #region 线性表

            //new LinearRelation().GetEnumNameList(typeof(LinearTypeEnum));

            //添加
            //Console.WriteLine("-------------添加分割线-----------\n");
            //LinearList linearObj = new LinearList();
            //SeqListType<Student> studentLs = new SeqListType<Student>();
            //linearObj.LinearListAdd<Student>(studentLs, new Student() { Id = 1, Name = "戴维", Age = 25 });
            //linearObj.LinearListAdd<Student>(studentLs, new Student() { Id = 2, Name = "迈克", Age = 43 });
            //linearObj.LinearListAdd<Student>(studentLs, new Student() { Id = 3, Name = "约翰", Age = 13 });
            //Console.WriteLine("展示下数据共有【{0}】条：\n", studentLs.ListLength);
            //Display(studentLs);
            ////索引搜查
            //Console.WriteLine("-------------索引查找分割线-----------\n");
            //Student searchObj = linearObj.LinearListSearch<Student>(studentLs, 1);
            //Console.WriteLine("索引ID为【{0}】的元素为:{1}\n", 1, string.Format("ID：{1}，Name：{1}，Age：{2}", searchObj.Id, searchObj.Name, searchObj.Age));
            ////key搜查
            //Console.WriteLine("-------------key查找分割线-----------\n");
            //Student searchKeyObj = linearObj.LinearListSearchByKey<Student, string>(studentLs, "戴维", n => n.Name);
            //Console.WriteLine("索引KEY为【{0}】的元素为:{1}\n", "戴维", string.Format("ID：{1}，Name：{1}，Age：{2}", searchKeyObj.Id, searchKeyObj.Name, searchKeyObj.Age));

            ////删除
            //Console.WriteLine("-------------删除查找分割线-----------\n");
            //linearObj.LinearListDelete<Student>(studentLs, 1);
            //Console.WriteLine("展示下数据共有【{0}】条：\n", studentLs.ListLength);
            //Display(studentLs);

            Console.WriteLine("-------------添加分割线-----------\n");
            LinkList linkList = new LinkList();
            Node<Student> node = null;
            node = linkList.LinkListAddToFirst<Student>(node, new Student() { Id = 1, Name = "戴维", Age = 25 });
            node = linkList.LinkListAddToFirst<Student>(node, new Student() { Id = 2, Name = "迈克", Age = 43 });
            node = linkList.LinkListAddToFirst<Student>(node, new Student() { Id = 3, Name = "约翰", Age = 13 });
            Console.WriteLine("展示下数据共有【{0}】条：\n", linkList.LinkListLength(node));
            Display(node);

            //索引搜查
            Console.WriteLine("-------------索引查找分割线-----------\n");
            node = linkList.LinkListSearchByKey(node, "迈克", n => n.Name);
            Display(node);

            //添加首节点
            Console.WriteLine("-------------添加首节点-----------\n");
            linkList.LinkListAddToFirst(node, new Student() { Id = 4, Name = "首节点", Age = 51 });
            Display(node);

            //添加尾节点
            Console.WriteLine("-------------添加首节点-----------\n");
            linkList.LinkListAddToEnd(node, new Student() { Id = 5, Name = "尾节点", Age = 99 });
            Display(node);

            //添加值2个节点
            Console.WriteLine("-------------添加首节点-----------\n");
            linkList.LinkListInsert(node, "戴维", n => n.Name, new Student() { Id = 2, Name = "插入节点", Age = 34 });
            Display(node);

            #endregion

            #region 动态Linq(动态lambda表达式构建)

            //QueryCondition queryCondition = new QueryCondition(null, "动态测试", new DateTime(2013, 1, 1), new DateTime(2013, 3, 1), null, null, 0, true);
            //QueryCondition queryCondition2 = new QueryCondition(null, string.Empty, null, null, null, 60, 1, false);

            //QueryCondition queryCondition3 = new QueryCondition(null, string.Empty, null, new DateTime(2013, 5, 1), null, 60, 5, true);

            //QueryCondition[] queryConditionLs = new QueryCondition[] { queryCondition, queryCondition2, queryCondition3 };
            //DynamicLambda dynamicLinq = new DynamicLambda();

            //List<TestUser> queryLs;
            //queryLs = dynamicLinq.GetTestData();
            //Console.WriteLine("原始测试数据有{0}条，如下\n", queryLs.Count);
            //dynamicLinq.PrintResult(queryLs);

            //Console.WriteLine("---------------查询分隔符------------------\n");

            ////queryLs = dynamicLinq.GetDataByGeneralQuery(queryConditionLs[0]);
            //queryLs = dynamicLinq.GetDataByDynamicQuery(queryConditionLs[0]);
            //Console.WriteLine("满足查询结果的数据有{0}条，如下\n", queryLs.Count);
            //dynamicLinq.PrintResult(queryLs);

            #endregion

            #region DataTable转成List<T>

            //DataTable dt = new DavidArray().GetDataTable();
            //string test = string.Empty;

            #endregion

            Console.ReadKey();
        }

        private static void Display(SeqListType<Student> list)
        {
            Console.WriteLine("--------展示数据---------");

            if (list.ListLength == 0)
                Console.WriteLine("没有数据可以展示！");

            for (int i = 0; i < list.ListLength; i++)
            {
                Console.WriteLine("ID：{0}，Name：{1}，Age：{2}", list.ListData[i].Id, list.ListData[i].Name, list.ListData[i].Age);
            }
        }

        private static void Display(Node<Student> node)
        {
            Console.WriteLine("--------展示数据---------");

            while (node != null)
            {
                Console.WriteLine("ID：{0}，Name：{1}，Age：{2}", node.data.Id, node.data.Name, node.data.Age);
                node = node.next;
            }
        }
    }
}
