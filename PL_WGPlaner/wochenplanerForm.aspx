<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wochenplanerForm.aspx.cs" Inherits="PL_WGPlaner.wochenplanerForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="styling.css" rel="stylesheet" />

    <title>Wochenplaner</title>
</head>
<body>

    <div id="content"> 
    <div id="logo"> 
            <img src="Bilder/logowg.png" width="250" >
        </div> 

    <form id="form1" runat="server">
        <div>
            <h1>Wochenplaner</h1>
            <h2><asp:Label ID="lbl_Gruppenname" runat="server" Text="GruppenName"></asp:Label> </h2>
            <br />
           

            <div id="inhalt"> 
            <asp:Button ID="btn_Hinzufuegen" runat="server" OnClick="btn_Hinzufuegen_Click" Text="hinzufügen" />
            <br />
            <asp:Button ID="btn_AufgabenBearbeiten" runat="server" Text="Aufgaben bearbeiten" OnClick="btn_AufgabenBearbeiten_Click" />
           </div>

                <br />
            <br />


            <asp:Label ID="lbl_Montag" runat="server" Text="Montag"></asp:Label>
            <div id="tabellewoche"> 
            <asp:GridView ID="grdvw_Montag" runat="server" AutoGenerateColumns="False" DataKeyNames="WID">
                 <Columns>
                    <asp:BoundField  DataField="Titel" HeaderText="Aufgabe" />
                    <asp:BoundField  DataField="person" HeaderText="Person" />
                </Columns>
            </asp:GridView>
                </div>


            <br />
             <asp:Label ID="lbl_Dienstag" runat="server" Text="Dienstag"></asp:Label>
             <div id="tabellewoche">
            <asp:GridView ID="grdvw_Dienstag" runat="server" AutoGenerateColumns="False" DataKeyNames="WID">
                 <Columns>
                    <asp:BoundField  DataField="Titel" HeaderText="Aufgabe" />
                    <asp:BoundField  DataField="person" HeaderText="Person" />
                </Columns>
            </asp:GridView>
                </div>


            <br />
            <asp:Label ID="lbl_Mittwoch" runat="server" Text="Mittwoch"></asp:Label>
            <div id="tabellewoche">
            <asp:GridView ID="grdvw_Mittwoch" runat="server" AutoGenerateColumns="False" DataKeyNames="WID">
                 <Columns>
                    <asp:BoundField  DataField="Titel" HeaderText="Aufgabe" />
                    <asp:BoundField  DataField="person" HeaderText="Person" />
                </Columns>
            </asp:GridView>
                </div>

            <br />
            <asp:Label ID="lbl_Donnerstag" runat="server" Text="Donnerstag"></asp:Label>
            <div id="tabellewoche">
            <asp:GridView ID="grdvw_Donnerstag" runat="server" AutoGenerateColumns="False" DataKeyNames="WID">
                 <Columns>
                    <asp:BoundField  DataField="Titel" HeaderText="Aufgabe" />
                    <asp:BoundField  DataField="person" HeaderText="Person" />
                </Columns>
            </asp:GridView>
                </div>

            <br />
            <asp:Label ID="lbl_Freitag" runat="server" Text="Freitag"></asp:Label>
            <div id="tabellewoche">
            <asp:GridView ID="grdvw_Freitag" runat="server" AutoGenerateColumns="False" DataKeyNames="WID">
                 <Columns>
                    <asp:BoundField  DataField="Titel" HeaderText="Aufgabe" />
                    <asp:BoundField  DataField="person" HeaderText="Person" />
                </Columns>
            </asp:GridView>
            </div>

            <br />
            <asp:Label ID="lbl_Samstag" runat="server" Text="Samstag"></asp:Label>
            <div id="tabellewoche">
            <asp:GridView ID="grdvw_Samstag" runat="server" AutoGenerateColumns="False" DataKeyNames="WID">
                 <Columns>
                    <asp:BoundField  DataField="Titel" HeaderText="Aufgabe" />
                    <asp:BoundField  DataField="person" HeaderText="Person" />
                </Columns>
            </asp:GridView>
                </div>

            <br />
            <asp:Label ID="lbl_Sonntag" runat="server" Text="Sonntag"></asp:Label>
            <div id="tabellewoche">
            <asp:GridView ID="grdvw_Sonntag" runat="server" AutoGenerateColumns="False" DataKeyNames="WID">
                 <Columns>
                    <asp:BoundField  DataField="Titel" HeaderText="Aufgabe" />
                    <asp:BoundField  DataField="person" HeaderText="Person" />
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
