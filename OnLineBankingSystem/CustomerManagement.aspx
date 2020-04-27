<%@ Page Title="" Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeBehind="CustomerManagement.aspx.cs" Inherits="test1.CustomerManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>
        Customer Management
    </h1>

    <div class="row">
        <div class="col-xs-6">
            Customer Name: 
        </div>
        <div class="col-xs-6">
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
   <div class="row">
        <div class="col-xs-6">
            Initial Deposit: 
        </div>
        <div class="col-xs-6">
            <asp:TextBox ID="initialDeposit" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>


    <div class="row">
        <div class="col-xs-12">
            <asp:Button CssClass="btn btn-primary" ID="btnAddCustomer" OnClick="btnAddCustomer_Click" runat="server" Text="Add Customer" />
        </div>
    </div>

    
    <div class="row">
        <h3>The following customers are currently in the system:</h3>
        <div class="col-xs-12">
            <asp:Table ID="tblCustomers" runat="server" CssClass="table">

            </asp:Table>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
