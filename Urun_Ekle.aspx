<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Urun_Ekle.aspx.vb" Inherits="UniMart.Urun_Ekle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel="stylesheet" href="css/reset.css" type="text/css" media="all"/>
      <link href='http://fonts.googleapis.com/css?family=Asap' rel='stylesheet' type='text/css'/>
       <link rel="stylesheet" href="css/grid.css" type="text/css" media="all" />
      <script type="text/javascript" src="js/jquery-1.6.js" ></script>
      <script type="text/javascript" src="js/script.js"></script>
      <script type="text/javascript" src="js/content_switch.js"></script>
      <script type="text/javascript" src="js/jquery.easing.1.3.js"></script>
      <script type="text/javascript" src="js/superfish.js"></script>
      <script type="text/javascript" src="js/forms.js"></script>
      <script type="text/javascript" src="js/bgStretch.js"></script>
      <script type="text/javascript" src="js/jquery.color.js"></script>
      <script type="text/javascript" src="js/jquery.mousewheel.js"></script>
      <script type="text/javascript" src="js/jquery-ui.js"></script>
      <script type="text/javascript" src="js/cScroll.js"></script>
      <script type="text/javascript" src="js/jcarousellite.js"></script>
      <script src="js/googleMap.js" type="text/javascript"></script>
      <script src="js/jquery.msgBox.js" type="text/javascript"></script>
      <link href="css/msgBoxLight.css" rel="stylesheet" type="text/css"/>
      <link rel="stylesheet" type="text/css" media="screen" href="ana_slider/css/slider.css"/>
        <script type="text/javascript" src="ana_slider/js/tms-0.4.x.js"></script>
        

    <meta charset="UTF-8" />
		<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/> 
		<meta name="viewport" content="width=device-width, initial-scale=1.0"/> 
		
		<meta name="description" content="Malatya Pazari" />
		<meta name="keywords" content="Malatya Pazari" />
		<meta name="author" content="Codrops" />
		<link rel="shortcut icon" href="../favicon.ico"/>
		<link rel="stylesheet" type="text/css" href="css/normalize.css" />
		<link rel="stylesheet" type="text/css" href="css/demo.css" />
		<link rel="stylesheet" type="text/css" href="css/component.css" />
		<script src="js/modernizr.custom.js"></script>


<script type="text/javascript">
    
    function URUN_ADI_YAZINIZ() {

        $.msgBox({
            title: "CARPEDIEM",
            content: "Lütfen ürün adını yazın..."
        });
    }

    function DOSYA_SIL_SECINIZ() {

        $.msgBox({
            title: "CARPEDIEM",
            content: "Lütfen Silmek istediğiniz dosyayı seçiniz."
        });
    }

    function Urun_Bulunamadi() {

        $.msgBox({
            title: "CARPEDIEM",
            content: "Aradığınız ürün bulunamadı."
        });
    }

    

    function DOSYA_SECINIZ() {

        $.msgBox({
            title: "CARPEDIEM",
            content: "Dosya Seçiniz."
        });
    }
</script>

    <style type="text/css">
        .ddl
        {
            border:2px solid #7d6754;
            border-radius:5px;
            padding:3px;
            -webkit-appearance: none; 
            background-image:url('Images/Arrowhead-Down-01.png');
            background-position:88px;
            background-repeat:no-repeat;
            text-indent: 0.01px;/*In Firefox*/
            text-overflow: '';/*In Firefox*/
        }
