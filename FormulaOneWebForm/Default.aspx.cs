﻿using System;
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
                //List<string> l = new List<string>();
                //l.Add("country");
                //l.Add("driver");
                //l.Add("team");
                lbxScelta.DataSource = Utils.GetTablesNames();
                lbxScelta.DataBind();
                
                
                //CARICO LA LISTA DINAMICAMENTE CON LE TABELLE PRESENTI NEL DATABASE
            }
            //else//Elaborazioni da eseguire tutte le volte che la pagina viene caricata
            //{

            //    lbxNazioni.DataSource = Utilities.GetTable(table_name);
            //    lbxNazioni.DataBind();
            //}
        }

        protected void lbxScelta_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dataTa.DataSource = Utils.GetDataTable(lbxScelta.SelectedValue);
            dataTable.DataSource = Utils.GetDataTable(lbxScelta.SelectedValue);
            dataTable.DataBind();
        }
    }
}