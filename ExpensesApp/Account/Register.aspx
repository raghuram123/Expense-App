<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new account.</h4>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtbxUserName" CssClass="col-md-2 control-label">User name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtbxUserName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtbxUserName"
                    CssClass="text-danger" ErrorMessage="The user name field is required." />
                <asp:CustomValidator ID="userNameValidator" CssClass="text-danger" runat="server" OnServerValidate="userNameValidator_ServerValidate"
                 ControlToValidate="txtbxUserName"
                 ToolTip="Please select a different UserName">
                </asp:CustomValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtbxPassword" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtbxPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtbxPassword"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtbxConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtbxConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtbxConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="txtbxPassword" ControlToValidate="txtbxConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                
                
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtbxFirstName" CssClass="col-md-2 control-label">First Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtbxFirstName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtbxFirstName"
                    CssClass="text-danger" ErrorMessage="The First name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtbxLastName" CssClass="col-md-2 control-label">Last Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtbxLastName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtbxLastName"
                    CssClass="text-danger" ErrorMessage="The First name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlIsAdmin" CssClass="col-md-2 control-label">Are you an Admin?</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlIsAdmin" runat="server">
                    <asp:ListItem Selected="True" Value="No"> No </asp:ListItem>
                    <asp:ListItem Value="Yes"> Yes </asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="btnRegister" runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>

