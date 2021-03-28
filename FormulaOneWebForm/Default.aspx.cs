using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FormulaOneDLL;
using FormulaOneDLL.Models;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.ComponentModel;
using System.Net;


namespace FormulaOneWebForm
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        public const string WORKINGPATH = @"C:\data\formulaone\";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)//Inizializzazioni che vengono eseguite solo la prima volta che carico la pagina
            {
                /*lblMessaggio.Text = "Scegli una tabella da visualizzare";
                //CARICO LA LISTA DINAMICAMENTE CON LE TABELLE PRESENTI NEL DATABASE
                lbxScelta.DataSource = Utils.GetTablesNames();
                lbxScelta.DataBind();
                dataTable.DataSource = Utils.GetDataTable(lbxScelta.SelectedValue);
                dataTable.DataBind();

                lbxScelta.DataSource = Utils.GetColumns("Country");*/
				
				lbxScelta.DataSource = Utils.GetTablesNames();
                lbxScelta.DataBind();
                lbxScelta.Items.Insert(0, new ListItem("Please select", ""));
            }
        }

        protected void lbxScelta_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataTable.DataSource = Utils.GetDataTable(lbxScelta.SelectedValue);
            dataTable.DataBind();
        }

        public static List<string> GetColumns(string tableName)
        {
            List<string> columns = new List<string>();

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                Console.WriteLine("\nQuery data example:");
                Console.WriteLine("=========================================\n");

                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = '{tableName}'";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}", reader.GetString(0));
                            columns.Add($"{reader.GetString(0)}");
                        }
                    }
                }
            }
            return columns;
        }
		
		public void GetCountry(string isoCode = "")
        {
            HttpWebRequest apiRequest = WebRequest.Create($"http://localhost:44308/api/Country/{isoCode}") as HttpWebRequest;
            string apiResponse = "";
            try
            {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    apiResponse = reader.ReadToEnd();
                    Country[] country = Newtonsoft.Json.JsonConvert.DeserializeObject<Country[]>(apiResponse);
                    // Dentro country ci sono i country
                }
            }
            catch (WebException ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}