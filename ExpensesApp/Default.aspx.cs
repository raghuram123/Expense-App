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
using System.Text.RegularExpressions;
using DataAccessLayer;
public partial class _Default : Page
{
    
    static SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnStringExpensesDB"].ConnectionString);
    BackendFunctions bf = new BackendFunctions(con);
    CreateTables ct = new CreateTables(con);
    protected void Page_Load(object sender, EventArgs e)
    {
        literalUserName.Text = Convert.ToString(Session["UserName"]);
        loggingStates();
        adminStates();
    }
    protected void adminStates() // check if user is admin
    {
        if (Convert.ToInt32(Session["IsAdmin"]) == 1)
        {
            otherExpenses.Visible = true;
            if (!IsPostBack)
            {
                BindGridOtherExpenses();
            }
        }
        else
        {
            otherExpenses.Visible = false;
        }
    }

    protected void loggingStates() // check if user is logged in
    {
        if (Session["LoggedIn"] == null)
        {
            loggedInContainer.Visible = false;
            loggedOutContainer.Visible = true;
        }
        else
        {
            loggedOutContainer.Visible = false;
            loggedInContainer.Visible = true;
            if (!IsPostBack)
            {
                BindGridMyExpenses();
                BindGridPerYear();
                BindGridPerMonth();
                BindGridPerDay();
                BindGridPerWeek();
            }
        }
    }
    protected void BindGridMyExpenses() // event to bind grid "My expenses" 
    {
            DataTable expenses = ct.createExpenseTableByUser(Convert.ToInt32(Session["UserId"]));
            if (expenses != null && expenses.Rows.Count > 0)
            {
                expenseGrid.DataSource = expenses;
                expenseGrid.DataBind();
            }
            else
            {

                expenses.Rows.Add(expenses.NewRow());
                expenseGrid.DataSource = expenses;
                expenseGrid.DataBind();
                int columncount = expenseGrid.Rows[0].Cells.Count;
                expenseGrid.Rows[0].Cells.Clear();
                expenseGrid.Rows[0].Cells.Add(new TableCell());
                expenseGrid.Rows[0].Cells[0].ColumnSpan = columncount;
                expenseGrid.Rows[0].Cells[0].Text = "You do not have any Expenses";
            }
        
    }
    protected void BindGridOtherExpenses() // Event to bind grid "Other's expenses, called only if user is admin
    {
        DataTable expenses = ct.createExpenseTableExceptUser(Convert.ToInt32(Session["UserId"]));
        if (expenses != null && expenses.Rows.Count > 0)
        {
            otherExpensesGrid.DataSource = expenses;
            otherExpensesGrid.DataBind();
        }
        else
        {

            expenses.Rows.Add(expenses.NewRow());
            otherExpensesGrid.DataSource = expenses;
            otherExpensesGrid.DataBind();
            int columncount = otherExpensesGrid.Rows[0].Cells.Count;
            otherExpensesGrid.Rows[0].Cells.Clear();
            otherExpensesGrid.Rows[0].Cells.Add(new TableCell());
            otherExpensesGrid.Rows[0].Cells[0].ColumnSpan = columncount;
            otherExpensesGrid.Rows[0].Cells[0].Text = "There are no Expenses";
        }
    }
    protected void BindGridPerYear() // event to bind grid that shows reports per year
    {
        
        DataTable expenses = ct.createTablePerYear(Convert.ToInt32(Session["UserId"]), startDatePicker1.Text, toDatePicker1.Text);
        if (expenses != null && expenses.Rows.Count > 0)
        {
            gridPerYear.DataSource = expenses;
            gridPerYear.DataBind();
        }
        else
        {

            expenses.Rows.Add(expenses.NewRow());
            gridPerYear.DataSource = expenses;
            gridPerYear.DataBind();
            int columncount = gridPerYear.Rows[0].Cells.Count;
            gridPerYear.Rows[0].Cells.Clear();
            gridPerYear.Rows[0].Cells.Add(new TableCell());
            gridPerYear.Rows[0].Cells[0].ColumnSpan = columncount;
            gridPerYear.Rows[0].Cells[0].Text = "There are no Expenses";
        }
    }
    protected void BindGridPerMonth() // event to bind grid that shows reports per month
    {
        DataTable expenses = ct.createTablePerMonth(Convert.ToInt32(Session["UserId"]), startDatePicker2.Text, toDatePicker2.Text);
        if (expenses != null && expenses.Rows.Count > 0)
        {
            gridPerMonth.DataSource = expenses;
            gridPerMonth.DataBind();
        }
        else
        {

            expenses.Rows.Add(expenses.NewRow());
            gridPerMonth.DataSource = expenses;
            gridPerMonth.DataBind();
            int columncount = gridPerMonth.Rows[0].Cells.Count;
            gridPerMonth.Rows[0].Cells.Clear();
            gridPerMonth.Rows[0].Cells.Add(new TableCell());
            gridPerMonth.Rows[0].Cells[0].ColumnSpan = columncount;
            gridPerMonth.Rows[0].Cells[0].Text = "There are no Expenses";
        }
    }
    protected void BindGridPerDay() // event to bind grid that shows reports per day
    {
        DataTable expenses = ct.createTablePerDay(Convert.ToInt32(Session["UserId"]), startDatePicker3.Text, toDatePicker3.Text);
        if (expenses != null && expenses.Rows.Count > 0)
        {
            gridPerDay.DataSource = expenses;
            gridPerDay.DataBind();
        }
        else
        {

            expenses.Rows.Add(expenses.NewRow());
            gridPerDay.DataSource = expenses;
            gridPerDay.DataBind();
            int columncount = gridPerDay.Rows[0].Cells.Count;
            gridPerDay.Rows[0].Cells.Clear();
            gridPerDay.Rows[0].Cells.Add(new TableCell());
            gridPerDay.Rows[0].Cells[0].ColumnSpan = columncount;
            gridPerDay.Rows[0].Cells[0].Text = "There are no Expenses";
        }
    }
    protected void BindGridPerWeek() // event to bind grid that shows reports per week
    {
        DataTable expenses = ct.createTablePerWeek(Convert.ToInt32(Session["UserId"]), startDatePicker4.Text, toDatePicker4.Text);
        if (expenses != null && expenses.Rows.Count > 0)
        {
            gridPerWeek.DataSource = expenses;
            gridPerWeek.DataBind();
        }
        else
        {

            expenses.Rows.Add(expenses.NewRow());
            gridPerWeek.DataSource = expenses;
            gridPerWeek.DataBind();
            int columncount = gridPerWeek.Rows[0].Cells.Count;
            gridPerWeek.Rows[0].Cells.Clear();
            gridPerWeek.Rows[0].Cells.Add(new TableCell());
            gridPerWeek.Rows[0].Cells[0].ColumnSpan = columncount;
            gridPerWeek.Rows[0].Cells[0].Text = "There are no Expenses";
        }
    }
    
