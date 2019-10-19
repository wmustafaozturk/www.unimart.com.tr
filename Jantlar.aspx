<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Jantlar.aspx.vb" Inherits="UniMart.Jantlar" %>

<!DOCTYPE html>
<html lang="en">

<head>
  
    <META http-equiv="content-type" content="text/html; charset=windows-1254" />
    <META http-equiv="content-type" content="text/html; charset=x-mac-turkish<code>" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="Deniz Ticaret Lastik" />
    <meta name="keywords" content="lastik,jant,kış lastiği,4 mevsim lastik" />

  <title>Deniz Ticaret Jantlar</title>

  <!-- css -->
  <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css">
  <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
  <link rel="stylesheet" type="text/css" href="plugins/cubeportfolio/css/cubeportfolio.min.css">
  <link href="css/nivo-lightbox.css" rel="stylesheet" />
  <link href="css/nivo-lightbox-theme/default/default.css" rel="stylesheet" type="text/css" />
  <link href="css/owl.carousel.css" rel="stylesheet" media="screen" />
  <link href="css/owl.theme.css" rel="stylesheet" media="screen" />
  <link href="css/animate.css" rel="stylesheet" />
  <link href="css/style.css" rel="stylesheet">
  <link href="css/cc-sp.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="css_product/demo.css" />
  <!-- boxed bg -->
  <link id="bodybg" href="bodybg/bg1.css" rel="stylesheet" type="text/css" />
  <!-- template skin -->
  <link id="t-colors" href="color/default.css" rel="stylesheet">

  <!-- =======================================================
    Theme Name: Medicio
    Theme URL: https://bootstrapmade.com/medicio-free-bootstrap-theme/
    Author: BootstrapMade
    Author URL: https://bootstrapmade.com
  ======================================================= -->
   
</head>

