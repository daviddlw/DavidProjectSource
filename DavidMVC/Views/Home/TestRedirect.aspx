﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	TestRedirect
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    ViewData：<%=ViewData["id"] == null ? string.Empty : ViewData["id"].ToString() %><br />
    TempData：<%=TempData["test"] == null ? string.Empty : TempData["test"].ToString()%>
    <h2>TestRedirect</h2>

</asp:Content>
