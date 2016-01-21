<%@ Page Title="Login" Language="C#" MasterPageFile="~/MetacriticSite.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MetacriticSite.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1><%: Title %></h1>
    </div>
    
    <label for="tbUsername">Username: </label>
    <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
    <label for="tbPassword">Password: </label>
    <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
   
    <asp:Button ID="btnLogin" runat="server" Text="Log in" Width="78px" OnClick="btnLogin_OnClick" />
    <div>
        Login met username: test123 en password: Test123
    </div>   
    </asp:Content>
