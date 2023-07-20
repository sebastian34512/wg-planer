﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="todoForm.aspx.cs" Inherits="PL_WGPlaner.todoForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>To-Do Liste</title>
    <link href="styling.css" rel="stylesheet" />

</head>
<body>
    <div id="content"> 
    <div id="logo"> 
            <img src="Bilder/logowg.png" width="250" >
        </div> 

    <form id="form1" runat="server">
        <div>
           <h1> <asp:Label ID="lbl_todoListe" runat="server" Text="To-Do-Liste"></asp:Label>  </h1> 
            <h2><asp:Label ID="lbl_gruppenname" runat="server"></asp:Label> </h2>
            <br />
        
            <asp:TextBox ID="txt_aufgabe" runat="server" placeholder="Aufgabe" MaxLength="50"></asp:TextBox>
            <div id="kalender"> 
            <asp:Calendar ID="cal_todoDate" runat="server" OnClientClick="return false;" OnDayRender="cal_todoDate_DayRender"></asp:Calendar> 
            </div>
            <br />
            <asp:DropDownList ID="ddlist_personen" runat="server" DataTextField="Benutzername" DataValueField="PID">
            </asp:DropDownList>                
            <br />
            <br />
            <asp:Button ID="btn_hinzufuegen" runat="server" Text="Hinzufügen" OnClick="btn_hinzufuegen_Click"/>
            <br />
            <br />
            <div id="todo"> 
            <asp:GridView ID="grdvw_ToDoListItems" runat="server" AutoGenerateDeleteButton="True" AutoGenerateColumns="False" OnRowDeleting="grdvw_ToDoListItems_RowDeleting" DataKeyNames="TDID">
                <Columns>
                    <asp:BoundField  DataField="Aufgabe" HeaderText="To-Dos" />
                    <asp:BoundField  DataField="Datum" HeaderText="Bis Wann?"/>
                    <asp:BoundField  DataField="Benutzername" HeaderText="Wer?" />
                </Columns>
            </asp:GridView>
                </div>
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

