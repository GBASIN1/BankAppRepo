<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register1.aspx.cs" Inherits="BankAppWeb.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label></td>
                    <%-- <td></td>--%>
                </tr>
                <tr>
                    <td>Name</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server">san</asp:TextBox></td>
                </tr>
                <tr>
                    <td>Account Number</td>
                    <td>
                        <asp:TextBox ID="txtAccNumber" runat="server">12356</asp:TextBox></td>
                </tr>
                <tr>
                    <td>DOB</td>
                    <td>
                        <asp:TextBox ID="txtDOB" runat="server">121212</asp:TextBox></td>
                </tr>
                <tr>
                    <td>Is Married</td>
                    <td>
                        <asp:CheckBox ID="chkMarried" runat="server" /></td>
                </tr>
                <tr>
                    <td>Email Address</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server">san@deep.com</asp:TextBox></td>
                </tr>

                <tr>
                    <td>CustomerID</td>
                    <td>
                        <asp:TextBox ID="txtCutomerID" runat="server">12585</asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnReset" runat="server" Text="Reset" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
