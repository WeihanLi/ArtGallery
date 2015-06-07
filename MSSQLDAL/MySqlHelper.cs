using System.Data;
using System.Data.SqlClient;

namespace MSSQLDAL
{
    public static class MySqlHelper
    {
        static string connStr = Common.ConfigurationHelper.ConnectionString("ConnStr");
        static SqlConnection con = null;

        #region 获取 SqlConnection
        /// <summary>
        /// 根据已有的连接字符串,获取 SqlConnection
        /// </summary>
        /// <returns>SqlConnection 对象</returns>
        private static SqlConnection GetSqlConnection()
        {
            if (con == null)
            {
                con = new SqlConnection(connStr);
            }
            return con;
        }

        /// <summary>
        /// 根据指定的连接字符串获取 SqlConnection
        /// </summary>
        /// <param name="connString">连接字符串</param>
        /// <returns>SqlConnection 对象</returns>
        private static SqlConnection GetSqlConnection(string connString)
        {
            return new SqlConnection(connString);
        }
        #endregion

        #region ExecuteNonQuery
        public static int ExecuteNonQuery(string commandText, params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteNonQuery(connStr, CommandType.Text, commandText, commandParameters);
        }

        public static int ExecuteNonQuery(string conStr, string commandText, params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteNonQuery(conStr, CommandType.Text, commandText, commandParameters);
        }

        public static int ExecuteNonQuery(SqlConnection con, string commandText, params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteNonQuery(con, CommandType.Text, commandText, commandParameters);
        }

        #endregion

        #region ExecuteDataTable
        public static DataTable ExecuteDataTable(string commandText, params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteDataset(connStr, CommandType.Text, commandText, commandParameters).Tables[0];
        }

        public static DataTable ExecuteDataTable(string conStr, string commandText, params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteDataset(conStr, CommandType.Text, commandText, commandParameters).Tables[0];
        }

        #endregion

        #region ExecuteScalar

        public static object ExecuteScalar(string commandText, params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteScalar(connStr, CommandType.Text, commandText, commandParameters);
        }

        public static object ExecuteScalar(string conStr, string commandText, params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteScalar(conStr, CommandType.Text, commandText, commandParameters);
        } 
        #endregion
    }
}
