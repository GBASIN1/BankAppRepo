<%@ Page Title="" Language="C#" MasterPageFile="~/blank.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BankAppWeb.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div> <asp:Label ID="lblNews" runat="server" Font-Bold="False" Font-Italic="True" ForeColor="#0066FF"></asp:Label></div>
     <div>
            <table>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label></td>
                    <%-- <td></td>--%>
                </tr>
                <tr>
                    <td>UserName</td>
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server">admin</asp:TextBox></td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password">admin</asp:TextBox></td>
                </tr>
                 <tr>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"  />
                    </td>
                    <td>
                        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
                    </td>
                </tr>


            </table>
        </div>
</asp:Content>
