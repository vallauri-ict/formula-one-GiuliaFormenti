using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace FormulaOneDLL
{
    public static class Utils
    {
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        public const string WORKINGPATH = @"C:\data\formulaone\";

        private static string DB_PATH = System.Environment.CurrentDirectory;
        private static string RESTORE_CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + DB_PATH + @"\FormulaOne.bak; Integrated Security=True";
        private static string DB_NAME = "[" + WORKINGPATH + "FormulaOne.mdf]";

        public static string[] tables = { "Country", "Driver", "Team", "Circuit", "Race", "Result", "TeamResult" };
        private static string[] sqls = { "countries.sql", "drivers.sql", "teams.sql", "circuits.sql", "races.sql", "results.sql", "teamResults.sql" };
        

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

        //public static List<string> GetTable(string table_name)
        //{
        //    List<string> retVal = new List<string>();

        //    using (SqlConnection dbConn = new SqlConnection())
        //    {
        //        dbConn.ConnectionString = CONNECTION_STRING;
        //        dbConn.Open();
        //        Console.WriteLine("\nQuery data example:");
        //        Console.WriteLine("=========================================\n");
        //        string sql = "SELECT * FROM " + table_name;
        //        using (SqlCommand command = new SqlCommand(sql, dbConn))
        //        {
        //            dbConn.Open();
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    string IsoCod = reader.GetString(0);
        //                    string descr = reader.GetString(1);
        //                    Console.WriteLine("{0} {1}", IsoCod, descr);
        //                }
        //            }
        //        }
        //    }
        //    return retVal;
        //}

        public static DataTable GetDataTable(string table)
        {
            DataTable retVal = new DataTable();
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            string sql = $"SELECT * FROM {table}";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(retVal);
            con.Close();
            da.Dispose();
            return retVal;
        }

        public static List<string> GetTablesNames()
        {
            List<string> tables = new List<string>();

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                Console.WriteLine("\nQuery data example:");
                Console.WriteLine("=========================================\n");

                StringBuilder sb = new StringBuilder();
                string sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}", reader.GetString(0));
                            tables.Add($"{reader.GetString(0)}");
                        }
                    }
                }
            }
            return tables;
        }

        public static void ResetDB()
        {
            Backup();
            try
            {
                Console.WriteLine("Dropping tables...");
                for (int i = 0; i < tables.Length; i++)
                {
                    DropTable(tables[i]);
                }
                Console.WriteLine("Recreating tables...");
                for(int i = 0; i < sqls.Length; i++)
                {
                    ExecuteSqlScript(sqls[i], WORKINGPATH, CONNECTION_STRING);
                }
                Console.WriteLine("Reset DB done");
            }
            catch (Exception)
            {
                Restore();
                Console.WriteLine("Reset gone wrong. The DB has been restored");
            }
        }

        private static void DropTable(string tableName)
        {
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand("DROP TABLE IF EXISTS " + tableName + ";", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table " + tableName + " dropped ");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("ERROR : " + ex.Message + " -->" + ex.Errors);
            }
            con.Close();
        }

        private static void Backup()
        {
            try
            {
                using (SqlConnection dbConn = new SqlConnection())
                {
                    dbConn.ConnectionString = CONNECTION_STRING;
                    dbConn.Open();

                    using (SqlCommand multiuser_rollback_dbcomm = new SqlCommand())
                    {
                        multiuser_rollback_dbcomm.Connection = dbConn;
                        multiuser_rollback_dbcomm.CommandText = @"ALTER DATABASE [" + DB_NAME + "] SET MULTI_USER WITH ROLLBACK IMMEDIATE";

                        multiuser_rollback_dbcomm.ExecuteNonQuery();
                    }
                    dbConn.Close();
                }

                SqlConnection.ClearAllPools();

                using (SqlConnection backupConn = new SqlConnection())
                {
                    backupConn.ConnectionString = CONNECTION_STRING;
                    backupConn.Open();

                    using (SqlCommand backupcomm = new SqlCommand())
                    {
                        backupcomm.Connection = backupConn;
                        backupcomm.CommandText = @"BACKUP DATABASE [" + DB_NAME + "] TO DISK='" + DB_PATH + @"\prova.bak'";
                        backupcomm.ExecuteNonQuery();
                    }
                    backupConn.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Restore()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
                {
                    con.Open();
                    string sqlStmt2 = string.Format(@"ALTER DATABASE [" + DB_NAME + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                    SqlCommand bu2 = new SqlCommand(sqlStmt2, con);
                    bu2.ExecuteNonQuery();

                    string sqlStmt3 = @"USE MASTER RESTORE DATABASE [" + DB_NAME + "] FROM DISK='" + DB_PATH + @"\prova.bak' WITH REPLACE;";
                    SqlCommand bu3 = new SqlCommand(sqlStmt3, con);
                    bu3.ExecuteNonQuery();

                    string sqlStmt4 = string.Format(@"ALTER DATABASE [" + DB_NAME + "] SET MULTI_USER");
                    SqlCommand bu4 = new SqlCommand(sqlStmt4, con);
                    bu4.ExecuteNonQuery();

                    Console.WriteLine("database restoration done successefully");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
