<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="meinKontoForm.aspx.cs" Inherits="PL_WGPlaner.meinKontoForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Mein Konto</title>
    <link href="styling.css" rel="stylesheet" />
</head>
<body>
    <div id="content"> 
    <div id="logo"> 
            <img src="Bilder/logowg.png" width="250" >
        </div> 

    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btn_zurueck" runat="server" Text="Zurück" OnClick="btn_zurueck_Click" />
            <br />
            
            <h1>Mein Konto </h1><br />
            <asp:Label ID="lbl_Benutzername" runat="server" Text="Benutzername"></asp:Label><br />
            <asp:Label ID="lbl_BenuzterNameAktuell" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:TextBox ID="txtbx_Benutzername" runat="server" MaxLength="50"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_EMail" runat="server" Text="E-Mail"></asp:Label><br />
            <asp:Label ID="lbl_EMailAktuell" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:TextBox ID="txtbx_EMail" runat="server" MaxLength="50"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_altesPasswort" runat="server" Text="altes Passwort"></asp:Label>
            <br />
            <asp:TextBox ID="txtbx_altesPasswort" runat="server" MaxLength="50"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_neuesPasswort1" runat="server" Text="neues Passwort"></asp:Label>
            <br />
            <asp:TextBox ID="txtbx_NeuesPasswort1" runat="server" MaxLength="50"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_neuesPasswort2" runat="server" Text="neues Passwort bestätigen"></asp:Label>
            <br />
            <asp:TextBox ID="txtbx_NeuesPasswort2" runat="server" MaxLength="50"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btn_Speichern" runat="server" OnClick="btn_Speichern_Click" Text="Speichern" />
            <br />
            <br />

            <nav> 
            <asp:ImageButton ID="ImageButton1" runat="server" Height="50px" ImageUrl="Bilder/startseite.png" OnClick="ImageButton1_Click" Width="50px" />

            <asp:Label ID="lbl_HeutigerTag" runat="server" Text=""></asp:Label>
            <asp:Label ID="lbl_HeutigesDatum" runat="server" Text=""></asp:Label>
            <asp:ImageButton ID="ImageButton2" runat="server" Height="45px" ImageUrl="Bilder/benutzer.png" OnClick="ImageButton2_Click" Width="45px" />

                </nav>
        </div>
    </form>
        </div>
</body>
</html>
