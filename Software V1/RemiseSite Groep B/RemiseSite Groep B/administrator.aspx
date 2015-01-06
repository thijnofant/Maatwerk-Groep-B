<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="administrator.aspx.cs" Inherits="RemiseSite_Groep_B.administrator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="upPlattegrond" runat="server">
        <ContentTemplate>
            <asp:ListView ID="lvSporen" runat="server">
                <ItemTemplate>
                    <div style="float:left;margin:10px">
                        <b>Spoornummer:</b> <%# Eval("Nummer") %>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
