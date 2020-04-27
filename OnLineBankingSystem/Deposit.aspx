<%@ Page Title="" Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" 
    CodeBehind="Deposit.aspx.cs" Inherits="test1.Deposit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <h1>
        Deposit Fund
    </h1>

    <div class="row">
        <div class="col-xs-6">
            Customer Name: 
        </div>
        <div class="col-xs-6">
            <asp:DropDownList CssClass="form-control" ID="drpCustomers" runat="server" 
            AutoPostBack="true" OnSelectedIndexChanged="drpCustomers_SelectedIndexChanged"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
               ControlToValidate="drpCustomers" runat="server" ErrorMessage="Required!" 
                ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-6">
            Checking Account Balance: 
        </div>
        <div class="col-xs-6">
            <asp:Label ID="lblChecking" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-6">
            Saving Account Balance: 
        </div>
        <div class="col-xs-6">
            <asp:Label ID="lblSaving" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-xs-6">
            <!-- radio button -->
            <asp:RadioButtonList ID="rblDepositTo" runat="server">
                <asp:ListItem Value="checking" Selected="True">To Checking Account</asp:ListItem>
                <asp:ListItem Value="saving">To Saving Account</asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-xs-6">
             Deposit Amount: 
        </div>
        <div class="col-xs-5">
            <asp:TextBox ID="txtDepositAmount" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RangeValidator ID="RangeValidator1" Type="Double" ControlToValidate="txtDepositAmount" MinimumValue="1" MaximumValue="999999" runat="server" ErrorMessage="InValid!" ForeColor="Red"></asp:RangeValidator>
        </div>
         <div class="col-xs-1">
            <asp:RequiredFieldValidator  ID="RequiredFieldValidator2" ControlToValidate="txtDepositAmount" ForeColor="Red" runat="server" ErrorMessage="Required!"></asp:RequiredFieldValidator>
        </div>
    </div>


    <div class="row">
        <div class="col-xs-12">
            <asp:Button CssClass="btn btn-primary" ID="btnDeposit" runat="server" Text="Deposit" OnClick="BtnDeposit_Click" />
        </div>

        <div class="col-xs-12">
            <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
