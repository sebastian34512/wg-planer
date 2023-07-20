using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace BL_WGPlaner
{
    public class Gruppe
    {
        internal Gruppe() { }

        //Membervariablen

        private List<Person> mmitglieder;
        private List<Einkaufslistenitem> meinkaufsliste;
        private string mGID;
        private string mGruppenID;
        private string mname;
        private DateTime jetzt = DateTime.Now;//new DateTime(2022, 8, 24, 12, 0 , 0);

        //Properties
        public List<Einkaufslistenitem> einkaufsliste
        {
            get { return meinkaufsliste; }
            internal set { meinkaufsliste = value; }
        }

        public  List<Person> mitglieder
        {
            get { return mmitglieder; }
            internal set { mmitglieder = value; }
        }

        public string GID
        {
            get { return mGID; }
            internal set { mGID = value; }
        }

        public string GruppenID
        {
            get { return mGruppenID; }
            internal set { mGruppenID = value; }
        }

        public string name
        {
            get { return mname; }
            internal set { mname = value; }
        }

        //Methoden

        public List<Person> getMitglieder(string GID)
        {
            string SQL = "select PID, Benutzername, EMail, GID from Personen where GID=@gid";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Starter.getConnection();
            cmd.Parameters.Add(new SqlParameter("gid", GID));

            SqlDataReader reader = cmd.ExecuteReader();

            List<Person> sqlPersonenListe = new List<Person>();

            while (reader.Read())
            {
                Person sqlPerson = new Person();
                sqlPerson.PID = reader.GetString(0);
                sqlPerson.benutzername = reader.GetString(1);
                sqlPerson.email = reader.GetString(2);
                sqlPerson.GID = reader.GetString(3);

                sqlPersonenListe.Add(sqlPerson);
            }
            cmd.Connection.Close();
            return sqlPersonenListe;
        }

        public bool deleteMitglied(string PID)
        {
            string SQL2 = "update Personen set GID = @gid where PID = @pid";
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = SQL2;
            cmd2.Connection = Starter.getConnection();

            cmd2.Parameters.Add(new SqlParameter("gid", DBNull.Value));
            cmd2.Parameters.Add(new SqlParameter("pid", PID));

            if (cmd2.ExecuteNonQuery() == 0)
            {
                cmd2.Connection.Close();
                return false;
            }
            else
            {
                cmd2.Connection.Close();
                return true;
            }
        }

        public List<Einkaufslistenitem> loadEinkaufsliste()
        {
            string SQL = "select EID, Artikel, Anzahl, Einheit, GID from Einkaufslistenitems where GID=@gid";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Starter.getConnection();
            cmd.Parameters.Add(new SqlParameter("gid", this.GID));

            SqlDataReader reader = cmd.ExecuteReader();

            List<Einkaufslistenitem> sqlEinkaufsListe = new List<Einkaufslistenitem>();

            while (reader.Read())
            {
                Einkaufslistenitem sqlItem = new Einkaufslistenitem();
                sqlItem.EID = reader.GetString(0);
                sqlItem.artikel = reader.GetString(1);
                sqlItem.anzahl = reader.GetInt32(2);
                sqlItem.einheit = reader.GetString(3);
                sqlItem.GID = reader.GetString(4);

                sqlEinkaufsListe.Add(sqlItem);
            }
            cmd.Connection.Close();
            return sqlEinkaufsListe;
        }

        public Einkaufslistenitem insertEinkaufslistenitem (string Artikel, int Anzahl, string Einheit)
        {
            //GUID erstellen
            string EID_GUID = Guid.NewGuid().ToString();

            Einkaufslistenitem newItem = new Einkaufslistenitem();
            newItem.EID = EID_GUID;
            newItem.artikel = Artikel;
            newItem.anzahl = Anzahl;
            newItem.einheit = Einheit;
            newItem.GID = this.GID;

            string SQL = "insert into Einkaufslistenitems (EID, Artikel, Anzahl, Einheit, GID) values (@eid, @artikel, @anzahl, @einheit, @gid)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Starter.getConnection();

            cmd.Parameters.Add(new SqlParameter("eid", EID_GUID));
            cmd.Parameters.Add(new SqlParameter("artikel", Artikel));
            cmd.Parameters.Add(new SqlParameter("anzahl", Anzahl));
            cmd.Parameters.Add(new SqlParameter("einheit", Einheit));
            cmd.Parameters.Add(new SqlParameter("gid", this.GID));

            if (cmd.ExecuteNonQuery() == 0)
            {
                cmd.Connection.Close();
                return null;
            } else
            {
                cmd.Connection.Close();
                return newItem;
            }            
        }

        public bool deleteEinkaufslistenitem (string EID)
        {
            string SQL = "delete from Einkaufslistenitems where EID = @eid";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Starter.getConnection();

            cmd.Parameters.Add(new SqlParameter("eid", EID));
            if (cmd.ExecuteNonQuery() == 0)
            {
                cmd.Connection.Close();
                return false;
            }
            else
            {
                cmd.Connection.Close();
                return true;
            }
        }

        public ToDolistenitem insertToDoListItem(string aufgabe, DateTime datum, string pid)
        {
            string TDID_GUID = Guid.NewGuid().ToString();

            ToDolistenitem newItem = new ToDolistenitem();
            newItem.TDID = TDID_GUID;
            newItem.aufgabe = aufgabe;
            newItem.datum = datum.Date.ToString("d");
            newItem.GID = this.GID;
            newItem.PID = pid;

            string SQL = "insert into ToDoListenItems (TDID, Aufgabe, Datum, GID, PID) values (@tdid, @aufgabe, @datum, @gid, @pid)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Starter.getConnection();

            cmd.Parameters.Add(new SqlParameter("tdid", TDID_GUID));
            cmd.Parameters.Add(new SqlParameter("aufgabe", aufgabe));
            cmd.Parameters.Add(new SqlParameter("datum", datum));
            cmd.Parameters.Add(new SqlParameter("gid", this.GID));
            cmd.Parameters.Add(new SqlParameter("pid", pid)); ;

            if (cmd.ExecuteNonQuery() == 0)
            {
                cmd.Connection.Close();
                return null;
            }
            else
            {
                cmd.Connection.Close();
                return newItem;
            }
        }

        public bool deleteTDItem(string TDID)
        {
            string SQL2 = "delete from ToDoListenitems where TDID = @tdid";
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = SQL2;
            cmd2.Connection = Starter.getConnection();

            cmd2.Parameters.Add(new SqlParameter("tdid", TDID));
            if (cmd2.ExecuteNonQuery() == 0)
            {
                cmd2.Connection.Close();
                return false;
            }
            else
            {
                cmd2.Connection.Close();
                return true;
            }
        }

        public List<ToDolistenitem> loadToDoListe()
        {
            //Join wird gebraucht um den Benutzernamen zu speichern
            string SQL = "select ToDoListenitems.TDID, ToDoListenitems.Aufgabe, ToDoListenitems.Datum, ToDoListenitems.PID, ToDoListenitems.GID, Personen.Benutzername from [dbo].[ToDoListenitems] inner join [dbo].[Personen] on ToDoListenitems.PID = Personen.PID where ToDoListenitems.GID = @gid";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Starter.getConnection();
            cmd.Parameters.Add(new SqlParameter("gid", this.GID));

            SqlDataReader reader = cmd.ExecuteReader();

            List<ToDolistenitem> sqlToDoListe = new List<ToDolistenitem>();


            while (reader.Read())
            {
                ToDolistenitem sqlItem = new ToDolistenitem();
                sqlItem.TDID = reader.GetString(0);
                sqlItem.aufgabe = reader.GetString(1);
                sqlItem.datum = reader.GetDateTime(2).ToString("d");
                sqlItem.GID = reader.GetString(3);
                sqlItem.PID = reader.GetString(4);
                sqlItem.benutzername = reader.GetString(5);
                sqlToDoListe.Add(sqlItem);
            }

            cmd.Connection.Close();

            return sqlToDoListe;
        }


        public WochenplanerItem insertWochenplanerItem(string Titel, List<string> personen, List<int> tage, int haeufigkeit)
        {
            //Item anlegen
            string WID_GUID = Guid.NewGuid().ToString();

            WochenplanerItem newItem = new WochenplanerItem();
            newItem.WID = WID_GUID;
            newItem.titel = Titel;
            DateTime erstellung = jetzt;
            newItem.erstellung = erstellung;
            newItem.haeufigkeit = haeufigkeit;
            newItem.GID = this.GID;

            string SQL = "insert into Wochenplaneritems (WID, Titel, GID, Erstellung, Haeufigkeit) values (@wid, @titel, @gid, @erstellung, @haeufigkeit)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Starter.getConnection();

            cmd.Parameters.Add(new SqlParameter("wid", WID_GUID));
            cmd.Parameters.Add(new SqlParameter("titel", Titel));
            cmd.Parameters.Add(new SqlParameter("gid", this.GID));
            cmd.Parameters.Add(new SqlParameter("erstellung", erstellung));
            cmd.Parameters.Add(new SqlParameter("haeufigkeit", haeufigkeit));

            if (cmd.ExecuteNonQuery() == 0)
            {
                cmd.Connection.Close();
                return null;
            }
            else
            {
                cmd.Connection.Close();
                for (int i = 0; i < personen.Count; i++)
                {
                    string SQL2 = "insert into WochenplaneritemsPersonen (WID, PID, Reihenfolge) values (@wid, @pid, @reihenfolge)";
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.CommandText = SQL2;
                    cmd2.Connection = Starter.getConnection();
                    string PID = personen[i];

                    cmd2.Parameters.Add(new SqlParameter("wid", WID_GUID));
                    cmd2.Parameters.Add(new SqlParameter("pid", PID));
                    cmd2.Parameters.Add(new SqlParameter("reihenfolge", i));
                    if (cmd2.ExecuteNonQuery() == 0)
                    {
                        cmd2.Connection.Close();
                        return null;
                    }
                    cmd2.Connection.Close();
                }

                    for (int j = 0; j < tage.Count; j++)
                    {
                        string SQL3 = "insert into WochenplaneritemsTage (WID, Tag) values (@wid, @tag)";
                        SqlCommand cmd3 = new SqlCommand();
                        cmd3.CommandText = SQL3;
                        cmd3.Connection = Starter.getConnection();
                        int tag = tage[j];

                        cmd3.Parameters.Add(new SqlParameter("wid", WID_GUID));
                        cmd3.Parameters.Add(new SqlParameter("tag", tag));
                        if (cmd3.ExecuteNonQuery() == 0)
                        {
                            cmd3.Connection.Close();
                        return null;
                        }
                        cmd3.Connection.Close();
                    }
                return newItem;
                }
            }

        public bool deleteAufgabe(string WID)
        {
            string wid = WID;
            string SQL = "delete from WochenplaneritemsTage where WID = @wid";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Starter.getConnection();

            cmd.Parameters.Add(new SqlParameter("wid", WID));

            if (cmd.ExecuteNonQuery() == 0)
            {
                return false;
            }
            string SQL2 = "delete from WochenplaneritemsPersonen where WID = @wid";
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = SQL2;
            cmd2.Connection = Starter.getConnection();

            cmd2.Parameters.Add(new SqlParameter("wid", WID));
            if (cmd2.ExecuteNonQuery() == 0)
            {
                return false;
            }

            string SQL3 = "delete from Wochenplaneritems where WID = @wid";
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = SQL3;
            cmd3.Connection = Starter.getConnection();
            cmd3.Parameters.Add(new SqlParameter("wid", WID));
            if (cmd3.ExecuteNonQuery() == 0)
            {
                return false;
            }    

            return true;

        }

        // This presumes that weeks start with Monday.
        // Week 1 is the 1st week of the year with a Thursday in it.
        private static int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        //getAufgaben wird nur verwendet um die Übersicht der Aufgaben zu laden, bei der sie gelöscht werden können.
        //Für den eigentlichen Wochenplaner wird sie also nicht benötigt.
        public List<WochenplanerItem> getAufgaben(string GID)
        {
            string SQL = "select WID, Titel, Erstellung, Haeufigkeit from Wochenplaneritems where GID=@gid";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Starter.getConnection();
            cmd.Parameters.Add(new SqlParameter("gid", GID));

            SqlDataReader reader = cmd.ExecuteReader();        

            List<WochenplanerItem> sqlAufgaben = new List<WochenplanerItem>();

            while (reader.Read())
            {
                WochenplanerItem sqlItem = new WochenplanerItem();
                sqlItem.WID = reader.GetString(0);
                sqlItem.titel = reader.GetString(1);
                sqlItem.erstellung = reader.GetDateTime(2);
                sqlItem.haeufigkeit = reader.GetInt32(3);
                sqlAufgaben.Add(sqlItem);
            }
            cmd.Connection.Close();
            return sqlAufgaben;
        }

        //Die Funktionalität des Wochenplaners besteht hauptsächlich aus drei Methoden: getWochentag, getName und loadPerson.
        //Wenn der Wochenplan aufgerufen wird, wird für jeden Tag der Woche (Montag = 0 bis Sonntag = 6) die Methode getWochentag aufgerufen.
        //Die Methode holt sich zuerst alle Wochenplaneritems, die für den gefragten Tag für die eigene Gruppe existieren (Ob das Item angezeigt
        //werden soll, wird erst später geschaut).
        //Beim Auslesen der Items wird dann die Methode getName relevant. Die erfüllt zwei Zwecke: sie gibt den Namen der Person zurück,
        //die diese Woche für das Item zuständig ist und wenn sie einen leeren String zurück gibt, soll das Item garnicht angezeigt
        //werden. (Wenn zB. das Item alle drei Wochen angezeigt werden soll und erst eine Woche vergangen ist)
        //Sie übernimmt also auch die Filterung der Items.
        //Die Methode funktionert mit einem Switch-Case Block, der nach der eingestellten Häufigkeit arbeitet. Der Switch-Case Block erledigt
        //zuerst die erste Aufgabe der Methode getName: Schauen, ob das Item in der aktuellen Woche angezeigt werden soll.
        //Dafür wird der Modulo der aktuellen Kalenderwoche minus der Kalenderwoche der Erstellung herangezogen. zB.:
        //KW Erstellung: 30         KW Jetzt: 32
        //Different: 32-30 = 2
        //Wenn jetzt als Häufigkeit "alle zwei Wochen" eingestellt wurde, muss nur geschaut werden, ob bei der Differenz Modulo 2 Null ergibt,
        //dann muss das Item angezeigt werden. (bei alle drei Wochen dann Modulo 3 und so weiter)
        //Wenn das der Fall ist, ist die erste Aufgabe erfüllt: wir wissen, das Item muss angezeigt werden. Jetzt zum zweiten Teil: welche
        //Person ist zuständig?
        //Beim Erstellen des Items wird in der Datenbank eine Reihenfolge der beteiligten Personen angelegt, zB.:
        //Anna 0    Peter 1     Martin 2
        //Damit und mit dem Datum der Erstellung kann sich zu jedem Zeitpunkt des Aufrufes des Wochenplaners berechnet werden,
        //welche Person diese Woche zuständig ist, und zwar mit folgender Formel:
        //  ( ( aktuelleKalenderwoche - erstellungKalenderwoche ) / Wochenintervall ) % anzahlPersonen
        // Hinweis: bei Wöchentlich und Jährlich ist das Interval 1 deshalb wird die Division weggelassen
        //Diese Formel gibt eine Zahl zurück, die der Reihenfolgenzahl in der Datenbank entrspricht. Dann wird dir Methode loadPerson aufgerufen
        //Und die getName gibt den Namen der Person zurück, womit das aktuell abgefrage Wochenplaneritem zum Wochenplaner dieser Woche
        //hinzugefügt wird. Gibt die Methode einen leeren String zurück wissen wir, dass das aktuell abgearbeitete Item diese Woche nicht
        //relevant ist und das Hinzufügen wird übersprungen.

        public List<WochenplanerItem> getWochentag (string GID, int wochentag)
        {
            string SQL = "select Wochenplaneritems.WID, Wochenplaneritems.Titel, Wochenplaneritems.Erstellung, Wochenplaneritems.Haeufigkeit from [dbo].[Wochenplaneritems] inner join [dbo].[WochenplaneritemsTage] on Wochenplaneritems.WID = WochenplaneritemsTage.WID where WochenplaneritemsTage.Tag=@tag AND Wochenplaneritems.GID = @gid";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Starter.getConnection();
            cmd.Parameters.Add(new SqlParameter("tag", wochentag));
            cmd.Parameters.Add(new SqlParameter("gid", GID));

            SqlDataReader reader = cmd.ExecuteReader();

            List<WochenplanerItem> sqlAufgaben = new List<WochenplanerItem>();

            while (reader.Read())
            {
                WochenplanerItem sqlItem = new WochenplanerItem();
                sqlItem.WID = reader.GetString(0);
                sqlItem.titel = reader.GetString(1);
                sqlItem.erstellung = reader.GetDateTime(2);
                sqlItem.haeufigkeit = reader.GetInt32(3);
                string name = getName(sqlItem.erstellung, sqlItem.haeufigkeit, sqlItem.WID);
                if ( name != "")
                {
                    sqlItem.person = name;
                    sqlAufgaben.Add(sqlItem);
                }
                
            }
            cmd.Connection.Close();
            return sqlAufgaben;
        }

        
        private string getName(DateTime erstellung, int haeufigkeit, string WID)
        {
            //Anzahl an beteiligten Personen
            string SQL = "select MAX(Reihenfolge) anzahl_personen from WochenplaneritemsPersonen where WID = @wid";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Starter.getConnection();
            cmd.Parameters.Add(new SqlParameter("wid", WID));

            SqlDataReader reader = cmd.ExecuteReader();

            int anzahlPersonen = 0;

            while (reader.Read())
            {
                //+1 Weil die Reihenfolge bei 0 beginnt, wenn es zB nur eine Person ist, ist die Anzahl nicht 0 sondern 1
                anzahlPersonen = reader.GetInt32(0) + 1;
            }
            cmd.Connection.Close();

            string name = "";
            int personNumber = 0;
            bool loadPerson = false;
            int aktuelleWoche = GetIso8601WeekOfYear(jetzt);
            int erstellungsWoche = GetIso8601WeekOfYear(erstellung);

            switch (haeufigkeit)
            {
                //mit (aktuelleWoche - erstellungsWoche == 0) wird geschaut, ob wir uns gerade in der Woche der Erstellung befinden,
                //dann ist die Häufigkeit nicht relevant.
                case 0:
                    //Wöchentlich
                    loadPerson = true;
                    personNumber = (aktuelleWoche - erstellungsWoche) % anzahlPersonen;
                    break;
                case 1:
                    //jede zweite Woche
                    if (aktuelleWoche - erstellungsWoche == 0)
                    {
                        loadPerson = true;
                    }
                    else if ((aktuelleWoche - erstellungsWoche) % 2 == 0)
                    {
                        loadPerson = true;
                    }
                    if(loadPerson)
                    {
                       personNumber = ((aktuelleWoche - erstellungsWoche) / 2) % anzahlPersonen;
                    }
                    break;
                case 2:
                    //jede dritte Woche
                    if (aktuelleWoche - erstellungsWoche == 0)
                    {
                        loadPerson = true;
                    }
                    else if ((aktuelleWoche - erstellungsWoche) % 3 == 0)
                    {
                        loadPerson = true;
                    }
                    if (loadPerson)
                    {
                        personNumber = ((aktuelleWoche - erstellungsWoche) / 3) % anzahlPersonen;
                    }
                    break;
                case 3:
                    //Monatlich
                    if (aktuelleWoche - erstellungsWoche == 0)
                    {
                        loadPerson = true;
                    }
                    else if ((aktuelleWoche - erstellungsWoche) % 4 == 0)
                    {
                        loadPerson = true;
                    }
                    if (loadPerson)
                    {
                        personNumber = ((aktuelleWoche - erstellungsWoche) / 4) % anzahlPersonen;
                    }
                    break;
                case 4:
                    //Jährlich
                    if (aktuelleWoche - erstellungsWoche == 0)
                    {
                        loadPerson = true;
                        personNumber = (jetzt.Year - erstellung.Year) % anzahlPersonen;
                    }
                    break;
                default:
                    loadPerson = false;
                    break;
            }
            if (loadPerson)
            {
                name = ladePerson(personNumber);
            }
            
            return name;
        }

        private string ladePerson (int reihenfolge)
        {
            string SQL2 = "select Personen.Benutzername from[dbo].[Personen] inner join [dbo].[WochenplaneritemsPersonen] on Personen.PID = WochenplaneritemsPersonen.PID where WochenplaneritemsPersonen.Reihenfolge = @reihenfolge";
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = SQL2;
            cmd2.Connection = Starter.getConnection();
            cmd2.Parameters.Add(new SqlParameter("reihenfolge", reihenfolge));

            SqlDataReader reader2 = cmd2.ExecuteReader();

            string name = "";

            while (reader2.Read())
            {
                name = reader2.GetString(0);
            }
            cmd2.Connection.Close();
            return name;
        }

        public List<Aktuelles> loadAktuelles ()
        {
            //Zuerst werden alle ToDoListenItems des heutigen Tages abgefragt
            string SQL = "select Aufgabe, DAY(Datum) tag, MONTH(Datum) monat from ToDoListenitems where GID=@gid and YEAR(Datum)=@year and MONTH(Datum)=@month and DAY(Datum)=@day";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Starter.getConnection();
            cmd.Parameters.Add(new SqlParameter("gid", this.GID));
            cmd.Parameters.Add(new SqlParameter("year", jetzt.Year));
            cmd.Parameters.Add(new SqlParameter("month", jetzt.Month));
            cmd.Parameters.Add(new SqlParameter("day", jetzt.Day));

            SqlDataReader reader = cmd.ExecuteReader();

            List<Aktuelles> sqlAktuelles = new List<Aktuelles>();

            //Die werden dann einer Liste "sqlAktuelles" hinzugefügt, die später im Frontend angezeigt wird.
            while (reader.Read())
            {
                Aktuelles sqlItem = new Aktuelles();
                sqlItem.bezeichnung = reader.GetString(0);
                string datum = reader.GetInt32(1).ToString();
                datum += ".";
                datum += reader.GetInt32(2).ToString();
                sqlItem.datum = datum;
                sqlAktuelles.Add(sqlItem);
            }
            int wochentag = (int)(jetzt.DayOfWeek + 6) % 7;

            List<WochenplanerItem> WPItems = new List<WochenplanerItem>();
            WPItems = getWochentag(this.GID, wochentag);

            //Weil bei Aktuelles aber auch die Wochenplaneritems angezeigt werden sollen, wird die oben beschriebene Methode
            //getWochentag verwendet, um die Wochenplaneritems für den heutigen Tag zu erhalten.
            if (WPItems.Count != 0)
            {
                for(int i = 0; i < WPItems.Count; i++)
                {
                    //Davon werden aber nur Bezeichnung und Datum benötigt, wobei das Datum ja sowieso das heutige Datum ist.
                    //Diese Items werden auch der Liste "sqlAktuelles" hinzugefügt. 
                    Aktuelles sqlItem = new Aktuelles();
                    sqlItem.bezeichnung = WPItems[i].titel;
                    string datum = jetzt.Day + "." + jetzt.Month;
                    sqlItem.datum = datum;
                    sqlAktuelles.Add(sqlItem);                    
                }
            }

            //Sollte es dann weder ToDoListenItems noch Wochenplaneritems in die Liste "sqlAktuelles" geschafft haben,
            //dann ist die Liste leer und es wird ein Dummy-Item hinzugefügt, dass nur besagt, dass es keine Items gibt.

            if(sqlAktuelles.Count == 0)
            {
                Aktuelles item = new Aktuelles();
                item.bezeichnung = "Heute keine Aufgaben!";
                item.datum = "";
                sqlAktuelles.Add(item);
            }

            cmd.Connection.Close();

            return sqlAktuelles;
        }
    }
}
