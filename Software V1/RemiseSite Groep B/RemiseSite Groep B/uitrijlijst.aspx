<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="uitrijlijst.aspx.cs" Inherits="RemiseSite_Groep_B.uitrijlijst" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Tram Historie:
        <br />
        <asp:ListBox ID="lbHistory" runat="server" Height="217px" Width="851px"></asp:ListBox>
        <br />
        <br />
        <br />
        Status wijzigen:<br />
&nbsp;<asp:DropDownList ID="ddTrams" runat="server">
        </asp:DropDownList>
        <br />
        <br />
&nbsp;<asp:DropDownList ID="ddStatus" runat="server">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnWijzig" runat="server" OnClick="btnWijzig_Click" Text="Wijzigstatus" />
    </p>
</asp:Content>
