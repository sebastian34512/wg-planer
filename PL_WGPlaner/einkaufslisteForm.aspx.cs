using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_WGPlaner;
using System.Globalization;
using System.Windows.Forms;

namespace PL_WGPlaner
{
    public partial class einkaufslisteForm : System.Web.UI.Page
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
                lbl_GruppenName.Text = sessionGruppe.name;

                grdvw_Einkaufslistenitems.DataSource = sessionGruppe.loadEinkaufsliste();
                grdvw_Einkaufslistenitems.DataBind();

                lbl_HeutigerTag.Text = cul.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek).ToString();
                lbl_HeutigesDatum.Text = DateTime.Now.ToString("d");
            }
        }

        protected void grdvw_Einkaufslistenitems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string EID = grdvw_Einkaufslistenitems.DataKeys[e.RowIndex].Value.ToString();
            sessionGruppe.deleteEinkaufslistenitem(EID);
            grdvw_Einkaufslistenitems.DataSource = sessionGruppe.loadEinkaufsliste();
            grdvw_Einkaufslistenitems.DataBind();
        }

        protected void btn_AddItem_Click(object sender, EventArgs e)
        {
            //Exception handeling!!
            int parsedValue;
            if (!int.TryParse(txtbx_Anzahl.Text, out parsedValue))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Die Angabe zur Anzahl darf nur aus Zahlen bestehen!')", true);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtbx_Artikel.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Eingabe fehlt oder wurde mit Leerzeichen befüllt!')", true);
            } 
            else
            {
                int Anzahl = int.Parse(txtbx_Anzahl.Text);
                sessionGruppe.insertEinkaufslistenitem(txtbx_Artikel.Text, Anzahl, txtbx_Einheit.Text);
                grdvw_Einkaufslistenitems.DataSource = sessionGruppe.loadEinkaufsliste();
                grdvw_Einkaufslistenitems.DataBind();
                txtbx_Anzahl.Text = "";
                txtbx_Artikel.Text = "";
                txtbx_Einheit.Text = "";
            }            
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