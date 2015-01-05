<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="administrator.aspx.cs" Inherits="RemiseSite_Groep_B.administrator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="upPlattegrond" runat="server">
        <ContentTemplate>
            <asp:ListView ID="lvSporen" runat="server">
            </asp:ListView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
