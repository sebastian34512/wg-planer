using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BL_WGPlaner;
using System.Globalization;


namespace PL_WGPlaner
{
    public partial class index : System.Web.UI.Page
    {
        CultureInfo cul = new CultureInfo("de-DE");
        protected void Page_Load(object sender, EventArgs e)
        {
            Gruppe sessionGruppe = (Gruppe)Session["Gruppe"];

            if(sessionGruppe == null) { 
                Response.Redirect("loginForm.aspx"); 
            } else
            {
                lbl_GruppenName.Text = sessionGruppe.name;
                lbl_HeutigerTag.Text = cul.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek).ToString();
                lbl_HeutigesDatum.Text = DateTime.Now.ToString("d");
                grdvw_Aktuelles.DataSource = sessionGruppe.loadAktuelles();
                grdvw_Aktuelles.DataBind();
            }            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("einkaufslisteForm.aspx");
        }

        protected void btn_ToDoListe_Click(object sender, EventArgs e)
        {
            Response.Redirect("todoForm.aspx");
        }

        protected void btn_Wochenplaner_Click(object sender, EventArgs e)
        {
            Response.Redirect("wochenplanerForm.aspx");
        }

     /*   protected void btn_Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void btn_Account_Click(object sender, EventArgs e)
        {
            Response.Redirect("accountForm.aspx");
        }*/

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