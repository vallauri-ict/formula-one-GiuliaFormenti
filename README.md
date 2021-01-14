# FORMULA ONE PROJECT

The FormulaOne Project constains 3 different projecs: the Console Project, the DLL and the WebForm Application.


# 1) FormulaOneConsole
This is the console project; here there is a menu where you can choose some operation that will be done on the database:
- you can create all the tables
- you can create the constraints
- you can drop the constraint
- you can reset the db
```csharp
    private static void menu()
        {
            Console.WriteLine("\n*** FORMULA ONE - BATCH SCRIPTS ***\n");
            Console.WriteLine("1 - Create Country");
            Console.WriteLine("2 - Create Teams");
            Console.WriteLine("3 - Create Driver");
            Console.WriteLine("4 - Create Circuit");
            Console.WriteLine("5 - Create Race");
            Console.WriteLine("6 - Create Result");
            Console.WriteLine("7 - Create TeamResult");
            Console.WriteLine("8 - Create Constraints");
            Console.WriteLine("------------------");
            Console.WriteLine("C - DROP CONSTRAINTS");
            Console.WriteLine("R - RESET DB");
            Console.WriteLine("------------------");
            Console.WriteLine("X - EXIT\n");
        }
 ```
 
 # 2) FormulaOneDLL
 This is the DLL; here there are all the methods useful for all the operation that are than on the database.
 For example
 ```csharp
    public static bool ExecuteSqlScript(string sqlScriptName, string WORKINGPATH, string CONNECTION_STRING, string tab = "")
        {
            bool retVal = true;
            var fileContent = File.ReadAllText(WORKINGPATH + sqlScriptName);
            fileContent = fileContent.Replace("\r\n", "");
            fileContent = fileContent.Replace("\r", "");
            fileContent = fileContent.Replace("\n", "");
            fileContent = fileContent.Replace("\t", "");

            if (sqlScriptName == "drop.sql")
            {
                fileContent = fileContent.Replace("table_name", tab);
            }

            var sqlqueries = fileContent.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            var con = new SqlConnection(CONNECTION_STRING);
            var cmd = new SqlCommand("query", con);
            con.Open();
            int i = 0;
            int nErr = 0;
            foreach (var query in sqlqueries)
            {
                cmd.CommandText = query; i++;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException err)
                {
                    Console.WriteLine("Errore in esecuzione della query numero: " + i);
                    Console.WriteLine("\tErrore SQL: " + err.Number + " - " + err.Message);
                    nErr++;
                    retVal = false;
                }
            }
            string finalMessage = nErr == 0 ? "Script " + sqlScriptName + " completed successfully without errors" : "Script " + sqlScriptName + " completed with " + nErr + " errors";
            Console.WriteLine(finalMessage);
            return retVal;
        }
 ```
 
 # 3) FormulaOneWebForm
 This is the WebForm application; here there is:
 - the **Default.aspx**, where you can build the structure of your page
 ```html
    <body>
        <form id="form1" runat="server">
            <div>
                <br />
                <h1 class="heading"> FROMULA UNO </h1>
                <br />

                <asp:Label id="lblMessaggio" runat="server" Text=" "></asp:Label> <br /><br />
                <asp:DropDownList id="lbxScelta" runat="server" OnSelectedIndexChanged="lbxScelta_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList> <br /><br />

                <asp:DataGrid ID="dataTable" runat="server" CssClass="grid" AllowPaging="True" PageSize="18">
                    <HeaderStyle CssClass="GridHeader"></HeaderStyle>
                    <ItemStyle CssClass="GridItem"></ItemStyle>
                    <AlternatingItemStyle CssClass="GridAltItem"></AlternatingItemStyle>
                </asp:DataGrid>
            </div>
        </form>
    </body>
 ```
 
 - the **Defauls.aspx.cs** where you specify the code that will be executed when the page will be loaded
 ```csharp
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
 ```
 
 
###### Created by Giulia Formenti 5B INF
