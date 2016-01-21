<%@ Page Title="Info" Language="C#" MasterPageFile="MetacriticSite.Master" AutoEventWireup="true" CodeBehind="InfoPage.aspx.cs" Inherits="MetacriticSite.InfoPage" %>

 <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div>
        <h1><%: Title %></h1>
    </div>
          <div id="info"  class="info" runat="server">
          </div>
     <div id="samenvatting" class="samenvatting" runat="server">
     </div>
     <div id="reviews" class="reviewcontainer" runat="server">
     </div>
     <asp:Button ID="btnWriteReview" runat="server" Text="Write a review" OnClick="btnWriteReview_Click" />
     <br/>
     <asp:Label ID="lblRate" runat="server" Text="Your score: " Visible="False"></asp:Label>
     <asp:TextBox ID="tbRate" runat="server" Width="29px" MaxLength="3" Visible="False"></asp:TextBox>
     <br/>
     <asp:TextBox ID="tbReview" runat="server" Height="100px" MaxLength="5000" TextMode="MultiLine" Width="250px" Visible="False">There is a 150 character minimum for reviews. If your review contains spoilers, please check the Spoiler box. Please do not use ALL CAPS. There is no linking or other HTML allowed. Your review may be edited for content.</asp:TextBox>
     <br/>
     <asp:CheckBox ID="cbSpoiler" runat="server" Text="Spoiler" Visible="False" />
     <br/>
     <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" Visible="False" />
    </asp:Content>