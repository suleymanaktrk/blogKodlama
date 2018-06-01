<%@ Page Title="" Language="C#" MasterPageFile="~/panel/Log.Master" AutoEventWireup="true" CodeBehind="kayit.aspx.cs" Inherits="blogKodlama.panel.kayit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Kayit</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card card-register mx-auto mt-5">
        <div class="card-header">Yeni Kullanıcı kaydet</div>
        <div class="card-body">
            <div class="form-group">
                <div class="form-row">
                    <div class="col-md-6">
                        <label for="exampleInputName">Ad</label>
                        <asp:TextBox ID="txtAd" runat="server" CssClass="form-control" aria-describedby="nameHelp" placeholder="Adı Giriniz" />
                    </div>
                    <div class="col-md-6">
                        <label for="exampleInputLastName">Soyad</label>
                        <asp:TextBox ID="txtSoyad" runat="server" CssClass="form-control" aria-describedby="nameHelp" placeholder="Soyadı Giriniz" />
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Mail Adresi</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" aria-describedby="emailHelp" placeholder="E mail Giriniz" TextMode="Email" />
            </div>
            <div class="form-group">
                <div class="form-row">
                    <div class="col-md-6">
                        <label for="exampleInputPassword1">Şifre</label>
                        <asp:TextBox ID="txtSifre" CssClass="form-control" placeholder="Şifre" TextMode="Password" runat="server" />
                    </div>
                    <div class="col-md-6">
                        <label for="exampleConfirmPassword">Şifre(Tekrar)</label>
                        <asp:TextBox ID="txtSifreTekrar" CssClass="form-control" placeholder="Şifreyi Tekrarla" TextMode="Password" runat="server" />
                    </div>
                </div>
            </div>
            <asp:LinkButton ID="btnKaydet" CssClass="btn btn-primary btn-block" Text="Kaydet" runat="server" OnClick="btnKaydet_Click" />
            <div class="text-center">
                <a class="d-block small mt-3" href="login.aspx">Giriş Sayfası</a>
                <a class="d-block small" href="sifremiunuttum.aspx">Şifremi Unuttum</a>
            </div>
            <asp:Literal ID="ltrModal" Text="" runat="server" />
        </div>
    </div>
</asp:Content>
