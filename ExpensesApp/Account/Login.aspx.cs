using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using DataAccessLayer;

public partial class Account_Login : Page
{
    static SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnStringExpensesDB"].ConnectionString);
    BackendFunctions bf = new BackendFunctions(con);
    CreateTables ct = new CreateTables(con);
    protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        protected void getUserName(int userId)
        {
            if (Session["LoggedIn"] != null)
            {
                String responseMessageString = bf.getUserName(userId);
                HttpContext.Current.Session["UserName"] = Convert.ToString(responseMessageString);
            }
            else
            {
                HttpContext.Current.Session["UserName"] = null;
            }
        }
        protected void LogIn(object sender, EventArgs e)
        {
            String userName = txtbxUserName.Text;
            String password = txtbxPassword.Text;
            if (!Page.IsValid)
            {
                return;
            }
            string[] result = bf.Login(userName, password);
            String userIdString = result[0];
            String responseMessageString = result[1];
            if (userIdString != "")
            {
                HttpContext.Current.Session["UserId"] = Convert.ToInt32(userIdString);
                HttpContext.Current.Session["LoggedIn"] = 1;
                checkIsAdmin();
                getUserName(Convert.ToInt32(userIdString));
                Response.Redirect("~/Default.aspx");
            }
            else {
                FailureText.Text = responseMessageString;
                ErrorMessage.Visible = true;
                FailureText.Visible = true;
                HttpContext.Current.Session["UserId"] = null;
                HttpContext.Current.Session["LoggedIn"] = null;
            }
            
    }

    protected void checkIsAdmin()
    {
        if (Session["LoggedIn"] != null)
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            String responseMessageString = bf.checkIsAdmin(userId);
            HttpContext.Current.Session["IsAdmin"] = Convert.ToInt32(responseMessageString);
        }
        else
        {
            HttpContext.Current.Session["IsAdmin"] = null;
        }
    }
}