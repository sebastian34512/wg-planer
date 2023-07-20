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
    public partial class mitgliederEinsehenForm : System.Web.UI.Page
    {
        Gruppe sessionGruppe;
        Person sessionUser;
        CultureInfo cul = new CultureInfo("de-DE");
        protected void Page_Load(object sender, EventArgs e)
        {
            sessionGruppe = (Gruppe)Session["Gruppe"];
            sessionUser = (Person)Session["User"];

            if(sessionGruppe == null)
            {
                Response.Redirect("loginForm.aspx");
            }else
            {
                lblGruppenName.Text = sessionGruppe.name;
                grdvw_Mitglieder.DataSource = sessionGruppe.getMitglieder(sessionGruppe.GID);
                grdvw_Mitglieder.DataBind();

                lbl_HeutigerTag.Text = cul.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek).ToString();
                lbl_HeutigesDatum.Text = DateTime.Now.ToString("d");
            }
        }

        protected void grdvw_Mitglieder_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string personID = grdvw_Mitglieder.DataKeys[e.RowIndex].Value.ToString();

            if (personID == sessionUser.PID)
            {
                //wenns der einzige user ist
                if (sessionGruppe.getMitglieder(sessionGruppe.GID).Count == 1)
                {
                    sessionUser.deleteGruppe(sessionGruppe.GID);
                } else
                {
                    sessionGruppe.deleteMitglied(personID);
                }
                sessionUser.GID = null;
                Session["User"] = sessionUser;
                Session["Gruppe"] = null;

                Response.Redirect("gruppenVerwaltungs_Form.aspx");
            }
            else
            {
                //wenn es ein anderer User ist
                sessionGruppe.deleteMitglied(personID);
                grdvw_Mitglieder.DataSource = sessionGruppe.getMitglieder(sessionGruppe.GID);
                grdvw_Mitglieder.DataBind();
            }         
        }

        protected void btn_zurueck_Click(object sender, EventArgs e)
        {
            Response.Redirect("accountForm.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("accountForm.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}