<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="blogKodlama.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>Resume - Start Bootstrap Theme</title>

    <!-- Bootstrap core CSS -->
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom fonts for this template -->
    <link href="https://fonts.googleapis.com/css?family=Saira+Extra+Condensed:100,200,300,400,500,600,700,800,900" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i" rel="stylesheet" />
    <link href="vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="vendor/devicons/css/devicons.min.css" rel="stylesheet" />
    <link href="vendor/simple-line-icons/css/simple-line-icons.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
    <link href="css/resume.min.css" rel="stylesheet" />
</head>
<body id="page-top">
    <form id="form1" runat="server">
        <%-- NAV BAR BEGIN --%>
        <nav class="navbar navbar-expand-lg navbar-dark bg-primary fixed-top" id="sideNav">
            <a class="navbar-brand js-scroll-trigger" href="#page-top">
                <span class="d-block d-lg-none">Süleyman Aktürk</span>
                <span class="d-none d-lg-block">
                    <asp:Image CssClass="img-fluid img-profile rounded-circle mx-auto mb-2" ID="imgProfil" runat="server" />
                </span>
            </a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav">
                    <asp:Repeater runat="server" ID="rptNav">
                        <ItemTemplate>
                            <li class="nav-item">
                                <a class="nav-link js-scroll-trigger" href="#<%#Eval("url") %>"><%#Eval("yazi") %></a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </nav>
        <%-- Nav Bar End --%>
        <div class="container-fluid p-0">

            <section class="resume-section p-3 p-lg-5 d-flex d-column" id="about">
                <div class="my-auto">
                    <h1 class="mb-0">
                        <asp:Literal ID="ltrAd" Text="" runat="server" />

                        <span class="text-primary">
                            <asp:Literal ID="ltrSoyad" Text="" runat="server" /></span>
                    </h1>
                    <div class="subheading mb-5">
                        <asp:Literal ID="ltrAdres" Text="" runat="server" />
                        <asp:Literal ID="ltrTel" Text="" runat="server" />

                        <asp:HyperLink ID="linkMail" runat="server" />
                    </div>
                    <p class="mb-5">
                        <asp:Literal ID="ltrAciklama" Text="" runat="server" />
                    </p>
                    <ul class="list-inline list-social-icons mb-0">
                        <li class="list-inline-item">
                            <a href="#">
                                <span class="fa-stack fa-lg">
                                    <i class="fa fa-circle fa-stack-2x"></i>
                                    <i class="fa fa-facebook fa-stack-1x fa-inverse"></i>
                                </span>
                            </a>
                        </li>
                        <li class="list-inline-item">
                            <a href="#">
                                <span class="fa-stack fa-lg">
                                    <i class="fa fa-circle fa-stack-2x"></i>
                                    <i class="fa fa-twitter fa-stack-1x fa-inverse"></i>
                                </span>
                            </a>
                        </li>
                        <li class="list-inline-item">
                            <a href="#">
                                <span class="fa-stack fa-lg">
                                    <i class="fa fa-circle fa-stack-2x"></i>
                                    <i class="fa fa-linkedin fa-stack-1x fa-inverse"></i>
                                </span>
                            </a>
                        </li>
                        <li class="list-inline-item">
                            <a href="#">
                                <span class="fa-stack fa-lg">
                                    <i class="fa fa-circle fa-stack-2x"></i>
                                    <i class="fa fa-github fa-stack-1x fa-inverse"></i>
                                </span>
                            </a>
                        </li>
                    </ul>
                </div>
            </section>

            <section class="resume-section p-3 p-lg-5 d-flex flex-column" id="experience">
                <div class="my-auto">
                    <h2 class="mb-5">ÖZGEÇMİŞİM</h2>
                    <%-- özgeçmişim BEGIN --%>
                    <asp:Repeater runat="server" ID="rptOzgecmis">
                        <ItemTemplate>
                            <div class="resume-item d-flex flex-column flex-md-row mb-5">
                                <div class="resume-content mr-auto">
                                    <h3 class="mb-0"><%#Eval("baslik") %></h3>
                                    <div class="subheading mb-3"><%#Eval("altbaslik") %></div>
                                    <p><%#Eval("aciklama") %></p>
                                </div>
                                <div class="resume-date text-md-right">
                                    <span class="text-primary"><%#Eval("bastarih") %> - <%#Eval("bittarih") %></span>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <%-- özgeçmişim END --%>
                </div>

            </section>

            <section class="resume-section p-3 p-lg-5 d-flex flex-column" id="education">
                <div class="my-auto">
                    <h2 class="mb-5">EĞİTİMİM</h2>
                    <%--EĞİTİM BEGIN  --%>
                    <asp:Repeater runat="server" ID="rptEgitim">
                        <ItemTemplate>
                            <div class="resume-item d-flex flex-column flex-md-row mb-5">
                                <div class="resume-content mr-auto">
                                    <h3 class="mb-0"><%#Eval("okul") %></h3>
                                    <div class="subheading mb-3"><%#Eval("fakulte") %></div>
                                    <div><%#Eval("bolum") %></div>
                                    <p>Ortalama: <%#Eval("mort") %></p>
                                </div>
                                <div class="resume-date text-md-right">
                                    <span class="text-primary"><%#Eval("bastarih") %> - <%#Eval("bittarih") %></span>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <%--EĞITIM END  --%>
                </div>
            </section>

            <section class="resume-section p-3 p-lg-5 d-flex flex-column" id="skills">
                <div class="my-auto">
                    <h2 class="mb-5">Skills</h2>
                    <%-- Beceri Kategori Begin --%>
                    <asp:Repeater runat="server" ID="rptBeceriKategori" OnItemDataBound="rptBeceriKategori_ItemDataBound">
                        <ItemTemplate>
                            <div class="subheading mb-3"><%#Eval("baslik")%></div>
                            <asp:Panel runat="server" ID="pnlType1">
                                <ul class="list-inline list-icons">
                                    <asp:Repeater runat="server" ID="rptBeceri1" OnItemDataBound="rptBeceri_ItemDataBound">
                                        <ItemTemplate>
                                            <li class="list-inline-item">
                                                <%#Eval("baslik")%></i>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="pnlType2">
                                <ul class="fa-ul mb-0">
                                    <asp:Repeater runat="server" ID="rptBeceri2" OnItemDataBound="rptBeceri_ItemDataBound">
                                        <ItemTemplate>
                                            <li>
                                                <i class="fa-li fa fa-check"></i>
                                                <%#Eval("baslik")%></li>
                                            <li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </asp:Panel>
                        </ItemTemplate>
                    </asp:Repeater>
                    <%-- Beceri Kategori End --%>
                </div>
            </section>

            <section class="resume-section p-3 p-lg-5 d-flex flex-column" id="interests">
                <div class="my-auto">
                    <h2 class="mb-5">İlgilerim</h2>
                    <asp:Repeater runat="server" ID="rptIlgilerim">
                        <ItemTemplate>
                            <p><%#Eval("icerik")%></p>
                        </ItemTemplate>
                        <FooterTemplate>
                            <p class="mb-0"></p>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </section>

            <section class="resume-section p-3 p-lg-5 d-flex flex-column" id="awards">
                <div class="my-auto">
                    <h2 class="mb-5">Awards &amp; Certifications</h2>
                    <ul class="fa-ul mb-0">
                        <asp:Repeater runat="server" ID="rptOduller">
                            <ItemTemplate>
                                <li>
                                    <i class="fa-li fa fa-trophy text-warning"></i>
                                    <%#Eval("icerik")%></li>
                                <li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </section>

        </div>
        <!-- Bootstrap core JavaScript -->
        <script src="vendor/jquery/jquery.min.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

        <!-- Plugin JavaScript -->
        <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

        <!-- Custom scripts for this template -->
        <script src="js/resume.min.js"></script>
    </form>

</body>
</html>
