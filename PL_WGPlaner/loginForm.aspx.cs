using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_WGPlaner;

namespace PL_WGPlaner
{
    public partial class loginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_zurRegistrierung_Click(object sender, EventArgs e)
        {
            Response.Redirect("registrierungsForm.aspx");
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbx_EmailLogin.Text) || string.IsNullOrWhiteSpace(txtbx_PasswortLogin.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Eingabe fehlt oder wurde mit Leerzeichen befüllt!')", true);
            }
            else
            {
                Session["User"] = Starter.login(txtbx_EmailLogin.Text, txtbx_PasswortLogin.Text);

                if (Session["User"] != null)
                {
                    Person sessionUser = (Person)Session["User"];
                    if (sessionUser.GID != null)
                    {
                        Session["Gruppe"] = sessionUser.getGruppe(sessionUser.GID);
                        Response.Redirect("index.aspx");
                    }
                    else
                    {
                        Response.Redirect("gruppenVerwaltungs_Form.aspx");
                    }

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
                }
            }
        }
    }
}