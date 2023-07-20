using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL_WGPlaner
{
    public class Person
    {
        internal Person() { }

        //variablen

        private string mPID;
        private string mbenutzername;
        private string memail;
        private string mGID;

        //properties

        public string PID {
            get { return mPID; }
            internal set { mPID = value; }
        }

        public string benutzername
        {
            get { return mbenutzername; }
            set { mbenutzername = value; }
        }

        public string email
        {
            get { return memail; }
            set { memail= value; }
        }

        //schauma mal wie das wird
        public string GID
        {
            get { return mGID; }
            set { mGID = value; }
        }

        //methoden
        static Random random = new Random();
        public string GetRandomHexNumber(int digits)
        {
            byte[] buffer = new byte[digits / 2];
            random.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            if (digits % 2 == 0)
                return result;
            return result + random.Next(16).ToString("X");
        }

        public Gruppe createGruppe(string name)
        {
            //Beim Gruppen erstellen muss die GUID angelegt und die Hex Zahl der GruppenID erzeugt werden. Dann die Gruppe in der
            //Datenbank anlegen und die GID der aktuell eingeloggten Person hinzufügen.

            //GUID erstellen
            string GID_GUID = Guid.NewGuid().ToString();

            //GruppenID erstellen
            string GruppenID = GetRandomHexNumber(6);

            Gruppe newGruppe = new Gruppe();
            newGruppe.GID = GID_GUID;
            newGruppe.GruppenID = GruppenID;
            newGruppe.name = name;

            string SQL = "insert into Gruppen (GID, GruppenID, [Name]) values (@gid, @gruppenID, @nameGruppe)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Starter.getConnection();

            cmd.Parameters.Add(new SqlParameter("gid", GID_GUID));
            cmd.Parameters.Add(new SqlParameter("gruppenID", GruppenID));
            cmd.Parameters.Add(new SqlParameter("nameGruppe", name));
            
            if (cmd.ExecuteNonQuery() == 0)
            {
                cmd.Connection.Close();
                return null;
            }
            cmd.Connection.Close();

            string SQL2 = "update Personen set GID = @gid where PID = @pid";
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = SQL2;
            cmd2.Connection = Starter.getConnection();

            cmd2.Parameters.Add(new SqlParameter("gid", GID_GUID));
            cmd2.Parameters.Add(new SqlParameter("pid", this.PID));
            if (cmd2.ExecuteNonQuery() == 0)
            {
                cmd2.Connection.Close();
                return null;
            } else
            {
                cmd2.Connection.Close();
                return newGruppe;
            }
        }

        public Gruppe getGruppe(string GID)
        {
            string SQL = "select GID, GruppenID, [Name] from Gruppen where GID=@gid";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Starter.getConnection();
            cmd.Parameters.Add(new SqlParameter("gid", GID));

            SqlDataReader reader = cmd.ExecuteReader();

            Gruppe sqlGruppe = new Gruppe();

            while (reader.Read())
            {
                sqlGruppe.GID = reader.GetString(0);
                sqlGruppe.GruppenID = reader.GetString(1);
                sqlGruppe.name = reader.GetString(2);
            }
            cmd.Connection.Close();
            return sqlGruppe;
        }

        public Gruppe joinGruppe (string gruppenID, string name)
        {
            //schauen ob es die Gruppe gibt
            string SQL = "select GID, GruppenID, [Name] from Gruppen where GruppenID=@gruppenID and [Name]=@name";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Starter.getConnection();
            cmd.Parameters.Add(new SqlParameter("gruppenID", gruppenID));
            cmd.Parameters.Add(new SqlParameter("name", name));

            SqlDataReader reader = cmd.ExecuteReader();

            Gruppe sqlGruppe = new Gruppe();

            while (reader.Read())
            {
                if(reader.IsDBNull(1) || reader.IsDBNull(2))
                {
                    return null;
                } else
                {
                    sqlGruppe.GID = reader.GetString(0);
                    sqlGruppe.GruppenID = reader.GetString(1);
                    sqlGruppe.name = reader.GetString(2);
                }
            }
            cmd.Connection.Close();

            //GID der Person zuweisen
            string SQL2 = "update Personen set GID = @gid where PID = @pid";
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = SQL2;
            cmd2.Connection = Starter.getConnection();

            cmd2.Parameters.Add(new SqlParameter("gid", sqlGruppe.GID));
            cmd2.Parameters.Add(new SqlParameter("pid", this.PID));
            if (cmd2.ExecuteNonQuery() == 0)
            {
                cmd2.Connection.Close();
                return null;
            }
            else
            {
                cmd2.Connection.Close();
                return sqlGruppe;
            }
        }

        public bool deleteGruppe(string GID)
        {
            //Zuerst muss Fremdschlüssel wert in der Datenbank gelöscht werden
            string SQL2 = "update Personen set GID = @gid where PID = @pid";
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = SQL2;
            cmd2.Connection = Starter.getConnection();

            cmd2.Parameters.Add(new SqlParameter("gid", DBNull.Value));
            cmd2.Parameters.Add(new SqlParameter("pid", this.PID));
            if (cmd2.ExecuteNonQuery() == 0)
            {
                cmd2.Connection.Close();
                return false;
            }
            else
            {
                cmd2.Connection.Close();
                string SQL = "delete from Gruppen where GID = @gid";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Starter.getConnection();

                cmd.Parameters.Add(new SqlParameter("gid", GID));
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
        }

        public string editBenutzername ( string benutzername)
        {
            string SQL2 = "update Personen set Benutzername = @benutzername where PID = @pid";
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = SQL2;
            cmd2.Connection = Starter.getConnection();

            cmd2.Parameters.Add(new SqlParameter("benutzername", benutzername));
            cmd2.Parameters.Add(new SqlParameter("pid", this.PID));

            if (cmd2.ExecuteNonQuery() == 1)
            {
                cmd2.Connection.Close();
                this.benutzername = benutzername;
                return benutzername;
            }
            else
            {
                cmd2.Connection.Close();
                return null;
            }
        }

        public string editEmail(string email)
        {
            string SQL2 = "update Personen set EMail = @email where PID = @pid";
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = SQL2;
            cmd2.Connection = Starter.getConnection();

            cmd2.Parameters.Add(new SqlParameter("email", email));
            cmd2.Parameters.Add(new SqlParameter("pid", this.PID));

            if (cmd2.ExecuteNonQuery() == 0)
            {
                cmd2.Connection.Close();
                return null;
            }
            else
            {
                cmd2.Connection.Close();
                this.email = email;
                return email;
            }
        }

        public bool editPasswort(string passwortAlt, string passwortNeu1, string passwortNeu2)
        {
            string SQL = "select Passwort from Personen where PID=@pid";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Starter.getConnection();
            cmd.Parameters.Add(new SqlParameter("pid", this.PID));

            SqlDataReader reader = cmd.ExecuteReader();

            string sqlPasswort = "";

            while (reader.Read())
            {
                sqlPasswort = reader.GetString(0);               
            }
            cmd.Connection.Close();

            if (sqlPasswort == passwortAlt && passwortNeu1 == passwortNeu2)
            {
                string SQL2 = "update Personen set Passwort = @passwort where PID = @pid";
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandText = SQL2;
                cmd2.Connection = Starter.getConnection();

                cmd2.Parameters.Add(new SqlParameter("passwort", passwortNeu2));
                cmd2.Parameters.Add(new SqlParameter("pid", this.PID));

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
            } else
            {
                return false;
            }            
        }
    }
}
