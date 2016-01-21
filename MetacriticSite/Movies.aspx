<%@ Page Title="Movies" Language="C#" MasterPageFile="~/MetacriticSite.Master" AutoEventWireup="true" CodeBehind="Movies.aspx.cs" Inherits="MetacriticSite.Movies" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1><%: Title %></h1>
    </div>
        <div class="images">
             <asp:ImageButton ID="sinister" runat="server" ImageUrl="Logo/Sinister.jpg" height="150px" width="90px" OnClick="sinister_Click" />
        </div>
        <div class="images">
             <asp:ImageButton ID="theDrop" runat="server" ImageUrl="Logo/TheDrop.jpg" height="150px" width="90px" OnClick="theDrop_Click" />
        </div>
    </asp:Content>