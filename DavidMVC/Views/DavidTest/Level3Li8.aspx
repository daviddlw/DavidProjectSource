<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Level3Li8
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Level3Li8</h2>
                <h2>
        自制导航</h2>
    <div hid="navDiv">
        <% Html.RenderPartial("NavigationCtrl");%>
    </div>
</asp:Content>
