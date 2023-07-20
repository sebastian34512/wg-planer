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
	public partial class todoForm : System.Web.UI.Page
	{
		Gruppe sessionGruppe;
		CultureInfo cul = new CultureInfo("de-DE");
		protected void Page_Load(object sender, EventArgs e)
		{
			sessionGruppe = (Gruppe)Session["Gruppe"];

			if(sessionGruppe == null)
            {
				Response.Redirect("loginForm.aspx");
            }
			else
			{
				lbl_gruppenname.Text = sessionGruppe.name;

				lbl_HeutigerTag.Text = cul.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek).ToString();
				lbl_HeutigesDatum.Text = DateTime.Now.ToString("d");

				//Seite wird zum ersten Mal aufgerufen 
				if (!Page.IsPostBack)
				{
					ddlist_personen.DataSource = sessionGruppe.getMitglieder(sessionGruppe.GID);
					ddlist_personen.DataBind();
					grdvw_ToDoListItems.DataSource = sessionGruppe.loadToDoListe();
					grdvw_ToDoListItems.DataBind();
				}
			}			
		}

		protected void btn_hinzufuegen_Click(object sender, EventArgs e)
		{
			string akutellePerson = ddlist_personen.SelectedValue.ToString();
			DateTime datum = cal_todoDate.SelectedDate.Date;

            if (!string.IsNullOrWhiteSpace(txt_aufgabe.Text)){
				sessionGruppe.insertToDoListItem(txt_aufgabe.Text, datum, akutellePerson);
				grdvw_ToDoListItems.DataSource = sessionGruppe.loadToDoListe();
				grdvw_ToDoListItems.DataBind();
				txt_aufgabe.Text = "";
			} 
			else
            {
				ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Eingabe fehlt oder wurde mit Leerzeichen befüllt!')", true);
			}			
		}

		protected void grdvw_ToDoListItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			string itemID = grdvw_ToDoListItems.DataKeys[e.RowIndex].Value.ToString();
			sessionGruppe.deleteTDItem(itemID);
			grdvw_ToDoListItems.DataSource = sessionGruppe.loadToDoListe();
			grdvw_ToDoListItems.DataBind();
		}
		protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
		{
			Response.Redirect("accountForm.aspx");
		}


		protected void cal_todoDate_DayRender(object sender, DayRenderEventArgs e)
        {
			if (e.Day.Date < DateTime.Now.Date)
			{
				e.Day.IsSelectable = false;
				e.Cell.ForeColor = System.Drawing.Color.Gray;
			}
		}

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
			Response.Redirect("index.aspx");
		}
    }
}

