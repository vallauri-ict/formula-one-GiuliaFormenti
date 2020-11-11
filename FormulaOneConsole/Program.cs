using System;
using System.Data.SqlClient;
using System.IO;

namespace FormulaOneConsole
{
    class Program
    {
        public const string WORKINGPATH = @"C:\data\formulaone\";
        public static string THISDATAPATH = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName}\\Data\\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        public static string[] tableNames = { "Country", "Driver", "Team" };
        public static string hour;

        //public const string WORKINGPATH = @"..\..\Data\";
        private static string DB_PATH = System.Environment.CurrentDirectory;
        //private static string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + DB_PATH + @"\prova.mdf; Integrated Security=True";
        private static string RESTORE_CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + DB_PATH + @"\FormulaOne.bak; Integrated Security=True";
        private static string DB_NAME = @"C:\data\formulaone\FormulaOne.mdf";
        //private static string DB_NAME = @"D:\USERS\DIEGO\DESKTOP\SCUOLA\CSHARP-CODE\BACKUPMDFDB\BACKUPMDFDB\BIN\DEBUG\PROVA.MDF";

        static void Main(string[] args)
        {
            char scelta = ' ';
            //copyFile("countries.sql");
            //copyFile("teams.sql");
            //copyFile("drivers.sql");
            //copyFile("relations.sql");
            do
            {
                Console.WriteLine("\n*** FORMULA ONE - BATCH SCRIPTS ***\n");
                Console.WriteLine("1 - Create Countries");
                Console.WriteLine("2 - Create Teams");
                Console.WriteLine("3 - Create Drivers");
                Console.WriteLine("4 - Create Constraints");
                Console.WriteLine("5 - Drop Constraints");
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
                    case '4':
                        ExecuteSqlScript("relations.sql");
                        break;
                    case '5':
                        DropConstraints("driverCountry");
                        DropConstraints("driverTeam");
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

        private static void copyFile(string dbName)
        {
            var oldDbFilePath = WORKINGPATH + dbName;
            string newDbFilePath = THISDATAPATH + dbName;
            File.Copy(newDbFilePath, oldDbFilePath, true);
        }

        private static void DropConstraints(string str)
        {
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand("ALTER TABLE Driver DROP CONSTRAINT " + str + ";", con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Constraint " + str + " dropped ");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("ERROR : " + ex.Message + " -->" + ex.Errors);
            }
            con.Close();
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
            //BACKUP
            Backup();
            

            //DROP TABLE
            string[] sql = { "drivers.sql", "teams.sql", "countries.sql" };
            //string[] database = { "Driver", "Team", "Country" };
            for (int i = 0; i < tableNames.Length; i++)
            {
                DropTable(tableNames[i]);
            }

            //CREATE TABLE
            for (int i = 0; i < sql.Length; i++)
            {
                ExecuteSqlScript(sql[i]);
            }

            //RIPRISTINO DELLE TABELLE
            //Restore();
            //ProvaR();
            Restore();
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
                        backupcomm.CommandText = @"BACKUP DATABASE ["+DB_NAME+"] TO DISK='"+ DB_PATH + @"\FormulaOne.bak'";
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

        static void DropTable(string sqlScriptName)
        {
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand("DROP TABLE IF EXISTS " + sqlScriptName + ";", con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table " + sqlScriptName + " dropped ");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("ERROR : " + ex.Message + " -->" + ex.Errors);
            }
            con.Close();
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

                    string sqlStmt3 = @"USE MASTER RESTORE DATABASE [" + DB_NAME + "] FROM DISK='" + DB_PATH + @"\FormulaOne.bak' WITH REPLACE;";
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

        /// <summary>
        /// BACKUP MDF
        /// </summary>
        //private static void Backup()
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
        //        {
        //            string sqlStmt = string.Format("backup database [" + WORKINGPATH + "FormulaOne.mdf] to disk='{0}'", WORKINGPATH + "FormulaOneBackup.mdf");
        //            using (SqlCommand bu2 = new SqlCommand(sqlStmt, conn))
        //            {
        //                conn.Open();
        //                bu2.ExecuteNonQuery();
        //                conn.Close();

        //                Console.WriteLine("Backup Created Sucessfully");
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("Backup Not Created");
        //    }
        //}

        private static void BackupAndRestore(string cmd = "backup database [" + WORKINGPATH + "FormulaOne.mdf] to disk='{0}'", string db = "WORKINGPATH + 'FormulaOneBackup.mdf'", string mex = "Backup created successfully", string errMex = "Backup not created")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    //string sqlStmt = string.Format(cmd, db);
                    string sqlStmt = "";
                    foreach (string table in tableNames)
                    {
                        sqlStmt += "SELECT* INTO " + table + "_bck FROM " + table + ";";
                    }
                    Console.WriteLine(sqlStmt);
                    using (SqlCommand command = new SqlCommand(sqlStmt, conn))
                    {
                        conn.Open();
                        command.ExecuteNonQuery();
                        conn.Close();

                        Console.WriteLine(mex);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine(errMex);
            }
        }

        private static void BackupG()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    //string sqlStmt = string.Format(cmd, db);
                    string sqlStmt = "";
                    foreach (string table in tableNames)
                    {
                        sqlStmt += "SELECT* INTO " + table + "_bck FROM " + table + ";";
                    }
                    Console.WriteLine(sqlStmt);
                    using (SqlCommand command = new SqlCommand(sqlStmt, conn))
                    {
                        conn.Open();
                        command.ExecuteNonQuery();
                        conn.Close();

                        Console.WriteLine("");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("");
            }
        }

        private static void ProvaB()
        {
            hour = DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss");
            
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    string cmd = "BACKUP DATABASE [" + /*conn.Database.ToString()*/WORKINGPATH + "countries.sql] TO DISK= '" + WORKINGPATH + "\\Database-" + hour + ".bak'";

                    using(SqlCommand command = new SqlCommand(cmd, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                    Console.WriteLine("Backup completed successfully");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("");
            }
        }

        private static void ProvaR()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    string sqlStm2 = string.Format("ALTER DATABASE [" + /*conn.Database.ToString()*/WORKINGPATH + "countries.bak] SET SINGLE-USER WITH ROLLBACK IMMEDIATE");
                    SqlCommand bu2 = new SqlCommand(sqlStm2, conn);
                    bu2.ExecuteNonQuery();
                    string sqlStm3 = "USE MASTER RESTORE DATABASE [" + /*conn.Database.ToString()*/WORKINGPATH + "countries.bak] FROM DISK= '" + WORKINGPATH + "\\Database-" + hour + ".bak'";
                    SqlCommand bu3 = new SqlCommand(sqlStm3, conn);
                    bu3.ExecuteNonQuery();
                    string sqlStm4 = string.Format("ALTER DATABASE [" + /*conn.Database.ToString()*/WORKINGPATH + "countries.bak] SET MULTI-USER");
                    SqlCommand bu4 = new SqlCommand(sqlStm4, conn);
                    bu4.ExecuteNonQuery();
                }
                Console.WriteLine("Restore completed successfully");
            }
            catch (Exception)
            {
                Console.WriteLine("");
            }
        }

        //private static void Restore()
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
        //        {
        //            //string sqlStmt = string.Format(cmd, db);
        //            string sqlStmt = "";
        //            foreach (string table in tableNames)
        //            {
        //                sqlStmt += "DROP TABLE " + table + ";";
        //                sqlStmt += "SELECT* INTO " + table + "_bck FROM " + table + ";";

        //                sqlStmt += "IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'" + ComboBoxDatabaseName.Text + "') DROP DATABASE " + ComboBoxDatabaseName.Text + " RESTORE DATABASE " + ComboBoxDatabaseName.Text + " FROM DISK = '" + OpenFileDialog1.FileName + "'";
        //            }
        //            Console.WriteLine(sqlStmt);
        //            using (SqlCommand command = new SqlCommand(sqlStmt, conn))
        //            {
        //                conn.Open();
        //                command.ExecuteNonQuery();
        //                conn.Close();

        //                Console.WriteLine("");
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("");
        //    }
        //}
    }
}
