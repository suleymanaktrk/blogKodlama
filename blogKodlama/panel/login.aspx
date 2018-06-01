<%@ Page Title="" Language="C#" MasterPageFile="~/panel/Log.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="blogKodlama.panel.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Giriş</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card card-login mx-auto mt-5">
        <div class="card-header">Giriş</div>
        <div class="card-body">
            <div class="form-group">
                <label for="exampleInputEmail1">Email Adres</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" TextMode="Email" aria-describedby="emailHelp" placeholder="E Posta Gir" runat="server" />
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">Şifre</label>
                <asp:TextBox CssClass="form-control" ID="txtSifre" runat="server" TextMode="Password" placeholder="Şifre Gir" />
            </div>
            <div class="form-group">
                <div class="form-check">
                    <label class="form-check-label">
                        <input class="form-check-input" type="checkbox">
                        Şifremi Hatırla</label>
                </div>
            </div>
            <asp:LinkButton ID="btnGiris" CssClass="btn btn-primary btn-block" Text="Giriş" OnClick="btnGiris_Click" runat="server" />
            <div class="text-center">
                <a class="d-block small mt-3" href="kayit.aspx">Kayıt Ol</a>
                <a class="d-block small" href="sifremiunuttum.aspx">Şifremi Unuttum</a>
            </div>
            <asp:Literal ID="ltrModal" Text="" runat="server" />
        </div>
    </div>
</asp:Content>
