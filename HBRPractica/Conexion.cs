using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HBRPractica
{
    public class Conexion
    {
        public SqlConnection sqlConn = null;

        public SqlConnection GetConnection
        {
            get { return sqlConn; }
            set { value = sqlConn; }
        }

        public SqlConnection Connection()
        {
            string cons = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            sqlConn = new SqlConnection(cons);
            return sqlConn;
        }
    }
}