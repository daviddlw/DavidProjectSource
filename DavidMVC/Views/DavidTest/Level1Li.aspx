﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Level1Li
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Level1Li</h2>
        <h2>
        自制导航</h2>
    <div hid="navDiv">
        <% Html.RenderPartial("NavigationCtrl");%>
    </div>
</asp:Content>
