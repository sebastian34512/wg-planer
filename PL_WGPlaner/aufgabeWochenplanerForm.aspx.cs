using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_WGPlaner;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace PL_WGPlaner
{
    public partial class aufgabeWochenplanerForm : System.Web.UI.Page
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
                lbl_HeutigerTag.Text = cul.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek).ToString();
                lbl_HeutigesDatum.Text = DateTime.Now.ToString("d");

                //fragt ab, ob die Seite zum erstem Mal gerendet wird, oder ob sie aufgrund eines Postbacks geladen wird
                if (!IsPostBack)
                {
                    chckbxlst_Personen.DataSource = sessionGruppe.getMitglieder(sessionGruppe.GID);
                    chckbxlst_Personen.DataBind();
                }
            }
        }

        protected void btn_hinzufügen_Click(object sender, EventArgs e)
        {
            //Get Personen
            List<string> personen = new List<string>();
            for (int i = 0; i < chckbxlst_Personen.Items.Count; i++)
            {
                if (chckbxlst_Personen.Items[i].Selected)
                {
                    personen.Add(chckbxlst_Personen.Items[i].Value.ToString());
                }
            }

            //Get Tage
            List<int> tage = new List<int>();
            for (int i = 0; i < chckbxlst_Tage.Items.Count; i++)
            {
                if (chckbxlst_Tage.Items[i].Selected)
                {
                    tage.Add(Int32.Parse(chckbxlst_Tage.Items[i].Value));
                }
            }

            if (string.IsNullOrWhiteSpace(txtbx_Titel.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Eingabe fehlt oder wurde mit Leerzeichen befüllt!')", true);
            }
            else
            {
                sessionGruppe.insertWochenplanerItem(txtbx_Titel.Text, personen, tage, drpdwnlst_Haeufigkeit.SelectedIndex);
                Response.Redirect("wochenplanerForm.aspx");
            }
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