<body id="page-top" data-spy="scroll" data-target=".navbar-custom">
      <form id="form1" runat="server">
    <div id="wrapper">
        <nav class="navbar navbar-custom navbar-fixed-top" role="navigation">
            <div class="top-area">
                <div class="container">
                    <div class="row">
                       <div class="col-sm-6 col-md-6">
                            <p class="bold text-left"><a style="color:#000000" href="mailto:deniz@contibayi.com">deniz@contibayi.com</a></p>
                        </div>
                        <div class="col-sm-6 col-md-6">
                            <p class="bold text-right"><a style="color:#000000" href="tel://+902128520303">Tel:212 852 03 03</a></p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="container navigation">
                <div class="navbar-header page-scroll">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-main-collapse">
                        <i class="fa fa-bars"></i>
                    </button>
                    <a class="navbar-brand" href="index.aspx">
                        <img src="img/logo.png" alt="" width="150" height="40" />
                    </a>
                </div>

                <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="collapse navbar-collapse navbar-right navbar-main-collapse">
                    <ul class="nav navbar-nav">
                        <li class="dropdown">
                            <a href="hakkimizda.aspx" class="toggle" data-toggle=""><span class="badge custom-badge red pull-right"></span>HAKKIMIZDA <b class=""></b></a>

                        </li>

                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown"><span class="badge custom-badge red pull-right"></span>HİZMETLERİMİZ <b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li><a href="#" target="_blank">Lastik Tamir</a></li>
                                    <li><a href="#" target="_blank">Balans</a></li>  
                                    <li><a href="#" target="_blank">Nitrojen Hava</a></li>  
                                    <li><a href="#" target="_blank">Akü Değişimi</a></li>  
                                    <li><a href="#" target="_blank">Akü Şarjı</a></li>                         
                            </ul>
                        </li>

                        <li class="dropdown">
                            <a href="Lastikler.aspx" class="toggle" data-toggle=""><span class="badge custom-badge red pull-right"></span>LASTİKLER <b class=""></b></a>

                        </li>
                        <li class="dropdown">
                            <a href="#" class="toggle" data-toggle=""><span class="badge custom-badge red pull-right"></span>JANTLAR <b class=""></b></a>
                        </li>
                         <li class="dropdown">
                            <a href="akuler.aspx" class="toggle" data-toggle=""><span class="badge custom-badge red pull-right"></span>AKÜLER <b class=""></b></a>
                        </li>
                         <li class="dropdown">
                            <a href="Kampanyalar.aspx" class="toggle" data-toggle=""><span class="badge custom-badge red pull-right"></span>KAMPANYALAR <b class=""></b></a>
                        </li>
                        <li class="dropdown">
                            <a href="iletisim.aspx" class="toggle" data-toggle=""><span class="badge custom-badge red pull-right"></span>İLETİŞİM <b class=""></b></a>
                        </li>

                    </ul>
                </div>
                <!-- /.navbar-collapse -->
            </div>
            <!-- /.container -->
        </nav>

        <!-- Section: intro -->
       

        <!-- /Section: intro -->
        <!-- Section: team -->
        <section id="doctor" class="home-section bg-gray paddingbot-60">
            <div class="container marginbot-50">
                <div class="row">
                    <div class="col-lg-8 col-lg-offset-2">
                        <div class="wow fadeInDown" data-wow-delay="0.1s">
                            <div class="section-heading text-center">
                                <h2 class="h-bold">JANTLAR</h2>
                                <!--<p>KURUYEMİŞ</p>-->
                            </div>
                        </div>
                        <div class="divider-short"></div>
                    </div>
                </div> 
                  <!--- ARAMA BOLUMU --->
                <asp:TextBox ID="TxtAra" runat="server" CssClass="Tracking_Text1"></asp:TextBox> 
                <asp:Button ID="Btn_Urun_Ara" runat="server" CssClass="Tracking_Buttons" Text="Ürün Ara" />  
                <!--- ARAMA BOLUMU --->
            </div>



        <div id="grid-container" class="cbp-l-grid-team">
        <asp:Repeater ID="Repeater1" runat="server" >
        <HeaderTemplate>
        <ul>
        </HeaderTemplate>
        <ItemTemplate>
        <li class="cbp-item" style="height:500px;width:300px;border: solid;">
        <a runat="server" href='<%#"~/PRODUCT_IMAGE/" + Eval("PRODUCT_IMAGE") %>' class="cbp-caption popup" data-iframe="evet" data-iframe-yukseklik="" data-maksgen="">    
        <div class="cbp-caption-defaultWrap">
        <img src='<%#Eval("PRODUCT_IMAGE", "PRODUCT_IMAGE/{0}") %>' style='height: 100%; width: 100%; object-fit: contain'/>
        </div> 
            <div class="cbp-caption-activeWrap">
            <div class="cbp-l-caption-alignCenter">
                <div class="cbp-l-caption-body">
                    <div class="cbp-l-caption-text"><asp:Label ID="Label4" Text='<%# Bind("PRODUCT_NAME") %>' runat="server"></asp:Label></div>
                </div>
            </div>
          </div>
        </a>
            <div style="font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;font-size:12pt;text-align:center">
                <asp:Label ID="Label1" Text='<%# Bind("PRODUCT_NAME") %>' runat="server"></asp:Label><br />
                <asp:Label ID="Label2" Text='<%# Bind("PRODUCT_DETAILS") %>' runat="server"></asp:Label><br />
                <asp:Label ID="Label3" ForeColor="#ff9900" Text='<%# Bind("PRODUCT_PRICE") %>' runat="server"></asp:Label>
            </div>
        </li>
        </ItemTemplate>
        <FooterTemplate>
        </ul>
        </FooterTemplate>
        </asp:Repeater>
        </div>