</style>
</head>
<body>
    <form id="form1" runat="server">

         <div class="container">
             <ul id="gn-menu" class="gn-menu-main" >
				<li class="gn-trigger">
					<a class="gn-icon gn-icon-menu"><span>Menu</span></a>
					<!---<nav class="gn-menu-wrapper">
						<div class="gn-scroller">
							<ul class="gn-menu">
								
								<li><a runat="server" id="BtnYonetimRapor"  title="Yönetim Raporu">YRaporu</a></li>  
                             
								
								
							</ul>
						</div>
					</nav>-->
				</li>   
     
          <li> <asp:TextBox ID="TxtAra" runat="server" CssClass="Tracking_Text1"></asp:TextBox>    </li>           
          <li> <asp:Button ID="Btn_Urun_Ara" runat="server" CssClass="BtnBeyanname_Ara"  ToolTip="Ara"/></li>
          <li><a class="codrops-icon" id="Btn_Urun_Ekle" runat="server" >ÜRÜN EKLE</a></li>                 
          <li><a class="codrops-icon" id="Btn_iptal" runat="server" href="URUN_EKLE.aspx" >İŞLEM İPTAL</a></li>


                 <asp:Label ID="LBL_URUN_ID" runat="server" Font-Bold="false"></asp:Label>                                         
                 <asp:Label ID="Label1" runat="server" Font-Bold="false"></asp:Label>
                 <asp:Label ID="LblDosyaAdi" runat="server" Font-Bold="TRUE"></asp:Label>
                 <li><asp:Label ID="Beyanname_id" runat="server" Font-Bold="true" Visible="true" ></asp:Label></li>
                 <li><a class="codrops-icon " href="default.aspx"><img src="images/home.png" /></a></li>
                 
             
   </ul>

</div><!--end container-->

<div id="Div_Urunler" runat="server" class="grid">

                <asp:GridView ID="GridView1" runat="server"
                    AutoGenerateColumns="False"
                    GridLines="None"
                    AllowPaging="True"
                    CssClass="mGrid"
                    PagerStyle-CssClass="pgr"
                    OnSelectedIndexChanged = "secilenirenklendir"
                    AlternatingRowStyle-CssClass="alt" PageSize="100">
                    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>

                    <Columns>
                        <asp:BoundField DataField="URUN_ID" HeaderText="ID"><HeaderStyle BackColor="#006699" ForeColor="White" /></asp:BoundField>               
                        <asp:BoundField DataField="URUN_ADI" HeaderText="ÜRÜN ADI"><HeaderStyle BackColor="#006699" ForeColor="White" /></asp:BoundField>                         
                        <asp:BoundField DataField="URUN_DETAY" HeaderText="Firma Adı"><HeaderStyle BackColor="#006699" ForeColor="White" /></asp:BoundField>                         
                         <asp:BoundField DataField="URUN_FIYAT" HeaderText="ÜRÜN FİYAT"><HeaderStyle BackColor="#006699" ForeColor="White" /></asp:BoundField> 
                        <asp:BoundField DataField="URUN_BIRIM" HeaderText="ÜRÜN BİRİM"><HeaderStyle BackColor="#006699" ForeColor="White" /></asp:BoundField> 
                        <asp:BoundField DataField="URUN_GURUBU" HeaderText="ÜRÜN GURUBU"><HeaderStyle BackColor="#006699" ForeColor="White" /></asp:BoundField>  
                        <asp:ImageField DataImageUrlField="URUN_RESMI" DataImageUrlFormatString="~\URUN_RESIMLER\{0}"  ControlStyle-Height="100" ControlStyle-Width="100"  HeaderStyle-BackColor="#006699"  HeaderStyle-ForeColor="White" HeaderText="ÜRÜN RESIM" />

                        <asp:BoundField DataField="URUN_RESMI" HeaderText="ÜRÜN RESIM ADI"><HeaderStyle BackColor="#006699" ForeColor="White" /></asp:BoundField> 
                <asp:TemplateField >
                <ItemTemplate >
                    <%--<asp:Button ID="indir" CommandName="download" runat="server" CssClass="Tracking_Buttons" Text="INDIR" Visible="true"   />--%>
                    
                    <asp:Button ID="BtnDosyaSil" CommandName="BtnUrunSil" runat="server" CssClass="Tracking_Buttons" Text="Sil"  Visible="true"  />
                </ItemTemplate>
                </asp:TemplateField>                   
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/9.png" ShowSelectButton="True"  SelectText="Seç" />                        
                </Columns>
                    <FooterStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />                
                </asp:GridView>
