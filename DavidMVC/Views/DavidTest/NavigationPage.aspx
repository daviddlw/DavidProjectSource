<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    自制导航
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        自制导航</h2>
    <div hid="navDiv">
        <% Html.RenderPartial("NavigationCtrl");%>
    </div>
    <div id="result">
    </div>
    <script language="javascript" type="text/javascript">

        var nav = new $.fn.jNavigationControl({
            renderTo: $("div[hid='navDiv']")
        });
        
    </script>
</asp:Content>
