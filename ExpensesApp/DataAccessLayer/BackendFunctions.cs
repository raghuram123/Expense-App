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
    public class BackendFunctions
    {
        SqlConnection con;
        public BackendFunctions(SqlConnection connection)
        {
            con = connection;
        }

        public bool isValidDate(String date)
        {
            DateTime temp;
            if (DateTime.TryParse(date, out temp))
            {
                if (temp >= Convert.ToDateTime("1/1/1753 12:00:00 AM") && temp <= Convert.ToDateTime("12/31/9999 11:59:59 PM"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public int validateGridInput(String Date, String Amount)
        {
            Regex rgx = new Regex(@"\d+(\.\d+)?");
            int value = 0;
            if (!rgx.IsMatch(Amount))
            {
                value += 2;
            }
            else
            {
                //do nothing;
            }
            DateTime temp;
            if (!isValidDate(Date))
            {
                value += 1;
            }
            else
            {
                //do nothing;
            }
            return value;
        }
        public String addExpense(DateTime expenseDate, String details, double amount, int userId)
        {
            SqlCommand com = new SqlCommand("addExpense", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("pUserId", userId);
            SqlParameter p2 = new SqlParameter("pExpenseDate", expenseDate);
            SqlParameter p3 = new SqlParameter("pDetails", details);
            SqlParameter p4 = new SqlParameter("pAmount", amount);
            com.Parameters.Add(p1);
            com.Parameters.Add(p2);
            com.Parameters.Add(p3);
            com.Parameters.Add(p4);
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
            return responseMessageString;
        }
        public String expenseUpdating(int expenseId, DateTime expenseDate, String details, double amount)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            SqlCommand com = new SqlCommand("updateExpense", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("pExpenseId", expenseId);
            SqlParameter p2 = new SqlParameter("pExpenseAmount", amount);
            SqlParameter p3 = new SqlParameter("pExpenseDate", expenseDate);
            SqlParameter p4 = new SqlParameter("pExpenseDetails", details);
            com.Parameters.Add(p1);
            com.Parameters.Add(p2);
            com.Parameters.Add(p3);
            com.Parameters.Add(p4);
            SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.NVarChar, 250);
            responseMessage.Direction = ParameterDirection.Output;
            com.Parameters.Add(responseMessage);
            com.ExecuteNonQuery();
            String responseMessageString = com.Parameters["@responseMessage"].Value.ToString();
            con.Close();
            return responseMessageString;
        }

        public String expenseDeleting(int expenseId)
        {
            SqlCommand com = new SqlCommand("deleteExpenseById", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("pExpenseId", expenseId);
            com.Parameters.Add(p1);
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
            return responseMessageString;
        }
        public String checkIsAdmin(int userId)
        {
            SqlCommand com = new SqlCommand("isAdmin", con);
            SqlParameter p1 = new SqlParameter("pUserId", userId);
            com.Parameters.Add(p1);
            com.CommandType = CommandType.StoredProcedure;
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
            return responseMessageString;

        }
        public string[] Login(String userName, String password)
        {
            SqlCommand com = new SqlCommand("userLogin", con);

            com.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("pUsername", userName);
            SqlParameter p2 = new SqlParameter("pPassword", password);
            com.Parameters.Add(p1);
            com.Parameters.Add(p2);
            SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.NVarChar, 250);
            responseMessage.Direction = ParameterDirection.Output;
            com.Parameters.Add(responseMessage);

            SqlParameter userId = new SqlParameter("@userId", SqlDbType.Int);
            userId.Direction = ParameterDirection.Output;
            com.Parameters.Add(userId);
            con.Open();
            com.ExecuteNonQuery();
            String userIdString = com.Parameters["@userId"].Value.ToString();
            String responseMessageString = com.Parameters["@responseMessage"].Value.ToString();
            con.Close();
            return new string[] { userIdString, responseMessageString };
        }
        public String getUserName(int userId)
        {
            SqlCommand com = new SqlCommand("getUserName", con);
            SqlParameter p1 = new SqlParameter("pUserId", userId);
            com.Parameters.Add(p1);
            com.CommandType = CommandType.StoredProcedure;
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
            return responseMessageString;
        }
        public String createUser(String userName, String password, String firstName, String lastName, bool isAdmin)
        {
            SqlCommand com = new SqlCommand("addUser", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("pUsername", userName);
            SqlParameter p2 = new SqlParameter("pPassword", password);
            SqlParameter p3 = new SqlParameter("pFirstName", firstName);
            SqlParameter p4 = new SqlParameter("pLastName", lastName);
            SqlParameter p5 = new SqlParameter("pIsAdmin", isAdmin); 
            com.Parameters.Add(p1);
            com.Parameters.Add(p2);
            com.Parameters.Add(p3);
            com.Parameters.Add(p4);
            com.Parameters.Add(p5);
            SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.NVarChar, 250);
            responseMessage.Direction = ParameterDirection.Output;
            com.Parameters.Add(responseMessage);
            con.Open();
            com.ExecuteNonQuery();
            String responseMessageString = com.Parameters["@responseMessage"].Value.ToString();
            con.Close();
            return responseMessageString;
        }
        public String validateUserName(String userName)
        {
            SqlCommand com = new SqlCommand("validateUserName", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("pUsername", userName);
            com.Parameters.Add(p1);
            SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.NVarChar, 250);
            responseMessage.Direction = ParameterDirection.Output;
            com.Parameters.Add(responseMessage);
            con.Open();
            com.ExecuteNonQuery();
            String responseMessageString = com.Parameters["@responseMessage"].Value.ToString();
            return responseMessageString;
        }
    }

    
}
