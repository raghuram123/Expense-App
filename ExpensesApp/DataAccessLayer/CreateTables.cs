using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace DataAccessLayer
{
    public class CreateTables
    {
        SqlConnection con;
        public CreateTables(SqlConnection connection)
        {
            con = connection;
        }

        public DataTable createExpenseTableByUser(int userId)
        {
            DataTable myExpenses = new DataTable();
            SqlCommand com = new SqlCommand("filterExpenseByUser", con);
            SqlParameter p1 = new SqlParameter("pUserId", userId);
            com.Parameters.Add(p1);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.NVarChar, 250);
            responseMessage.Direction = ParameterDirection.Output;
            com.Parameters.Add(responseMessage);
            if (con.State != ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            com.ExecuteNonQuery();

            String responseMessageString = com.Parameters["@responseMessage"].Value.ToString();
            con.Close();
            da.Fill(myExpenses);
            if (responseMessageString == "Success")
            {
                return myExpenses;
            }
            else
            {
                return null;
            }
        }

        public DataTable createExpenseTableExceptUser(int userId)
        {
            DataTable myExpenses = new DataTable();

            SqlCommand com = new SqlCommand("filterExpenseExceptUser", con);
            SqlParameter p1 = new SqlParameter("pUserId", userId);
            com.Parameters.Add(p1);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.NVarChar, 250);
            responseMessage.Direction = ParameterDirection.Output;
            com.Parameters.Add(responseMessage);
            if (con.State != ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            com.ExecuteNonQuery();

            String responseMessageString = com.Parameters["@responseMessage"].Value.ToString();
            con.Close();
            da.Fill(myExpenses);
            if (responseMessageString == "Success")
            {
                return myExpenses;
            }
            else
            {
                return null;
            }
        }

        public DataTable createTablePerYear(int userId, String startDate, String endDate)
        {
            DataTable myExpenses = new DataTable();

            SqlCommand com = new SqlCommand("filterExpenseByYear", con);
            SqlParameter p1 = new SqlParameter("pUserId", userId);
            com.Parameters.Add(p1);
            if (startDate != "")
            {
                DateTime start = Convert.ToDateTime(startDate);
                SqlParameter p2 = new SqlParameter("pStartDate", start);
                com.Parameters.Add(p2);
            }
            else
            {
                //do nothing
            }
            if (endDate != "")
            {
                DateTime end = Convert.ToDateTime(endDate);
                SqlParameter p3 = new SqlParameter("pEndDate", end);
                com.Parameters.Add(p3);
            }
            else
            {
                //do nothing
            }
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.NVarChar, 250);
            responseMessage.Direction = ParameterDirection.Output;
            com.Parameters.Add(responseMessage);
            if (con.State != ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            com.ExecuteNonQuery();

            String responseMessageString = com.Parameters["@responseMessage"].Value.ToString();
            con.Close();
            da.Fill(myExpenses);
            if (responseMessageString == "Success")
            {
                return myExpenses;
            }
            else
            {
                return null;
            }
        }

        public DataTable createTablePerMonth(int userId, String startDate, String endDate)
        {
            DataTable myExpenses = new DataTable();

            SqlCommand com = new SqlCommand("filterExpenseByMonth", con);
            SqlParameter p1 = new SqlParameter("pUserId", userId);
            com.Parameters.Add(p1);
            if (startDate != "")
            {
                DateTime start = Convert.ToDateTime(startDate);
                SqlParameter p2 = new SqlParameter("pStartDate", start);
                com.Parameters.Add(p2);
            }
            else
            {
                //do nothing
            }
            if (endDate != "")
            {
                DateTime end = Convert.ToDateTime(endDate);
                SqlParameter p3 = new SqlParameter("pEndDate", end);
                com.Parameters.Add(p3);
            }
            else
            {
                //do nothing
            }
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.NVarChar, 250);
            responseMessage.Direction = ParameterDirection.Output;
            com.Parameters.Add(responseMessage);
            if (con.State != ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            com.ExecuteNonQuery();

            String responseMessageString = com.Parameters["@responseMessage"].Value.ToString();
            con.Close();
            da.Fill(myExpenses);
            if (responseMessageString == "Success")
            {
                return myExpenses;
            }
            else
            {
                return null;
            }
        }

        public DataTable createTablePerDay(int userId, String startDate, String endDate)
        {
            DataTable myExpenses = new DataTable();

            SqlCommand com = new SqlCommand("filterExpenseByDay", con);
            SqlParameter p1 = new SqlParameter("pUserId", userId);
            com.Parameters.Add(p1);
            if (startDate != "")
            {
                DateTime start = Convert.ToDateTime(startDate);
                SqlParameter p2 = new SqlParameter("pStartDate", start);
                com.Parameters.Add(p2);
            }
            else
            {
                //do nothing
            }
            if (endDate != "")
            {
                DateTime end = Convert.ToDateTime(endDate);
                SqlParameter p3 = new SqlParameter("pEndDate", end);
                com.Parameters.Add(p3);
            }
            else
            {
                //do nothing
            }
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.NVarChar, 250);
            responseMessage.Direction = ParameterDirection.Output;
            com.Parameters.Add(responseMessage);
            if (con.State != ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            com.ExecuteNonQuery();

            String responseMessageString = com.Parameters["@responseMessage"].Value.ToString();
            con.Close();
            da.Fill(myExpenses);
            if (responseMessageString == "Success")
            {
                return myExpenses;
            }
            else
            {
                return null;
            }
        }

        public DataTable createTablePerWeek(int userId, String startDate, String endDate)
        {
            DataTable myExpenses = new DataTable();

            SqlCommand com = new SqlCommand("filterExpenseByWeek", con);
            SqlParameter p1 = new SqlParameter("pUserId", userId);
            com.Parameters.Add(p1);
            if (startDate != "")
            {
                DateTime start = Convert.ToDateTime(startDate);
                SqlParameter p2 = new SqlParameter("pStartDate", start);
                com.Parameters.Add(p2);
            }
            else
            {
                //do nothing
            }
            if (endDate != "")
            {
                DateTime end = Convert.ToDateTime(endDate);
                SqlParameter p3 = new SqlParameter("pEndDate", end);
                com.Parameters.Add(p3);
            }
            else
            {
                //do nothing
            }
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.NVarChar, 250);
            responseMessage.Direction = ParameterDirection.Output;
            com.Parameters.Add(responseMessage);
            if (con.State != ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            com.ExecuteNonQuery();

            String responseMessageString = com.Parameters["@responseMessage"].Value.ToString();
            con.Close();
            da.Fill(myExpenses);
            if (responseMessageString == "Success")
            {
                return myExpenses;
            }
            else
            {
                return null;
            }
        }
    }
}
