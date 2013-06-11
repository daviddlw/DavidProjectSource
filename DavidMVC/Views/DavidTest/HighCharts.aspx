<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    HighCharts 控件测试
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        HighCharts 控件测试</h2>
    <div id="container" class="wp100 height400">
    </div>
    <div id="resultInfo"></div>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            init_chart();
        })
        var chart;
        var init_chart = function () {
            $.ajax({
                url: "/DavidTest/GetHighChartOptions",
                type: "post",
                dataType: "json",
                success: function (data) {
                    DrawCharts(data.options);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });

        }

        //画图方法
        var DrawCharts = function (chartOptions) {
            var chart = new Highcharts.Chart({
                chart: chartOptions.chart,
                title: chartOptions.title,
                subtitle: chartOptions.subtitle,
                credits: chartOptions.credits,
                xAxis: chartOptions.xAxis,
                yAxis: chartOptions.yAxis,
                tooltip: chartOptions.tooltip,
                plotOptions: {
                    line: {
                        dataLabels: {
                            enabled: chartOptions.plotOptions.enableDataLabels
                        },
                        enableMouseTracking: chartOptions.plotOptions.enableMouseTracking,
                        events: {
                            mouseOver: function (event) {

                            }
                        }
                    },
                    column: {
                        stacking: chartOptions.plotOptions.stacking
                    },
                    pie: {
                        showInLegend: chartOptions.plotOptions.showInLegend
                    },
                    series: {
                        stacking: chartOptions.plotOptions.stacking,
                        point: {
                            events: {
                                mouseOver: function () {
                                    $("#resultInfo").html("类别值：" + this.category + " 维度值：" + this.x + " 指标值：" + this.y);
                                },
                                mouseOut: function () {
                                    $("#resultInfo").empty();
                                }
                            }
                        },
                        events: {
                            mouseOver: function (event) {

                            },
                            click: function (event) {

                            }
                        }
                    }
                },
                series: chartOptions.series
            });

        }
    </script>
</asp:Content>