    protected void btnAddExpense_Click(object sender, EventArgs e) // add expense button click event handler
    {
        if (!Page.IsValid)
        {
            return;
        }
        DateTime expenseDate = Convert.ToDateTime(expenseDatePicker.Text + " " + txtbxTime.Text);
        String details = txtbxDetails.Text;
        double amount = Convert.ToDouble(txtbxAmount.Text);
        int userId = Convert.ToInt32(Session["UserId"]);
        String response = bf.addExpense(expenseDate, details, amount, userId);
        if (response == "Success")
        {
            updates();
            txtbxDetails.Text = "";
            txtbxAmount.Text = "";
            txtbxTime.Text = "";
            expenseDatePicker.Text = "";
        }
        else
        {
            return;
        }
        
    }
    protected void updates()  // function to perform all partial page updates
    {
        BindGridMyExpenses();
        BindGridOtherExpenses();
        BindGridPerDay();
        BindGridPerMonth();
        BindGridPerWeek();
        BindGridPerYear();
        UpdatePanel2.Update();
        UpdatePanel3.Update();
        UpdatePanel4.Update();
        UpdatePanel5.Update();
        UpdatePanel6.Update();
        UpdatePanel7.Update();
        UpdatePanel8.Update();
        UpdatePanel9.Update();
        UpdatePanel10.Update();
        UpdatePanel11.Update();
    }
    protected void expenseGrid_RowEditing(object sender, GridViewEditEventArgs e) // event handler for grid "My expenses
    {
        expenseGrid.EditIndex = e.NewEditIndex;
        BindGridMyExpenses();
    }
    
    protected void expenseGrid_RowUpdating(object sender, GridViewUpdateEventArgs e) //event handler for grid "My expenses"
    {
        GridViewRow row = (GridViewRow)expenseGrid.Rows[e.RowIndex];
        System.Web.UI.WebControls.Label lblUpdateId = (System.Web.UI.WebControls.Label)row.FindControl("lblExpenseID");
        int expenseId = Convert.ToInt32(lblUpdateId.Text);
        TextBox textDetails = (TextBox)row.Cells[1].Controls[0];
        TextBox textDate = (TextBox)row.Cells[2].Controls[0];
        TextBox textAmount = (TextBox)row.Cells[3].Controls[0];
        int result = bf.validateGridInput(textDate.Text, textAmount.Text);
        if (result == 1)
        {
            gridValidity.Text = "The date you entered is not valid";
            return;
        }
        if (result == 2)
        {
            gridValidity.Text = "The amount you entered is not valid";
            return;
        }
        if (result == 3)
        {
            gridValidity.Text = "The date and amount you entered are not valid";
            return;
        }
        else
        {
            gridValidity.Text = "";
        }
        DateTime expenseDate = Convert.ToDateTime(textDate.Text);
        String details = textDetails.Text;
        double amount = Convert.ToDouble(textAmount.Text);
        expenseGrid.EditIndex = -1;
        String responseMessageString = bf.expenseUpdating(expenseId, expenseDate, details, amount);
        if (responseMessageString == "Success")
        {
            updates();
        }
        else
        {
            return;
        }
    }


