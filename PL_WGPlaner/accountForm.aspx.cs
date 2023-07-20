using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_WGPlaner;
using System.Globalization;


namespace PL_WGPlaner
{
    public partial class accountForm : System.Web.UI.Page
    {
        Person sessionUser;
        Gruppe sessionGruppe;
        CultureInfo cul = new CultureInfo("de-DE");
        protected void Page_Load(object sender, EventArgs e)
        {
            sessionGruppe = (Gruppe)Session["Gruppe"];
            sessionUser = (Person)Session["User"];

            if(sessionUser == null)
            {
                Response.Redirect("loginForm.aspx");
            } 
            else
            {
                lbl_HeutigerTag.Text = cul.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek).ToString();
                lbl_HeutigesDatum.Text = DateTime.Now.ToString("d");

                if(sessionGruppe == null)
                {
                    lbl_gruppenname.Text = "";
                    lbl_gruppenID.Text = "";
                    lbl_ruppenID.Text = "";
                    btn_gruppeLoeschen.Enabled = false;
                    btn_mitgliederEinsehen.Enabled = false;
                } else
                {
                    lbl_gruppenname.Text = sessionGruppe.name;
                    lbl_gruppenID.Text = sessionGruppe.GruppenID;
                    lbl_ruppenID.Text = "GruppenID";
                    btn_gruppeLoeschen.Enabled = true;
                    btn_mitgliederEinsehen.Enabled = true;
                }
            }
        }

        protected void btn_gruppeLoeschen_Click(object sender, EventArgs e)
        {
            Person sessionPerson = (Person)Session["User"];
            
            if (sessionPerson.deleteGruppe(sessionPerson.GID))
            {
                Session["Gruppe"] = null;
                Response.Redirect("gruppenVerwaltungs_Form.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
            }
        }

        protected void btn_mitgliederEinsehen_Click(object sender, EventArgs e)
        {
            Response.Redirect("mitgliederEinsehenForm.aspx");
        }

        protected void btn_Ausloggen_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Session["Gruppe"] = null;
            Response.Redirect("loginForm.aspx");
        }

        protected void btn_meinKonto_Click(object sender, EventArgs e)
        {
            Response.Redirect("meinKontoForm.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("accountForm.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (sessionGruppe == null)
            {
                Response.Redirect("gruppenVerwaltungs_Form.aspx");
            } else
            {
                Response.Redirect("index.aspx");
            }
        }
    }
}