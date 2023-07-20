<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gruppenVerwaltungs_Form.aspx.cs" Inherits="PL_WGPlaner.gruppenVerwaltungs_Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="styling.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Gruppe verwalten</title>
</head>
<body>
    <div id="content">
     <div id="logo"> 
            <img src="Bilder/logowg.png" width="250" >
        </div> 
       
       
    
    <form id="gruppenVerwaltungs_Form" runat="server">
        <div id="inhalt">
            <h1>Willkommen!</h1><br />
            <asp:TextBox ID="txtbx_neuerGruppenName" runat="server" placeholder="Gruppenname" MaxLength="50"></asp:TextBox>
            <br />
            <asp:Button ID="btn_GruppeErstellen" runat="server" Text="neue Gruppe erstellen" OnClick="btn_GruppeErstellen_Click" />
            <br />
            <br />
            <asp:TextBox ID="txtbx_GruppenID" runat="server" placeholder="Gruppen ID" MaxLength="50"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtbx_Gruppenname" runat="server" placeholder="Gruppenname" MaxLength="50"></asp:TextBox>
            <br />
            <asp:Button ID="btn_GruppeBeitreten" runat="server" Text="Gruppe beitreten" OnClick="btn_GruppeBeitreten_Click" />
            <br />
            <br />
            <br />
            <nav> <asp:ImageButton ID="ImageButton2" runat="server" Height="45px" ImageUrl="Bilder/benutzer.png" OnClick="ImageButton2_Click" Width="45px" />
 </nav>
        </div>
    </form>

   
           </div>
</body>
</html>
