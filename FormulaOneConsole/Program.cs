using System;
using System.Data.SqlClient;
using System.IO;

namespace FormulaOneConsole
{
    class Program
    {
        public const string WORKINGPATH = @"C:\data\formulaone\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";

        static void Main(string[] args)
        {
            char scelta = ' ';
            do
            {
                Console.WriteLine("\n*** FORMULA ONE - BATCH SCRIPTS ***\n");
                Console.WriteLine("1 - Create Countries");
                Console.WriteLine("2 - Create Teams");
                Console.WriteLine("3 - Create Drivers");
                Console.WriteLine("------------------");
                Console.WriteLine("R - RESET DB");
                Console.WriteLine("------------------");
                Console.WriteLine("X - EXIT\n");
                scelta = Console.ReadKey(true).KeyChar;
                switch (scelta)
                {
                    case '1':
                        ExecuteSqlScript("countries.sql");
                        break;
                    case '2':
                        ExecuteSqlScript("teams.sql");
                        break;
                    case '3':
                        ExecuteSqlScript("drivers.sql");
                        break;
                    case 'R':
                        ResetDB();
                        break;
                    default:
                        if (scelta != 'X' && scelta != 'x') Console.WriteLine("\nUncorrect Choice - Try Again\n");
                        break;
                }
            } while (scelta != 'X' && scelta != 'x');
        }
        
        static bool ExecuteSqlScript(string sqlScriptName, string tab = "")
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
            string finalMessage = nErr == 0 ? "Script " + sqlScriptName + " completed successfully without errors" : "Script completed with " + nErr + " errors";
            Console.WriteLine(finalMessage);
            return retVal;
        }

        static void ResetDB()
        {
            //DROP TABLE
            string[] sql = { "drivers.sql", "teams.sql", "countries.sql" };
            string[] database = { "Driver", "Team", "Country" };
            for (int i = 0; i < database.Length; i++)
            {
                ExecuteDropTable(database[i]);
            }
            //CREATE TABLE
            for (int i = 0; i < sql.Length; i++)
            {
                ExecuteSqlScript(sql[i]);
            }


            //bool OK = DropTable("Country");
            //if (OK)
            //{
            //    DropTable("Driver");
            //}
            //if (OK)
            //{
            //    DropTable("Team");
            //}
            //if (OK)
            //{
            //    ExecuteSqlScript("countries.sql");
            //}
            //if (OK)
            //{
            //    ExecuteSqlScript("countries.sql");
            //}
            //if (OK)
            //{
            //    ExecuteSqlScript("countries.sql");
            //}
        }

        //private bool DropTable(string)
        //{
        //    try
        //    {
        //        using (resource)
        //        {
        //            using (resource)
        //            {

        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return true;
        //}

        static void ExecuteDropTable(string sqlScriptName)
        {
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand("DROP TABLE IF EXISTS " + sqlScriptName + ";", con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table " + sqlScriptName + " is Dropped ");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("ERROR : " + ex.Message + " -->" + ex.Errors);
            }
            con.Close();
        }
    }
}
