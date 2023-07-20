using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;

namespace BL_WGPlaner
{
    public static class Starter
    {
       
        // Hilfsmethode, die eine Verbindung zur DB erzeugt und retourniert.
        public static SqlConnection getConnection()
        {

            // Hinweis: das @ am Anfang von Strings verhindert das Sonder- und Escapezeichen interpretiert werden.

            //Variante 1: DB File direkt angeben
            //Vorteil: Man spart sich das Registrieren der DB im SQL Manager
            //Nachteil: Pfad zur DB hardcoded - sollte besser in Web-Config gemacht werden

            //string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\NORA\DOCUMENTS\WGPLANER.MDF;Integrated Security=True;Connect Timeout=5";

            //Variante 2: wie oben, aber der Pfad wird aus dem absoluten App-Pfad und der relativen Position des DB-Files berechnet.
            List<string> dirs = new List<string>(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory).Split('\\'));
            dirs.RemoveAt(dirs.Count - 1); //letztes Verzeichnis entfernen
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + String.Join(@"\", dirs) + @"\DB\WGPlanerDB.mdf;Integrated Security=True;Connect Timeout=5";

            //Variante 3: DBFile mit SQL Server Manager Express im SQL-Server registrieren und den "Kurznamen aus dem SQL Manager angeben
            //Vorteil: nur ein logischer Name - Name und Pfad der DB kann verändert werden (SQL Manager)
            //Nachteil: App kann nicht mit Copy&Paste auf den Zielserver verschoben werden, da DB regstriert werden muss.
            //string conString = @"Data Source=localhost\SQLEXPRESS;Database=KundenDB4;Integrated Security=true;Integrated Security=True;Connect Timeout=30";

            // weitere Varianten:
            // man könnte den Conectionstring auch in eine externe Konfigurationsdatei schreioben und von dort auslesen...

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            return con;
        }

        public static Person getUser(string email)
        {
            string SQL = "select PID, Benutzername, EMail, GID from Personen where EMail=@email";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Starter.getConnection();
            cmd.Parameters.Add(new SqlParameter("email", email));

            SqlDataReader reader = cmd.ExecuteReader();

            Person person = new Person();

            while (reader.Read())
            {
                person.PID = reader.GetString(0);
                person.benutzername = reader.GetString(1);
                person.email = reader.GetString(2);
                if (!reader.IsDBNull(3))
                {
                    person.GID = reader.GetString(3);
                }                
            }
            return person;
        }

        public static Person registrieren(string benutzername, string email, string passwort1, string passwort2)
        {
            if (passwort1 == passwort2)
            {
                //Schauen ob Person schon existiert                
                if (getUser(email).email == null)
                {
                    //registrieren
                    //GUID für ID erzeugen und als String zurückgeben (weil mID=="")!
                    string PID_GUID = Guid.NewGuid().ToString();

                    Person newPerson = new Person();
                    newPerson.PID = PID_GUID;
                    newPerson.benutzername = benutzername;
                    newPerson.email = email;

                    string SQL2 = "insert into Personen (PID, Benutzername, EMail, Passwort) values (@pid, @benutzer, @mail, @pwd)";
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.CommandText = SQL2;
                    cmd2.Connection = Starter.getConnection();

                    cmd2.Parameters.Add(new SqlParameter("pid", PID_GUID));
                    cmd2.Parameters.Add(new SqlParameter("benutzer", benutzername));
                    cmd2.Parameters.Add(new SqlParameter("mail", email));
                    cmd2.Parameters.Add(new SqlParameter("pwd", passwort1));
                    if (cmd2.ExecuteNonQuery() > 0)
                    {
                        return new Person();
                    } else
                    {
                        return null;
                    }                    
                }
                else
                {
                    return null;
                }
            } else
            {
                return null;
            }
            
        }
    
        public static Person login(string email, string passwort) 
        {
            Person person = getUser(email);

            string SQL = "select Passwort from Personen where EMail=@email";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Starter.getConnection();
            cmd.Parameters.Add(new SqlParameter("email", email));

            SqlDataReader reader = cmd.ExecuteReader();

            string passwort_reader = "";
            while (reader.Read())
            {
                passwort_reader = reader.GetString(0);
            }

            if(passwort_reader == passwort)
            {
                return person;
            } else
            {
                return null;
            }
            
        }
    }
}
