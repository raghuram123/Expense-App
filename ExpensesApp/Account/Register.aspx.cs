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

public partial class Account_Register : Page
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
    protected void CreateUser_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
        {
            return;
        }
        String userName = txtbxUserName.Text;
        String password = txtbxPassword.Text;
        String firstName = txtbxFirstName.Text;
        String lastName = txtbxLastName.Text;
        bool isAdmin = false; // by default it takes false value
        if (ddlIsAdmin.SelectedValue == "Yes")
        {
            isAdmin = true;
        }
        String responseMessageString = bf.createUser(userName, password, firstName, lastName, isAdmin);
        if (responseMessageString == "Success")
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            ErrorMessage.Text = responseMessageString;
            ErrorMessage.Visible = true;
        }
        
    }

    protected void userNameValidator_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        String responseMessageString = bf.validateUserName(txtbxUserName.Text);
        if (responseMessageString == "No") {
            args.IsValid = true;
        }
        else if (responseMessageString == "Yes")
        {
            userNameValidator.ErrorMessage = "User Name " + txtbxUserName.Text + " already exists";
            args.IsValid = false;
        }
        con.Close();
}
}