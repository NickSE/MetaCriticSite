<%@ Page Title="Metacritic" Language="C#" MasterPageFile="MetacriticSite.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="MetacriticSite.MainPage" %>
    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1><%: Title %></h1>
        Hoofdscherm
    </div>
          <div class="images">
               <asp:ImageButton ID="sinisterMainpage" runat="server" ImageUrl="Logo/Sinister.jpg" height="150px" width="90px" OnClick="sinisterMainpage_Click" />
          </div>
          <div class="images">
               <asp:ImageButton ID="falloutMainpage" runat="server" ImageUrl="Logo/Fallout4.jpg" height="150px" width="90px" OnClick="falloutMainpage_Click" />
          </div>
    </asp:Content>

