using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CollegeNet
{
    public static class  SqlHelper
    {
        public static readonly string connstr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        
        public static SqlConnection OpenConnection()
        {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            return conn;
        }

        public static int ExecuteNonQuery(string cmdText,
            params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                return ExecuteNonQuery(conn, cmdText, parameters);
            }
        }

        public static object ExecuteScalar(string cmdText,
            params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                return ExecuteScalar(conn, cmdText, parameters);
            }
        }

        public static DataTable ExecuteDataTable(string cmdText,
            params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                return ExecuteDataTable(conn, cmdText, parameters);
            }
        }

        public static int ExecuteNonQuery(SqlConnection conn,string cmdText,
           params SqlParameter[] parameters)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(SqlConnection conn, string cmdText,
            params SqlParameter[] parameters)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
        }

        public static DataTable ExecuteDataTable(SqlConnection conn, string cmdText,
            params SqlParameter[] parameters)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange(parameters);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public static object ToDBValue(this object value)
        {
            return value == null ? DBNull.Value : value;
        }

        public static object FromDBValue(this object dbValue)
        {
            return dbValue == DBNull.Value ? null : dbValue;
        }

        //----------add by song 2014.11.10--------
        public static SqlCommand BuildCommand(SqlParameter[] param, SqlCommand comm)
        {
            //无参类型
            if (param == null)
                return comm;
            //添加参数到command对象
            foreach (SqlParameter para in param)
                if (para != null)
                    comm.Parameters.Add(para);
            return comm;
        }
        public static SqlCommand BuildReturnCommand(SqlCommand comm)
        {
            //添加一个返回参数。
            comm.Parameters.Add(new SqlParameter
                ("ConfigSqlReturnValueName",
                SqlDbType.Int, 4,
                ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, 0));
            return comm;
        }
        public static void ExecuteProcedure(string procName, SqlParameter[] param, out int returnValue)
        {
            //打开数据连接
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                //初始化command对象
                SqlCommand comm = conn.CreateCommand();
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = procName;
                //编译参数
                BuildCommand(param, comm);
                BuildReturnCommand(comm);
                //执行命令
                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception();
                }
                //把命令的返回值参数的值赋给
                //需要返回的值 ，returnValue
                returnValue = Convert.ToInt32(comm.Parameters["ConfigSqlReturnValueName"].Value);
            }
        }
        public static void ExecuteProcedure(string procName, SqlParameter[] param, ref DataSet ds)
        {
            //打开连接
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                //建立Command对象
                SqlCommand comm = conn.CreateCommand();
                //初始化comm对象
                comm.CommandText = procName;
                comm.CommandType = CommandType.StoredProcedure;
                BuildCommand(param, comm);
                //建立ada对象
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                //填充dataset
                try { ada.Fill(ds); }
                catch
                {
                    throw new Exception();
                }
                //关闭连接
            }
        }
        public static Object ExecuteProcedure(string procName, SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procName;
                BuildCommand(param, command);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch { throw new Exception(); }


                return param[param.Length - 1].Value;
            }
        }
        //--------------------------------------------
    }
}
