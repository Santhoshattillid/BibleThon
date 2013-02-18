<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Biblethon.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="divAccordian">
           <%-- <table style="width: 700px;">
                <tr>
                    <td>
                        Name
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtCustName" runat="server"></asp:TextBox><asp:ImageButton ID="imgSearch" runat="server" OnClientClick="return IsValidate()"
                            OnClick="imgSearch_Click" /><asp:Button ID="btnPopup" runat="server" Text="" Style="visibility: hidden" />
                    </td>
                    <td>
                        Telephone
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table style="width: 700px;">
                <tr>
                    <td>
                        Address
                    </td>
                    <td colspan="3">
                        <asp:Label ID="lblAddress1" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td rowspan="3" valign="bottom">
                        City
                    </td>
                    <td colspan="3">
                        <asp:Label ID="lblAddress2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        Email
                    </td>
                    <td>
                        <asp:TextBox ID="txtBEmail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblAddress3" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblCity" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:CheckBox ID="cbMention" Text="Please do not mention name" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        State
                    </td>
                    <td>
                        <asp:Label ID="lblState" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        Zip Code
                    </td>
                    <td>
                        <asp:Label ID="lblZipCode" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:CheckBox ID="cbCaller" Text="First time caller" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Country
                    </td>
                    <td colspan="3">
                        <asp:DropDownList ID="ddlBCoutry" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">
                        <asp:CheckBox ID="cbShipping" Text="Use same information for shipping address" runat="server" />
                    </td>
                </tr>
            </table>--%>
            <table style="width: 700px;">
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnBillingBack" runat="server" Text="<< Back" />
                        <asp:Button ID="btnBillContinue"
                            runat="server" Text="Continue" onclick="btnBillContinue_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
