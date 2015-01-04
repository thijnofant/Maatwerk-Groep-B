<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bestuurder.aspx.cs" Inherits="RemiseSite_Groep_B.Bestuurder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    ga naar spoor<br />
    <asp:Label ID="lblGoToTrack" runat="server" Text="..."></asp:Label>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="tbInput" runat="server" Height="37px" Width="99px"></asp:TextBox>
    <br />
    <asp:Button ID="btnOne" runat="server" OnClick="btnOne_Click" Text="1" Width="65px" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnTwo" runat="server" OnClick="btnTwo_Click" Text="2" Width="65px" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnThree" runat="server" OnClick="btnThree_Click" Text="3" Width="65px" />
    <br />
    <asp:Button ID="btnFour" runat="server" OnClick="btnFour_Click" Text="4" Width="65px" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnFive" runat="server" OnClick="btnFive_Click" Text="5" Width="65px" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnSix" runat="server" OnClick="btnSix_Click" Text="6" Width="65px" />
    <br />
    <asp:Button ID="btnSeven" runat="server" OnClick="btnSeven_Click" Text="7" Width="65px" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnEight" runat="server" OnClick="btnEight_Click" Text="8" Width="65px" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnNine" runat="server" OnClick="btnNine_Click" Text="9" Width="65px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:CheckBox ID="cbMaintenance" runat="server" Text="Onderhoud nodig" />
    <br />
    <asp:Button ID="btnBackspace" runat="server" OnClick="btnBackspace_Click" Text="herstel" Width="65px" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnZero" runat="server" OnClick="btnZero_Click" Text="0" Width="65px" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="Bevestig" Width="65px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:CheckBox ID="cbCleaning" runat="server" Text="schoonmaak nodig" />
    <br />
    <br />
    <asp:Label ID="lblMessage" runat="server" Text="..."></asp:Label>
    <br />
</asp:Content>
