<%@ Page Title="Music" Language="C#" MasterPageFile="MetacriticSite.Master" AutoEventWireup="true" CodeBehind="Music.aspx.cs" Inherits="MetacriticSite.Music" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1><%: Title %></h1>
    </div>
    <div class="images">
         <asp:ImageButton ID="blackmill" runat="server" ImageUrl="Logo/Blackmill.jpg" height="150px" width="90px" OnClick="blackmill_Click" />
          </div>
          <div class="images">
               <asp:ImageButton ID="eminem" runat="server" ImageUrl="Logo/eminem.jpg" height="150px" width="90px" OnClick="eminem_Click" />
          </div>
    </asp:Content>
