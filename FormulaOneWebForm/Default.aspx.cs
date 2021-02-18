using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FormulaOneDLL;


namespace FormulaOneWebForm
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)//Inizializzazioni che vengono eseguite solo la prima volta che carico la pagina
            {
                lblMessaggio.Text = "Scegli una tabella da visualizzare";
                //CARICO LA LISTA DINAMICAMENTE CON LE TABELLE PRESENTI NEL DATABASE
                lbxScelta.DataSource = Utils.GetTablesNames();
                lbxScelta.DataBind();
                dataTable.DataSource = Utils.GetDataTable(lbxScelta.SelectedValue);
                dataTable.DataBind();
            }
        }

        protected void lbxScelta_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataTable.DataSource = Utils.GetDataTable(lbxScelta.SelectedValue);
            dataTable.DataBind();
        }
    }
}