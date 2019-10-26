<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WhenWillIGetThere._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>When will I get there?</h1>
        <p class="lead">
            This mini-app allows to record the starting and ending times for your commutes. By recording times, an ETA can be calculated
            and also some visualizations can be constructed to help you get a hold of patterns in your commute.<br />
            You should probably record for some time before coming back.
        </p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>List</h2>
            <p>
                List the recorded that over here.
            </p>
            <p>
                <a class="btn btn-default" runat="server" href="~/Commute/List">List &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Record</h2>
            <p>
                Mark the start or end of a commute.
            </p>
            <p>
                <a class="btn btn-default" runat="server" href="~/Commute/StartStop">Start/Stop a counter &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>More</h2>
            <p>
                More will be comming along soon.
            </p>
        </div>
    </div>

</asp:Content>
