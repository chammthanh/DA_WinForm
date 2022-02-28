using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class DataProvider
    {
        private static SqlTransaction tran;
        private static SqlDataAdapter adapter = new SqlDataAdapter();
        private static SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-I5R2LUD\SQLEXPRESS;Initial Catalog=QuanAo_DA;Integrated Security=True");

        public DataProvider()
        {
            
        }

        private static SqlConnection OpenConnection()
        {
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }
        public static int ExecuteInsertQueryScalar(string query, SqlParameter[] parameter)
        {
            SqlCommand cmd = new SqlCommand();
            int rowsAffected = 0;
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = OpenConnection();
                cmd.CommandText = query;
                cmd.Parameters.AddRange(parameter);
                adapter.InsertCommand = cmd;
                rowsAffected = (int)cmd.ExecuteScalar();
                conn.Close();
            }
            catch (SqlException e)
            {
                try
                {
                    tran.Rollback();
                }
                catch (Exception exRollback)
                {
                    Console.WriteLine(exRollback.Message);
                }
                throw new Exception(e.Message);
            }
            return rowsAffected;
        }
        public static DataTable ExecuteSelectQuery(string query, SqlParameter[] param)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable dtbKetQua= new DataTable();
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = OpenConnection();
                cmd.CommandText = query;
                cmd.Parameters.AddRange(param);
                adapter.SelectCommand = cmd;
                adapter.Fill(dtbKetQua);
                conn.Close();
            }
            catch (SqlException e)
            {
                return null;
            }
            return dtbKetQua;
        }

        public static int ExecuteNonQuery(string query, SqlParameter[] param)
        {
            SqlCommand cmd = new SqlCommand();
            int rowsAffected;
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = OpenConnection();
                cmd.CommandText = query;
                cmd.Parameters.AddRange(param);
                rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException e)
            {
                return 0;
            }
            return rowsAffected;
        }

        public static DataTable HoaDon(string query, SqlParameter[] param)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable dtbKetQua = new DataTable();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = OpenConnection();
                cmd.CommandText = query;
                cmd.Parameters.AddRange(param);
                adapter.SelectCommand = cmd;
                adapter.Fill(dtbKetQua);
                conn.Close();
            }
            catch (SqlException e)
            {
                return null;
            }
            return dtbKetQua;
        }
    }
}