</section>   
        <footer >
            <div class="container">
                <div class="row">
                    <div class="col-sm-6 col-md-4">

                        <div class="wow fadeInDown" data-wow-delay="0.1s">
                            <div class="widget">
                                <h5>KURUMSAL</h5>
                                <ul>
                                    <li><a href="hakkimizda.aspx">Hakkımızda</a></li>
                                   

                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-4">
                        <div class="wow fadeInDown" data-wow-delay="0.1s">
                            <div class="widget">
                                <h5>HİZMETLERİMİZ</h5>
                                <ul>
                                    <li><a href="#" target="_blank">Lastik Tamir</a></li>
                                    <li><a href="#" target="_blank">Balans</a></li>  
                                    <li><a href="#" target="_blank">Nitrojen Hava</a></li>  
                                    <li><a href="#" target="_blank">Akü Değişimi</a></li>  
                                    <li><a href="#" target="_blank">Akü Şarjı</a></li>                        
                                </ul>
                                <ul>
                                    <li>
                                        <span class="fa-stack fa-lg">
                                            <i class="fa fa-circle fa-stack-2x"></i>
                                            <i class="fa fa-calendar-o fa-stack-1x fa-inverse"></i>
                                          </span> Çalışma Saatleri : 10:00 - 22:00
                                    </li>
                                     <li>
                                        <span class="fa-stack fa-lg">
                                            <i class="fa fa-circle fa-stack-2x"></i>
                                            <i class="fa fa-phone fa-stack-1x fa-inverse"></i>
                                        </span> <a style="color:#000000" href="tel://+902128520303">Tel:212 852 03 03</a>
                                    </li>
                                    <li>
                                        <span class="fa-stack fa-lg">
                                            <i class="fa fa-circle fa-stack-2x"></i>
                                            <i class="fa fa-envelope-o fa-stack-1x fa-inverse"></i>
                                        </span>  <a style="color:#000000" href="mailto:deniz@contibayi.com">deniz@contibayi.com</a>
                                    </li>

                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-4">
                        <div class="wow fadeInDown" data-wow-delay="0.1s">
                            <div class="widget">
                                <h5>HİZMET NOKTALARIMIZ</h5>
                                <ul>
                                   
                                      <li><a href="#" target="_blank">Beylikdüzü Migros Avm</a></li>
                                    <!--<li><a href="https://itunes.apple.com/tr/app/malatya-pazar%C4%B1-online/id1337670021?l=tr&mt=8" target="_blank"><img src="images/ios.png" /></a></li>
                                <li><a href="https://play.google.com/store/apps/details?id=com.44dukkan.mobil" target="_blank"><img src="images/android.png" /></a></li>-->

                                </ul>

                            </div>
                        </div>
                        <div class="wow fadeInDown" data-wow-delay="0.1s">
                            <div class="widget">
                                <h5>SOSYAL MEDYA</h5>
                                <ul class="company-social">
                                     <li class="social-facebook"><a href="https://www.facebook.com/lastikhauscontinental"><i class="fa fa-facebook"></i></a></li>
                                    <li class="social-twitter"><a href="https://www.instagram.com/lastikhaus/"><i class="fa fa-instagram"></i></a></li>
                                    <li class="social-google"><a href="#"><i class="fa fa-youtube"></i></a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="sub-footer">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-6 col-md-6 col-lg-6">
                            <div class="wow fadeInLeft" data-wow-delay="0.1s">
                                <div class="text-left">
                                    <p>&copy;Deniz Ticaret</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-6 col-lg-6">
                            <div class="wow fadeInRight" data-wow-delay="0.1s">
                                <div class="text-right">
                                    <div class="credits">

                                        Designed by <a href="#">Wm</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </footer>

    </div>
  <a href="#" class="scrollup"><i class="fa fa-angle-up active"></i></a>

  <!-- Core JavaScript Files -->
  <script src="js/jquery.min.js"></script>
  <script src="js/bootstrap.min.js"></script>
  <script src="js/jquery.easing.min.js"></script>
  <script src="js/wow.min.js"></script>
  <script src="js/jquery.scrollTo.js"></script>
  <script src="js/jquery.appear.js"></script>
  <script src="js/stellar.js"></script>
  <script src="plugins/cubeportfolio/js/jquery.cubeportfolio.min.js"></script>
  <script src="js/owl.carousel.min.js"></script>
  <script src="js/nivo-lightbox.min.js"></script>
  <script src="js/custom.js"></script>
    <script src="js/codecillop-muhtesempoap.v1.4.1.js"></script>
</form>
</body>
</html>