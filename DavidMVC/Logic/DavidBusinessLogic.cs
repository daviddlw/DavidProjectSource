using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DavidMVC.Models;
using System.Web.Routing;
using System.Drawing;

namespace DavidMVC.Logic
{
    public class DavidBusinessLogic
    {
        public List<TestModel> GetJsonSerializeData()
        {
            string paramStr = HttpContext.Current.Request.Form["id"] == null ? string.Empty : Convert.ToString(HttpContext.Current.Request.Form["id"]);
            TestModel testModelOne = new TestModel()
            {
                Id = 1,
                Name = "David1",
                TestLs = new List<string>() { "aa", "bb", "cc", "dd" },
                TestInnerModelLs = new List<InnerModel>()
                {
                    new InnerModel(){InnerId=1, InnerName="Inner1"},
                    new InnerModel(){InnerId=2, InnerName="Inner2"},
                    new InnerModel(){InnerId=3, InnerName="Inner3"},
                    new InnerModel(){InnerId=4, InnerName="Inner4"},
                    new InnerModel(){InnerId=5, InnerName="Inner5"},
                }
            };
            TestModel testModelTwo = new TestModel()
            {
                Id = 1,
                Name = "David2",
                TestLs = new List<string>() { "ee", "ff", "gg", "hh" },
                TestInnerModelLs = new List<InnerModel>()
                {
                    new InnerModel(){InnerId=6, InnerName="Inner6"},
                    new InnerModel(){InnerId=7, InnerName="Inner7"},
                    new InnerModel(){InnerId=8, InnerName="Inner8"},
                    new InnerModel(){InnerId=9, InnerName="Inner9"},
                    new InnerModel(){InnerId=10, InnerName="Inner10"},
                }
            };
            TestModel testModelThree = new TestModel()
            {
                Id = 1,
                Name = "David3",
                TestLs = new List<string>() { "ii", "jj", "kk", "ll" },
                TestInnerModelLs = new List<InnerModel>()
                {
                    new InnerModel(){InnerId=11, InnerName="Inner11"},
                    new InnerModel(){InnerId=12, InnerName="Inner12"},
                    new InnerModel(){InnerId=13, InnerName="Inner13"},
                    new InnerModel(){InnerId=14, InnerName="Inner14"},
                    new InnerModel(){InnerId=15, InnerName="Inner15"},
                }
            };

            List<TestModel> testModelLs = new List<TestModel>();
            testModelLs.Add(testModelOne);
            testModelLs.Add(testModelTwo);
            testModelLs.Add(testModelThree);

            //string jsonString = JsonHelper.JsonSerializer<List<TestModel>>(testModelLs);

            return testModelLs;
        }

        public HighChartOptions GetHighChartOptions()
        {
            HighChartOptions options = new HighChartOptions();
            options.chart.borderWidth = 2;
            options.chart.borderColor = "#EBBA95";
            options.chart.renderTo = "container";
            //options.chart.type = ChartTypeEnum.bar.ToString();
            //options.chart.backgroundColor = "#FFFFBB";
            //options.chart.borderWidth = 5;
            options.title.text = "Fruit Consumption";
            List<string> categoriesStr = new List<string>() { "Apples", "Bananas", "Oranges", "Photo", "Coffee" };
            //options.xAxis = new XAxis { categories = categoriesStr, title = new Title() { text = "水果" } };
            options.xAxis.AddRange(new List<XAxis>{
                new XAxis { categories = categoriesStr, reversed = false, opposite = false },
                //new XAxis { categories = categoriesStr, reversed = false, opposite = true, title = new Title() { text = "正极" }, linkedTo=0 },
            });
            options.yAxis.title.text = "水果种类";
            options.tooltip.crosshairs.Insert(0, true);
            options.tooltip.crosshairs.Insert(1, false);
            //options.plotOptions.showInLegend = true;
            //options.plotOptions.enableDataLabels = true;
            //options.plotOptions.stacking = StackingTypeEnum.normal.ToString();
            options.tooltip.shared = false;
            //options.tooltip.useHTML = true;
            //options.yAxis.plotLines.AddRange(new List<PlotLines>() { new PlotLines() { value = 5.5 }, new PlotLines() { value = 3.5 } });
            //options.xAxis.plotLines.Add(new PlotLines() { value = 2.5 });
            //options.tooltip.headerFormat = "<b>数据名：{point.key}</b><br/>";
            //options.tooltip.pointFormat = "{point.y}-{series.name}";
            //options.tooltip.footerFormat = "";

            #region 饼图数据

            List<object> pieDataLs = new List<object>() { 
                new object[2] { "中国", 511 },
                new object[2] { "美国", 114 },
                new object[2] { "英国", 345 },
                new { name = "思密达", y = 622, sliced = true, selected = true },
                new object[2] { "日本", 411 }
            };

            #endregion

            List<Series> list = new List<Series>() { 
                //new Series{ name="国家", type=ChartTypeEnum.pie.ToString(), data=pieDataLs, allowPointSelect=true }
                //new Series { name = "John", data = new List<object> { -5, -7, -3,-5,-1 } },
                //new Series { name = "David", data = new List<object> { 12, 8, 9,2,3 } }
                //new Series { name = "Micheal", data = pieDataLs, type=ChartTypeEnum.pie.ToString(),  showInLegend=true, size=100, center=new int[2]{80,30}, allowPointSelect=true },
                new Series { name = "Meachieal", data = new List<object> { 11, 13, 5, 7, 4 }, type= ChartTypeEnum.column.ToString(),allowPointSelect=false, color="#FF8800" },
                new Series { name = "Helloword", data = new List<object> { 8, 7, 3, 2, 3 }, type= ChartTypeEnum.spline.ToString(),allowPointSelect=false, color= "#00BBFF" }           
            };
            options.series = list;
            return options;

        }
    }

    public class MyPage : IHttpHandler
    {
        public RequestContext RequestContext { get; set; }

        public MyPage(RequestContext context)
        {
            this.RequestContext = context;
        }
        public bool IsReusable
        {
            get { return false; }
        }

        public virtual void ProcessRequest(HttpContext context) { }
    }

    public class MyRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new MyPage(requestContext);
        }
    }


}