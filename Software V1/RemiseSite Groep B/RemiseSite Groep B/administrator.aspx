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
                            <div runat="server" style="float:left;border:solid;width:80px;height:250px">
                                Spoor: <%# Eval("Nummer") %> <br />
                                <asp:ListView ID="lvSectoren" runat="server" DataSource='<%# Eval("sectoren") %>'>
                                    <ItemTemplate>
                                        Sector <%# Eval("Id") %> <br />
                                    </ItemTemplate>
                                </asp:ListView>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        Spoor blokkeren 
        <br />
        Spoor:<br /><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:Button ID="Button2" runat="server" Text="Button" />
    </asp:Panel>
</asp:Content>
