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
    public partial class meinKontoForm : System.Web.UI.Page
    {
        Person sessionUser;
        CultureInfo cul = new CultureInfo("de-DE");
        protected void Page_Load(object sender, EventArgs e)
        {
            sessionUser = (Person)Session["User"];

            if (sessionUser == null)
            {
                Response.Redirect("loginForm.aspx");
            }
            else
            {
                lbl_BenuzterNameAktuell.Text = sessionUser.benutzername;
                lbl_EMailAktuell.Text = sessionUser.email;

                lbl_HeutigerTag.Text = cul.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek).ToString();
                lbl_HeutigesDatum.Text = DateTime.Now.ToString("d");
            }
        }

        protected void btn_Speichern_Click(object sender, EventArgs e)
        {
            if (sessionUser.benutzername != txtbx_Benutzername.Text)
            {
                if (txtbx_Benutzername.Text.Trim().Length == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Eingabe wurde mit Leerzeichen befüllt!')", true);
                }
                else
                {
                    sessionUser.editBenutzername(txtbx_Benutzername.Text);
                    sessionUser.benutzername = txtbx_Benutzername.Text;
                    lbl_BenuzterNameAktuell.Text = sessionUser.benutzername;
                    txtbx_Benutzername.Text = "";
                }               
            }

            if (sessionUser.email != txtbx_EMail.Text)
            {
                if (txtbx_EMail.Text.Trim().Length == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Eingabe wurde mit Leerzeichen befüllt!')", true);
                } 
                else
                {
                    sessionUser.editEmail(txtbx_EMail.Text);
                    sessionUser.email = txtbx_EMail.Text;
                    lbl_EMailAktuell.Text = sessionUser.email;
                    txtbx_EMail.Text = "";
                }                
            }

            if (txtbx_altesPasswort.Text != "" && txtbx_NeuesPasswort1.Text != "" && txtbx_NeuesPasswort2.Text != "")
            {
                if (txtbx_altesPasswort.Text.Trim().Length == 0 || txtbx_NeuesPasswort1.Text.Trim().Length == 0 || txtbx_NeuesPasswort2.Text.Trim().Length == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Eingabe wurde mit Leerzeichen befüllt!')", true);
                }
                else
                {
                    sessionUser.editPasswort(txtbx_altesPasswort.Text, txtbx_NeuesPasswort1.Text, txtbx_NeuesPasswort2.Text);
                    txtbx_altesPasswort.Text = "";
                    txtbx_NeuesPasswort1.Text = "";
                    txtbx_NeuesPasswort2.Text = "";
                }   
            }

            Session["User"] = sessionUser;
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