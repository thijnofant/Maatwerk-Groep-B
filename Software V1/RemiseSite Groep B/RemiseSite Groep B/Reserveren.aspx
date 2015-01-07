<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reserveren.aspx.cs" Inherits="RemiseSite_Groep_B.Reserveren" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
        <tr>
            <td style="width: 196px">
    <asp:Label ID="Label1" runat="server" Text="Tramnummer"></asp:Label>
            </td>
            <td>
    <asp:Label ID="Label2" runat="server" Text="Spoornummer"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 196px">
    <asp:TextBox ID="tbTramnr" runat="server" Height="30px"></asp:TextBox>
            </td>
            <td>
    <asp:TextBox ID="tbSpoornr" runat="server" Height="30px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 196px">&nbsp;</td>
            <td>
    <asp:Button ID="btnBevestig" runat="server" OnClick="btnBevestig_Click" Text="Bevestig" />
            </td>
        </tr>
    </table>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;<asp:Panel ID="Panel1" runat="server" Width="799px">
        <asp:CheckBox ID="cbReparatie" runat="server" OnCheckedChanged="cbReparatie_CheckedChanged" Text="Reparatie" />
        <br />
        <table class="nav-justified">
            <tr>
                <td style="width: 197px">
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 197px">Soort Reparatie</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 197px">
                    <asp:RadioButton ID="rbKlein" runat="server" Text="Klein" />
                </td>
                <td>
                    <asp:RadioButton ID="rbGroot" runat="server" Text="Groot" />
                </td>
            </tr>
        </table>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:Panel>
    <br />
&nbsp;<asp:Label ID="lblMessage" runat="server" Text="..."></asp:Label>
</asp:Content>
