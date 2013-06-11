using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DavidMeeting
{
    public class LinqToXmlHelper
    {
        private string path = @"J:\DavidTest\DavidWinform\bin\Debug\持久化.xml";

        public void TestLinqQueryXml()
        {
            XElement root = XElement.Load(path);

            #region 测试查询list

            IEnumerable<XElement> queryXmlLs = from ele in root.Elements("RegisterInfo")
                                               select ele;

            foreach (var singleQuery in queryXmlLs)
            {
                printProperties(singleQuery);
            }

            #endregion

            #region 测试查询单个对象
            //IEnumerable<XElement> queryXmlLs = from ele in root.Elements("RegisterInfo")
            //                                   select ele;

            //XElement searchQuery = queryXmlLs.FirstOrDefault(n => n.Element("Id").Value.ToString() == "9463a520-3f51-4833-8f54-15afee5a05b0");

            //printProperties(searchQuery);

            #endregion

            #region 测试添加单个对象属性节点

            //IEnumerable<XElement> queryXmlLs = from ele in root.Elements("RegisterInfo")
            //                                   select ele;

            //XElement searchQuery = queryXmlLs.FirstOrDefault(n => n.Element("Id").Value.ToString() == "9463a520-3f51-4833-8f54-15afee5a05b0");

            //XElement newNode = new XElement("newAttribute") { Value = "newAttributeValue" };

            //searchQuery.Add(newNode);

            //printProperties(searchQuery);

            #endregion

            #region 测试删除单个对象属性节点

            //IEnumerable<XElement> queryXmlLs = from ele in root.Elements("RegisterInfo")
            //                                   select ele;

            //XElement searchQuery = queryXmlLs.FirstOrDefault(n => n.Element("Id").Value.ToString() == "9463a520-3f51-4833-8f54-15afee5a05b0");

            //searchQuery.Element("ChineseName").Remove();

            //printProperties(searchQuery);

            #endregion

            #region 测试修改单个节点属性值

            //IEnumerable<XElement> queryXmlLs = from ele in root.Elements("RegisterInfo")
            //                                   select ele;

            //XElement searchQuery = queryXmlLs.FirstOrDefault(n => n.Element("Id").Value.ToString() == "9463a520-3f51-4833-8f54-15afee5a05b0");

            //searchQuery.Element("ChineseName").Value = "ModifyName";

            //printProperties(searchQuery);

            #endregion

        }

        private void printProperties(XElement element)
        {
            Console.WriteLine("Register对象：");
            Console.WriteLine("Id:{0}", element.Element("Id") == null ? string.Empty : element.Element("Id").Value);
            Console.WriteLine("ChineseName:{0}", element.Element("ChineseName") == null ? string.Empty : element.Element("ChineseName").Value);
            Console.WriteLine("EnglishName:{0}", element.Element("EnglishName") == null ? string.Empty : element.Element("EnglishName").Value);
            Console.WriteLine("Birth:{0}", element.Element("Birth") == null ? string.Empty : element.Element("Birth").Value);
            Console.WriteLine("Address:{0}", element.Element("Address") == null ? string.Empty : element.Element("Address").Value);
            Console.WriteLine("Cellphone:{0}", element.Element("Cellphone") == null ? string.Empty : element.Element("Cellphone").Value);
            Console.WriteLine("IsStudent:{0}", element.Element("IsStudent") == null ? string.Empty : element.Element("IsStudent").Value);
            Console.WriteLine("Email:{0}", element.Element("Email") == null ? string.Empty : element.Element("Email").Value);
            Console.WriteLine("Description:", element.Element("Description") == null ? string.Empty : element.Element("Description").Value);
            Console.WriteLine("newAttribute:{0}", element.Element("newAttribute") == null ? string.Empty : element.Element("newAttribute").Value);
            Console.WriteLine("--------------------------");
        }
    }

    /// <summary>
    /// 动态Lambda表达式类
    /// </summary>
    public class DynamicLambda
    {
        public Dictionary<string, string> queryDict = new Dictionary<string, string>();
        public OrderEntry[] orderEntries;

        public DynamicLambda()
        {
            InitDynamicQueryMapping();
            orderEntries = new OrderEntry[] { 
                new OrderEntry(){OrderStr="Id",OrderType=typeof(int)},
                new OrderEntry(){OrderStr="Name",OrderType=typeof(string)},
                new OrderEntry(){OrderStr="Birth",OrderType=typeof(string)},
                new OrderEntry(){OrderStr="IsStudent",OrderType=typeof(string)},
                new OrderEntry(){OrderStr="Cellphone",OrderType=typeof(string)},
                new OrderEntry(){OrderStr="Email",OrderType=typeof(string)},
                new OrderEntry(){OrderStr="Score",OrderType=typeof(int)}
            };
        }

        /*在一般的业务环境中我们常常会遇到动态查询的情况，对于以前纯T-SQL情况下我们一般是采用根据相应条件动态拼接相应的where条件上去达到相应效果
         如今在这个LINQ横行的年代，怎么能利用LINQ完成动态查询呢
         */

        #region 一般的解决方案

        //如果要根据对应的Linq的方式怎么完成
        public List<TestUser> GetDataByGeneralQuery(QueryCondition queryCondition)
        {
            //此处一般会从数据库或者其他地方获取到业务所用到的数据源
            List<TestUser> sourceLs = GetTestData();

            /*根据不同情况添加不同查询条件，但是我们都知道平时开发中需求是不断变化的，怎么能更好的应对PM各种扭曲的要求尔不必一次一次的添加各种if条件呢
            万一有一天，PM要求你将某些条件合并例如名字和ID变为OR的关系怎么办，如果需要利用LINQ进行动态的排序怎么办，或者如果过滤的名字是一个
            不定的字符串数组怎么办，这些都是我们经常会遇到的，我们不能因为每次这样的改动而去修改这里的东西， 而且有的时候我们知道在Where(n=>n.?==?)
            但是编译器是不知道的，这是我们就要用到动态lambda表达式（动态linq的方式）
            */
            if (queryCondition.QueryId.HasValue)
                sourceLs = sourceLs.Where(n => n.Id == queryCondition.QueryId).ToList<TestUser>();
            if (!string.IsNullOrEmpty(queryCondition.QueryName))
                sourceLs = sourceLs.Where(n => n.Name.ToLower().Contains(queryCondition.QueryName.ToLower())).ToList<TestUser>();
            if (queryCondition.QueryStartTime.HasValue)
                sourceLs = sourceLs.Where(n => n.Birth >= queryCondition.QueryStartTime.Value).ToList<TestUser>();
            if (queryCondition.QueryEndTime.HasValue)
                sourceLs = sourceLs.Where(n => n.Birth < queryCondition.QueryEndTime.Value).ToList<TestUser>();
            if (queryCondition.QueryBoolean != null)
                sourceLs = sourceLs.Where(n => n.IsStudent = queryCondition.QueryBoolean.Value).ToList<TestUser>();
            if (queryCondition.QueryScore.HasValue)
                sourceLs = sourceLs.Where(n => n.Score == queryCondition.QueryScore.Value).ToList<TestUser>();

            switch (queryCondition.OrderField)
            {
                case 0:
                    {
                        if (queryCondition.IsDesc)
                            sourceLs = sourceLs.OrderByDescending(n => n.Id).ToList<TestUser>();
                        else
                            sourceLs = sourceLs.OrderBy(n => n.Id).ToList<TestUser>();
                    }; break;
                case 1:
                    {
                        if (queryCondition.IsDesc)
                            sourceLs = sourceLs.OrderByDescending(n => n.Name).ToList<TestUser>();
                        else
                            sourceLs = sourceLs.OrderBy(n => n.Name).ToList<TestUser>();
                    }; break;
                case 2:
                    {
                        if (queryCondition.IsDesc)
                            sourceLs = sourceLs.OrderByDescending(n => n.Birth).ToList<TestUser>();
                        else
                            sourceLs = sourceLs.OrderBy(n => n.Birth).ToList<TestUser>();
                    }; break;
                case 3:
                    {
                        if (queryCondition.IsDesc)
                            sourceLs = sourceLs.OrderByDescending(n => n.IsStudent).ToList<TestUser>();
                        else
                            sourceLs = sourceLs.OrderBy(n => n.IsStudent).ToList<TestUser>();
                    }; break;
                case 4:
                    {
                        if (queryCondition.IsDesc)
                            sourceLs = sourceLs.OrderByDescending(n => n.Cellphone).ToList<TestUser>();
                        else
                            sourceLs = sourceLs.OrderBy(n => n.Cellphone).ToList<TestUser>();
                    }; break;
                case 5:
                    {
                        if (queryCondition.IsDesc)
                            sourceLs = sourceLs.OrderByDescending(n => n.Email).ToList<TestUser>();
                        else
                            sourceLs = sourceLs.OrderBy(n => n.Email).ToList<TestUser>();
                    }; break;
                case 6:
                    {
                        if (queryCondition.IsDesc)
                            sourceLs = sourceLs.OrderByDescending(n => n.Score).ToList<TestUser>();
                        else
                            sourceLs = sourceLs.OrderBy(n => n.Score).ToList<TestUser>();
                    }; break;
                default:
                    break;
            }

            return sourceLs;
        }

        #endregion

        #region 动态构建Lambda表达式-动态Expression树

        public List<TestUser> GetDataByDynamicQuery(QueryCondition queryCondition)
        {
            IQueryable<TestUser> sourceLs = GetTestData().AsQueryable<TestUser>();
            string[] orderParams = new string[] { "OrderField", "IsDesc" };

            Expression filter;
            Expression totalExpr = Expression.Constant(true);

            ParameterExpression param = Expression.Parameter(typeof(TestUser), "n");
            Type queryConditionType = queryCondition.GetType();
            foreach (PropertyInfo item in queryConditionType.GetProperties())
            {
                //反射找出所有查询条件的属性值，如果该查询条件值为空或者null不添加动态lambda表达式
                string propertyName = item.Name;
                var propertyVal = item.GetValue(queryCondition, null);

                if (!orderParams.Contains(propertyName) && propertyVal != null && propertyVal.ToString() != string.Empty)
                {
                    //n.property
                    Expression left = Expression.Property(param, typeof(TestUser).GetProperty(queryDict[propertyName]));
                    //等式右边的值
                    Expression right = Expression.Constant(propertyVal);
                    //此处如果有特殊的判断可以自行修改例如要是Contain的，要是时间大于小于的这种判断, 这里也可以用类似InitDynamicQueryMapping方法进行表驱动维护

                    if (propertyName == "QueryStartTime")
                        filter = Expression.GreaterThanOrEqual(left, right);
                    else if (propertyName == "QueryEndTime")
                        filter = Expression.LessThan(left, right);
                    else if (propertyName == "QueryName")
                        filter = Expression.Call(Expression.Property(param, typeof(TestUser).GetProperty(queryDict[propertyName])), typeof(string).GetMethod("Contains", new Type[] { typeof(string) }), Expression.Constant(propertyVal));
                    else
                        filter = Expression.Equal(left, right);

                    totalExpr = Expression.And(filter, totalExpr);
                }
            }
            //Where部分条件
            Expression pred = Expression.Lambda(totalExpr, param);
            Expression whereExpression = Expression.Call(typeof(Queryable), "Where", new Type[] { typeof(TestUser) }, Expression.Constant(sourceLs), pred);
            //OrderBy部分排序
            MethodCallExpression orderByCallExpression = Expression.Call(typeof(Queryable), queryCondition.IsDesc ? "OrderByDescending" : "OrderBy", new Type[] { typeof(TestUser), orderEntries[queryCondition.OrderField].OrderType }, whereExpression, Expression.Lambda(Expression.Property(param, orderEntries[queryCondition.OrderField].OrderStr), param));

            //生成动态查询
            sourceLs = sourceLs.Provider.CreateQuery<TestUser>(orderByCallExpression);

            return sourceLs.ToList<TestUser>();
        }

        #endregion

        /// <summary>
        /// 具体查询属性和实体里面属性作Mapping，当然你可以对名字规范做一个显示那样不用做映射用反射获取到直接构建表达式也行
        /// 具体这里只是假设模拟了一个这种情况，使用者可以根据自身业务情况适当修改
        /// </summary>
        public void InitDynamicQueryMapping()
        {
            //查询mapping
            queryDict.Add("QueryId", "Id");
            queryDict.Add("QueryName", "Name");
            queryDict.Add("QueryStartTime", "Birth");
            queryDict.Add("QueryEndTime", "Birth");
            queryDict.Add("QueryBoolean", "IsStudent");
            queryDict.Add("QueryScore", "Score");
        }

        /// <summary>
        /// 制造测试数据
        /// </summary>
        /// <returns></returns>
        public List<TestUser> GetTestData()
        {
            List<TestUser> testLs = new List<TestUser>();
            testLs.AddRange(new TestUser[] { 
                new TestUser() { Id=1, Name="测试1", Birth=new DateTime(2013,1,1), IsStudent=true, Cellphone="123456789", Email="test001@qq.com", Score=100 },
                new TestUser() { Id=2, Name="测试2", Birth=new DateTime(2013,1,2), IsStudent=false, Cellphone="23123513", Email="test002@qq.com", Score=60 },
                new TestUser() { Id=3, Name="测试3", Birth=new DateTime(2013,1,3), IsStudent=true, Cellphone="36365656", Email="test003@qq.com", Score=98 },
                new TestUser() { Id=4, Name="测试4", Birth=new DateTime(2013,1,4), IsStudent=false, Cellphone="23423525", Email="test004@qq.com", Score=86 },
                new TestUser() { Id=5, Name="测试5", Birth=new DateTime(2013,1,5), IsStudent=true, Cellphone="9867467", Email="test006@qq.com", Score=96 },
                new TestUser() { Id=6, Name="测试6", Birth=new DateTime(2013,1,6), IsStudent=false, Cellphone="536546345", Email="test007@qq.com", Score=99 },
                new TestUser() { Id=7, Name="测试7", Birth=new DateTime(2013,1,7), IsStudent=true, Cellphone="45234552", Email="test008@qq.com", Score=98 },
                new TestUser() { Id=8, Name="测试8", Birth=new DateTime(2013,1,8), IsStudent=false, Cellphone="536375636", Email="test009@qq.com", Score=97 },
                new TestUser() { Id=9, Name="测试9", Birth=new DateTime(2013,2,1), IsStudent=true, Cellphone="123456789", Email="test010@qq.com", Score=88 },
                new TestUser() { Id=10, Name="测试10", Birth=new DateTime(2013,2,2), IsStudent=false, Cellphone="4524245", Email="test011@qq.com", Score=88 },
                new TestUser() { Id=11, Name="动态测试11", Birth=new DateTime(2013,2,3), IsStudent=false, Cellphone="64767484", Email="test012@qq.com", Score=87 },
                new TestUser() { Id=12, Name="动态测试12", Birth=new DateTime(2013,2,4), IsStudent=true, Cellphone="78578568", Email="test013@qq.com", Score=86 },
                new TestUser() { Id=13, Name="动态测试13", Birth=new DateTime(2013,2,5), IsStudent=false, Cellphone="123456789", Email="test014@qq.com", Score=60 },
                new TestUser() { Id=14, Name="动态测试14", Birth=new DateTime(2013,2,6), IsStudent=true, Cellphone="123456789", Email="test015@qq.com", Score=60 },
                new TestUser() { Id=15, Name="动态测试15", Birth=new DateTime(2013,2,7), IsStudent=false, Cellphone="123456789", Email="test016@qq.com", Score=59 },
                new TestUser() { Id=16, Name="动态测试16", Birth=new DateTime(2013,2,8), IsStudent=true, Cellphone="34135134", Email="test017@qq.com", Score=58 },
                new TestUser() { Id=17, Name="动态测试17", Birth=new DateTime(2013,3,1), IsStudent=false, Cellphone="123456789", Email="test018@qq.com", Score=100 },
                new TestUser() { Id=18, Name="动态测试18", Birth=new DateTime(2013,3,2), IsStudent=true, Cellphone="34165451234", Email="test019@qq.com", Score=86 },
                new TestUser() { Id=19, Name="动态测试19", Birth=new DateTime(2013,3,3), IsStudent=false, Cellphone="462645246", Email="test020@qq.com", Score=64 },
                new TestUser() { Id=20, Name="动态测试20", Birth=new DateTime(2013,3,4), IsStudent=true, Cellphone="61454343", Email="test021@qq.com", Score=86 },
            });
            return testLs;
        }

        /// <summary>
        /// 打印测试数据
        /// </summary>
        /// <param name="resultLs"></param>
        public void PrintResult(List<TestUser> resultLs)
        {
            foreach (TestUser item in resultLs)
            {
                Console.WriteLine("序号：{0}，姓名：{1}，生日：{2}，是否在读：{3}，联系手机：{4}，邮箱：{5}，分数：{6}", item.Id, item.Name, item.Birth, item.IsStudent ? "是" : "否", item.Cellphone, item.Email, item.Score);
            }
        }
    }

    /// <summary>
    /// 业务实体类-你可以想象成你业务中需要实际使用的类
    /// </summary>
    public class TestUser
    {
        public TestUser() { }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birth { get; set; }

        public bool IsStudent { get; set; }

        public string Cellphone { get; set; }

        public string Email { get; set; }

        public int Score { get; set; }
    }

    /// <summary>
    /// 排序帮助类
    /// </summary>
    public class OrderEntry
    {
        public string OrderStr { get; set; }

        public Type OrderType { get; set; }
    }

    /// <summary>
    /// 业务查询条件类-实际使用中你可以根据自己的需要构建你的查询条件类
    /// </summary>
    public class QueryCondition
    {
        public QueryCondition() { }

        public QueryCondition(int? queryId, string queryName, DateTime? queryStart, DateTime? queryEnd, bool? queryBoolean, int? queryScore, int orderField, bool isDesc)
        {
            this.QueryId = queryId;
            this.QueryName = queryName;
            this.QueryStartTime = queryStart;
            this.QueryEndTime = queryEnd;
            this.QueryBoolean = queryBoolean;
            this.QueryScore = queryScore;
            this.OrderField = orderField;
            this.IsDesc = isDesc;
        }

        public int? QueryId { get; set; }

        public string QueryName { get; set; }

        public DateTime? QueryStartTime { get; set; }

        public DateTime? QueryEndTime { get; set; }

        public bool? QueryBoolean { get; set; }

        public int? QueryScore { get; set; }

        public int OrderField { get; set; }

        public bool IsDesc { get; set; }
    }
}
