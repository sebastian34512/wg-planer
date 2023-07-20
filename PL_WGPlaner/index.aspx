<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="PL_WGPlaner.index" %>

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
        
            <h1><asp:Label ID="lbl_GruppenName" runat="server" Text="GruppenName"></asp:Label></h1>
&nbsp;
        <div id="scroll">
        
            <div id="aktuelles">
                <u>Aktuelles </u>
                <br />
                <br />
                
            
            <asp:GridView ID="grdvw_Aktuelles" AutoGenerateColumns="False" runat="server">
                <Columns>
                <asp:BoundField  DataField="bezeichnung" HeaderText="Bezeichnung" />
                <asp:BoundField  DataField="datum" HeaderText="Datum"/>
                </Columns>
            </asp:GridView>
            </div>
            </div>
        <br />
        
        
            <asp:Button ID="btn_Einkaufliste" runat="server" Text="Einkaufsliste" OnClick="Button1_Click" />
            <asp:Button ID="btn_Wochenplaner" runat="server" Text="Wochenplaner" OnClick="btn_Wochenplaner_Click" />
            <asp:Button ID="btn_ToDoListe" runat="server" Text="To-Do Liste" OnClick="btn_ToDoListe_Click" />
        <br />
        <br />
        
    <br />
    <br />
    <br />
       
            <nav>
            <asp:ImageButton ID="ImageButton1" runat="server" Height="50px" ImageUrl="Bilder/startseite.png" OnClick="ImageButton1_Click" Width="50px" />
            <asp:Label ID="lbl_HeutigerTag" runat="server" Text=""></asp:Label>
            <asp:Label ID="lbl_HeutigesDatum" runat="server" Text=""></asp:Label>
            <asp:ImageButton ID="ImageButton2" runat="server" Height="45px" ImageUrl="Bilder/benutzer.png" OnClick="ImageButton2_Click" Width="45px" />
             </nav>
         
    </form>
           </div>
</body>
</html>
