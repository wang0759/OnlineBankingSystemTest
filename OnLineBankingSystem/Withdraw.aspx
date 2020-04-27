<%@ Page Title="" Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeBehind="Withdraw.aspx.cs" Inherits="test1.Withdraw" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
    Withdraw Fund
</h1>
    <div class="row">
        <div class="col-xs-6">
            Customer Name: 
        </div>
        <div class="col-xs-6">
            <asp:DropDownList CssClass="form-control" ID="drpCustomers" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpCustomers_SelectedIndexChanged"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
               ControlToValidate="drpCustomers" runat="server" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
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
            <asp:RadioButtonList ID="rbtDepositTo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rblDepositTo_SelectedIndexChanged">
                <asp:ListItem Value="checking" Selected="True"> From Checking Account</asp:ListItem>
                <asp:ListItem Value="saving"> From Saving Account</asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-xs-6">
             Withdraw Amount: 
        </div>
        <div class="col-xs-5">
            <asp:TextBox ID="txtWithdrawAmount" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RangeValidator ID="amountValidator" ControlToValidate="txtWithdrawAmount" MinimumValue="0" MaximumValue="1" Type="Double" runat="server" ForeColor="Red" ErrorMessage="At least 1 dollar and no more than the amount balance!"></asp:RangeValidator>
        </div>
        <div class="col-xs-1">
            <asp:RequiredFieldValidator  ID="RequiredFieldValidator2" ControlToValidate="txtWithdrawAmount" ForeColor="Red" runat="server" ErrorMessage="Required!"></asp:RequiredFieldValidator>
        </div>
    </div>


    <div class="row">
        <div class="col-xs-6">
            <asp:Button CssClass="btn btn-primary" ID="btnWithdraw" runat="server" Text="Withdraw" OnClick="btnWithdraw_Click"  />
        </div>
        <br />
        <div class="col-xs-6">
            <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
        </div>
    </div>








</asp:Content>





<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
