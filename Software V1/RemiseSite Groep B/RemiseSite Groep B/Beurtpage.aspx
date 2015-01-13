<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Beurtpage.aspx.cs" Inherits="RemiseSite_Groep_B.BeurtPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblPaginaTitel" Text="Beurten" runat="server" Font-Size="XX-Large" CssClass="panel-title" ForeColor="#333333"></asp:Label>
    <asp:Table ID="StyleTable" runat="server" GridLines="Both" BorderStyle="Solid" BorderWidth="2">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Panel ScrollBars="Vertical" ID="PanelLijstBeurten" runat="server" Width="600" Height="800" Visible="true">
                    <asp:DataList ID="lijstBeurten" runat="server" OnSelectedIndexChanged="lijstBeurten_SelectedIndexChanged" DataSource='<%# BeurtenOphalen() %>' CellPadding="4" ForeColor="#333333">
                        <AlternatingItemStyle BackColor="White" ForeColor="#284775"></AlternatingItemStyle>

                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

                        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333"></ItemStyle>
                        <ItemTemplate>
                        </ItemTemplate>
                        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedItemStyle>
                    </asp:DataList>
                </asp:Panel>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Panel ID="PanelBeheerder" runat="server" Width="600" Height="800" Visible="false">

                </asp:Panel>
                <asp:Panel ID="PanelMedewerker" runat="server" Width="600" Height="800" Visible="true">
                </asp:Panel>

            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
