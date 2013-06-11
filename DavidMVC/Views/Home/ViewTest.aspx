<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    HighChartTest
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        HighChartTest</h2>
    <div id="result">
    </div>
    ViewData：<%=ViewData["id"] == null ? string.Empty : ViewData["id"].ToString() %><br />
    TempData：<%=TempData["test"] == null ? string.Empty : TempData["test"].ToString()%>
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {
            init();
        })

        var init = function () {
            $.ajax({
                url: "/Home/GetTestData",
                type: "POST",
                data: ({ id: "test" }),
                dataType: "json",
                success: function (msg) {
                    $("#result").html(msg.Data);
                }
            })
        }
    </script>
</asp:Content>
