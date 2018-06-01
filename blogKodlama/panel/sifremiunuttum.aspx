<%@ Page Title="" Language="C#" MasterPageFile="~/panel/Log.Master" AutoEventWireup="true" CodeBehind="sifremiunuttum.aspx.cs" Inherits="blogKodlama.panel.sifremiunuttum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Şifremi Unuttum</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card card-login mx-auto mt-5">
        <div class="card-header">Reset Password</div>
        <div class="card-body">
            <div class="text-center mt-4 mb-5">
                <h4>Forgot your password?</h4>
                <p>Enter your email address and we will send you instructions on how to reset your password.</p>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtEMail" CssClass="form-control" TextMode="Email" aria-describedby="emailHelp" placeholder="E-Mail gir" runat="server" />
            </div>
            <asp:LinkButton ID="btnGonder" CssClass="btn btn-primary btn-block" Text="Şifreyi Yenile" runat="server" OnClick="btnGonder_Click" />
            <div class="text-center">
                <a class="d-block small mt-3" href="kayit.aspx">Register an Account</a>
                <a class="d-block small" href="login.aspx">Login Page</a>
            </div>
            <asp:Literal ID="ltrModal" Text="" runat="server" />
        </div>
    </div>
</asp:Content>
