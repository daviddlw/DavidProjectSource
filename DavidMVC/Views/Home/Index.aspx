<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%: ViewData["Message"] %></h2>
    <p>
        To learn more about ASP.NET MVC visit <a href="http://asp.net/mvc" title="ASP.NET MVC Website">
            http://asp.net/mvc</a>.
    </p>
    <%=Html.ActionLink("测试跳转页面", "TestRedirect", "Home")%><br />
    <%=Html.ActionLink("测试HighChart页面", "HighCharts", "DavidTest")%><br />
    <%=Html.ActionLink("测试NavigationPage页面", "NavigationPage", "DavidTest")%>
</asp:Content>
