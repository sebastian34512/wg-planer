﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deleteWochenplanerForm.aspx.cs" Inherits="PL_WGPlaner.deleteWochenplanerForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="styling.css" rel="stylesheet" />
    <title>Aufgaben löschen</title>

</head>
<body>
     <div id="content"> 
    <div id="logo"> 
            <img src="Bilder/logowg.png" width="250" >
        </div> 

    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btn_zurueck" runat="server" Text="Zurück" OnClick="btn_zurueck_Click" /><br /><br />
            <h1> Aufgaben bearbeiten</h1><br />
            <div id="tabellewoche"> 
            <asp:GridView ID="grdvw_Aufgaben" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" DataKeyNames="WID" OnRowDeleting="grdvw_Aufgaben_RowDeleting">
                 <Columns>
                    <asp:BoundField  DataField="Titel" HeaderText="Aufgabe" />
                </Columns>
            </asp:GridView>
                </div>
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
