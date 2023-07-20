using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_WGPlaner;

namespace PL_WGPlaner
{
    public partial class registrierungsForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_Registrieren_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbx_Benutzername.Text) || string.IsNullOrWhiteSpace(txtbx_EMail.Text) || string.IsNullOrWhiteSpace(txtbx_Passwort1.Text) || string.IsNullOrWhiteSpace(txtbx_Passwort2.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Eingabe fehlt oder wurde mit Leerzeichen befüllt!')", true);
            }
            else
            {
                Person retValue = Starter.registrieren(txtbx_Benutzername.Text, txtbx_EMail.Text, txtbx_Passwort1.Text, txtbx_Passwort2.Text);
                if (retValue == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
                }
                else
                {
                    Session["User"] = Starter.getUser(txtbx_EMail.Text);

                    if (Session["User"] != null)
                    {
                        Response.Redirect("gruppenVerwaltungs_Form.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
                    }
                }
            }
        }

        protected void btn_zumLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("loginForm.aspx");
        }
    }
}