using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_WGPlaner;

namespace PL_WGPlaner
{
    public partial class gruppenVerwaltungs_Form : System.Web.UI.Page
    {
        Person sessionUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            sessionUser = (Person)Session["User"];
            if(sessionUser == null)
            {
                Response.Redirect("loginForm.aspx");
            }
        }

        protected void btn_GruppeErstellen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbx_neuerGruppenName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Eingabe fehlt oder wurde mit Leerzeichen befüllt!')", true);
            }  
            else
            {
                Session["Gruppe"] = sessionUser.createGruppe(txtbx_neuerGruppenName.Text);

                if (Session["Gruppe"] != null)
                {
                    Gruppe sessionGruppe = (Gruppe)Session["Gruppe"];
                    sessionUser.GID = sessionGruppe.GID;
                    Session["User"] = sessionUser;
                    Response.Redirect("index.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
                }
            }           
        }

        protected void btn_GruppeBeitreten_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbx_Gruppenname.Text) || string.IsNullOrWhiteSpace(txtbx_GruppenID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Eingabe fehlt oder wurde mit Leerzeichen befüllt!')", true);
            }
            else
            {
                Session["Gruppe"] = sessionUser.joinGruppe(txtbx_GruppenID.Text, txtbx_Gruppenname.Text);

                if (Session["Gruppe"] != null)
                {
                    Gruppe sessionGruppe = (Gruppe)Session["Gruppe"];
                    sessionUser.GID = sessionGruppe.GID;
                    Session["User"] = sessionUser;
                    Response.Redirect("index.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
                }
            }            
        }
      

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("accountForm.aspx");
        }
    }
}