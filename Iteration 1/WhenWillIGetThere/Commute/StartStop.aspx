<%@ Page Title="Start/Stop" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StartStop.aspx.cs" Inherits="WhenWillIGetThere.Commute.StartStop" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p>This allows to Start and Stop a commute.</p>
    <asp:Label ID="lblRoute" runat="server" Text="Label"></asp:Label>
    <hr />
    <asp:HiddenField ID="hidCommuteId" runat="server" />
    <asp:Label ID="lblStart" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="btnStart" runat="server" Text="Start" OnClick="btnStart_Click" />
    <asp:Button ID="btnStop" runat="server" Text="Stop" OnClick="btnStop_Click" />

</asp:Content>
