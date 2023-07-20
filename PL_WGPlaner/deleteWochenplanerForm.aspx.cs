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
    public partial class deleteWochenplanerForm : System.Web.UI.Page
    {
        Gruppe sessionGruppe;
        CultureInfo cul = new CultureInfo("de-DE");
        protected void Page_Load(object sender, EventArgs e)
        {
            sessionGruppe = (Gruppe)Session["Gruppe"];
            if (sessionGruppe == null)
            {
                Response.Redirect("loginForm.aspx");
            }
            else
            {
                grdvw_Aufgaben.DataSource = sessionGruppe.getAufgaben(sessionGruppe.GID);
                grdvw_Aufgaben.DataBind();

                lbl_HeutigerTag.Text = cul.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek).ToString();
                lbl_HeutigesDatum.Text = DateTime.Now.ToString("d");
            }
        }

        protected void grdvw_Aufgaben_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string WID = grdvw_Aufgaben.DataKeys[e.RowIndex].Value.ToString();
            sessionGruppe.deleteAufgabe(WID);
            grdvw_Aufgaben.DataSource = sessionGruppe.getAufgaben(sessionGruppe.GID);
            grdvw_Aufgaben.DataBind();
        }

        protected void btn_zurueck_Click(object sender, EventArgs e)
        {
            Response.Redirect("wochenplanerForm.aspx");
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