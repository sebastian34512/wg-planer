<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginForm.aspx.cs" Inherits="PL_WGPlaner.loginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="styling.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
</head>
<body>
    <div id="content">
        <div id="logo"> 
            <img src="Bilder/logowg.png" width="250" >
        </div> 
       
        
        <form id="form1" runat="server">
         
            <h1><asp:Label ID="lbl_login" runat="server" Text="Login"></asp:Label></h1><br />
            <asp:TextBox ID="txtbx_EmailLogin" runat="server" placeholder="E-Mail" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox><br />
            <asp:TextBox ID="txtbx_PasswortLogin" runat="server" placeholder="Passwort" MaxLength="50" AutoCompleteType="Disabled"></asp:TextBox><br />
            <br />
            <asp:Button ID="btn_login" runat="server" Text="Login" OnClick="btn_login_Click" /><br />
            <asp:Button ID="btn_zurRegistrierung" runat="server" Text="Zur Registrierung" OnClick="btn_zurRegistrierung_Click" /><br />
              
        </form>
         
          
    
&nbsp;</p>
        </div>     
     
</body>
</html>
