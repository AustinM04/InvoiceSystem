using System.Reflection;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace InvoiceSystem.Common
{
    /// <summary>
    /// Class used to access the database.
    /// </summary>
    public class clsDataAccess
    {
        /// <summary>
        /// Connection string to the database.
        /// </summary>
        private string sConnectionString;

        /// <summary>
        /// Constructor that sets the connection string to the database
        /// </summary>
        public clsDataAccess()
        {
            sConnectionString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data source= {Directory.GetCurrentDirectory()}\\Invoice.mdb";
        }

        /// <summary>
        /// This method takes an SQL statement that is passed in and executes it.  The resulting values
        /// are returned in a DataSet. The number of rows returned from the query will be put into
        /// the reference parameter iRetVal.
        /// </summary>
        /// <param name="sSQL">The SQL statement to be executed.</param>
        /// <param name="iRetVal">Reference parameter that returns the number of selected rows.</param>
        /// <returns>Returns a DataSet that contains the data from the SQL statement.</returns>
        public DataSet ExecuteSQLStatement(string sSQL, ref int iRetVal)
        {
            try
            {
                DataSet ds = new DataSet();

                using (OleDbConnection conn = new OleDbConnection(sConnectionString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {
                        conn.Open();

                        adapter.SelectCommand = new OleDbCommand(sSQL, conn);
                        adapter.SelectCommand.CommandTimeout = 0;

                        adapter.Fill(ds);
                    }
                }
                iRetVal = ds.Tables[0].Rows.Count;

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + 
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method takes an SQL statement that is passed in and executes it. The resulting single 
        /// value is returned.
        /// </summary>
        /// <param name="sSQL">The SQL statement to be executed.</param>
        /// <returns>Returns a string from the scalar SQL statement.</returns>
        public string ExecuteScalarSQL(string sSQL)
        {
            try
            {
                object obj;

                using (OleDbConnection conn = new OleDbConnection(sConnectionString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {
                        conn.Open();

                        adapter.SelectCommand = new OleDbCommand(sSQL, conn);
                        adapter.SelectCommand.CommandTimeout = 0;

                        obj = adapter.SelectCommand.ExecuteScalar();
                    }
                }
                if (obj == null)
                {
                    return "";
                }
                else
                {
                    return obj.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + 
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method takes an SQL statement that is a non query and executes it.
        /// </summary>
        /// <param name="sSQL">The SQL statement to be executed.</param>
        /// <returns>Returns the number of rows affected by the SQL statement.</returns>
        public int ExecuteNonQuery(string sSQL)
        {
            try
            {
                int iNumRows;

                using (OleDbConnection conn = new OleDbConnection(sConnectionString))
                {
                    conn.Open();

                    OleDbCommand cmd = new OleDbCommand(sSQL, conn);
                    cmd.CommandTimeout = 0;

                    iNumRows = cmd.ExecuteNonQuery();
                }
                return iNumRows;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + 
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}