    protected void expenseGrid_RowDeleting(object sender, GridViewDeleteEventArgs e) //event handler for grid "My expenses"
    {
        GridViewRow row = (GridViewRow)expenseGrid.Rows[e.RowIndex];
        System.Web.UI.WebControls.Label lblDeleteid = (System.Web.UI.WebControls.Label)row.FindControl("lblExpenseID");
        int expenseId = Convert.ToInt32(lblDeleteid.Text);
        String responseMessageString = bf.expenseDeleting(expenseId);
        if (responseMessageString == "Success")
        {
            updates();
        }
    }

    protected void expenseGrid_RowDataBound(object sender, GridViewRowEventArgs e) //event handler for grid "My expenses"
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton db = (LinkButton)e.Row.Cells[4].Controls[0];
            db.OnClientClick = "return confirm(Are you certain you want to delete this expense?)";

        }
    }
    protected void expenseGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) //event handler for grid "My Expenses"
    {
        expenseGrid.EditIndex = -1;
        updates();
    }
    protected void btnFilterPerYear_Click(object sender, EventArgs e) //click event handler for button "Filter per year"
    {
        if((startDatePicker1.Text=="" || bf.isValidDate(startDatePicker1.Text)) &&(toDatePicker1.Text=="" || bf.isValidDate(toDatePicker1.Text)))
        {
            if(startDatePicker1.Text!="" && toDatePicker1.Text != "")
            {
                if (Convert.ToDateTime(startDatePicker1.Text) < Convert.ToDateTime(toDatePicker1.Text))
                {
                    datesYearLiteral.Visible = false;
                    updates();
                }
                else
                {
                    datesYearLiteral.Text = "Start date should be lesser than end date";
                    datesYearLiteral.Visible = true;
                    return;
                }
            }
            else
            {
                datesYearLiteral.Visible = false;
                updates();
            }
            
        }
        else
        {
            datesYearLiteral.Text = "Enter valid dates";
            datesYearLiteral.Visible = true;
            return;
        }
    }

    protected void btnFilterPerMonth_Click(object sender, EventArgs e) // click event handler for button "Filter per month"
    {
        if ((startDatePicker2.Text == "" || bf.isValidDate(startDatePicker2.Text)) && (toDatePicker2.Text == "" || bf.isValidDate(toDatePicker2.Text)))
        {
            if (startDatePicker2.Text != "" && toDatePicker2.Text != "")
            {
                if (Convert.ToDateTime(startDatePicker2.Text) < Convert.ToDateTime(toDatePicker2.Text))
                {
                    datesMonthLiteral.Visible = false;
                    updates();
                }
                else
                {
                    datesMonthLiteral.Text = "Start date should be lesser than end date";
                    datesMonthLiteral.Visible = true;
                    return;
                }
            }
            else
            {
                datesMonthLiteral.Visible = false;
                updates();
            }

        }
        else
        {
            datesMonthLiteral.Text = "Enter valid dates";
            datesMonthLiteral.Visible = true;
            return;
        }
    }


protected void btnFilterPerDay_Click(object sender, EventArgs e) //click event handler for button "Filter per day"
    {
        if ((startDatePicker3.Text == "" || bf.isValidDate(startDatePicker3.Text)) && (toDatePicker3.Text == "" || bf.isValidDate(toDatePicker3.Text)))
        {
            if (startDatePicker3.Text != "" && toDatePicker3.Text != "")
            {
                if (Convert.ToDateTime(startDatePicker3.Text) < Convert.ToDateTime(toDatePicker3.Text))
                {
                    datesDayLiteral.Visible = false;
                    updates();
                }
                else
                {
                    datesDayLiteral.Text = "Start date should be lesser than end date";
                    datesDayLiteral.Visible = true;
                    return;
                }
            }
            else
            {
                datesDayLiteral.Visible = false;
                updates();
            }

        }
        else
        {
            datesDayLiteral.Text = "Enter valid dates";
            datesDayLiteral.Visible = true;
            return;
        }
    }

    protected void btnFilterPerWeek_Click(object sender, EventArgs e) //click event handler for button "Filter per week"
    {
        if ((startDatePicker4.Text == "" || bf.isValidDate(startDatePicker4.Text)) && (toDatePicker4.Text == "" || bf.isValidDate(toDatePicker4.Text)))
        {
            if (startDatePicker4.Text != "" && toDatePicker4.Text != "")
            {
                if (Convert.ToDateTime(startDatePicker4.Text) < Convert.ToDateTime(toDatePicker4.Text))
                {
                    datesWeekLiteral.Visible = false;
                    updates();
                }
                else
                {
                    datesWeekLiteral.Text = "Start date should be lesser than end date";
                    datesWeekLiteral.Visible = true;
                    return;
                }
            }
            else
            {
                datesWeekLiteral.Visible = false;
                updates();
            }

        }
        else
        {
            datesWeekLiteral.Text = "Enter valid dates";
            datesWeekLiteral.Visible = true;
            return;
        }
    }

    
}
