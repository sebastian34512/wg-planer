<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aufgabeWochenplanerForm.aspx.cs" Inherits="PL_WGPlaner.aufgabeWochenplanerForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="styling.css" rel="stylesheet" />
    <title>Aufgabe hinzufügen</title>
</head>
<body>
<div id="content"> 
    <div id="logo"> 
            <img src="Bilder/logowg.png" width="250" >
        </div> 

    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btn_zurueck" runat="server" Text="Zurück" OnClick="btn_zurueck_Click" /><br />
            
            <h1>Aufgabe zu Wochenplaner hinzufügen</h1> <br />
            <asp:TextBox ID="txtbx_Titel" runat="server" placeholder="Titel" MaxLength="50"></asp:TextBox>
            <br />
            <br />
            <fieldset>
                <legend>Personen:</legend>
            <asp:CheckBoxList ID="chckbxlst_Personen" runat="server" DataTextField="Benutzername" DataValueField="PID">
            </asp:CheckBoxList>
                </fieldset>
            <br />
            <fieldset>
                <legend>Tage:</legend>
            <asp:CheckBoxList ID="chckbxlst_Tage" runat="server" RepeatColumns="2">
                <asp:ListItem Value="0">Montag</asp:ListItem>
                <asp:ListItem Value="1">Dienstag</asp:ListItem>
                <asp:ListItem Value="2">Mittwoch</asp:ListItem>
                <asp:ListItem Value="3">Donnerstag</asp:ListItem>
                <asp:ListItem Value="4">Freitag</asp:ListItem>
                <asp:ListItem Value="5">Samstag</asp:ListItem>
                <asp:ListItem Value="6">Sonntag</asp:ListItem>
            </asp:CheckBoxList>
                </fieldset>
            <br />
            <asp:DropDownList ID="drpdwnlst_Haeufigkeit" runat="server">
                <asp:ListItem Value="0">wöchentlich</asp:ListItem>
                <asp:ListItem Value="1">alle zwei Wochen</asp:ListItem>
                <asp:ListItem Value="2">alle drei Wochen</asp:ListItem>
                <asp:ListItem Value="3">monatlich</asp:ListItem>
                <asp:ListItem Value="4">jährlich</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btn_hinzufügen" runat="server" Text="hinzufügen" OnClick="btn_hinzufügen_Click" /><br />
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
