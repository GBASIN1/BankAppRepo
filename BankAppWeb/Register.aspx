<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BankAppWeb.Register1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
</asp:Content>