</div>
        

        <%--URUN EKLE ///////////////////////////////////////////////////////////////////////////////////////////////--%>
 <div id="Div_Urun_Ekle" class="KullaniciGiris" runat="server" visible="false" >
            
                <table class="mGrid">
                 <tr>
                        <td>ÜRÜN ADI :</td>
                        <td>
                            <asp:TextBox ID="TXT_URUN_ADI" runat="server" CssClass="Tracking_Text1"></asp:TextBox>
                        </td>
                    </tr>

                       <tr>
                        <td>ÜRÜN AÇIKLAMA :</td>
                        <td>
                            <asp:TextBox ID="TXT_URUN_DETAY" runat="server" CssClass="Tracking_Text1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>ÜRÜN FİYAT :</td>
                        <td>
                            <asp:TextBox ID="TXT_URUN_FIYAT" runat="server" CssClass="Tracking_Text1"></asp:TextBox>
                        </td>
                    </tr>

                       <tr>
                        <td>ÜRÜN BIRIM :</td>
                        <td>
                            <asp:TextBox ID="TXT_URUN_BIRIM" runat="server" CssClass="Tracking_Text1"></asp:TextBox>
                        </td>
                    </tr>
                  



                           <tr>
                        <td>ÜRÜN GURUBU :</td>
                        <td>
                        <asp:DropDownList ID="DropDownList1"  runat="server" Width="320px" BackColor="#0066cc" ForeColor="#ffffff" Font-Names="Andalus" CssClass="ddl">
                            <asp:ListItem Text="Menü Doğum Günü>>>"   Value=""></asp:ListItem>
                        <asp:ListItem Text="DOGUM_GUNU_KULLANAT_URUNLER" Value="DOGUM_GUNU_KULLANAT_URUNLER"></asp:ListItem> 
                        <asp:ListItem Text="DOGUM_GUNU_HEDIYELIK_URUNLER" Value="DOGUM_GUNU_HEDIYELIK_URUNLER"></asp:ListItem>
                        <asp:ListItem Text="KIZ_DOGUM_GUNU_URUNLERI" Value="KIZ_DOGUM_GUNU_URUNLERI"></asp:ListItem>
                        <asp:ListItem Text="ERKEK_DOGUM_GUNU_URUNLERI" Value="ERKEK_DOGUM_GUNU_URUNLERI"></asp:ListItem>
                        <asp:ListItem Text="BIR_YAS_DOGUM_GUNU" Value="BIR_YAS_DOGUM_GUNU"></asp:ListItem>
                           <asp:ListItem Text="MENU BABYSHOWER YENİDOĞAN>>>"   Value=""></asp:ListItem>
                        <asp:ListItem Text="KIZ_BEBEK" Value="KIZ_BEBEK"></asp:ListItem>
                        <asp:ListItem Text="ERKEK_BEBEK" Value="ERKEK_BEBEK"></asp:ListItem>
                        <asp:ListItem Text="DIS_BUGDAYI" Value="DIS_BUGDAYI"></asp:ListItem>
                            <asp:ListItem Text="MENU KINA NİŞAN NİKAH>>>"   Value=""></asp:ListItem>
                        <asp:ListItem Text="KINA_SUS_MALZEMELERI" Value="KINA_SUS_MALZEMELERI"></asp:ListItem>
                        <asp:ListItem Text="NISAN_SUS_SEKERLERI" Value="NISAN_SUS_SEKERLERI"></asp:ListItem>
                        <asp:ListItem Text="NIKAH_SUS_SEKERLERI" Value="NIKAH_SUS_SEKERLERI"></asp:ListItem>
                        
                             <asp:ListItem Text="SUNNET_SUSLERI" Value="SUNNET_SUSLERI"></asp:ListItem>
                             <asp:ListItem Text="EL_YAPIMI_CINI" Value="EL_YAPIMI_CINI"></asp:ListItem>
                             <asp:ListItem Text="DEKOR_HEDIYELIK" Value="DEKOR_HEDIYELIK"></asp:ListItem>

                       
                    </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                       <td>ÜRÜN SEÇ :</td>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="Tracking_Text1" />
                            </td>
                    </tr>                   

                        <tr>
                            <td>
                                <asp:Button ID="Btn_Urun_Yukle_Kaydet" runat="server" CssClass="Tracking_Buttons" Text="Kaydet" />                                
                                <asp:Button ID="Btn_Urun_Kaydet_Iptal" runat="server" CssClass="Tracking_Buttons" Text="İptal" />
                            </td>
                    </tr>
               
                </table>

    </div>
<%--URUN EKLE BITIS///////////////////////////////////////////////////////////////////////////////////////////////////--%>
    </form>
</body>
</html>
