<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registrierungsForm.aspx.cs" Inherits="PL_WGPlaner.registrierungsForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="styling.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <div id="content">
     <div id="logo"> 
            <img src="Bilder/logowg.png" width="250" >
        </div> 
       
        
    <form id="form1" runat="server">
        <div>
            <h1>Registrierung</h1><br />
            <asp:TextBox ID="txtbx_Benutzername" runat="server" placeholder="Benutzername" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtbx_EMail" runat="server" placeholder="EMail" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtbx_Passwort1" runat="server" placeholder="Passwort" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtbx_Passwort2" runat="server" placeholder="Passwort wiederholen" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btn_Registrieren" runat="server" OnClick="btn_Registrieren_Click" Text="Registrieren" />
            <br />
            <asp:Button ID="btn_zumLogin" runat="server" Text="zum Login" OnClick="btn_zumLogin_Click" />
        </div>
    </form>
           </div>
</body>
</html>
