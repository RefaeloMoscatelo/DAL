using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
     public class Database
    {
       
        private SqlConnection con;
        private SqlCommand cmd;

        public void Open()
        {
            con.Open();
        }

        public void Close()
        {
            con.Close();
        }

        public T ExecuteScalar<T>(string command,params SqlParameter [] parameters)
        {
            init(parameters);
            cmd.CommandText = command;
            return (T)cmd.ExecuteScalar();
        }
        public int ExecuteNonQuery(string command,params SqlParameter[] parameters)
        {
            init(parameters);
            cmd.CommandText = command;
            return cmd.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteReader(string command, params SqlParameter[] parameters)
        {
            init(parameters);
            cmd.CommandText = command;
            return cmd.ExecuteReader();
        }

        public Database(string connectionNameInConfigFile)
        {
            string config = ConfigurationManager.ConnectionStrings[connectionNameInConfigFile].ConnectionString;
            con = new SqlConnection(config);
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        public void init( SqlParameter[] parameters)
        {
            cmd.Parameters.Clear();
            if (parameters != null && parameters.Any())
            {
                cmd.Parameters.AddRange(parameters);
            }
            
        }

        public SqlParameter CreateParameter(string name, object value)
        {
            SqlParameter param = new SqlParameter();
            param.Value = value;
            param.ParameterName = name;
            if (value == null)
            {
                param.Value = DBNull.Value;
            }
            else
            {
                param.Value = value;
            }
            return param;
        }

    }
}
