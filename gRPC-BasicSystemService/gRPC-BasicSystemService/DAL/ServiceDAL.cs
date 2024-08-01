using Microsoft.Data.SqlClient;

namespace gRPC_BasicSystemService.DAL
{
    public class ServiceDAL
    {
        #region DatabaseConnection
        private static readonly string dataSource = "Initial catalog=Services;";

        public static SqlConnection GetConnection(string dataSource)
        {
            return CreateConnection(dataSource);
        }

        private static SqlConnection CreateConnection(string dataSource)
        {
            dataSource = "Data Source=(local);" + dataSource + "Integrated Security=SSPI;Encrypt=False";
            SqlConnection conn = new SqlConnection(dataSource);
            return conn;
        }
        #endregion

        #region Procedures
        public string GetServiceNames()
        {
            string procedure = "[dbo].[SelectAllServices]";
            return ServiceNames(procedure, dataSource);
        }

        private string ServiceNames(string procedure, string dataSource)
        {
            string services = "";
            try
            {
                using (SqlConnection conn = GetConnection(dataSource))
                {
                    conn.Open();
                    SqlCommand sqlCommand = new SqlCommand(procedure, conn);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        services += reader[0].ToString() + ", ";
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Log to DB.
            }
            return services;
        }
        #endregion
    }
}
