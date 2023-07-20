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
    public partial class wochenplanerForm : System.Web.UI.Page
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
                lbl_Gruppenname.Text = sessionGruppe.name;
                grdvw_Montag.DataSource = sessionGruppe.getWochentag(sessionGruppe.GID, 0);
                grdvw_Montag.DataBind();
                grdvw_Dienstag.DataSource = sessionGruppe.getWochentag(sessionGruppe.GID, 1);
                grdvw_Dienstag.DataBind();
                grdvw_Mittwoch.DataSource = sessionGruppe.getWochentag(sessionGruppe.GID, 2);
                grdvw_Mittwoch.DataBind();
                grdvw_Donnerstag.DataSource = sessionGruppe.getWochentag(sessionGruppe.GID, 3);
                grdvw_Donnerstag.DataBind();
                grdvw_Freitag.DataSource = sessionGruppe.getWochentag(sessionGruppe.GID, 4);
                grdvw_Freitag.DataBind();
                grdvw_Samstag.DataSource = sessionGruppe.getWochentag(sessionGruppe.GID, 5);
                grdvw_Samstag.DataBind();
                grdvw_Sonntag.DataSource = sessionGruppe.getWochentag(sessionGruppe.GID, 6);
                grdvw_Sonntag.DataBind();

                lbl_HeutigerTag.Text = cul.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek).ToString();
                lbl_HeutigesDatum.Text = DateTime.Now.ToString("d");
            }
        }

        protected void btn_Hinzufuegen_Click(object sender, EventArgs e)
        {
            Response.Redirect("aufgabeWochenplanerForm.aspx");
        }

        protected void btn_AufgabenBearbeiten_Click(object sender, EventArgs e)
        {
            Response.Redirect("deleteWochenplanerForm.aspx");
        }
        
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("accountForm.aspx");
        }
    }
}