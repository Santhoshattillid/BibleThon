<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Biblethon.Master"
    CodeBehind="OrderDetails.aspx.cs" Inherits="Biblethon.OrderDetails" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <asp:GridView ID="gdvOrders" AutoGenerateColumns="false" runat="server" 
            Width="786px">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="cbAll" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbCheck" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- <asp:BoundField DataField=""  />--%>
                <asp:TemplateField HeaderText="Order No.">
                    <ItemTemplate>
                        <%--<asp:LinkButton ID="lnkOrderId" runat="server" Text='<%# Bind("OrderNo") %>'></asp:LinkButton>--%>
                        <asp:LinkButton ID="lnkOrderId" runat="server" Text=''></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="" HeaderText="Date" />
                <asp:BoundField DataField="" HeaderText="Operator" />
                <asp:BoundField DataField="" HeaderText="OrderName" />
                <asp:BoundField DataField="" HeaderText="OrderTotal" />
                <asp:BoundField DataField="" HeaderText="Status" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="GridView1" runat="server" >  
        </asp:GridView>
    </div>
</asp:Content>
