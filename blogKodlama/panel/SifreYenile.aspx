<%@ Page Title="" Language="C#" MasterPageFile="~/panel/Log.Master" AutoEventWireup="true" CodeBehind="SifreYenile.aspx.cs" Inherits="blogKodlama.panel.SifreYenile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card card-register mx-auto mt-5">
        <div class="card-header">Şifreyi Yenile</div>
        <div class="card-body">
           
            <div class="form-group">
                <label for="exampleInputEmail1">Mail Adresi</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" aria-describedby="emailHelp" placeholder="E mail Giriniz" TextMode="Email" Enabled="false" />
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Doğrulama Kodu</label>
                <asp:TextBox ID="txtDogrulamaKodu" CssClass="form-control" runat="server" placeholder="Doğrulama kodunu giriniz." Enabled="false"/>
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
            <asp:LinkButton CssClass="btn btn-primary btn-block" Text="Kaydet" runat="server" ID="btnKaydet" OnClick="btnKaydet_Click" />
            <div class="text-center">
                <a class="d-block small mt-3" href="login.aspx">Giriş Sayfası</a>
                <a class="d-block small" href="sifremiunuttum.aspx">Şifremi Unuttum</a>
            </div>
            <asp:Literal ID="ltrModal" Text="" runat="server" />
        </div>
    </div>
</asp:Content>
