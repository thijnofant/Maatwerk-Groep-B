<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="administrator.aspx.cs" Inherits="RemiseSite_Groep_B.administrator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="105px" Width="138px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div runat="server" style="width:1200px">
                    <asp:ListView ID="lvSporen" runat="server" GroupItemCount="12">
                        <LayoutTemplate>
                            <div runat="server">
                                <div id="groupPlaceHolder" runat="server"></div>
                            </div>
                        </LayoutTemplate>
                        <GroupTemplate>
                            <div id="itemPlaceHolder" runat="server"></div>
                        </GroupTemplate>
                        <GroupSeparatorTemplate>
                            <div runat="server" style="clear:both"></div>                       
                        </GroupSeparatorTemplate>
                        <ItemTemplate>
                            <div runat="server" style="float:left;border:solid;width:80px;height:210px">
                                <b> Spoor: <%# Eval("Nummer") %> <b /><br />
                                <asp:ListView ID="lvSectoren" runat="server" DataSource='<%# Eval("sectoren") %>'>
                                    <ItemTemplate>
                                        <b> <%# Eval("Id") %> <b /> : <%# Eval("Blokkade") %> <%# Eval("Tram.Id") %> <br />
                                    </ItemTemplate>
                                </asp:ListView>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>

    <asp:UpdatePanel ID="upPlattegrond" runat="server">
        <ContentTemplate>
            <asp:UpdatePanel ID="upSporen" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Table ID="tableSporen1" runat="server" BorderStyle="None">
                        <asp:TableRow ID="rowSporen1">
                            <asp:TableCell ID="CellSpoor38" runat="server">
                                <asp:Table ID="spoor38" runat="server">
                                    <asp:TableHeaderRow>
                                        <asp:TableCell Width="80" Height="30" HorizontalAlign="Center">
                                            <asp:Button ID="btnSpoor38" runat="server" Width="70" Height="30" Text="38" />
                                        </asp:TableCell>
                                    </asp:TableHeaderRow>
                                    <asp:TableRow>
                                        <asp:TableCell><asp:Button ID="Button1" runat="server" Width="70" Height="30" Text="38" /></asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell></asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:TableCell>
                            <asp:TableCell ID="CellSpoor37" runat="server"></asp:TableCell>
                            <asp:TableCell ID="CellSpoor36" runat="server"></asp:TableCell>
                            <asp:TableCell ID="CellSpoor35" runat="server"></asp:TableCell>
                            <asp:TableCell ID="CellSpoor34" runat="server"></asp:TableCell>
                            <asp:TableCell ID="CellSpoor33" runat="server"></asp:TableCell>
                            <asp:TableCell ID="CellSpoor32" runat="server"></asp:TableCell>
                            <asp:TableCell ID="CellSpoor31" runat="server"></asp:TableCell>
                            <asp:TableCell ID="CellSpoor30" runat="server"></asp:TableCell>
                            <asp:TableCell runat="server" Width="20"></asp:TableCell>
                            <asp:TableCell ID="CellSpoor40" runat="server"></asp:TableCell>
                            <asp:TableCell ID="CellSpoor41" runat="server"></asp:TableCell>
                            <asp:TableCell ID="CellSpoor42" runat="server"></asp:TableCell>
                            <asp:TableCell ID="CellSpoor58" runat="server"></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <asp:Table ID="tableSporen2" runat="server" BorderStyle="None">
                        <asp:TableRow ID="rowSporen2">
                            <asp:TableCell ID="CellSpoor57" runat="server">
                                <asp:Table ID="TableSpoor38" runat="server" BorderStyle="Solid" BorderWidth="1"></asp:Table>
                            </asp:TableCell>
                            <asp:TableCell ID="CellSpoor56" runat="server"></asp:TableCell>
                            <asp:TableCell ID="CellSpoor55" runat="server"></asp:TableCell>
                            <asp:TableCell ID="CellSpoor54" runat="server"></asp:TableCell>
                            <asp:TableCell ID="CellSpoor53" runat="server"></asp:TableCell>
                            <asp:TableCell ID="CellSpoor52" runat="server"></asp:TableCell>
                            <asp:TableCell ID="CellSpoor51" runat="server"></asp:TableCell>
                            <asp:TableCell ID="CellSpoor64" runat="server"></asp:TableCell>
                            <asp:TableCell ID="CellSpoor63" runat="server"></asp:TableCell>
                            <asp:TableCell ID="CellSpoor62" runat="server"></asp:TableCell>
                            <asp:TableCell ID="CellSpoor61" runat="server"></asp:TableCell>
                            <asp:TableCell runat="server" Width="10"></asp:TableCell>
                            <asp:TableCell ID="CellSpoor74" runat="server"></asp:TableCell>
                            <asp:TableCell ID="CellSpoor75" runat="server"></asp:TableCell>
                            <asp:TableCell ID="CellSpoor76" runat="server"></asp:TableCell>
                            <asp:TableCell ID="CellSpoor77" runat="server"></asp:TableCell>
                            <asp:TableCell runat="server" Width="20"></asp:TableCell>
                            <asp:TableCell ID="CellExtraSporen1" runat="server"></asp:TableCell>
                            <asp:TableCell ID="CellExtraSporen2" runat="server"></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer1" />
                </Triggers>
            </asp:UpdatePanel>
            <!--<asp:Timer ID="Timer1" runat="server" Interval="500"></asp:Timer> -->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
