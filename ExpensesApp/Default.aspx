<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <script src="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/js/bootstrap-datepicker.min.js"></script>
    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/css/datepicker.min.css" />
    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/css/datepicker3.min.css" />
    <script>
        $(document).ready(function () {
            $('.date')
                .datepicker({
                    format: 'mm/dd/yyyy'
                })
        });
    </script>
    <script>
        function UserDeleteConfirmation() {
            return confirm("Are you sure you want to delete this user?");
        }
    </script>
    <style>
        .header {
            font-size: larger;
            font-weight: bold; 
            background-color: lightblue;
            font-family: 'Comic Sans MS';
        }
        .tab-pane{
            margin: 20px;
        }
    </style>

     <div class="container" runat="server" id="loggedOutContainer">

         <div class ="row" style="margin: 100px;">
             <div class="col-md-2">

             </div>
             <div class="col-md-3">
                 <h2>Welcome to the Expense Tracker website.</h2>
                 <h3>Please login to continue if you are an old user</h3>
                 <h3>Please register if you are a new user</h3>
             </div>
             <div class="col-md-5">
                 <asp:Image ID="frontImage" runat="server" ImageUrl="~/Title.ico" />
             </div>
             <div class="col-md-2">

             </div>
         </div>

     </div>
     <div class="container" runat="server" id="loggedInContainer">
        <br />
        <br />
        <ul class="nav nav-pills">
            <li class="active"><a data-toggle="pill" href="#home">Home</a></li>
            <li><a data-toggle="pill" href="#addExpense">Add An Expense</a></li>
            <li><a data-toggle="pill" href="#perYear">Aggregated per year</a></li>
            <li><a data-toggle="pill" href="#perMonth">Aggregated per month</a></li>
            <li><a data-toggle="pill" href="#perDay">Aggregated per day</a></li>
            <li><a data-toggle="pill" href="#perWeek">Aggregated per week</a></li>
            <li><a data-toggle="pill" href="#listExpenses">List of Expenses</a></li>
        </ul>
        <div class="tab-content">
            <div id="home" class="tab-pane fade in active">
                <div class="row" style="margin: 100px;">
                    <div class="col-md-2">
                    </div>
                    <div class="col-md-3">
                        <h2>Welcome <asp:Literal ID="literalUserName" runat="server"></asp:Literal></h2>
                        <h3>What do you like to do today from the above options? </h3>
                    </div>
                    <div class="col-md-5">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Title.ico" />
                    </div>
                    <div class="col-md-2">
                    </div>
                </div>
            </div>
            <div id="addExpense" class="tab-pane fade">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Literal ID="literalAddExpense" runat="server"></asp:Literal>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtbxDetails" CssClass="col-md-2 control-label">Details</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtbxDetails" TextMode="MultiLine" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtbxDetails"
                                    CssClass="text-danger" ErrorMessage="The Details field is required." />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtbxAmount" CssClass="col-md-2 control-label">Amount</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtbxAmount" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtbxAmount"
                                    CssClass="text-danger" ErrorMessage="The Amount field is required." />
                                <asp:RegularExpressionValidator ID="amountValidator" runat="server" ControlToValidate="txtbxAmount"
                                    CssClass="text-danger" ValidationExpression="\d+(\.\d{1,2})?" ErrorMessage="Enter a valid amount (with at most 2 demial places and with atleast 0 decimal places)" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="expenseDatePicker" CssClass="col-md-2 control-label">Date</asp:Label>
                            <div class="col-md-3 date">
                                <div class="input-group input-append date" id="datePicker" data-provide="datepicker">
                                    <asp:TextBox ID="expenseDatePicker" class="form-control" runat="server"></asp:TextBox>
                                    <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
                                </div>
                            </div>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="expenseDatePicker"
                                CssClass="text-danger" ErrorMessage="The Time field is required." />
                            <asp:RegularExpressionValidator runat="server" ControlToValidate="expenseDatePicker"
                                CssClass="text-danger" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d" ErrorMessage="Enter a valid date" />
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtbxTime" CssClass="col-md-2 control-label">Time</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtbxTime" TextMode="Time" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtbxTime"
                                    CssClass="text-danger" ErrorMessage="The Time field is required." />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" OnClick="btnAddExpense_Click" Text="Add Expense" CssClass="btn btn-default" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="perYear" class="tab-pane fade">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-5">
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="startDatePicker1" CssClass="col-md-2 control-label">From</asp:Label>
                                    <div class="col-md-3 date">
                                        <div class="input-group input-append date" id="divStartdatePicker1" data-provide="datepicker">
                                            <asp:TextBox ID="startDatePicker1" Width="100" class="form-control" runat="server"></asp:TextBox>
                                            <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="toDatePicker1" CssClass="col-md-2 control-label">To</asp:Label>
                                    <div class="col-md-3 date">
                                        <div class="input-group input-append date" id="divTodatePicker1" data-provide="datepicker">
                                            <asp:TextBox ID="toDatePicker1" Width="100" class="form-control" runat="server"></asp:TextBox>
                                            <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-1"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-5"></div>
                            <div class="col-md-5">
                                <asp:Button ID="btnFilterPerYear" CausesValidation="False" CssClass="btn btn-default" runat="server" Text="Filter" OnClick="btnFilterPerYear_Click" />
                            </div>
                            <div class="col-md-5"></div>

                        </div>
                        <div class="row" style="text-align:center;">
                            <asp:Literal ID="datesYearLiteral" runat="server"></asp:Literal>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnFilterPerYear" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="row" id="divGridPerYear" runat="server">
                            <h3 style="text-align: center; font-family: 'Comic Sans MS'">Report of Expenses Per Year</h3>
                            <asp:GridView HorizontalAlign="Center" ID="gridPerYear" AlternatingRowStyle-BackColor="SlateGray" runat="server" CssClass="gridView" AutoGenerateColumns="false"
                                Width="600" AlternatingRowStyle-BorderColor="Snow" AlternatingRowStyle-ForeColor="LightBlue" AlternatingRowStyle-Font-Bold="true" BorderStyle="Groove" BorderWidth="10"
                                Font-Names="Tahoma">
                                <Columns>
                                    <asp:BoundField DataField="YearNum" HeaderText="Year" />
                                    <asp:BoundField DataField="Total_Amt" HeaderText="Amount" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="perMonth" class="tab-pane fade">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-5">
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="startDatePicker2" CssClass="col-md-2 control-label">From</asp:Label>
                                    <div class="col-md-3 date">
                                        <div class="input-group input-append date" id="divStartdatePicker2" data-provide="datepicker">
                                            <asp:TextBox ID="startDatePicker2" Width="100" class="form-control" runat="server"></asp:TextBox>
                                            <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="toDatePicker2" CssClass="col-md-2 control-label">To</asp:Label>
                                    <div class="col-md-3 date">
                                        <div class="input-group input-append date" id="divTodatePicker2" data-provide="datepicker">
                                            <asp:TextBox ID="toDatePicker2" Width="100" class="form-control" runat="server"></asp:TextBox>
                                            <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-1"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-5"></div>
                            <div class="col-md-5">
                                <asp:Button ID="btnFilterPerMonth" CausesValidation="False" CssClass="btn btn-default" runat="server" Text="Filter" OnClick="btnFilterPerMonth_Click" />
                            </div>
                            <div class="col-md-5"></div>

                        </div>
                        <div class="row" style="text-align:center;">
                            <asp:Literal ID="datesMonthLiteral" runat="server"></asp:Literal>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnFilterPerMonth" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="row" id="divGridPerMonth" runat="server">
                            <h3 style="text-align: center; font-family: 'Comic Sans MS'">Report of Expenses Per Month</h3>
                            <asp:GridView HorizontalAlign="Center" ID="gridPerMonth" AlternatingRowStyle-BackColor="SlateGray" runat="server" CssClass="gridView" AutoGenerateColumns="false"
                                Width="600" AlternatingRowStyle-BorderColor="Snow" AlternatingRowStyle-ForeColor="LightBlue" AlternatingRowStyle-Font-Bold="true" BorderStyle="Groove" BorderWidth="10"
                                Font-Names="Tahoma">
                                <Columns>
                                    <asp:BoundField DataField="MonNum" HeaderText="Month" />
                                    <asp:BoundField DataField="Total_Amt" HeaderText="Amount" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="perDay" class="tab-pane fade">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-5">
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="startDatePicker3" CssClass="col-md-2 control-label">From</asp:Label>
                                    <div class="col-md-3 date">
                                        <div class="input-group input-append date" id="divStartdatePicker3" data-provide="datepicker">
                                            <asp:TextBox ID="startDatePicker3" Width="100" class="form-control" runat="server"></asp:TextBox>
                                            <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="toDatePicker3" CssClass="col-md-2 control-label">To</asp:Label>
                                    <div class="col-md-3 date">
                                        <div class="input-group input-append date" id="divTodatePicker3" data-provide="datepicker">
                                            <asp:TextBox ID="toDatePicker3" Width="100" class="form-control" runat="server"></asp:TextBox>
                                            <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-1"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-5"></div>
                            <div class="col-md-5">
                                <asp:Button ID="btnFilterPerDay" CausesValidation="False" CssClass="btn btn-default" runat="server" Text="Filter" OnClick="btnFilterPerDay_Click" />
                            </div>
                            <div class="col-md-5"></div>

                        </div>
                        <div class="row" style="text-align:center;">
                            <asp:Literal ID="datesDayLiteral" runat="server"></asp:Literal>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnFilterPerDay" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="row" id="divGridPerDay" runat="server">
                            <h3 style="text-align: center; font-family: 'Comic Sans MS'">Report of Expenses Per Day</h3>
                            <asp:GridView HorizontalAlign="Center" ID="gridPerDay" AlternatingRowStyle-BackColor="SlateGray" runat="server" CssClass="gridView" AutoGenerateColumns="false"
                                Width="600" AlternatingRowStyle-BorderColor="Snow" AlternatingRowStyle-ForeColor="LightBlue" AlternatingRowStyle-Font-Bold="true" BorderStyle="Groove" BorderWidth="10"
                                Font-Names="Tahoma">
                                <Columns>
                                    <asp:BoundField DataField="DayNum" HeaderText="Day" />
                                    <asp:BoundField DataField="Total_Amt" HeaderText="Amount" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="perWeek" class="tab-pane fade">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-5">
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="startDatePicker4" CssClass="col-md-2 control-label">From</asp:Label>
                                    <div class="col-md-3 date">
                                        <div class="input-group input-append date" id="divStartdatePicker4" data-provide="datepicker">
                                            <asp:TextBox ID="startDatePicker4" Width="100" class="form-control" runat="server"></asp:TextBox>
                                            <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="toDatePicker4" CssClass="col-md-2 control-label">To</asp:Label>
                                    <div class="col-md-3 date">
                                        <div class="input-group input-append date" id="divTodatePicker4" data-provide="datepicker">
                                            <asp:TextBox ID="toDatePicker4" Width="100" class="form-control" runat="server"></asp:TextBox>
                                            <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-1"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-5"></div>
                            <div class="col-md-5">
                                <asp:Button ID="btnFilterPerWeek" CausesValidation="False" CssClass="btn btn-default" runat="server" Text="Filter" OnClick="btnFilterPerWeek_Click" />
                            </div>
                            <div class="col-md-5"></div>

                        </div>
                        <div class="row" style="text-align: center;">
                            <asp:Literal ID="datesWeekLiteral" runat="server"></asp:Literal>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnFilterPerWeek" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="row" id="divGridPerWeek" runat="server">
                            <h3 style="text-align: center; font-family: 'Comic Sans MS'">Report of Expenses Per Week</h3>
                            <asp:GridView HorizontalAlign="Center" ID="gridPerWeek" AlternatingRowStyle-BackColor="SlateGray" runat="server" CssClass="gridView" AutoGenerateColumns="false"
                                Width="600" AlternatingRowStyle-BorderColor="Snow" AlternatingRowStyle-ForeColor="LightBlue" AlternatingRowStyle-Font-Bold="true" BorderStyle="Groove" BorderWidth="10"
                                Font-Names="Tahoma">
                                <Columns>
                                    <asp:BoundField DataField="WeekNum" HeaderText="Week" />
                                    <asp:BoundField DataField="Total_Amt" HeaderText="Amount" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="listExpenses" class="tab-pane fade">        
                <div class="row" id="allExpenses" runat="server">
                    <h3 style="text-align: center;font-family:'Comic Sans MS'"> Your Expenses</h3>  
                    <asp:Literal ID="gridValidity" runat="server"></asp:Literal>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="True">
                        <ContentTemplate>
                            <asp:GridView HorizontalAlign="Center" ID="expenseGrid" AlternatingRowStyle-BackColor="SlateGray" runat="server" CssClass="EU_DataTable" AutoGenerateColumns="false"
                                OnRowEditing="expenseGrid_RowEditing" Width="600" OnRowDataBound="expenseGrid_RowDataBound" OnRowUpdating="expenseGrid_RowUpdating" OnRowDeleting="expenseGrid_RowDeleting" OnRowCancelingEdit="expenseGrid_RowCancelingEdit"
                                AlternatingRowStyle-BorderColor="Snow" AlternatingRowStyle-ForeColor="LightBlue" AlternatingRowStyle-Font-Bold="true" BorderStyle="Groove" BorderWidth="10"
                                Font-Names="Tahoma">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExpenseID" runat="server" Visible="false" Text='<%#Eval("ExpenseID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Details" HeaderText="Details" />
                                    <asp:BoundField DataField="ExpenseDate" HeaderText="Transaction Date" />
                                    <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                    <asp:CommandField ShowEditButton="true" CausesValidation="False" />
                                    <asp:CommandField ShowDeleteButton="true" CausesValidation="False" />
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="expenseGrid" EventName="RowUpdating" />
                        </Triggers>

                    </asp:UpdatePanel>
                </div>     
                <div class="row" id="otherExpenses" runat="server">
                    <h3 style="text-align: center; font-family: 'Comic Sans MS'">Other's Expenses</h3>
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView HorizontalAlign="Center" ID="otherExpensesGrid" AlternatingRowStyle-BackColor="SlateGray" runat="server" CssClass="gridView" AutoGenerateColumns="false"
                                 Width="600" AlternatingRowStyle-BorderColor="Snow" AlternatingRowStyle-ForeColor="LightBlue" AlternatingRowStyle-Font-Bold="true" BorderStyle="Groove" BorderWidth="10"
                                Font-Names="Tahoma">
                                <Columns>
                                    <asp:BoundField DataField="UserName" HeaderText="Owner" />
                                    <asp:BoundField DataField="Details" HeaderText="Details" />
                                    <asp:BoundField DataField="ExpenseDate" HeaderText="Transaction Date" />
                                    <asp:BoundField DataField="Amount" HeaderText="Amount"/>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>


    <div class="row">
        <div class="col-md-4">
            
        </div>
        <div class="col-md-4">
            
        </div>
        <div class="col-md-4">
            
        </div>
    </div>
</asp:Content>
