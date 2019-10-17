<%@ Page Title="Commute Listing" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WhenWillIGetThere.Commute.List" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p>This lists your existing commutes.</p>

    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>