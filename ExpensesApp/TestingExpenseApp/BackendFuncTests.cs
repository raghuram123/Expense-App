using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Linq;
using DataAccessLayer;
// This series of tests test the data access layer. 
namespace TestingExpenseApp
{
    [TestClass]
    public class BackendFuncTests
    {
        SqlConnection con = new SqlConnection();
        // tesing function isValidDate()
        public BackendFuncTests()
        {
            con.ConnectionString = "Data Source=expensedb.cwycpovsdcfd.us-west-1.rds.amazonaws.com,1433;Initial Catalog=Expenses;User Id=raghuExpenseDb; password=gigsterexpenses;";
        }
        [TestMethod]
        public void overflowDateTest()
        {
            String date1 = "1/1/1752 12:00:00 AM";
            BackendFunctions bf = new BackendFunctions(con);
            bool result = bf.isValidDate(date1);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void dateOnlyTest()
        {
            String date1 = "1/1/2016";
            BackendFunctions bf = new BackendFunctions(con);
            bool result = bf.isValidDate(date1);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void stringTest()
        {
            String date1 = "gigster";
            BackendFunctions bf = new BackendFunctions(con);
            bool result = bf.isValidDate(date1);
            Assert.AreEqual(false, result);
        }
        //Testing function validGridInput()
        [TestMethod]
        public void invalidDateTest()
        {
            String date1 = "gigster";
            BackendFunctions bf = new BackendFunctions(con);
            int result = bf.validateGridInput(date1, "1.5");
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void invalidAmountTest()
        {
            String date1 = "1/1/2016 12:00 PM";
            BackendFunctions bf = new BackendFunctions(con);
            int result = bf.validateGridInput(date1, "abcd");
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void invalidDateAmountTest()
        {
            String date1 = "gigster";
            BackendFunctions bf = new BackendFunctions(con);
            int result = bf.validateGridInput(date1, "abcd");
            Assert.AreEqual(3, result);
        }
        [TestMethod]
        public void allValidTest()
        {
            String date1 = "1/1/2016 12:00 PM";
            BackendFunctions bf = new BackendFunctions(con);
            int result = bf.validateGridInput(date1, "100.12345");
            Assert.AreEqual(0, result);
        }
        //testing addExpense() function
        [TestMethod]
        public void addExpenseTest()
        {
            DateTime date1 = Convert.ToDateTime("1/1/2016 12:00 PM");
            String details = "laptop";
            double amount = 300.0;
            int userId = 1;
            BackendFunctions bf = new BackendFunctions(con);
            String result = bf.addExpense(date1, details, amount, userId);
            Assert.AreEqual("Success", result);
        }

        [TestMethod]
        public void addExpenseTestInvalidUser()
        { // this adds an expense for a user that is not there, so there will be a foreign key conflict
            DateTime date1 = Convert.ToDateTime("1/1/2016 12:00 PM");
            String details = "laptop";
            double amount = 300.0;
            int userId = 20;
            BackendFunctions bf = new BackendFunctions(con);
            String result = bf.addExpense(date1, details, amount, userId);
            Assert.AreNotEqual("Success", result);
        }

        [TestMethod]
        public void updateExpenseTest()
        { 
            DateTime date1 = Convert.ToDateTime("1/1/2016 12:00 PM");
            String details = "Phone";
            double amount = 300.0;
            int expenseId = 1052;
            BackendFunctions bf = new BackendFunctions(con);
            String result = bf.expenseUpdating(expenseId, date1, details, amount);
            Assert.AreEqual("Success", result);
        }

        [TestMethod]
        public void updateExpenseInvalidIdTest()
        { // when we try to update an expense that is not there
            DateTime date1 = Convert.ToDateTime("1/1/2016 12:00 PM");
            String details = "Phone";
            double amount = 300.0;
            int expenseId = 2000;
            BackendFunctions bf = new BackendFunctions(con);
            String result = bf.expenseUpdating(expenseId, date1, details, amount);
            Assert.AreEqual("No Such Expense", result);
        }

        [TestMethod]
        public void deleteExpenseInvalidIdTest()
        { // when trying to delete an expense that is not there
            int expenseId = 2000;
            BackendFunctions bf = new BackendFunctions(con);
            String result = bf.expenseDeleting(expenseId);
            Assert.AreEqual("No Such Expense", result);
        }

        [TestMethod]
        public void checkIsAdminTest()
        { 
            int userId = 1;
            BackendFunctions bf = new BackendFunctions(con);
            String result = bf.checkIsAdmin(userId);
            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void checkIsAdminTest2()
        { 
            int userId = 2;
            BackendFunctions bf = new BackendFunctions(con);
            String result = bf.checkIsAdmin(userId);
            Assert.AreEqual("0", result);
        }

        [TestMethod]
        public void getUserNameTest()
        {
            int userId = 1;
            BackendFunctions bf = new BackendFunctions(con);
            String result = bf.getUserName(userId);
            Assert.AreEqual("Admin", result);
        }

        [TestMethod]
        public void validUserNameTest() //valid user name
        {
            String userName = "don";
            BackendFunctions bf = new BackendFunctions(con);
            String result = bf.validateUserName(userName);
            Assert.AreEqual("Yes", result);
        }

        [TestMethod]
        public void invalidUserNameTest() //valid user name
        {
            String userName = "john";
            BackendFunctions bf = new BackendFunctions(con);
            String result = bf.validateUserName(userName);
            Assert.AreEqual("No", result);
        }


    }
}
