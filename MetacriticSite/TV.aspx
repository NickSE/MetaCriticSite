<%@ Page Title="TV" Language="C#" MasterPageFile="MetacriticSite.Master" AutoEventWireup="true" CodeBehind="TV.aspx.cs" Inherits="MetacriticSite.TV" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1><%: Title %></h1>
    </div>
    <div class="images">
         <asp:ImageButton ID="power" runat="server" ImageUrl="Logo/Power.jpg" height="150px" width="90px" OnClick="power_Click" />
          </div>
          <div class="images">
               <asp:ImageButton ID="scandal" runat="server" ImageUrl="Logo/Scandal.jpg" height="150px" width="90px" OnClick="scandal_Click" />
          </div>
    </asp:Content>
