<%@ Page Title="Games" Language="C#" MasterPageFile="MetacriticSite.Master" AutoEventWireup="true" CodeBehind="Games.aspx.cs" Inherits="MetacriticSite.Games" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1><%: Title %></h1>
    </div>
    <div class="images">
         <asp:ImageButton ID="fallout" runat="server" ImageUrl="Logo/Fallout4.jpg" height="150px" width="90px" OnClick="fallout_Click" />
          </div>
          <div class="images">
              <asp:ImageButton ID="dishonored" runat="server" ImageUrl="Logo/Dishonored2.jpg" height="150px" width="90px" OnClick="dishonored_Click" />
          </div>
    </asp:Content>
