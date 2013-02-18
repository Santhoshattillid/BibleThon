<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Biblethon.Master"
    CodeBehind="BiblethonHome.aspx.cs" Inherits="Biblethon.BiblethonHome" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div style=" margin:150px 0px 0px 350px;">
        <asp:Button ID="btnBiblethon" runat="server" Text="Biblethon Order Entry" 
            Width="220px" onclick="btnBiblethon_Click" /><br /><br />
        <asp:Button ID="btnShareathon"
            runat="server" Width="220px" Text="Share-a-thon Order Entry" />

    </div>
</asp:Content>
