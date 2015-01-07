<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoonmaakPage.aspx.cs" Inherits="RemiseSite_Groep_B.SchoonmaakPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="pnlMedewerker" runat="server">
                <table>
                    <tr>
                        <td>
                            Schoonmaakbeurten voor:
                        </td>
                        <td>
                            <asp:Label ID="lblSchoonmaker" runat="server">Schoonmaker</asp:Label><asp:ListBox ID="lbxBeheerderMedewerker" runat="server" Visible="False" OnSelectedIndexChanged="lbxBeheerderMedewerker_SelectedIndexChanged"></asp:ListBox>
                        </td>
                    </tr>
                </table>
                <asp:ListBox ID="lbxSchoonmaakBeurten" runat="server"></asp:ListBox>
            </asp:Panel>
            <asp:Panel ID="pnlSchoonmaak" runat="server">
                <table>
                    <tr>
                        <td>
                            Beurt ID:
                        </td>
                        <td>
                            <asp:Label ID="lblSchoonmaakBeurtId" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            BeurtType:
                        </td>
                        <td>
                            <asp:Label ID="lblSchoonmaakBeurtType" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tram:
                        </td>
                        <td>
                            <asp:Label ID="lblSchoonmaakTram" runat="server"></asp:Label><br />
                            op spoort <asp:Label ID="lblSchoonmaakSpoor" runat="server"></asp:Label><br />
                            op sector <asp:Label ID="lblSchoonmaakSector" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Begin Datum:
                        </td>
                        <td>
                            <asp:Label ID="lblSchoonmaakBeginDatum" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Medewerkers:
                        </td>
                        <td>
                            <asp:ListBox ID="lbxSchoonmaakMedewerkers" runat="server"></asp:ListBox><br />
                            <asp:Button ID="btnSchoonmaakMedewerkers" runat="server" Text="Verwijderen" Visible="False" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>

            <asp:Panel ID="pnlBeheerder" runat="server" Visible="False">
                <asp:ListBox ID="lbxBeheerderMedewerkers" runat="server"></asp:ListBox>
                <asp:ListBox ID="lbxBeheerderSchoonmaakBeurten" runat="server"></asp:ListBox><br />
                <asp:Button ID="btnBeheerderMedewerkers" runat="server" Text="Voeg Toe" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
