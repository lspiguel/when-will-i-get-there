<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WhenWillIGetThere.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>An application description page.</h3>
    <p>
        <a class="btn btn-default" runat="server" href="~/Guidance">This is the original guidance page &raquo;</a>
    </p>
</asp:Content>
