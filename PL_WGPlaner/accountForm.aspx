<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accountForm.aspx.cs" Inherits="PL_WGPlaner.accountForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Account</title>
    <link href="styling.css" rel="stylesheet" />
</head>
<body>
    <div id="content"> 
    <div id="logo"> 
            <img src="Bilder/logowg.png" width="250" >
        </div> 

    <form id="form1" runat="server">
        <div>
            <h1><asp:Label ID="lbl_account" runat="server" Text="Account"></asp:Label> </h1>
            <h2>  <asp:Label ID="lbl_gruppenname" runat="server" Text="Gruppennamen"></asp:Label></h2>
            <br />
            <div id="gruppenid"> 
            <b> <asp:Label ID="lbl_gruppenID" runat="server" Text="ABCDEF"></asp:Label><br /></b>
            <asp:Label ID="lbl_ruppenID" runat="server" Text="GruppenID"></asp:Label><br />
                </div>
            <br />
            <br />
            <br />
            <br />

            <asp:Button ID="btn_mitgliederEinsehen" runat="server" Text="Mitglieder Einsehen" OnClick="btn_mitgliederEinsehen_Click" /><br />
            <asp:Button ID="btn_meinKonto" runat="server" Text="Mein Konto" OnClick="btn_meinKonto_Click" /><br /> 
            <asp:Button ID="btn_Ausloggen" runat="server" OnClick="btn_Ausloggen_Click" Text="Ausloggen" />
            <br />
            <br />
            <asp:Button ID="btn_gruppeLoeschen" runat="server" Text="Gruppe löschen" OnClick="btn_gruppeLoeschen_Click" />
            <br />
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
